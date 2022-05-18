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
            Console.WriteLine("Wpisz komendę(ping lub ...)");
            string command = Console.ReadLine();
            if (command.Contains("ping "))
            {
                Ping.Command(client,command);
            }
            if (command.Contains("send "))
            {
                
            }
            else
            {
                Console.WriteLine("Opcji nie ma na liście!\n Wciśnij 1 żeby spróbować ponownie 0 - żeby wyjść");
                string command2 = Console.ReadLine();
                if (int.Parse(command2) == 1)
                {
                    getCommand(client);
                }
                
            }
        }
    }
}
