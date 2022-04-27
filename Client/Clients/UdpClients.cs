using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.Clients
{
    public static class UdpClients
    {
        public static void Start()
        {
            UdpClient client = new UdpClient();
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12312);
            System.Threading.Thread.Sleep(1000);
            try
            {
                client.Connect(ip);
                string command = "";
                while (true)
                {
                    command = Console.ReadLine();
                    byte[] data = Encoding.ASCII.GetBytes(command + Environment.NewLine);
                    var watch = System.Diagnostics.Stopwatch.StartNew();
 
                    client.Send(data, data.Length);

                    byte[] received = client.Receive(ref ip);

                    Console.WriteLine(Encoding.ASCII.GetString(received));
                    Console.WriteLine("UPD time: " + watch.Elapsed);
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
