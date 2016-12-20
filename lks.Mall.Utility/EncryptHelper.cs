using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class EncryptHelper
    {
        public static string EntryptStr(this string str, string key = "coderush")
        {
            var des = DES.Create();
            var inputBytes = Encoding.UTF8.GetBytes(str);
            var keyBytes = Encoding.UTF8.GetBytes(key);
            SHA1 ha = new SHA1Managed();

            var hb = ha.ComputeHash(keyBytes);

            var skey = new byte[8];
            var sIv = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                skey[i] = hb[i];
            }

            for (int i = 8; i < 16; i++)
            {
                sIv[i - 8] = hb[i];
            }
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputBytes, 0, inputBytes.Length);
                    cs.FlushFinalBlock();
                    var ret = new StringBuilder();
                    foreach (var b in ms.ToArray())
                    {
                        ret.AppendFormat("{0:X2}", b);
                    }

                    return ret.ToString();
                }
            }
        }

        //private static char[] MixUp(string str)
        //{
        //    var timeStamp = Guid.NewGuid().ToString();
        //    var count=str.Length+
        //}
    }
}
