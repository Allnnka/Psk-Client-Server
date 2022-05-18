using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Clients
{
    public abstract class IClient
    {
        //Metode która wyśle i odbierze
        public abstract string QA(string command);
    }
}
