using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Clients
{
    public  class RS232Clients
    {
        public static void Start()
        {
            try
            {
                SerialPort port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
                while (true)
                {
                    port.Open();
                    port.Write("Hello World");
                    port.Write(new byte[] { 0x0A, 0xE2, 0xFF }, 0, 3);
                    port.Close();

                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
