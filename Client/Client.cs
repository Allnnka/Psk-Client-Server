using Client.Clients;
using Client.util;
using System;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Client
    {
        static void Main(string[] args)
        {
            //TcpClients.Start();
            //UdpClients.Start();
            Start();
        }
        static void Start()
        {
            IClient iclient = null;
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Wybierz opcję: ");
                Console.WriteLine("1. TCP");
                Console.WriteLine("2. UDP");
                Console.WriteLine("0. EXIT");

                int option;
                int.TryParse(Console.ReadLine(), out option);
                switch (option)
                {
                    case 0: exit = true; 
                        break;
                    case 1:
                        int port = 12346;
                        string server = "localhost";
                        TcpClient client = new TcpClient(server, port);
                        NetworkStream networkStream = client.GetStream();
                        iclient = new TcpClients(networkStream);
                        exit = true;
                        break;
                    case 2:
                        UdpClient udpClient = new UdpClient();
                        IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12312);
                        iclient = new UdpClients(udpClient, ip);
                        exit = true;
                        break;
                }
            }
            CommandUtil.getCommand(iclient);
        }
    }
}
