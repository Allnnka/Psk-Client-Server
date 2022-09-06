using Server.listener;
using Server.service;
using System;
using System.Collections.Generic;

namespace Server
{
    class Server
    {
        Dictionary<string, IServiceModule> services = new Dictionary<string, IServiceModule>();
        List<IListener> listeners = new List<IListener>();
        List<ICommunicator> communicators = new List<ICommunicator>();

        void AddCommunicator(ICommunicator communicator)
        {
            communicators.Add(communicator);
            communicator.Start(new CommandD(Answer), RemoveCommunicator);
        }
        private string Answer(string command)
        {
            if (command != null)
            {
                string serviceName = command.Split()[0];
                if (services.ContainsKey(serviceName))
                    return services[serviceName].AnswerCommand(command);
              
                return "Services is unavailable.";
            }
            return "Command was null!";
        }
        void RemoveCommunicator(ICommunicator communicator)
        {
            var cm = communicators.Find(x => x.Equals(communicator));
            cm.Stop();
            
            Console.WriteLine("Removed communicator!");
        }

        void AddListener(IListener listener)
        {
            listeners.Add(listener);
            listener.Start(new CommunicatorD(AddCommunicator));
        }
        void Start()
        {
            for (int i = 0; i < listeners.Count; i++)
                listeners[i].Start(new CommunicatorD(AddCommunicator));
        }
        public void AddServiceModule(string command, IServiceModule serviceModule)
        {
            services.Add(command, serviceModule);
        }

        static void Main()
        {        
            var server = new Server();
            server.AddServiceModule("ping", new PingPongService());
            server.AddServiceModule("chat", new ChatService());
            server.AddServiceModule("file", new FileService());
            server.Start();
            server.AddListener(new TCPListener());
            server.AddListener(new UDPListener());
            server.AddListener(new RS232Listener());
            while (true) { }
        }
    }
}
