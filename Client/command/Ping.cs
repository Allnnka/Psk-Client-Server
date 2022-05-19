using Client.Clients;
using Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.command
{
    public class Ping
    {
        public static void Command(IClient client, string message)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine($"Wysłane {message}");
            int numOfResponse = int.Parse(message.Split()[1]);
            for (int i = 0; i < numOfResponse; i++)
            {
                string responseStr = string.Empty;  
                responseStr = client.QA(PingClass.Ping(int.Parse(message.Split()[1]), int.Parse(message.Split()[2])));
                Console.WriteLine($"[{i + 1}] Odpowiedź: {responseStr}");
            }
            Console.WriteLine($"{message.Split()[0]} Time: " + watch.Elapsed);
        }
    }
}
