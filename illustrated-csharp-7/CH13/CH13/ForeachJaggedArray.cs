using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH13
{
    internal class ForeachJaggedArray
    {
        private static void Main(string[] args)
        {
            int total = 0;
            int[][] arr1 = new int[2][];
            arr1 =
            [
                new int[] { 10, 11 },
                new int[] { 12, 13, 14 }
            ];

            foreach (var array in arr1)
            {
                Console.WriteLine("Starting new array");
                foreach (var item in array)
                {
                    total += item;
                    Console.WriteLine($" Item: {item},Current Total: {total}");
                }
            }
        }
    }
}