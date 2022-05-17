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
        static string IpAddress = "8.8.8.8";
        private const int CursorUnderHeadY = 4;
        private const int BorderOfPrintingList = 25;
        private const int DeletedIndex = 0;
        private const int Block = 10;
        static List<string> _pings = new List<string>();
        static int _succes;
        static int _fail;
        static int _avg;
		static string dataForPing = "HELLO KEENMATEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE";
		static byte[] buffer = Encoding.ASCII.GetBytes(dataForPing);
		static void Main(string[] args)
        {
	        Console.Clear();
	        if (args.Length != 0)
	        {
		        IpAddress = args[0];
	        }
			Console.CursorVisible = false;
            bool cursor = true;
            PrintStartDate();
            while (true)
            {
                for (int i = 0; i < BorderOfPrintingList; i++)
                {
                    Head();
                    Console.SetCursorPosition(0, i + CursorUnderHeadY);
                    Pinging();
                    Helpers.ClearSection(60, 0, i + 5,false);
                }
                Console.SetCursorPosition(0, CursorUnderHeadY);
                Helpers.PrintigList(_pings);
            }
        }

        private static void Head()
        {
            Console.SetCursorPosition(0, 1);
            Helpers.NumberOfX("Successful", _succes);
            Console.SetCursorPosition(0, 2);
            Helpers.NumberOfX("Failed", _fail);
        }

        private static void PrintStartDate()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(DateTime.Now.ToString("yyyy'-'MM'-'dd'|'HH':'mm':'ss"));
            Console.ResetColor();
        }

        private static void Pinging()
        {

            Ping ping = new Ping();
            PingReply reply = ping.Send(IpAddress,1000,buffer);
            CheckIfPingWasSuccessful(reply);
        }

        private static void CheckIfPingWasSuccessful(PingReply reply)
        {
            if (reply.Status.ToString().Equals("Success"))
            {
                int roundedTime;
                int roundedAvgTime;
                _succes++;
                _avg = Helpers.average(_succes, (int) reply.RoundtripTime);
                roundedTime = Helpers.DividedByXAndRoundedIt(Block, (int) reply.RoundtripTime);
                roundedAvgTime = Helpers.DividedByXAndRoundedIt(Block, _avg);
                PrintPing(reply);
                AddingInfoAboutPingToList(reply, _pings,true);
                Helpers.ClearSection(60, 20, 1, false);
                TimeBars.PrintTimeBar(roundedAvgTime, _avg, 20, 1, false);
                TimeBars.PrintTimeBar(roundedTime, (int) reply.RoundtripTime, 20, 2, true);
            }
            else
            {
                _fail++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(reply.Status.ToString());
                Console.ResetColor();
                AddingInfoAboutPingToList(reply, _pings,false);
				Thread.Sleep(1000);
                
            }
        }
        private static void PrintPing(PingReply reply)
        {
           
            Console.WriteLine(
                $"reply from  {reply.Address}: bytes={reply.Buffer.Length} time={reply.RoundtripTime}ms TTL={reply.Options.Ttl}");
        }

        private static void AddingInfoAboutPingToList(PingReply reply, List<string> pings,bool PingWasSuccessful)
        {
            var index = pings.Count;
            if (index > BorderOfPrintingList)
            {
                MoveList(DeletedIndex);
                Console.SetCursorPosition(0, CursorUnderHeadY);
            }

            if (PingWasSuccessful)
            {
				pings.Add(
					$"reply from  {reply.Address}: bytes={reply.Buffer.Length} time={reply.RoundtripTime}ms TTL={reply.Options.Ttl}");
			}
            else
            {
	            pings.Add($"{reply.Status.ToString()}");
            }
        }

        private static void MoveList(int oldIndex)
        {
            _pings.RemoveAt(oldIndex);
        }
    }
}