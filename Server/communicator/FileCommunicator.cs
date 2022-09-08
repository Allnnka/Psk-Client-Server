using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server.communicator
{
    public class FileCommunicator : ICommunicator
    {
        private string fullPath;
        string clientPath = @"../../../File/Client/";


        public FileCommunicator(string fullPath)
        {
            this.fullPath = fullPath;
        }

        public void Start(CommandD onCommand, CommunicatorD onDisconnect)
        {
            using (StreamReader streamReader = new StreamReader(fullPath))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string fileName = fullPath.Split('\\')[1];
                    File.WriteAllText(clientPath + fileName, onCommand(line));
                }
                streamReader.Close();
            }
            
        }

        public void Stop()
        {
            Console.WriteLine("File communicator stop");
        }
    }
}
