using System;

namespace pings
{
    internal class TimeBars
    {
        const char Char = '\u2591';

        public static void PrintTimeBar(int steps, int WhereLeft, int WhereTop, bool DeleterAndColor)
        {
            Helpers.setingCursor(WhereLeft, WhereTop);
            if (DeleterAndColor)
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
            if (DeleterAndColor)
            {
                BarDeleter(steps, WhereLeft, WhereTop);
            }
        }
        private static void BarDeleter(int steps, int WhereLeft, int WhereTop)
        {
            Console.Write($"{steps}ms");
            Helpers.setingCursor(30, 0);
            Helpers.sleeping(1000);
            Helpers.ClearSection(steps + 6, WhereLeft, WhereTop);
        }
    }
}