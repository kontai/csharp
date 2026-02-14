using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CH7
{
    internal class StaticConstractorExample
    {
        public static void Main()
        {
            RandomNumberClass a = new RandomNumberClass();
            RandomNumberClass b = new RandomNumberClass();

            Console.WriteLine("Next Random # : {0}", a.GetRandomNumber());
            Console.WriteLine($"Next Random # : {b.GetRandomNumber()}");

        }
    }

    class RandomNumberClass
    {
        private int number;
        private static Random RandomKey;        //私有静态字段        
        static RandomNumberClass()              //静态构造函数
        {
            Console.WriteLine("static constructor is called");
            RandomKey = new Random();           //初始化 RandomKey

            //無法訪問非靜態成員。
            //number = 0;

        }
        public int GetRandomNumber()
        {
            return RandomKey.Next();
        }
    }
}
