using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share
{
    public static class FileClass
    {
        public static string FileToBase64(string path)
        {
            if (File.Exists(path))
            {
                byte[] bytes = File.ReadAllBytes(path);
                String file = Convert.ToBase64String(bytes);
                return file;
            }
            return "File does not exist";
        }
        public static string Base64ToFile(string path, string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);
            File.WriteAllBytes(path, bytes);
            return "File saved successfully";
        }
    }
}
