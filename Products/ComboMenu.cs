using PizzeriaProject.Patterns.FactoryMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProject.Products
{
    public abstract class ComboMenu : IProduct
    {
        public string Name {  get; set; }
        public List<IProduct> products = new List<IProduct>();
        public string Description { get; set; }
        public int Price { get; set; }
    }

    public class AmericanCombo : ComboMenu
    {
        public AmericanCombo()
        {
            Name = "Американське комбо";
            products = new List<IProduct>
            {
                new American(),
                new American(),
                new CocaColaOneLiter()

            };
            Description = "2 x Американа, Кока кола 1 л.";
            Price = 300;
        }
    }
    public class InternationalCombo : ComboMenu
    {
        public InternationalCombo()
        {
            Name = "Інтернаціональне комбо";
            products = new List<IProduct>
            {
                new American(),
                new Mexican(),
                new Bavarian()

            };
            Description = "Американа, Мексиканська, Баварська";
            Price = 500;
        }
    }
    public class X4Combo : ComboMenu
    {
        public X4Combo()
        {
            Name = "Квадро-комбо";
            products = new List<IProduct>
            {
                new FourCheese(),
                new FourMeat()
            };
            Description = "піца 4 Сири, піца 4 М'яса";
            Price = 380;
        }
    }
}
