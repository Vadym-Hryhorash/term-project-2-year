using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PizzeriaProject.Products;

namespace PizzeriaProject.Patterns.Decorator
{
    public class PizzaDecorator : Pizza
    {
        protected Pizza pizza;
        public PizzaDecorator(Pizza pizza)
        {
            this.pizza = pizza;
        }
        protected PizzaDecorator() { }
    }

    public class ExtraMozzarella : PizzaDecorator
    {
        public ExtraMozzarella(Pizza pizza) : base(pizza)
        {
            this.Name = pizza.Name;
            Description = pizza.Description + ", додаткова Моцарела";
            Price = pizza.Price + 20;
            Weight = pizza.Weight + 50; 
        }
        [JsonConstructor]
        private ExtraMozzarella() { }
    }
    public class ExtraParmesan : PizzaDecorator
    {
        public ExtraParmesan(Pizza pizza) : base(pizza)
        {
            this.Name = pizza.Name;
            Description = pizza.Description + ", додатковий Пармезан";
            Price = pizza.Price + 25;
            Weight = pizza.Weight + 20;
        }
        [JsonConstructor]
        private ExtraParmesan() { }
    }
    public class ExtraPepperoni : PizzaDecorator
    {
        public ExtraPepperoni(Pizza pizza) : base(pizza)
        {
            this.Name = pizza.Name;
            Description = pizza.Description + ", додаткове Пепероні";
            Price = pizza.Price + 45;
            Weight = pizza.Weight + 30;
        }
        [JsonConstructor]
        private ExtraPepperoni() { }
    }
    public class ExtraHam : PizzaDecorator
    {
        public ExtraHam(Pizza pizza) : base(pizza)
        {
            this.Name = pizza.Name;
            Description = pizza.Description + ", додаткова Шинка";
            Price = pizza.Price + 40;
            Weight = pizza.Weight + 35;
        }
        [JsonConstructor]
        private ExtraHam() { }
    }
    public class ExtraChicken : PizzaDecorator
    {
        public ExtraChicken(Pizza pizza) : base(pizza)
        {
            this.Name = pizza.Name;
            Description = pizza.Description + ", додаткова Курка";
            Price = pizza.Price + 35;
            Weight = pizza.Weight + 35;
        }
        [JsonConstructor]
        private ExtraChicken() { }
    }
    public class ExtraBacon : PizzaDecorator
    {
        public ExtraBacon(Pizza pizza) : base(pizza)
        {
            this.Name = pizza.Name;
            Description = pizza.Description + ", додатковий Бекон";
            Price = pizza.Price + 40;
            Weight = pizza.Weight + 25;
        }
        [JsonConstructor]
        private ExtraBacon() { }
    }
    public class ExtraSalami : PizzaDecorator
    {
        public ExtraSalami(Pizza pizza) : base(pizza)
        {
            this.Name = pizza.Name;
            Description = pizza.Description + ", додаткова Салямі";
            Price = pizza.Price + 45;
            Weight = pizza.Weight + 30;
        }
        [JsonConstructor]
        private ExtraSalami() { }
    }
    public class ExtraMushrooms : PizzaDecorator
    {
        public ExtraMushrooms(Pizza pizza) : base(pizza)
        {
            this.Name = pizza.Name;
            Description = pizza.Description + ", додаткові Гриби";
            Price = pizza.Price + 20;
            Weight = pizza.Weight + 35;
        }
        [JsonConstructor]
        private ExtraMushrooms() { }
    }
    public class ExtraCorn : PizzaDecorator
    {
        public ExtraCorn(Pizza pizza) : base(pizza)
        {
            this.Name = pizza.Name;
            Description = pizza.Description + ", додаткова Кукурудза";
            Price = pizza.Price + 30;
            Weight = pizza.Weight + 25;
        }
        [JsonConstructor]
        private ExtraCorn() { }
    }
    public class ExtraOlives : PizzaDecorator
    {
        public ExtraOlives(Pizza pizza) : base(pizza)
        {
            this.Name = pizza.Name;
            Description = pizza.Description + ", додаткові Оливки";
            Price = pizza.Price + 35;
            Weight = pizza.Weight + 25;
        }
        [JsonConstructor]
        private ExtraOlives() { }
    }
    public class ExtraPepper : PizzaDecorator
    {
        public ExtraPepper(Pizza pizza) : base(pizza)
        {
            this.Name = pizza.Name;
            Description = pizza.Description + ", додатковий Болгарський перець";
            Price = pizza.Price + 30;
            Weight = pizza.Weight + 25;
        }
        [JsonConstructor]
        private ExtraPepper() { }
    }
    public class ExtraOnion : PizzaDecorator
    {
        public ExtraOnion(Pizza pizza) : base(pizza)
        {
            this.Name = pizza.Name;
            Description = pizza.Description + ", додаткова Цибуля";
            Price = pizza.Price + 15;
            Weight = pizza.Weight + 20;
        }
        [JsonConstructor]
        private ExtraOnion() { }
    }
    public class ExtraTomatoes : PizzaDecorator
    {
        public ExtraTomatoes(Pizza pizza) : base(pizza)
        {
            this.Name = pizza.Name;
            Description = pizza.Description + ", додаткові Помідори";
            Price = pizza.Price + 40;
            Weight = pizza.Weight + 50;
        }
        [JsonConstructor]
        private ExtraTomatoes() { }
    }
}
