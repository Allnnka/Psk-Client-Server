using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client.Clients
{
    public class UdpClients: IClient
    {
        UdpClient client;
        IPEndPoint ip;
        public UdpClients(UdpClient client, IPEndPoint ip)
        {
            this.client = client;
            this.ip = ip;
        }

        public override string QA(string command)
        {
            
            try
            {
                client.Connect(ip);
                
                byte[] data = Encoding.ASCII.GetBytes(command + Environment.NewLine);

                client.Send(data, data.Length);
                string responseStr = string.Empty;
                do
                {
                    byte[] received = client.Receive(ref ip);
                    responseStr += Encoding.ASCII.GetString(received);
                } while (responseStr.IndexOf('\n') < 0);
                return responseStr;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }
    }
}
