using Server.communicator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.listener
{
    public class UDPListener: IListener
    {
        private UdpClient server;

        public void Start(CommunicatorD onConnect)
        {
            Console.WriteLine("UDP listener start");
            server = new UdpClient(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12312));
            onConnect(new UDPCommunicator(server));
        }

        public void Stop()
        {
            server.Close();
        }
    }
}
