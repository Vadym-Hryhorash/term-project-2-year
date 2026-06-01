using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProject.UI
{
    public class MainMenuScreen
    {
        public static void Show()
        {
            UIHelper.SetConsoleSettings();

            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                 Вітаємо в нашій піцерії! Що бажаєте зробити?                 ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════╣");

            while (true)
            {

                List<string> mainMenu = new List<string> { "Переглянути меню", "Переглянути корзину", "Переглянути історію замовлень", "Вийти" };
                int userChoice = UIHelper.ReturnMenuOption(mainMenu);

                switch (userChoice)
                {
                    case 0: PizzeriaMenuScreen.Show(); break;
                    case 1: CartScreen.Show(); break;
                    case 2: HistoryScreen.Show(); break;
                    case 3: return;
                }
            }
        }

        
    }
}
