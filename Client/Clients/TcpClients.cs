using Share;
using System;
using System.Net.Sockets;
using System.Text;

namespace Client.Clients
{
    public static  class TcpClients
    {
        private static string getCommand()
        {
            Console.WriteLine("Wpisz komendę(ping lub send)");
            string command = Console.ReadLine();
            if (command.Contains("ping "))
            {
                return PingClass.Ping(int.Parse(command.Split()[1]), int.Parse(command.Split()[2]));
            }
            if(command.Contains("send "))
            {
                //return command + " " + FTP.FileToString(command.Split()[2]);
                return null;
            }
            else
            {
                Console.WriteLine("Opcji nie ma na liście!\n Wciśnij 1 żeby spróbować ponownie 0 - żeby wyjść");
                string command2 = Console.ReadLine();
                if (int.Parse(command2) == 1)
                {
                    getCommand();
                }
                return "0";
            }
        }

        public static void Start()
        {
            try
            {
                string server = "localhost";
                while (true)
                {
                    int port = 12346;
                    TcpClient client = new TcpClient(server, port);
                    string command = null;
                    NetworkStream stream = client.GetStream();
                    while (true)
                    {
                        command = getCommand();
                        if (command.Equals("0")) break;
                        //string message = PingClass.Ping(123);
                        byte[] data = Encoding.ASCII.GetBytes(command + Environment.NewLine);
                        var watch = System.Diagnostics.Stopwatch.StartNew();
                        Console.WriteLine($"Wysłane {command}");
                        int numOfResponse = int.Parse(command.Split()[1]);
                        for(int i = 0; i < numOfResponse; i++)
                        {
                            stream.Write(data, 0, data.Length);
                            byte[] response = new byte[256];
                            string responseStr = string.Empty;
                            int bytes;
                            do
                            {
                                bytes = stream.Read(response, 0, response.Length);
                                responseStr += Encoding.ASCII.GetString(response, 0, bytes);
                            } while (stream.DataAvailable);
                            Console.WriteLine("Odpowiedź: {0}", responseStr);
                        }
                        Console.WriteLine($"{command.Split()[0]} Time: " + watch.Elapsed);
                    }
                    client.Close();
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
