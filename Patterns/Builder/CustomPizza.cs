using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzeriaProject.Products;

namespace PizzeriaProject.Patterns.Builder
{
    public class CustomPizza : Pizza
    {
        public List<string> ingredients = new List<string>();
        public CustomPizza()
        {
            Name = "Авторська піца";
            Description = "Створена власноруч";
            Price = 0;
            Weight = 0;
        }
        public void AddIngredient(string ingredient)
        {
            ingredients.Add(ingredient);
        }
        public void CreateDescription()
        {
            Description = string.Join(", ", ingredients);
        }
    }
}
