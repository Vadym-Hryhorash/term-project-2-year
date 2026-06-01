using Microsoft.EntityFrameworkCore.Storage;
using PizzeriaProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProject.Patterns.CachedProxy
{
    public class CachedOrderProxy : IOrderService
    {
        private readonly DatabaseOrderService realService;
        private readonly Dictionary<string, List<Cart>> cache;

        public CachedOrderProxy(DatabaseOrderService realService)
        {
            this.realService = realService;
            cache = new Dictionary<string, List<Cart>>();
        }

        public List<Cart> GetUserOrders(string fullName, string targetDate)
        {
            string cacheKey = $"{fullName}_{targetDate}";

            if (targetDate == DateTime.Now.ToString("dd.MM.yyyy") && cache.ContainsKey(cacheKey))
            {
                cache.Remove(cacheKey);
            }
            else if (cache.ContainsKey(cacheKey))
            {
                return cache[cacheKey];
            }

            var ordersFromDb = realService.GetUserOrders(fullName, targetDate);
            cache.Add(cacheKey, ordersFromDb);

            return ordersFromDb;
        }
    }
}
