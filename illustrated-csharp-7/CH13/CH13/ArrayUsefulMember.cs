namespace CH13
{
    internal class ArrayUsefulMember
    {
        public static void PrintArray(int[] a)
        {
            foreach (var x in a)
                Console.Write($"{x} ");

            Console.WriteLine("");
        }

        private static void Main()
        {
            int[] arr = new int[] { 15, 20, 5, 25, 10 };
            PrintArray(arr);
            Array.Sort(arr);
            PrintArray(arr);
            Array.Reverse(arr); PrintArray(arr);
            Console.WriteLine();
            Console.WriteLine($"Rank = {arr.Rank}, Length = {arr.Length}");
            Console.WriteLine($"Getlength(0) ={arr.GetLength(0)}");
            Console.WriteLine($"GetType() = {arr.GetType()}");
        }
    }
}