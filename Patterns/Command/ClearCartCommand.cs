using PizzeriaProject.Data;
using PizzeriaProject.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProject.Patterns.Command
{
    public class ClearCartCommand : ICommand
    {
        private readonly Cart cart;
        private List<IProduct> backup;

        public ClearCartCommand(Cart cart)
        {
            this.cart = cart;
        }

        public void Execute()
        {
            backup = new List<IProduct>(cart.Products);
            cart.ClearCart();
        }

        public void Undo()
        {
            foreach (var product in backup)
            {
                cart.AddToCart(product);
            }
        }
    }
}
