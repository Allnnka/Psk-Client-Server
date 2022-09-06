using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Clients
{
    public  class RS232Clients: IClient
    {
        private SerialPort serialPort;

        public RS232Clients(SerialPort serialPort)
        {
            this.serialPort = serialPort;
        }

        public override string QA(string command)
        {
            string response = String.Empty;
            try
            {
                
                if (!serialPort.IsOpen)
                    serialPort.Open();

                serialPort.WriteLine(command);
                while (response == String.Empty)
                {
                    response = serialPort.ReadExisting();
                }
            } catch (Exception e) { Console.WriteLine(e.Message); }
            return response;
        }
    }
}
