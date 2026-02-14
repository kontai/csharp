using System.Diagnostics;

/*
 * 使用返回Task<int>對象的方法
 * 
 */
namespace CH21.異步方法
{
    internal class TaskT
    {
        public static void Main(string[] args)
        {
            Task<int> value = DoAsyncStuff.CalculateSuuAsync(5, 6);
            Console.WriteLine("Value: {0}", value.Result);  //Result:異步處理結果


            DoAsyncStuff.CalculateSuuAsync(5, 6);   //"調用並忘記"
            Thread.Sleep(200);
            Console.WriteLine("Program Exiting.");
        }
    }

    internal static class DoAsyncStuff
    {
        public static async Task<int> CalculateSuuAsync(int i1, int i2)
        {
            int sum = await Task.Run(() => GetSum(i1, i2));
            //Thread.Sleep(1000);
            return sum;
        }

        static int GetSum(int i1, int i2)
        {
            return i1 + i2;
        }
    }
}