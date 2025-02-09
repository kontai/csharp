using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    delegate int Transformer(int x);

    internal class Demo_delegate
    {
        static void Main(string[] args)
        {
            int[] x = { 1, 2, 3 };
            Transform(x, square);
            foreach (int i in x)
            {
                Console.WriteLine(i + " ");
            }
        }

        public static int square(int x) => x * x;
        public static int cube(int x) => x * x * x;

        public static void Transform(int[] x, Transformer t)
        {
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = t(x[i]);
            }
        }
    }
}