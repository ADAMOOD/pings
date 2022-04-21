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
        const string IPAddress = "8.8.4.4";
        private const int CursorUnderHeadY = 3;
        private const int BorderOfPrintingList = 25;
        private const int DeletedIndex = 0;
        private const int time = 200;
        static List<string> Pings = new List<string>();
        static int Succes;
        private static int Fail;

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
            Helpers.setingCursor(0, 1);
            Helpers.NumberOfX("Succesful", Succes);
            Helpers.setingCursor(0, 2);
            Helpers.NumberOfX("Failed", Fail);
        }

        private static void Pinging()
        {
            var stopwatch = Stopwatch.StartNew();
            Ping ping = new Ping();
            PingReply reply = ping.Send(IPAddress);
            stopwatch.Stop();
            CheckIfPingWasSuccessful(reply);
            TimeBars.PrintTimeBar((int) reply.RoundtripTime, 40, 2, true);
        }

        private static void CheckIfPingWasSuccessful(PingReply reply)
        {
            if (reply.Status.ToString().Equals("Success"))
            {
                Succes = Helpers.count();
                PrintPing(reply);
                AddingInfoAboutPingToList(reply, Pings);
            }
            else
            {
                Fail = Helpers.count();
                Console.WriteLine(reply.Status.ToString());
            }
        }
        private static void PrintPing(PingReply reply)
        {
            Console.WriteLine(
                $"reply from  {reply.Address}: bytes={reply.Buffer.Length} time={reply.RoundtripTime}ms TTL={reply.Options.Ttl}");
        }

        private static void AddingInfoAboutPingToList(PingReply reply, List<string> Pings)
        {
            var index = Pings.Count;
            if (index > BorderOfPrintingList)
            {
                MoveList(DeletedIndex);
                Helpers.setingCursor(0, CursorUnderHeadY);
            }

            Pings.Add(
                $"reply from  {reply.Address}: bytes={reply.Buffer.Length} time={reply.RoundtripTime}ms TTL={reply.Options.Ttl}");
        }

        private static void MoveList(int oldIndex)
        {
            Pings.RemoveAt(oldIndex);
        }
    }
}