// 導入 System.Runtime.Intrinsics.X86 命名空間
//using System.Runtime.Intrinsics.X86;

// 定義 TestProject 命名空間
namespace TestProject
{
    // 定義一個泛型委派 Func，代表一個方法，它接受兩個參數 p1 和 p2，並返回 TR 類型的值
    delegate TR Func<T1, T2, TR>(T1 p1, T2 p2);

    // 定義一個類別 Simple
    class Simple
    {
        // 定義一個靜態方法 PrintString，接受兩個 int 參數 v1 和 v2，並返回一個 string 值
        public static string PrintString(int v1, int v2)
        {
            // 將 v1 和 v2 相加，並將結果轉換為 string 類型
            int total = v1 + v2;
            return total.ToString();
        }
    }

    // 定義一個類別 Demo03
    public class Demo03
    {
        // 定義一個靜態方法 Main，作為程式的入口點
        static void Main(string[] args)
        {
            // 建立一個 Func 委派實例，指向 Simple.PrintString 方法
            var del = new Func<int, int, string>(Simple.PrintString);
            string str = new Func<int, int, string>(Simple.PrintString)(29, 10);
            // 呼叫委派實例，並將結果輸出到主控台
            System.Console.WriteLine($"{del(20, 10)}");
        }
    }
}