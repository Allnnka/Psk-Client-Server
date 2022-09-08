using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

            Thread.Sleep(20);

            using (StreamReader streamReader = new StreamReader(serverPath))
            {
                string lines = streamReader.ReadToEnd();
                streamReader.Close();
                return lines;
            }
        }
    }
}
