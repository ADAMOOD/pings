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
                   if (Cursor)
                   {
                       setingCursor();
                       Cursor = false;
                   }
                   Pinging();
               }
               sleeping();
               printigList();
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
                AddingInfoAboutPingToList(reply, timeOfPing);
            }
            else
            {
                Console.WriteLine(reply.Status.ToString());
            }
        }
        private static void AddingInfoAboutPingToList(PingReply reply, long timeOfPing)
        {
            var index = Pings.Count;
            if (index > BorderOfPrintingList)
            {
                MoveList(DeletedIndex);
                setingCursor();
            }
            Pings.Add($"reply from  {reply.Address}: bytes={reply.Buffer.Length} time={reply.RoundtripTime}ms TTL={reply.Options.Ttl}");
        }

        private static void MoveList(int oldIndex)
        {
            Pings.RemoveAt(oldIndex);
        }
        private static void printigList()
        {
            foreach (var VARIABLE in Pings)
            {
                Console.WriteLine(VARIABLE);
            }
        }
        private  static void setingCursor()
        {
            Console.SetCursorPosition(0, CursorUnderHeadY);
        }

        private static void sleeping()
        {
            Thread.Sleep(time);
        }
    }
}
