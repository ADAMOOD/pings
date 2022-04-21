using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace pings
{
    internal class TimeBars
    {
        const char Char = '\u2591';
        public static void PrintTimeBar(long steps)
        {
            Helpers.setingCursor(30,0);
            for (int i = 1; i <= steps; i++)
            {
              //  Program.sleeping(100);
                Console.Write(Char);
            }
            Console.Write($"{steps}ms");
        }
        
    }
}