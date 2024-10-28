using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_string
{
    internal class Array
    {
        static void Main(string[] args)
        {
            int[] arr={1,2,3,4,5,6,7,8,9,10};
            int[] arr2 = arr;
            arr[0] += 4;
            foreach (var i in arr)
            {
                Console.Write("{0,3:D}",i);
            }

            Console.WriteLine("");

            Console.WriteLine("..................................");
            foreach (var i in arr2)
            {
                Console.Write("{0,3:D}",i);
            }
            Console.WriteLine("");
            Console.WriteLine("..................................");

        }
    }
}
