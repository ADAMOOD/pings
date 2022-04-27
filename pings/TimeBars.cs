using System;

namespace pings
{
    internal class TimeBars
    {
        const char Char = '\u2591';

        public static void PrintTimeBar(int steps,int time, int whereLeft, int whereTop, bool deleteRowAndColor)
        {
            Helpers.SetingCursor(whereLeft, whereTop);
            if (deleteRowAndColor)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("current ping");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
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
            Helpers.Sleeping(1000);
            Helpers.ClearSection(steps + 15, whereLeft+12, whereTop,true);
        }
    }
}