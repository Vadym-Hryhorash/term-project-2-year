using PizzeriaProject.Data;
using PizzeriaProject.Patterns.Builder;
using PizzeriaProject.Patterns.Command;
using PizzeriaProject.Patterns.FactoryMethod;
using PizzeriaProject.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProject.UI
{
    public class PizzeriaMenuScreen
    {
        public static void Show()
        {

            while (true)
            {
                int startPosition = Console.CursorTop - 4;
                Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════╣");
                List<string> pizzeriaMenu = new List<string> { "Піци", "Напої", "Комбо-меню", "Повернутись↑" };
                int userChoice = UIHelper.ReturnMenuOption(pizzeriaMenu);
                switch (userChoice)
                {
                    case 0: ShowPizzas(); break;
                    case 1: ShowDrinksMenu(); break;
                    case 2: ShowComboMenu(); break;
                    case 3: UIHelper.ClearSubMenu(startPosition); return;

                }
            }

        }
        private static void ShowPizzas()
        {
            List<Pizza> pizzaList = ProductData.GetPizzas();
            List<Bakery> bakeryList = ProductData.GetBakeries();

            List<string> menuItems = pizzaList.Select(p => p.Name).ToList();
            menuItems.Add("Авторська");
            menuItems.Add("Повернутись↑");

            while (true)
            {
                int startPosition = Console.CursorTop - 5;
                Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════╣");

                int userChoice = UIHelper.ReturnMenuOption(menuItems);
                if (userChoice < menuItems.Count - 2)
                {
                    Bakery selectedBakery = bakeryList[userChoice];
                    Pizza orderedPizza = selectedBakery.BakePizza();
                    PizzaDecoration(orderedPizza, startPosition);
                }
                else if (userChoice == menuItems.Count - 2)
                {
                    PizzaBuilding(startPosition);
                }
                else if (userChoice == menuItems.Count - 1)
                {
                    UIHelper.ClearSubMenu(startPosition);
                    return;
                }
            }

        }
        private static void PizzaBuilding(int startPosition)
        {
            int buildPosition = Console.CursorTop;
            ConcretePizzaBuilder builder = new ConcretePizzaBuilder();
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║ Оберіть тісто:                                                               ║");

            List<string> menu = new List<string> { "Тонке", "Пухке" };
            int ingredientChoice = UIHelper.ReturnMenuOption(menu);
            builder.SetDough(menu[ingredientChoice]);
            UIHelper.ClearSubMenu(buildPosition);

            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║ Оберіть соус:                                                                ║");

            menu = new List<string>{ "Класичний Томатний", "Білий Вершковий", "Томадоро", "Шрірача", "Гірчичний", "Барбек'ю" };
            ingredientChoice = UIHelper.ReturnMenuOption(menu);
            builder.SetSauce(menu[ingredientChoice]);
            UIHelper.ClearSubMenu(buildPosition);

            while (true)
            {
                Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║ Оберіть інгредієнт:                                                          ║");

                menu = new List<string>();
                menu.Add("Додати в кошик");
                foreach (var item in ProductData.ingredientsDictionary)
                {
                    menu.Add($"+ {item.Key} (+{item.Value.price} грн.)");
                }
                menu.Add("Переглянути опис");
                menu.Add("Повернутись до вибору піци↑");

                ingredientChoice = UIHelper.ReturnMenuOption(menu);
                if (ingredientChoice == 0)
                {

                    ICommand addCommand = new AddToCartCommand(OrderManager.Instance.CurrentCart, builder.GetPizza());
                    OrderManager.Instance.ExecuteCommand(addCommand);
                    builder.Reset();
                    UIHelper.ClearSubMenu(startPosition + 5);
                    break;
                }
                else if (ingredientChoice <= ProductData.ingredientsDictionary.Count)
                {
                    builder.AddIngredient(
                        ProductData.ingredientsDictionary.ElementAt(ingredientChoice - 1).Key,
                        ProductData.ingredientsDictionary.ElementAt(ingredientChoice - 1).Value.price,
                        ProductData.ingredientsDictionary.ElementAt(ingredientChoice - 1).Value.weight
                        );
                    UIHelper.ClearSubMenu(buildPosition);
                }
                else if (ingredientChoice == ProductData.ingredientsDictionary.Count + 1)
                {
                    UIHelper.ClearSubMenu(buildPosition);
                    DrawDescription(builder.GetPizza());
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.WriteLine("║ Натисніть будь-яку клавішу...                                                ║");
                    Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");
                    Console.ReadKey(true);
                    UIHelper.ClearSubMenu(buildPosition);
                }
                else
                {
                    builder.Reset();
                    UIHelper.ClearSubMenu(startPosition + 5);
                    break;
                }

            }
        }
        private static void PizzaDecoration(Pizza orderedPizza, int startPosition)
        {
            while (true)
            {
                int decMenuPosition = Console.CursorTop;
                DrawDescription(orderedPizza);

                List<string> menu = ProductData.ingredientsDictionary.Select(i => $"+ {i.Key} (+{i.Value.price} грн.)").ToList();

                menu.Add("Додати в кошик");
                menu.Add("Повернутись↑");

                int userSecondChoice = UIHelper.ReturnMenuOption(menu);

                if (userSecondChoice == menu.Count - 2)
                {
                    ICommand addCommand = new AddToCartCommand(OrderManager.Instance.CurrentCart, orderedPizza);
                    OrderManager.Instance.ExecuteCommand(addCommand);
                    UIHelper.ClearSubMenu(startPosition + 5);
                    break;
                }
                else if (userSecondChoice < ProductData.ingredientsDictionary.Count)
                {
                    orderedPizza = ProductData.ingredientsDictionary.ElementAt(userSecondChoice).Value.Decorate(orderedPizza);
                    UIHelper.ClearSubMenu(decMenuPosition);
                }
                else
                {
                    UIHelper.ClearSubMenu(startPosition + 5);
                    break;
                }
            }
        }
        private static void ShowDrinksMenu()
        {
            List<Drinks> drinkList = ProductData.GetDrinks();
            List<string> menuItems = drinkList.Select(d => $"{d.Name} ({d.Price} грн.)").ToList();
            menuItems.Add("Повернутись↑");

            int startPosition = Console.CursorTop;
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════╣");
            int userChoice = UIHelper.ReturnMenuOption(menuItems);

            if (userChoice < menuItems.Count - 1)
            {
                ICommand addCommand = new AddToCartCommand(OrderManager.Instance.CurrentCart, drinkList[userChoice]);
                OrderManager.Instance.ExecuteCommand(addCommand);
            }
            UIHelper.ClearSubMenu(startPosition - 5);

        }
        private static void ShowComboMenu()
        {
            List<ComboMenu> comboList = ProductData.GetComboMenus();
            List<string> menuItems = comboList.Select(x => $"{x.Name} ({x.Price} грн.) - {x.Description}").ToList();
            menuItems.Add("Повернутись↑");

            int startPosition = Console.CursorTop;
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════╣");
            int userChoice = UIHelper.ReturnMenuOption(menuItems);

            if (userChoice < menuItems.Count - 1)
            {
                ICommand addCommand = new AddToCartCommand(OrderManager.Instance.CurrentCart, comboList[userChoice]);
                OrderManager.Instance.ExecuteCommand(addCommand);
            }
            UIHelper.ClearSubMenu(startPosition - 5);

        }
        private static void DrawDescription(Pizza pizza)
        {
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════╣");

            int limit = 75;

            string[] words = pizza.Description.Split(' ');
            string line = "";

            foreach (var word in words)
            {
                if ((line + word).Length > limit)
                {
                    Console.WriteLine($"║ {line,-76} ║");
                    line = "";
                }

                if (line.Length > 0)
                {
                    line += " " + word;
                }
                else
                {
                    line += "" + word;
                }
            }

            if (line.Length > 0)
            {
                Console.WriteLine($"║ {line,-76} ║");
            }
            string temp = $"║ Вага: {pizza.Weight} г.";
            Console.Write(temp.PadRight(UIHelper.windowWidth - 1, ' '));
            Console.WriteLine("║");
            Console.WriteLine("║                                                                              ║");
            temp = $"║ Ціна: {pizza.Price} грн.";
            Console.Write(temp.PadRight(UIHelper.windowWidth - 1, ' '));
            Console.WriteLine("║");
            Console.WriteLine("║                                                                              ║");
            Console.WriteLine("║ Бажаєте додати піцу до замовлення?                                           ║");
        }
    }
}
