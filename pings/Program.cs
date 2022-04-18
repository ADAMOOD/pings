using System;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;


namespace pings
{
    internal class Program
    {
       const string IPAddress="8.8.8.8";
       private const int CursorUnderHeadY = 4;
        static void Main(string[] args)
        {
           bool onlyStartDate = true;
           bool Cursor = true;

           for (int i = 0; i < 26; i++)
           {
               Head(onlyStartDate);
               onlyStartDate = false;
               if (Cursor)
               {
                   setingCursor();
                   Cursor = false;
                }
               Pinging();
            }
        }
        private static void Head(bool checkForDate)
        {
           
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            if (checkForDate)
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy'-'MM'-'dd'|'HH':'mm':'ss"));
            }
            Console.ResetColor();
        }
        private static void Pinging()
        {
            var stopwatch = Stopwatch.StartNew();
            Ping ping = new Ping();
            PingReply reply = ping.Send(IPAddress);
            stopwatch.Stop();
            var timeOfPing = stopwatch.ElapsedMilliseconds;
            CheckIfPingWasSuccessful(reply, timeOfPing);
        }

        private static void CheckIfPingWasSuccessful(PingReply reply, long timeOfPing)
        {
            if (reply.Status.ToString().Equals("Success"))
            {
               
                Console.WriteLine($"reply from  {reply.Address}: bytes={reply.Buffer.Length} time={timeOfPing}x{reply.RoundtripTime} TTL={reply.Options.Ttl}");

            }
            else
            {
                Console.WriteLine(reply.Status.ToString());
            }
        }
        private  static void setingCursor()
        {
            Console.SetCursorPosition(0, CursorUnderHeadY);
        }

     
    }
}
