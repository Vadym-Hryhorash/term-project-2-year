using PizzeriaProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProject.Patterns.Strategy
{
    public interface IPaymentStrategy
    {
        bool Pay(int price);
    }

    public class CardPaymentStrategy : IPaymentStrategy
    {
        public bool Pay(int price)
        {
            bool result = false;
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════╣");
            if (OrderManager.Instance.UserCardMoney >= price)
            {
                double bonusValue = Math.Round(price * 0.03, 1);
                OrderManager.Instance.UserCardMoney -= price;
                OrderManager.Instance.UserBonuses += bonusValue;
                Console.WriteLine("║ Оплата карткою пройшла успішно!                                              ║");
                string line = $"║ Отримано бонусів: {bonusValue}";
                Console.Write(line.PadRight(79, ' '));
                Console.WriteLine("║");
                result = true;
            }
            else
            {
                Console.WriteLine("║ Помилка: Недостатньо коштів! Виберіть інший спосіб оплати.                   ║");
            }
            Console.WriteLine("║ Натисніть будь-яку клавішу...                                                ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");
            Console.ReadKey(true);
            return result;
        }
    }
    public class CashPaymentStrategy : IPaymentStrategy
    {
        public bool Pay(int price)
        {
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════╣");
            string line = $"║ До сплати: {price}";
            Console.Write(line.PadRight(79, ' '));
            Console.WriteLine("║");
            if (price > 600)
            {
                Console.WriteLine($"║ Ваше замовлення зроблене на суму більше 600 грн, доставка безкоштовна!       ║");
                Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════╣");
            }
            else
            {
                Console.WriteLine("║ Замовлення зроблено успішно! Очікуйте кур'єра.                               ║");
                price = (int)(price + price * 0.1);
                line = $"║ До сплати з урахуванням доставки: {price}";
                Console.Write(line.PadRight(79, ' '));
                Console.WriteLine("║");
            }
            
            Console.WriteLine("║ Натисніть будь-яку клавішу...                                                ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");
            Console.ReadKey(true);
            return true;
        }
    }
    public class BonusPaymentStrategy : IPaymentStrategy
    {
        
        public bool Pay(int price)
        {
            bool result = false;
            price = (int)(price + price * 0.1 - price * 0.03);
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════╣");
            if (OrderManager.Instance.UserBonuses >= price)
            {
                string line = $"║ До сплати з урахуванням доставки та отриманих бонусів: {price}";
                Console.Write(line.PadRight(79, ' '));
                Console.WriteLine("║");
                OrderManager.Instance.UserBonuses -= price;
                Console.WriteLine("║ Оплата бонусами пройшла успішно! Очікуйте кур'єра.                           ║");
                result = true;

            }
            else
            {
                Console.WriteLine("║ Помилка: Недостатньо бонусів! Виберіть інший спосіб оплати.                  ║");
            }
            Console.WriteLine("║ Натисніть будь-яку клавішу...                                                ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");
            Console.ReadKey(true);
            return result;
        }
    }
    public class PaymentManager
    {
        private IPaymentStrategy paymentStrategy;
        private int price;
        public PaymentManager(int price)
        {
            this.price = price;
        }
        public void SetPaymentStrategy(IPaymentStrategy strategy)
        {
            this.paymentStrategy = strategy;
        }
        public bool PayWithStrategy()
        {
            if (paymentStrategy == null)
            {
                throw new InvalidOperationException("Ви не обрали спосіб оплати!");
            }
            return paymentStrategy.Pay(price);
        }
    }   


}
