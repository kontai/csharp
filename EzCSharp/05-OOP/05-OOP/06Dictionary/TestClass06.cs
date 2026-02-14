using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _05_OOP._05Dictionary
{
    internal class TestClass06
    {
        static void Main06(string[] args)
        {
            //字典 I
            Dictionary<string, int> dic1 = new Dictionary<string, int>();
            dic1.Add("k01", 20);
            dic1.Add("k02", 30);
            dic1.Add("k03", 40);
            dic1.Add("k04", 50);

            //字典 II
            Dictionary<string, int> dic2 = new Dictionary<string, int>()
            {
                ["k01"] = 20,
                ["k02"] = 30,
                ["k03"] = 40,
                ["k04"] = 50
            };
            
            showDictionary(dic2);

        }

        static void showDictionary(Dictionary<string, int> dict)
        {
            foreach (var key in dict.Keys)
            {
                Console.WriteLine(string.Format($"{key}:{dict[key]}"));
            }
        }
    }
}
