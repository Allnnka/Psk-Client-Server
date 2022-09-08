using Server.communicator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace Server.listener
{
    public class DotNetRemotingListener : IListener
    {
        TcpChannel tcpChannel;
        public DotNetRemotingListener()
        {
            this.tcpChannel = new TcpChannel(8085);
        }
        public void Start(CommunicatorD onConnect)
        {
            Console.WriteLine(".Net Remoting listener start");
            onConnect(new DotNetRemotingCommunicator(tcpChannel));
        }

        public void Stop()
        {
            Console.WriteLine(".Net Remoting listener stop");
        }
    }
}
