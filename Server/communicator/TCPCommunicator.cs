using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.communicator
{
    class TCPCommunicator : ICommunicator
    {
        TcpClient client;
        public TCPCommunicator(TcpClient client)
        {
            this.client = client;
        }

        public void Start(CommandD onCommand, CommunicatorD onDisconnect)
        {
            Console.WriteLine("TCP communicator start");

            NetworkStream networkStream = client.GetStream();
            byte[] bytes = new byte[256];
            string data = string.Empty;
            while (client.Connected)
            {
                try
                {

                    if (networkStream.DataAvailable)
                    {
                        int len = networkStream.Read(bytes, 0, bytes.Length);
                        data += Encoding.ASCII.GetString(bytes, 0, len);
                    }
                    else if (data != string.Empty)
                    {
                        string message = onCommand(data);
                        bytes = Encoding.ASCII.GetBytes(message);
                        networkStream.Write(bytes, 0, bytes.Length);
                        Console.WriteLine($"TCP Wysłano: {message}");
                        data = string.Empty;
                    }
                }
                catch { onDisconnect(this); Stop(); };
            }
            networkStream.Close();
            //string message = onCommand("pong 123");
            // byte[] bytes = Encoding.ASCII.GetBytes(message);
            //Console.WriteLine("Wysłane: {0}", message);

        }
        public void Stop()
        {
            Console.WriteLine("TCP communicator stop");
            client.Close();
        }
    }
}
