using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetObject(new { Id = 1, Name = "andy" });
            //Console.ReadKey();

            WebClient client = new WebClient();
            string res = client.DownloadString("https://www.baidu.com/");

            Regex regex = new Regex("href=\"([^#]+?)\"");
            MatchCollection matches = regex.Matches(res);
            foreach (Match item in matches)
            {
                Console.WriteLine(item.Groups[1].Value);
            }
            Console.ReadKey();
        }

        static void GetObject(object obj)
        {
            Type o = obj.GetType();
            foreach (var item in o.GetProperties())
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.GetValue(obj));
            }
        }
    }
}
