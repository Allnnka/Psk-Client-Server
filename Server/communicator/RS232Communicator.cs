using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace Server.communicator
{
    internal class RS232Communicator : ICommunicator
    {
        private SerialPort serialPort;
        List<byte> bBuffer = new List<byte>();
        string sBuffer = String.Empty;


        public RS232Communicator(SerialPort serialPort)
        {
            this.serialPort = serialPort;
        }
        public void Start(CommandD onCommand, CommunicatorD onDisconnect)
        {
            Console.WriteLine("RS232 communicator start");
            serialPort.Open();
            string command = serialPort.ReadLine();
            Console.WriteLine("RS232: " + command);
            serialPort.WriteLine(onCommand(command));
        }

        public void Stop()
        {
            Console.WriteLine("RS232 communicator stop");
            serialPort.Close();
        }
    }
}
