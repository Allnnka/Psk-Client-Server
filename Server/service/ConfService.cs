using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.service
{
    public class ConfService : IServiceModule
    {
        public string AnswerCommand(string command)
        {
            if(command.Split()[1] == "start-service")
            {

            }
            else if(command.Split()[1] == "stop-service")
            {

            }
            else if (command.Split()[1] == "start-medium")
            {

            }
            else if (command.Split()[1] == " stop-medium")
            {

            }
            return "Command not found";
        }
    }
}
