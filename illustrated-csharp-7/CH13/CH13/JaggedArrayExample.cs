/*
 *不規則陣列(Jagged Array)
 */

using System.Collections;

namespace CH13
{
    internal class JaggedArrayExample
    {
        private static void Main(string[] args)
        {
            //陳述式中進行宣告。 每個包含的陣列會在後續陳述式中建立。
            int[][] Arr = new int[3][]; //實例化頂層數組
            Arr[0] = new int[] { 10, 20, 30 }; //實例化子數組
            Arr[1] = new int[] { 40, 50, 60, 70 }; //實例化子數組
            Arr[2] = new int[] { 80, 90, 100, 110, 120 }; //實例化子數組

            //在一個陳述式中進行宣告和初始化。 混合使用不規則陣列與多維陣列是可行的。
            int[][] arr0 =
            [
                [1, 3, 5, 7, 9],
                [0, 2, 4, 6],
                [11, 22]
                           ];
            //與上例相同
            //int[][] arr0 = new int[3][]
            //{
            //    [1, 3, 5, 7, 9],
            //    [0, 2, 4, 6],
            //    [11, 22]

            //};

            int[][,] Arr02 = new int[3][,];
            Arr02 =
            [
                new int[,]
                {
                    { 1, 2, 3 },
                    { 10, 20, 30 }
                },
                new int[,]
                {
                    { 30, 40, 50, 60 },
                    { 300, 400, 500, 600 }
                },
                new int[,]
                {
                    { 60, 70, 80, 90 },
                    { 600, 700, 800, 900 }
                }
            ];
            for (int i = 0; i < Arr02.GetLength(0); i++)
            {
                for (int j = 0; j < Arr02[i].GetLength(0); j++)
                {
                    for (int k = 0; k < Arr02[i].GetLength(1); k++)
                    {
                        Console.WriteLine($"[{i}][{j},{k}]={Arr02[i][j, k]}");
                    }
                }
            }

            foreach (var i in Arr02)
            {
                Console.WriteLine(i.IsReadOnly);
                foreach (var j in i.AsParallel())
                {
                    Console.WriteLine(j);
                }
            }
            //與上例相同
            /*
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
            */

        }
    }
}