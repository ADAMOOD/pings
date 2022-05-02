using System;
using System.Threading;

namespace pings
{
    internal class TimeBars
    {
        const char Char = '\u2591';

        public static void PrintTimeBar(int steps,int time, int whereLeft, int whereTop, bool deleteRowAndColor)
        {
            Console.SetCursorPosition(whereLeft, whereTop);
            if (deleteRowAndColor)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("current ping");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("avg Ping time");
            }
            for (int i = 1; i <= steps; i++)
            {
                Console.Write(Char);
            }
            Console.Write($"{time}ms");
            if (deleteRowAndColor)
            {
                BarDeleter(steps, whereLeft, whereTop);
            }

        }
        private static void BarDeleter(int steps, int whereLeft, int whereTop)
        {
            Thread.Sleep(1000);
            Helpers.ClearSection(steps + 15, whereLeft+12, whereTop,true);
        }
    }
}