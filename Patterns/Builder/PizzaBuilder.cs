using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProject.Patterns.Builder
{
    public interface IPizzaBuilder
    {
        IPizzaBuilder SetDough(string type);
        IPizzaBuilder SetSauce(string type);
        IPizzaBuilder AddIngredient(string type, int price, int weight);
        void Reset();
        CustomPizza GetPizza();
    }
    public class ConcretePizzaBuilder : IPizzaBuilder
    {
        private CustomPizza pizza;
        public ConcretePizzaBuilder()
        {
            Reset();
        }
        public IPizzaBuilder SetDough(string type)
        {
            pizza.AddIngredient($"{type} тісто");
            pizza.Price += 60;
            pizza.Weight += 300;
            return this;
        }
        public IPizzaBuilder SetSauce(string type)
        {
            pizza.AddIngredient($"cоус {type}");
            pizza.Price += 15;
            pizza.Weight += 50;
            return this;
        }

        public IPizzaBuilder AddIngredient(string type, int price, int weight)
        {
            pizza.AddIngredient(type);
            pizza.Price += price;
            pizza.Weight += weight;
            return this;
        }
        public void Reset()
        {
            pizza = new CustomPizza();
        }
        public CustomPizza GetPizza()
        {
            pizza.CreateDescription();
            CustomPizza result = pizza;
            return result;
        }
    }
}
