namespace CH13
{
    internal class ArrayInitializeExample
    {
        public static void Main()
        {
            //顯式類型數組
            int[] intArr1 = new int[] { 10, 20, 30, 40, 50 };
            //隱式類型數組
            var intArr2 = new[] { 10, 20, 30, 40, 50 };

            //顯式類型數組
            int[,] intArr3 = new int[,] { { 1, 2 }, { 3, 4 }, { 4, 5 }, { 5, 6 }, { 6, 7 }, { 7, 8 } };
            //隱式類型數組
            var intArr4 = new[,] { { 1, 2 }, { 3, 4 }, { 4, 5 }, { 5, 6 }, { 6, 7 }, { 7, 8 } };

            //顯式類型數組
            string[] sArr1 = new string[] { "lige", "liberty", "pursuit of happiness" };
            //隱式類型數組
            var sArr2 = new[] { "lige", "liberty", "pursuit of happiness" };

            //example
            var arr = new[,] { { 0, 1, 2 }, { 10, 11, 12 } };
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine($"Element [{i},{j}] is {arr[i, j]}");
                }
            }
        }
    }
}