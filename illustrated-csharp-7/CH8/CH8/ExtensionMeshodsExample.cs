using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CH8
{
    internal sealed class MyData
    {
        private double D1, D2, D3;

        public MyData(double d1, double d2, double d3)
        {
            D1 = d1; D2 = d2; D3 = d3;
        }

        public double Sum()
        {
            return D1 + D2 + D3;
        }
    }

    internal static class ExtensionMethods
    {
        public static double Average(this MyData data)  //擴展方法 ， 必須是靜態類static class , 靜態方法static method ,和this 闗鍵字
        {
            return data.Sum() / 3;
        }
    }

    internal class ExtensionMeshodsExample
    {
        public static void Main(string[] args)
        {
            MyData md = new MyData(1, 2, 3);
            Console.WriteLine($"Sum:    {md.Sum()}");

            //without extension methods
            Console.WriteLine("Average: {0}", ExtensionMethods.Average(md));

            //with extension methods
            Console.WriteLine("Average: {0}", md.Average());
        }
    }
}