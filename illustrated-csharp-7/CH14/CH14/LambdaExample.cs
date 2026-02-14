namespace CH14;

public class LambdaExample
{
    private static void Main(string[] args)
    {
        MyDel del = delegate (int x) { return x + 1; }; //匿名方法
        MyDel le1 = (int x) => { return x + 1; }; //Lambda表达式
        MyDel le2 = (x) => { return x + 1; }; //編譯器自動判斷x型別
        MyDel le3 = x => { return x + 1; }; //只有一個參數時，可省略參數列表的圓括號
        MyDel le4 = x => x + 1; //如果只有一個回傳值，可只設為一行要回傳的語句

        Console.WriteLine($"{del(12)}");
        Console.WriteLine($"{le1(12)}");
        Console.WriteLine($"{le2(12)}");
        Console.WriteLine($"{le3(12)}");
        Console.WriteLine($"{le4(12)}");
    }

    private delegate int MyDel(int x);
}