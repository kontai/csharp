namespace CH14;

public class AnonymousDelegateExample
{
    private delegate int Add20(int abc);

    private delegate void SomeDel(int x);

    private static void Main(string[] args)
    {
        //匿名方法:如果方法只有調用一次,可以用匿名方法。
        Add20 a = delegate (int x) { return x + 20; };
        Console.WriteLine(a(10));
        Console.WriteLine(a(10));

        int x = 10;     //外部參數
        SomeDel SDel = delegate
        {
            Console.WriteLine("省略參數列表");
            Console.WriteLine($"方法補獲的參數:{x}");  //於匿名參數內部調用外部參數。(方法捕獲)
        };
        SDel(0);
    }
}