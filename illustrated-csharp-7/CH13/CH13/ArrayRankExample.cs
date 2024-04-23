using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH13
{
    internal class ArrayRankExample
    {
        public static void Main()
        {
            int[] arr1;     //1維數組
            int[,] arr2;    //2維數組
            int[,,] arr3;   //3維數組
            arr1 = new int[5];
            arr2 = new int[2, 3];
            arr3 = new int[1, 2, 3];

            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = i * 10;
            }

            for (int i = 0; i < arr1.Length; i++)
            {
                Console.WriteLine($"Value of element {i} = {arr1[i]}");
            }
        }
    }
}
