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
        }

        public void Stop()
        {
            Console.WriteLine("TCP listener stop");
            server.Stop();
        }
    }
}
