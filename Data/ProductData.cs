using PizzeriaProject.Patterns.FactoryMethod;
using PizzeriaProject.Patterns.Decorator;
using PizzeriaProject.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProject.Data
{
    public class ProductData
    {
        public static readonly Dictionary<string, (int price, int weight, Func<Pizza, Pizza> Decorate)> ingredientsDictionary = new Dictionary<string, (int price, int weight, Func<Pizza, Pizza> Decorate)>()
        {
            {"Моцарела",            (20, 50, pizza => new ExtraMozzarella(pizza)) },
            {"Пармезан",            (25, 20, pizza => new ExtraParmesan(pizza)) },
            {"Пепероні",            (45, 30, pizza => new ExtraPepperoni(pizza)) },
            {"Шинка",               (40, 35, pizza => new ExtraHam(pizza)) },
            {"Курка",               (35, 35, pizza => new ExtraChicken(pizza)) },
            {"Бекон",               (40, 25, pizza => new ExtraBacon(pizza)) },
            {"Салямі",              (45, 30, pizza => new ExtraSalami(pizza)) },
            {"Гриби",               (20, 35, pizza => new ExtraMushrooms(pizza)) },
            {"Кукурудза",           (20, 25, pizza => new ExtraCorn(pizza)) },
            {"Оливки",              (35, 25, pizza => new ExtraOlives(pizza)) },
            {"Болгарський перець",  (30, 25, pizza => new ExtraPepper(pizza)) },
            {"Цибуля",              (15, 20, pizza => new ExtraOnion(pizza)) },
            {"Помідори",            (40, 50, pizza => new ExtraTomatoes(pizza)) }


        };

        public static List<Pizza> GetPizzas()
        {
            return new List<Pizza>()
            {
                new Margherita(),
                new American(),
                new Pepperoni(),
                new Hawaiian(),
                new FourCheese(),
                new FourMeat(),
                new Carbonara(),
                new Barbecue(),
                new Bavarian(),
                new Mexican()
            };
        }
        public static List<Bakery> GetBakeries()
        {
            return new List<Bakery>()
            {
                new MargheritaBakery(),
                new AmericanBakery(),
                new PepperoniBakery(),
                new HawaiianBakery(),
                new FourCheeseBakery(),
                new FourMeatBakery(),
                new CarbonaraBakery(),
                new BarbecueBakery(),
                new BavarianBakery(),
                new MexicanBakery()
            };
        }
        public static List<Drinks> GetDrinks()
        {
            return new List<Drinks>
            {
                new CocaColaHalfLiter(),
                new CocaColaOneLiter(),
                new CocaColaZeroHalfLiter(),
                new CocaColaZeroOneLiter(),
                new FantaHalfLiter(),
                new FantaOneLiter(),
                new FantaZeroHalfLiter(),
                new FantaZeroOneLiter(),
                new SpriteHalfLiter(),
                new SpriteOneLiter(),
            };
        }
        public static List<ComboMenu> GetComboMenus()
        {
            return new List<ComboMenu>()
            {
                new AmericanCombo(),
                new X4Combo(),
                new InternationalCombo()
            };
        }
    }
}
