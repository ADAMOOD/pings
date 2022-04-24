using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace pings
{
    
    internal class Helpers
    {
        static int Runs = 0;
        private static int AVG = 0;
        public static void printigList(List<string> Pings)
        {
            foreach (var ping in Pings)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ping);
                Console.ResetColor();
            }
        }
        public static void setingCursor(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }
        public static void sleeping(int time)
        {
            Thread.Sleep(time);
        }
        public static void ClearSection(int length, int WhereLeft, int WhereTop)
        {
            Helpers.setingCursor(WhereLeft, WhereTop);
            for (int i = 0; i < length; i++)
            {
               Console.Write(" ");
               sleeping(10);
            }
        }
      public static int count()
      {
          Runs++;
          return Runs;
      }
      public static void NumberOfX(string x, int count)
      {
          Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{x}:{count}");
            Console.ResetColor();
        }
      public static int DividedByXAndRoundedIt(int divisor, int dividend)
      {
          double division = (dividend / divisor);
          int roundedDivision = (int)Math.Round(division);
          return roundedDivision;
      }
    }
}