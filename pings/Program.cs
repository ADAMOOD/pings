using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;

namespace pings
{
    internal class Program
    {
       const string IPAddress= "8.8.8.8";
       private const int CursorUnderHeadY = 3;
       private const int BorderOfPrintingList = 25;
       private const int DeletedIndex = 0;
       private const int time = 200;
       static List<string> Pings = new List<string>();
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            bool onlyStartDate = true;
           bool Cursor = true;
           while (true)
           {
               for (int i = 0; i < BorderOfPrintingList; i++)
               {
                   Head(onlyStartDate);
                   onlyStartDate = false;
                   Helpers.setingCursor(0, i + CursorUnderHeadY);
                    Pinging();
               }
               Helpers.sleeping(time);
               Helpers.setingCursor(0, CursorUnderHeadY);
               Helpers.printigList(Pings);
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
            CheckIfPingWasSuccessful(reply);
            TimeBars.PrintTimeBar(reply.RoundtripTime);
        }
        private static void CheckIfPingWasSuccessful(PingReply reply)
        {
            if (reply.Status.ToString().Equals("Success"))
            {
                AddingInfoAboutPingToList(reply, Pings);
            }
            else
            {
                Console.WriteLine(reply.Status.ToString());
            }
        }
        private static void AddingInfoAboutPingToList(PingReply reply,List<string> Pings)
        {
            var index = Pings.Count;
            if (index > BorderOfPrintingList)
            {
                MoveList(DeletedIndex);
                Helpers.setingCursor(0, CursorUnderHeadY);
            }
            Pings.Add($"reply from  {reply.Address}: bytes={reply.Buffer.Length} time={reply.RoundtripTime}ms TTL={reply.Options.Ttl}");
        }
        private static void MoveList(int oldIndex)
        {
            Pings.RemoveAt(oldIndex);
        }

    }
}
