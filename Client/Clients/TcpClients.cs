using Share;
using System;
using System.Net.Sockets;
using System.Text;

namespace Client.Clients
{
    public class TcpClients : IClient
    {

        //public static void Start()
        //{
        //    try
        //    {
        //        string server = "localhost";
        //        while (true)
        //        {
        //            int port = 12346;
        //            TcpClient client = new TcpClient(server, port);
        //            string command = null;
        //            NetworkStream stream = client.GetStream();
        //            while (true)
        //            {
        //                command = getCommand();
        //                if (command.Equals("0")) break;
        //                byte[] data = Encoding.ASCII.GetBytes(command + Environment.NewLine);
        //                var watch = System.Diagnostics.Stopwatch.StartNew();
        //                Console.WriteLine($"Wysłane {command}");
        //                int numOfResponse = int.Parse(command.Split()[1]);
        //                for(int i = 0; i < numOfResponse; i++)
        //                {
        //                    stream.Write(data, 0, data.Length);
        //                    byte[] response = new byte[256];
        //                    string responseStr = string.Empty;
        //                    int bytes;
        //                    do
        //                    {
        //                        bytes = stream.Read(response, 0, response.Length);
        //                        responseStr += Encoding.ASCII.GetString(response, 0, bytes);
        //                    } while (stream.DataAvailable);
        //                    Console.WriteLine($"[{i+1}] Odpowiedź: {responseStr}");
        //                }
        //                Console.WriteLine($"{command.Split()[0]} Time: " + watch.Elapsed);
        //            }
        //            client.Close();
        //        }
        //    }
        //    catch (Exception e) { Console.WriteLine(e.Message); }
        //}
        NetworkStream networkStream;
        public TcpClients(NetworkStream networkStream)
        {
            this.networkStream = networkStream;
        }

        public override string QA(string command)
        {
            byte[] data = Encoding.ASCII.GetBytes(command + Environment.NewLine);
            networkStream.Write(data, 0, data.Length);
            byte[] response = new byte[256];
            string responseStr = string.Empty;
            int bytes;
            do
            {
                bytes = networkStream.Read(response, 0, response.Length);
                responseStr += Encoding.ASCII.GetString(response, 0, bytes);
            } while (networkStream.DataAvailable);
            return responseStr;
        }
    }
}
