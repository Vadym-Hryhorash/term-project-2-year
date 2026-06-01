using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProject.Products
{
    public abstract class Drinks : IProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }

    public class CocaColaHalfLiter : Drinks
    {
        public CocaColaHalfLiter()
        {
            Name = "Кока-кола 0.5 л.";
            Price = 50;
        }
    }
    public class CocaColaOneLiter : Drinks
    {
        public CocaColaOneLiter()
        {
            Name = "Кока-кола 1 л.";
            Price = 80;
        }
    }
    public class CocaColaZeroHalfLiter : Drinks
    {
        public CocaColaZeroHalfLiter()
        {
            Name = "Кока-кола (без цукру) 0.5 л.";
            Price = 60;
        }
    }
    public class CocaColaZeroOneLiter : Drinks
    {
        public CocaColaZeroOneLiter()
        {
            Name = "Кока-кола (без цукру) 1 л.";
            Price = 95;
        }
    }
    public class SpriteHalfLiter : Drinks
    {
        public SpriteHalfLiter()
        {
            Name = "Спрайт 0.5 л.";
            Price = 40;
        }
    }
    public class SpriteOneLiter : Drinks
    {
        public SpriteOneLiter()
        {
            Name = "Спрайт 1 л.";
            Price = 70; ;
        }
    }
    public class FantaHalfLiter : Drinks
    {
        public FantaHalfLiter()
        {
            Name = "Фанта 0.5 л.";
            Price = 35;
        }
    }
    public class FantaOneLiter : Drinks
    {
        public FantaOneLiter()
        {
            Name = "Фанта 1 л.";
            Price = 65;
        }
    }
    public class FantaZeroHalfLiter : Drinks
    {
        public FantaZeroHalfLiter()
        {
            Name = "Фанта (без цукру) 0.5 л.";
            Price = 50;
        }
    }
    public class FantaZeroOneLiter : Drinks
    {
        public FantaZeroOneLiter()
        {
            Name = "Фанта (без цукру) 1 л.";
            Price = 85;
        }
    }
}
