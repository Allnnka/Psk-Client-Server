using Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.service
{
    public class FileService : IServiceModule
    {
        string folder = "FileFilder";
        public string AnswerCommand(string command)
        {
            if(command.Split()[1] == "dir")
            {
                return folder;
            }
            else if (command.Split()[1] == "get")
            {
                return FileClass.FileToBase64(folder + "\\" + command.Split()[2]);
            }
            else if (command.Split()[1] == "put")
            {
                return FileClass.Base64ToFile(folder + "\\" + command.Split()[2], command.Split()[3]);
            }
            return "Command not found";
        }

    }
}
