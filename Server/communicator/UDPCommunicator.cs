using Server.listener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.communicator
{

    public class UDPCommunicator : ICommunicator
    {
        private UdpClient client;

        private IPEndPoint ip;

        public UDPCommunicator(UdpClient client)
        {
            this.client = client;
            ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12312);
        }

        public void Start(CommandD onCommand, CommunicatorD onDisconnect)
        {
            Console.WriteLine("TCP communicator start");

            string hi = "Witam tu server";
            byte[] bytesHi = Encoding.ASCII.GetBytes(hi);
            while (true)
            {
                byte[] bytes = client.Receive(ref ip);
                string res = Encoding.ASCII.GetString(bytes);
                Console.WriteLine($"Otrzymano {res} z adresu {ip.Address}, port {ip.Port}");
                client.Send(bytesHi, bytesHi.Length, ip);
                Console.WriteLine($"Wysłano {hi} do adresu {ip.Address}, port {ip.Port}");
                break;
            }
            client.Close();
        }

        public void Stop()
        {
            client.Close();
        }
    }
}
