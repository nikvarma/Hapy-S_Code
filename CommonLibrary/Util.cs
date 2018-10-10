using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CommonLibrary
{
    public static class Util
    {
        public static string ServerPath(string name)
        {
            return System.Web.Hosting.HostingEnvironment.MapPath("~/"+ name);
        }

        public static bool IsFileExists(string filename, bool ifNoFileCreate = false)
        {
            if (ifNoFileCreate)
            {
                File.Create(ServerPath(filename));
            }
            return File.Exists(ServerPath(filename));
        }

        public static bool IsDirExists(string filename, bool ifNoDirCreate = false)
        {
            if (ifNoDirCreate)
            {
                Directory.CreateDirectory(ServerPath(filename));
            }
            return Directory.Exists(ServerPath(filename));
        }

        public static string GenerateRandHashToken()
        {
            string randString = GenerateRadAlphaNumaric<string>(0, 50, 20, false);
            StringBuilder hashToken = new StringBuilder();
            foreach (var item in GetHash(randString))
            {
                hashToken.Append(item.ToString());
            }
            return hashToken.ToString();
        }

        public static byte[] GetHash(string hashString)
        {
            HashAlgorithm hashAlgorithm = MD5.Create();
            return hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(hashString));
        }

        public static T GenerateRadAlphaNumaric<T>(int minValue, int maxValue, int length = 2, bool isOnlyNumValue = false)
        {
            string randText;
            string aToz = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rand = new Random();
            if (isOnlyNumValue)
            {
                randText = rand.Next(minValue, maxValue).ToString("D" + length);
            }
            else
            {
                randText = new string(Enumerable.Repeat(aToz, maxValue).Select(x => x[rand.Next(x.Length -1)]).ToArray());
            }
            return (T)Convert.ChangeType(randText, typeof(T));
        }
    }
}
