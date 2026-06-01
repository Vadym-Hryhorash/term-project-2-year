using Microsoft.EntityFrameworkCore;
using PizzeriaProject.Data;
using PizzeriaProject.Patterns.CachedProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProject.UI
{
    public class HistoryScreen
    {
        public static void Show()
        {
            while (true)
            {
                int startPosition = Console.CursorTop;
                Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║ Введіть дату для пошуку (dd.mm.yyyy), щоб вийти, введіть 'quit':             ║");
                Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");

                Console.SetCursorPosition(67, Console.CursorTop - 2);
                string date = Console.ReadLine();
                
                UIHelper.ClearSubMenu(Console.CursorTop);
                if (date == "quit" || string.IsNullOrEmpty(date))
                {
                    UIHelper.ClearSubMenu(startPosition - 4);
                    break;
                }

                ShowOrdersListByDate(date);
                UIHelper.ClearSubMenu(startPosition);
            }
        }
        private static void ShowOrdersListByDate(string date)
        {
            while (true)
            {
                int startPosition = Console.CursorTop;

                var orders = OrderManager.Instance.OrderServiceProxy.GetUserOrders(OrderManager.Instance.User, date);

                Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════╣");
                string title = $"║ Знайдені замовлення за {date}: ";
                Console.WriteLine(title.PadRight(UIHelper.windowWidth - 1) + "║");

                if (orders.Count == 0)
                {
                    Console.WriteLine("║ На жаль, за цю дату замовлень не знайдено.                                   ║");
                    Console.WriteLine("║ Натисніть будь-яку клавішу...                                                ║");
                    Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");
                    Console.ReadKey(true);
                    UIHelper.ClearSubMenu(startPosition);
                    return;
                }

                List<string> orderMenu = new List<string>();

                for (int i = 0; i < orders.Count; i++)
                {
                    orderMenu.Add($"Замовлення #{i + 1}");
                }
                orderMenu.Add("Повернутись↑");

                int userChoice = UIHelper.ReturnMenuOption(orderMenu);

                if (userChoice == orderMenu.Count - 1)
                {
                    UIHelper.ClearSubMenu(startPosition);
                    return;
                }
                else
                {
                    Cart cart = orders[userChoice];
                    ShowOrderDetails(cart);
                    UIHelper.ClearSubMenu(startPosition);
                }
            }
        }
        private static void ShowOrderDetails(Cart cart)
        {
            int startPosition = Console.CursorTop;

            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════╣");
            int price = 0;
            foreach (var product in cart.Products)
            {
                Console.WriteLine($"║ {product.Name.PadRight(76)} ║");
                price += product.Price;
            }

            Console.WriteLine("║------------------------------------------------------------------------------║");
            string fullPriceString = $"║ Загальна сума: {price}";
            Console.WriteLine(fullPriceString.PadRight(UIHelper.windowWidth - 1, ' ') + "║");
            Console.WriteLine("║                                                                              ║");
            List<string> menuOptions = new List<string> { "Скопіювати замовлення", "Повернутись↑" };

            int userChoice = UIHelper.ReturnMenuOption(menuOptions);

            if (userChoice == 0)
            {
                OrderManager.Instance.CurrentCart.ClearCart();
                Cart clonedCart = cart.DeepClone();
                OrderManager.Instance.CurrentCart = clonedCart;

                Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║ Замовлення успішно скопійовано у вашу поточну корзину!                       ║");
                Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");
                Console.ReadKey(true);
            }

        }

    }
}
