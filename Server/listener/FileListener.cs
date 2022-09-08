using Server.communicator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.listener
{
    public class FileListener : IListener
    {
        FileSystemWatcher fileWatcher;
        CommunicatorD onConnect;
        string serverPath = @"../../../File/Server";
        public FileListener()
        {
            if (!Directory.Exists(serverPath))
            {
                Directory.CreateDirectory(serverPath);
            }
            fileWatcher = new FileSystemWatcher(serverPath);
        }
        public void Start(CommunicatorD onConnect)
        {
            Console.WriteLine("File listener start");
            this.onConnect = onConnect;
            fileWatcher.NotifyFilter = NotifyFilters.LastWrite;
            fileWatcher.Filter = "*.txt";
            fileWatcher.Changed += new FileSystemEventHandler(OnChanged);
            fileWatcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            onConnect(new FileCommunicator(e.FullPath));
        }

        public void Stop()
        {
            Console.WriteLine("File listener stop");
            fileWatcher.Dispose();
        }
    }
}
