using PizzeriaProject.Data;
using PizzeriaProject.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProject.Patterns.Command
{
    public class AddToCartCommand : ICommand
    {
        private readonly Cart cart;
        private readonly IProduct product;

        public AddToCartCommand(Cart cart, IProduct product)
        {
            this.cart = cart;
            this.product = product;
        }
        public void Execute()
        {
            cart.AddToCart(product);
        }

        public void Undo()
        {
            cart.Products.Remove(product);
        }
    }
}
