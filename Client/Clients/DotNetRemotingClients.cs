using Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Clients
{
    public class DotNetRemotingClients : IClient
    {
        DotNetRemotingClass dotNetRemotingClass;

        public DotNetRemotingClients(DotNetRemotingClass dotNetRemotingClass)
        {
            this.dotNetRemotingClass = dotNetRemotingClass;
        }
    
        public override string QA(string command)
        {
            return dotNetRemotingClass.Command(command);
        }
    }
}
