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

        public RS232Listener()
        {
        }
        public void Start(CommunicatorD onConnect)
        {
            Console.WriteLine("RS232 listener start");
            serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
            onConnect(new RS232Communicator(serialPort));
        }

        public void Stop()
        {
            Console.WriteLine("RS232 communicator stop");
        }
    }
}
