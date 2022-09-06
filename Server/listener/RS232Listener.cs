using Server.communicator;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.listener
{
    public class RS232Listener : IListener
    {
        private SerialPort serialPort;
        private CommunicatorD onConnect;

        public RS232Listener()
        {
            serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        }
        public void Start(CommunicatorD onConnect)
        {
            Console.WriteLine("RS232 listener start");
            this.onConnect = onConnect;
            onConnect(new RS232Communicator(serialPort));
        }

        public void Stop()
        {
            Console.WriteLine("RS232 communicator stop");
        }
    }
}
