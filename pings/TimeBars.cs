using System;

namespace pings
{
    internal class TimeBars
    {
        const char Char = '\u2591';

        public static void PrintTimeBar(int steps,int Time, int WhereLeft, int WhereTop, bool DeleteRowAndColor)
        {
            Helpers.setingCursor(WhereLeft, WhereTop);
            if (DeleteRowAndColor)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            for (int i = 1; i <= steps; i++)
            {
                Console.Write(Char);
            }
            Console.Write($"{Time}ms");
            if (DeleteRowAndColor)
            {
                BarDeleter(steps, WhereLeft, WhereTop);
            }
        }
        private static void BarDeleter(int steps, int WhereLeft, int WhereTop)
        {
            Helpers.setingCursor(WhereLeft, WhereTop);
            Helpers.sleeping(1000);
            Helpers.ClearSection(steps + 6, WhereLeft, WhereTop);
        }
    }
}