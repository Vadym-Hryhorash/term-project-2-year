using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProject.Products
{
    public abstract class Pizza : IProduct
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }
    }
    public class Margherita : Pizza
    {
        public Margherita()
        {
            Name = "Маргарита";
            Description = "Помідори свіжі, сир Моцарела, соус Томадоро, орегано сухий";
            Price = 119;
            Weight = 420;
        }
    }
    public class American : Pizza
    {
        public American()
        {
            Name = "Американа";
            Description = "Соус томатний для піци, сир твердий, соус Барбекю, філе куряче копчене, ковбаса Салямі, кукурудза консервована, цибуля ріпчаста";
            Price = 159;
            Weight = 500;
        }

    }
    public class Pepperoni : Pizza
    {
        public Pepperoni()
        {
            Name = "Пепероні";
            Description = "Ковбаса Пепероні, сир Моцарела, соус Томадоро, сир Пармезан";
            Price = 209;
            Weight = 450;
        }

    }
    public class Hawaiian : Pizza
    {
        public Hawaiian()
        {
            Name = "Гавайська";
            Description = "Філе куряче, ананас, сир Моцарела, соус Томадоро, кукурудза, орегано сухий";
            Price = 185;
            Weight = 450;
        }

    }
    public class FourCheese : Pizza
    {
        public FourCheese()
        {
            Name = "Чотири Сири";
            Description = "Сир Дор Блю, сир Фета, сир твердий, сир Моцарела, вершки, орегано сухий";
            Price = 219;
            Weight = 430;
        }
    }
    public class FourMeat : Pizza
    {
        public FourMeat()
        {
            Name = "Чотири М'яса";
            Description = "Шинка, ковбаски Баварські, бекон, салямі, помідори свіжі, сир Моцарела, соус Гірчичний, зелень свіжа";
            Price = 209;
            Weight = 500;
        }

    }
    public class Carbonara : Pizza
    {
        public Carbonara()
        {
            Name = "Карбонара";
            Description = "Бекон, ковбаски Мисливські, печериці свіжі, помідори свіжі, сир Моцарела, вершки, орегано сухий, ковбаса Пепероні";
            Price = 199;
            Weight = 460;
        }

    }
    public class Barbecue : Pizza
    {
        public Barbecue()
        {
            Name = "Барбек'ю";
            Description = "Бекон, філе куряче, печериці свіжі, перець болгарський свіжий, сир Моцарела, соус Барбекю, соус Томадоро, цибуля маринована, орегано сухий";
            Price = 199;
            Weight = 500;
        }
    }
    public class Bavarian : Pizza
    {
        public Bavarian()
        {
            Name = "Баварська";
            Description = "Ковбаски Баварські, бекон, печериці свіжі, перець болгарський свіжий, сир Моцарела, соус Гірчичний, цибуля маринована, суміш трав";
            Price = 209;
            Weight = 460;
        }

    }
    public class Mexican : Pizza
    {
        public Mexican()
        {
            Name = "Мексиканська";
            Description = "Філе куряче, ковбаски Баварські, сир Моцарела, соус Томадоро, соус Шрірача, перець чілі свіжий, кукурудза, перець болгарський свіжий, зелень свіжа";
            Price = 209;
            Weight = 450;
        }

    }
}
