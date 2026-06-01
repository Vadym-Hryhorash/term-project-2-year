using PizzeriaProject.Data;
using PizzeriaProject.Patterns.Command;
using PizzeriaProject.Patterns.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProject.UI
{
    public class CartScreen
    {
        public static void Show()
        {
            int startPosition = Console.CursorTop - 4;
            int limit = UIHelper.windowWidth - 4;
            int fullPrice = 0;
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════╣");
            foreach (var product in OrderManager.Instance.CurrentCart.Products)
            {
                string namePart = $"{product.Name} ";
                string pricePart = $" {product.Price} грн.";
                int leftPartLength = limit - pricePart.Length;
                string formattedLine = namePart.PadRight(leftPartLength, '.') + pricePart;

                Console.WriteLine($"║ {formattedLine} ║");
                fullPrice += product.Price;
            }
            Console.WriteLine("║------------------------------------------------------------------------------║");
            string fullPriceString = $"║ Загальна сума: {fullPrice}";
            Console.WriteLine(fullPriceString.PadRight(UIHelper.windowWidth - 1, ' ') + "║");
            Console.WriteLine("║                                                                              ║");
            List<string> menuOptions = new List<string> { "Підтвердити замовлення", "Очистити корзину", "Скасувати попередню дію", "Повернутись↑" };
            int cartChoice = UIHelper.ReturnMenuOption(menuOptions);
            if (cartChoice == 0)
            {
                if (fullPrice == 0)
                {
                    Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════╣");
                    Console.WriteLine("║ Ваша корзина пуста!                                                          ║");
                    Console.WriteLine("║ Натисніть будь-яку клавішу...                                                ║");
                    Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");
                    Console.ReadKey(true);
                }
                else
                {
                    bool isPaid = false;
                    while (!isPaid)
                    {
                        Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════╣");
                        Console.WriteLine("║ Виберіть спосіб оплати:                                                      ║");
                        string line = $"║ Баланс на карті: {OrderManager.Instance.UserCardMoney}, Бонуси: {Math.Round(OrderManager.Instance.UserBonuses, 1)}";
                        Console.Write(line.PadRight(UIHelper.windowWidth - 1, ' '));
                        Console.WriteLine("║");
                        Console.WriteLine("║                                                                              ║");
                        int paymentChoice = UIHelper.ReturnMenuOption(new List<string> { "Готівкою", "Карткою", "Бонусами", "Повернутись↑" });
                        IPaymentStrategy paymentStrategy = null;
                        switch (paymentChoice)
                        {
                            case 0: paymentStrategy = new CashPaymentStrategy(); break;
                            case 1: paymentStrategy = new CardPaymentStrategy(); break;
                            case 2: paymentStrategy = new BonusPaymentStrategy(); break;
                            default: isPaid = true; break;
                        }

                        if (paymentStrategy != null)
                        {
                            PaymentManager paymentManager = new PaymentManager(fullPrice);
                            paymentManager.SetPaymentStrategy(paymentStrategy);
                            isPaid = paymentManager.PayWithStrategy();

                            if (isPaid)
                            {
                                SqlManager.saveOrder(OrderManager.Instance.CurrentCart, OrderManager.Instance.User);
                                OrderManager.Instance.CurrentCart.ClearCart();
                                UIHelper.ClearSubMenu(startPosition);
                            }
                            else
                            {
                                UIHelper.ClearSubMenu(startPosition - 1);
                            }
                        }
                    }
                }
            }
            else if (cartChoice == 1)
            {
                ICommand clearCmd = new ClearCartCommand(OrderManager.Instance.CurrentCart);
                OrderManager.Instance.ExecuteCommand(clearCmd);
            }
            else if(cartChoice == 2)
            {
                OrderManager.Instance.UndoLastAction();
            }
            UIHelper.ClearSubMenu(startPosition);

        }
        
    }
}
