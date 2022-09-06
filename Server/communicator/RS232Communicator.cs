using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;

namespace Server.communicator
{
    internal class RS232Communicator : ICommunicator
    {
        private SerialPort serialPort;
        private CommandD onCommand;
        public RS232Communicator(SerialPort serialPort)
        {
            this.serialPort = serialPort;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
        }
        void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string command = serialPort.ReadLine();
            while(command == String.Empty)
            {
                command = serialPort.ReadLine();
            }
            Console.WriteLine("RS232: " + command);
            serialPort.WriteLine(onCommand(command));
        }
        public void Start(CommandD onCommand, CommunicatorD onDisconnect)
        {
            Console.WriteLine("RS232 communicator start");
            this.onCommand = onCommand;
            if(!serialPort.IsOpen)
                serialPort.Open();
        }

        public void Stop()
        {
            Console.WriteLine("RS232 communicator stop");
            serialPort.Close();
        }
    }
}
