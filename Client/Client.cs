using Client.Clients;
using Client.util;
using System;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Client
    {
        static void Main(string[] args)
        {
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
                Console.WriteLine("3. RS-232");
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
                    case 3:
                        SerialPort serialPort = new SerialPort("COM2", 9600, Parity.None, 8, StopBits.One);
                        iclient = new RS232Clients(serialPort);
                        exit = true;
                        break;
                }
            }
            CommandUtil.getCommand(iclient);
        }
    }
}
