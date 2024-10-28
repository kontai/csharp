using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_string
{
    internal class Program
    {
        static void Main2(string[] args)
        {
            Test01();
            //Test02();
            //Test03();
        }

        static void Test01()
        {
            string str1 = "abcde@def.com  ";

            //IndexOf
            var res1 = str1.IndexOf("@");
            var str2 = string.Format($"str1 indexOf(@) = {res1} ");
            Console.WriteLine(str2);

            //Substring
            var str3 = str1.Substring(0, 5);
            Console.WriteLine(str3);

            //Length
            Console.WriteLine("str1的長度是:" + str1.Length);

            //Replace
            Console.WriteLine("替換後的字串是:" + str1.Replace("abc", "ABC"));

            //Split 
            var str4 = str1.Split('@');
            foreach (var se in str4)
            {
                Console.WriteLine(se);
            }
            Console.WriteLine("Split後的字串是:" + string.Join(",", str1.Split('@')));

            //Trim 
            Console.WriteLine("Trim後的字串是:{0}----移除前後空白", str1.Trim());

            //ToUpper 
            Console.WriteLine("ToUpper後的字串是:" + str1.ToUpper());

        }

        static void Test02()
        {
            //string format
            string str1 = "abcde@def.com";
            Console.WriteLine("str1  = {0} ", str1);
            Console.WriteLine($"str1 = {str1} ");
            Console.WriteLine(string.Format($"str1 = {str1} "));

        }

        static void Test03()
        {
            int i = 123456;
            Console.WriteLine("{0:C}", i); // ￥123,456.00
            Console.WriteLine("{0:D}", i); // 123456
            Console.WriteLine("{0:E}", i); // 1.234560E+005
            Console.WriteLine("{0:F}", i); // 123456.00
            Console.WriteLine("{0:F1}", i); // 123456.0
            Console.WriteLine("{0:G}", i); // 123456
            Console.WriteLine("{0:N}", i); // 123,456.00
            Console.WriteLine("{0:P}", i); // 12,345,600.00 %
            Console.WriteLine("{0:X}", i); // 1E240
        }
    }
}
