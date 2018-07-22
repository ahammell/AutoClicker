using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoClicker
{
    class Program
    {
        [DllImport("user32.dll", CharSet=CharSet.Auto, CallingConvention =CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        static void Main(string[] args)
        {
            bool endProgram = false;
            do
            {
                Console.WriteLine("Welcome \nQuick Start (F1)\nManual Enter (F2)\nExit Program: (F10)");
                ConsoleKey userInput = Console.ReadKey(true).Key;

                switch (userInput)
                {
                    case ConsoleKey.F1:
                        break;
                    case ConsoleKey.F2:
                        Console.WriteLine("Enter first number:");
                        string firstNumber = Console.ReadLine();
                        int value;
                        if (int.TryParse(firstNumber, out value))
                        {
                            Console.WriteLine("Bet Enter second number:");
                            string secondNumber = Console.ReadLine();
                            int secondValue;
                            if (int.TryParse(secondNumber, out secondValue))
                            {
                                Console.WriteLine("Clicking, Press F3 to stop");
                                do
                                {
                                    while (!Console.KeyAvailable)
                                    {
                                        Random random = new Random();
                                        int interval = random.Next(value, secondValue);
                                        string intervalToString = interval + "000";
                                        System.Threading.Thread.Sleep(Convert.ToInt32(intervalToString));
                                        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                                        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                                    }
                                } while (Console.ReadKey(true).Key != ConsoleKey.F3);
                                endProgram = false;
                            }
                            else
                            {
                                Console.WriteLine("I actually hate you");
                                System.Threading.Thread.Sleep(1000);
                                endProgram = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("You're really pissing me off");
                            System.Threading.Thread.Sleep(1000);
                            endProgram = false;
                        }
                        break;
                    case ConsoleKey.F10:
                        endProgram = true;
                        break;
                    default:
                        Console.WriteLine("CmonBruh Stop Being Stupid");
                        System.Threading.Thread.Sleep(1000);
                        endProgram = false;
                        break;
                }
            } while (!endProgram);
        }
    }
}
