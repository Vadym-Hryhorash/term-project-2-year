using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PizzeriaProject.Entities;
using PizzeriaProject.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProject.Data
{

    public static class SqlManager
    {
        public static void saveOrder(Cart cart, string currentUser)
        {
            if (cart.Products.Count == 0){return;}

            string todayString = DateTime.Now.ToString("dd.MM.yyyy");

            int fullPrice = 0;
            foreach (var product in cart.Products)
            {
                fullPrice += product.Price;
            }

            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            string jsonOrderList = JsonConvert.SerializeObject(cart, settings);

            using var db = new DatabaseContext();

            var user = db.Users.FirstOrDefault(u => u.FullName == currentUser);

            Order newOrder = new Order
            {
                UserId = user.UserId,
                OrderList = jsonOrderList,
                OrderPrice = fullPrice,
                OrderDate = todayString
            };

            db.Orders.Add(newOrder);
            db.SaveChanges();
        }
    }
    public interface IOrderService
    {
        List<Cart> GetUserOrders(string fullName, string targetDate);
    }

    public class DatabaseOrderService : IOrderService
    {
        public List<Cart> GetUserOrders(string targetName, string targetDate)
        {
            using var db = new DatabaseContext();

            List<Cart> cartList = new List<Cart>();
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            foreach (var order in db.Orders.Include(o => o.User).Where(o => o.User.FullName == targetName && o.OrderDate == targetDate))
            {
                var restoredCarts = JsonConvert.DeserializeObject<Cart>(order.OrderList, settings);
                cartList.Add(restoredCarts);
            }

            return cartList;
        }
    }

    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        private string sql = "Server=localhost;Port=5433;Database=pizzeria; User Id = postgres; Password = postgre;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(sql);
        }
    }
}
