using Share;
using System;
using System.Net.Sockets;
using System.Text;

namespace Client.Clients
{
    public class TcpClients : IClient
    {
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
