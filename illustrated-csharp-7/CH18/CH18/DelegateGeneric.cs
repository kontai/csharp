namespace CH18;

public delegate TR Func<T1, T2, TR>(T1 p1, T2 p2); //泛型委托

class Simple
{
    public static string PrintString(int p1, int p2) //方法匹配委托
    {
        int total = p1 + p2;
        return total.ToString();
    }
}
public class DelegateGeneric
{
    static void Main(string[] args)
    {
        var myDel = new Func<int, int, string>(Simple.PrintString); //創建委托實例
        Console.WriteLine($"Total: {myDel(15, 13)}");
    }
}