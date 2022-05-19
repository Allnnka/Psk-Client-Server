using Client.Clients;
using Client.command;
using Share;
using System;

namespace Client.util
{
    public class CommandUtil
    {
        public static void getCommand(IClient client)
        {
            Console.WriteLine("Wpisz komendę(ping, chat lub file)");
            string command = Console.ReadLine();
            if (command.Contains("ping "))
            {
                Ping.Command(client,command);
            }
            else if (command.Contains("chat "))
            {
                ChatCommand.Msg(client, command);
            }
            else
            {
                Console.WriteLine("Wprowadzono niepoprawną komendę {0}",command);
            }
            getCommand(client);
        }
    }
}
