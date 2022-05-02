using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace pings
{
    internal class Helpers
    {
        public static void PrintigList(List<string> pings)
        {
            foreach (var ping in pings)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(ping);
                Console.ResetColor();
            }
        }
        public static void ClearSection(int length, int whereLeft, int whereTop, bool graduallyDeleted)
        {
            Console.SetCursorPosition(whereLeft, whereTop);
            for (int i = 0; i < length; i++)
            {
               Console.Write(" ");
               if (graduallyDeleted)
               {
                   Thread.Sleep(5);
                }
            }
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
          if (roundedDivision < 1)
          {
              return 1;
          }
            return roundedDivision;
      }

      public static int average(int number, int sum,int original)
      {
          int whole = sum + original;
          return whole / number;
      }
    }
}