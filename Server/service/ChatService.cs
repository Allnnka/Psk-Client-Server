using Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.service
{
    public class Chat
    {

        //String mynickname;
        String receiveNickname;
        String text;
        public Chat(String receiveNickname, String text)
        {
            this.receiveNickname = receiveNickname;
            this.text = text;
        }
        public override string ToString()
        {
            return string.Format("Message send to {0} | Text: {1}\n", receiveNickname, text);
        }
    }
    public class ChatService : IServiceModule
    {
        private Dictionary<string, List<Chat>> chatList = new Dictionary<string, List<Chat>>();

        public string AnswerCommand(string command)
        {
            if (command.Split()[1]== "msg")
            {
                if (chatList.ContainsKey(command.Split()[2]) && chatList[command.Split()[2]] != null)
                {
                    chatList[command.Split()[2]].Add(new Chat(command.Split()[3], command.Split()[4]));
                }
                else
                {
                    List<Chat> tmp = new List<Chat>();
                    tmp.Add(new Chat(command.Split()[3], command.Split()[4]));
                    chatList.Add(command.Split()[2], tmp);
                }
                return String.Format("Send message from {0} to {1}", command.Split()[2], command.Split()[3]);
            }
            else if (command.Split()[1] == "get")
            {
                if(!chatList.ContainsKey(command.Split()[2]) || chatList[command.Split()[2]] == null)
                {
                    return "Thre is no message for this user";
                }
                return string.Join(" ", chatList[command.Split()[2]].ToList());

            }
            return "Unknown command";
        }
    }
}
