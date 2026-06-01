using Newtonsoft.Json;
using PizzeriaProject.Patterns.Prototype;
using PizzeriaProject.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProject.Data
{
    public class Cart : IPrototype<Cart>
    {
        public List<IProduct> Products { get; private set; } = new List<IProduct>();
        public void AddToCart(IProduct product)
        {
            Products.Add(product);
        }
        public void ClearCart()
        {
            Products.Clear();
        }
        public Cart ShallowClone()
        {
            return (Cart)MemberwiseClone();
        }
        public Cart DeepClone()
        {
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All};
            string jsonFile = JsonConvert.SerializeObject(this, settings);
            return JsonConvert.DeserializeObject<Cart>(jsonFile, settings);
        }

    }
}
