using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace pings
{
    internal class Helpers
    {
        public static void printigList(List<string> Pings)
        {
            foreach (var ping in Pings)
            {
                Console.WriteLine(ping);
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

        public static void ClearSection()
        {
            
        }
    }
}
