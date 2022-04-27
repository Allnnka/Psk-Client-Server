using Client.Clients;
using System;

namespace Client
{
    class Client
    {
        static void Main(string[] args)
        {
            //TcpClients.Start();
            UdpClients.Start();
            //Start();
        }
        static void Start()
        {
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
                    case 1: TcpClients.Start(); 
                        break;
                    case 2:
                        UdpClients.Start();
                    break;
                }
            }
        }
    }
}
