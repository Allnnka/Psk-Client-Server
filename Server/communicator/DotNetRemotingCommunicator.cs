using Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace Server.communicator
{
    public class DotNetRemotingCommunicator : ICommunicator
    {
        TcpChannel tcpChannel;

        public DotNetRemotingCommunicator(TcpChannel tcpChannel)
        {
            this.tcpChannel = tcpChannel;
        }

        public void Start(CommandD onCommand, CommunicatorD onDisconnect)
        {
            Console.WriteLine(".Net Remoting communicator start");

            ChannelServices.RegisterChannel(tcpChannel);
            DotNetRemotingClass dotNetRemotingClass = new DotNetRemotingClass(new DotNetRemotingClass.CommandD(onCommand));
            RemotingServices.Marshal(dotNetRemotingClass, "netRemoting");
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
