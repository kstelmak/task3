using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public class Security
    {
        public static string ConvertToHex(byte[] data)
        {
            StringBuilder hexData = new StringBuilder(data.Length * 2);
            foreach (byte b in data)
            {
                hexData.AppendFormat("{0:x2}", b);
            }
            return hexData.ToString();
        }

        public static string CreateStrongRandomKey()
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] keyData = new byte[128];
            rng.GetBytes(keyData);
            return ConvertToHex(keyData);
        }

        public static string CreateHMAC(string key, string computerMove)
        {
            using HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
            byte[] hashData = hmac.ComputeHash(Encoding.UTF8.GetBytes(computerMove.ToString()));
            return ConvertToHex(hashData);
        }
    }
}
