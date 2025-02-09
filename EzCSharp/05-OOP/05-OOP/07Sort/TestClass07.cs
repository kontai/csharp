using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_OOP._07Sort
{
    internal class TestClass07
    {
        static void Main07(string[] args)
        {
            /*
            int[] arr = { 1000, 2000, 4000, 3000, 5000 };
            Array.Sort(arr);
            foreach (var i in arr)
            {
                Console.WriteLine(i);
            }
            */

            course c1 = new course("c#", 9000);
            course c2 = new course("java", 6000);
            course c3 = new course("c++", 7000);
            course c4 = new course("python", 8000);

            List<course> list= new List<course>() { c1, c2, c3, c4 };
            list.Sort();
            //list.Sort((x,y)=>x.Price.CompareTo(y.Price).CompareTo(y.Price));
            Console.WriteLine(list.ToString());
            list.ForEach(c=>c.showInfo());

        }

    }
}
