using Client.Clients;
using Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.command
{
    public class ChatCommand
    {
        public static void Msg(IClient client, string message)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            string responseStr = client.QA(message);
            Console.WriteLine("Odpowiedź: {0}", responseStr);
            Console.WriteLine("chat time: " + watch.Elapsed);
        }
    }
}
