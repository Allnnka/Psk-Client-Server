using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share
{
    public static class PingClass
    {
        public static string Ping(int num,int size)
        {
            return $"ping {num} {size}\n";
        }
        private static string RandomString(int size)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, size).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string Pong(string command)
        {
            string[] tab = command.Split();
            string response = "pong ";
            return $"{response} {int.Parse(tab[1])} {RandomString(int.Parse(tab[2]))}\n";
        }
    }
}
