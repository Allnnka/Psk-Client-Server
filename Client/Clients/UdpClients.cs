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
        /*public static void Start()
        {
            UdpClient client = new UdpClient();
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12312);
            System.Threading.Thread.Sleep(1000);
            try
            {
                client.Connect(ip);
                string command = "";
                while (true)
                {
                    command = Console.ReadLine();
                    byte[] data = Encoding.ASCII.GetBytes(command + Environment.NewLine);
                    var watch = System.Diagnostics.Stopwatch.StartNew();
 
                    client.Send(data, data.Length);

                    byte[] received = client.Receive(ref ip);

                    Console.WriteLine(Encoding.ASCII.GetString(received));
                    Console.WriteLine("UPD time: " + watch.Elapsed);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }
*/
        public override string QA(string command)
        {
            
            System.Threading.Thread.Sleep(1000);
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
