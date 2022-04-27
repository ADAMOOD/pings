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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ping);
                Console.ResetColor();
            }
        }
        public static void SetingCursor(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }
        public static void Sleeping(int time)
        {
            Thread.Sleep(time);
        }
        public static void ClearSection(int length, int whereLeft, int whereTop, bool graduallyDeleted)
        {
            SetingCursor(whereLeft, whereTop);
            for (int i = 0; i < length; i++)
            {
               Console.Write(" ");
               if (graduallyDeleted)
               {
                   Sleeping(5);
                }
               
            }
        }
      public static int Count(int input)
      {
          input++;
          return input;
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
              roundedDivision=1;
          }
          return roundedDivision;
      }
    }
}