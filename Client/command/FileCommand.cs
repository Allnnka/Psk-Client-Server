using Client.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.command
{
    public class FileCommand
    {
        public static void Command(IClient client, string message)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            string responseStr = client.QA(message+"\n");
            Console.WriteLine("Odpowiedź: {0}", responseStr);
            Console.WriteLine("chat time: " + watch.Elapsed);
        }
    }
}
