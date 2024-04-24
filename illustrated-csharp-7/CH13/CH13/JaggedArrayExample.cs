using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *不規則陣列(Jagged Array)
 */

namespace CH13
{
    internal class JaggedArrayExample
    {
        private static void Main(string[] args)
        {
            int[][] Arr = new int[3][]; //實例化頂層數組
            Arr[0] = new int[] { 10, 20, 30 }; //實例化子數組
            Arr[1] = new int[] { 40, 50, 60, 70 }; //實例化子數組
            Arr[2] = new int[] { 80, 90, 100, 110, 120 }; //實例化子數組

            //交錯數組中的子數組
            int[][,] Arr2;
            Arr2 = new int[3][,];
            Arr2[0] = new int[,]
            {
                { 1, 2, 3 },
                { 10, 20, 30 }
            };
            Arr2[1] = new int[,]
            {
                { 30, 40, 50, 60 },
                { 300, 400, 500, 600 }
            };
            Arr2[2] = new int[,]
            {
                { 60, 70, 80, 90 },
                { 600, 700, 800, 900 }
            };

            for (int i = 0; i < Arr2.GetLength(0); i++)
            {
                for (int j = 0; j < Arr2[i].GetLength(0); j++)
                {
                    for (int k = 0; k < Arr2[i].GetLength(1); k++)
                    {
                        Console.WriteLine($"[{i}][{j},{k}]={Arr2[i][j, k]}");
                    }
                }
            }
        }
    }
}
