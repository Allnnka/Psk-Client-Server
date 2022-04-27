using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.listener
{
    public class RS232Listener : IListener
    {
        public void Start(CommunicatorD onConnect)
        {
            Console.WriteLine("RS232 listener start");
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
