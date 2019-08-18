using System;
using System.Threading;
using System.Globalization;

namespace MBGE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[" + typeof(System.DateTime) + "] " + "Ok!");
            __MBGE_PressEnter();
        }

        private static void __MBGE_PressEnter()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru-RU");
            Console.WriteLine(Properties.locale.PressEnter);
            do
            {
                while (!Console.KeyAvailable)
                {
                    // Do something
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
        }
    }
}
