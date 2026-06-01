using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProject.UI
{
    public class UIHelper
    {
        public static readonly int windowWidth = 80;
        public static void SetConsoleSettings()
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.WindowWidth = windowWidth;
            Console.BufferWidth = windowWidth;
            Console.WindowHeight = 45;
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
        }
        public static void ClearSubMenu(int startPosition)
        {
            int currentPosition = Console.CursorTop;
            for (int i = startPosition; i <= currentPosition; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', windowWidth));
            }
            Console.SetCursorPosition(0, startPosition);
        }
        public static int ReturnMenuOption(List<string> menuItems)
        {
            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine("║                                                                              ║");
            }
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");
            int selectedIndex = 0;
            int currentLine = Console.CursorTop;
            Console.SetCursorPosition(0, currentLine - menuItems.Count - 1);

            while (true)
            {
                for (int i = 0; i < menuItems.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.Write("║ => " + menuItems[i] + "    ");
                    }
                    else
                    {

                        Console.Write("║   " + menuItems[i] + "    ");
                    }
                    Console.WriteLine();
                }

                var keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selectedIndex == 0)
                        {
                            selectedIndex = menuItems.Count - 1;
                        }
                        else
                        {
                            selectedIndex = selectedIndex - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (selectedIndex == menuItems.Count - 1)
                        {
                            selectedIndex = 0;
                        }
                        else
                        {
                            selectedIndex = selectedIndex + 1;
                        }
                        break;
                    case ConsoleKey.Enter:
                        return selectedIndex;
                }

                currentLine = Console.CursorTop;
                Console.SetCursorPosition(0, currentLine - menuItems.Count);
            }
        }

    }
}
