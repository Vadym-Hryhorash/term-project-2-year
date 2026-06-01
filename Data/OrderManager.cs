using PizzeriaProject.Patterns.CachedProxy;
using PizzeriaProject.Patterns.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProject.Data
{
    public class OrderManager
    {
        private static OrderManager instance;
        private Stack<ICommand> history = new Stack<ICommand>();
        public static OrderManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderManager();
                }
                return instance;
            }
        }
        public Cart CurrentCart { get; set; }
        public int UserCardMoney { get; set; }
        public double UserBonuses {  get; set; }
        public List<Cart> OrderHistory { get; private set; }
        public string User { get; set; }
        public IOrderService OrderServiceProxy { get; set; }
        private OrderManager()
        {
            CurrentCart = new Cart();
            UserCardMoney = 1000;
            UserBonuses = 326.4;
            OrderHistory = new List<Cart>();
            User = "Григораш Вадим Олександрович";
            OrderServiceProxy = new CachedOrderProxy(new DatabaseOrderService());

        }
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            history.Push(command);
        }
        public void UndoLastAction()
        {
            if (history.Count > 0)
            {
                var command = history.Pop();
                command.Undo();
            }
        }
    }
}
