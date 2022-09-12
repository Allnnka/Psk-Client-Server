using System.IO;
using System.Threading;

namespace Client.Clients
{
    public class FileClients : IClient
    {
        public FileClients() { }
        string serverPath = @"../../../File/Client/file.txt";
        string clientPath = @"../../../File/Server/file.txt";

        public override string QA(string command)
        {
            File.WriteAllText(clientPath, command);

            Thread.Sleep(30);

            using (StreamReader streamReader = new StreamReader(serverPath))
            {
                string lines = streamReader.ReadToEnd();
                streamReader.Close();
                return lines;
            }
        }
    }
}
