using Server.communicator;
using Share;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server.listener
{
    public class TCPListener : IListener
    {
        TcpListener server;
        CommunicatorD _onConnect;
        public TCPListener() { }

        
        private void DoBeginAcceptTcpClient(IAsyncResult ar)
        {
            try
            {
                TcpClient tcpClient = server.EndAcceptTcpClient(ar);
                server.BeginAcceptTcpClient(DoBeginAcceptTcpClient, server);
                ICommunicator communicator = new TCPCommunicator(tcpClient);
                _onConnect(communicator);
                //Console.WriteLine("TCP Connected with: " + tcpClient.Client.RemoteEndPoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Start(CommunicatorD onConnect)
        {
            Console.WriteLine("TCP listener start");
            _onConnect = onConnect;
            server = new TcpListener(IPAddress.Any, 12346);
            server.Start();
            server.BeginAcceptTcpClient(DoBeginAcceptTcpClient, server);
            //byte[] bytes = new byte[256];
            //while (true)
            //{
            //    Console.WriteLine("Trwa łączenie....");
            //    TcpClient client = server.AcceptTcpClient();

            //    Console.WriteLine("Udało się nazwiązać połączenie!");
            //    NetworkStream stream = client.GetStream();
            //    string data = null;
            //    int len;
            //    while ((len = stream.Read(bytes, 0, bytes.Length)) > 0)
            //    {
            //        data += Encoding.ASCII.GetString(bytes, 0, len);
            //        Console.WriteLine(data);
            //        ICommunicator communicator = new TCPCommunicator(client);
            //        //Czy to do servisu?
            //        CommandD command = new CommandD(PingClass.Pong);
            //        communicator.Start(command, onConnect);
            //        data = null;
            //    }
            //    client.Close(); 
            //}
        }

        public void Stop()
        {
            Console.WriteLine("TCP listener stop");
            server.Stop();
        }
    }
}
