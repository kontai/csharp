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

            //arr1 = new int[5];        //聲明一維數組
            //arr1 = new int[] { 1, 2, 3, 4, 5, 6 };      //顯式初始化

            arr2 = new int[3, 4];
            arr2 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 10, 20, 30 } };
            arr3 = new int[1, 2, 3];

            //快捷語法
           / int[] arr4 = { 1, 2, 3, 4, 5 };
            int[,] arr5 = { { 1, 2, 3 }, { 4, 5, 6 }, { 10, 20, 30 } };

            for (int i = 0; i < arr1.Length; i++ii)
            {
                arr1[i] = i * 10;
            }
            */

            for (int i = 0; i < arr1.Length; i++)
            {
                Console.WriteLine($"Value of element {i} = {arr1[i]}");
            }
        }
    }
}