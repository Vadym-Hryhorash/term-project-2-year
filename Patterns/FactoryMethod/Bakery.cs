using PizzeriaProject.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProject.Patterns.FactoryMethod
{
    public abstract class Bakery
    {
        public abstract Pizza BakePizza();
    }

    public class MargheritaBakery : Bakery
    {
        public override Pizza BakePizza()
        {
            return new Margherita();
        }
    }
    public class AmericanBakery : Bakery
    {
        public override Pizza BakePizza()
        {
            return new American();
        }
    }
    public class PepperoniBakery : Bakery
    {
        public override Pizza BakePizza()
        {
            return new Pepperoni();
        }
    }
    public class HawaiianBakery : Bakery
    {
        public override Pizza BakePizza()
        {
            return new Hawaiian();
        }
    }
    public class FourCheeseBakery : Bakery
    {
        public override Pizza BakePizza()
        {
            return new FourCheese();
        }
    }
    public class FourMeatBakery : Bakery
    {
        public override Pizza BakePizza()
        {
            return new FourMeat();
        }
    }
    public class CarbonaraBakery : Bakery
    {
        public override Pizza BakePizza()
        {
            return new Carbonara();
        }
    }
    public class BarbecueBakery : Bakery
    {
        public override Pizza BakePizza()
        {
            return new Barbecue();
        }
    }
    public class BavarianBakery : Bakery
    {
        public override Pizza BakePizza()
        {
            return new Bavarian();
        }
    }
    public class MexicanBakery : Bakery
    {
        public override Pizza BakePizza()
        {
            return new Mexican();
        }
    }
}
