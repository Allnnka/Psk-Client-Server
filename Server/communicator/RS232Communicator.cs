using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.communicator
{
    internal class RS232Communicator : ICommunicator
    {
       // RS232Communicator client;
        private SerialPort serialPort;
        public RS232Communicator(RS232Communicator client)
        {
            this.client = client;
            serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        }
        public void Start(CommandD onCommand, CommunicatorD onDisconnect)
        {
           serialPort.Open();

        }

        public void Stop()
        {
            client.Stop();
        }
    }
}
