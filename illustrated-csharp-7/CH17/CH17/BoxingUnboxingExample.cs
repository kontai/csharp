namespace CH17;

public class BoxingUnboxingExample
{
    static void Main(string[] args)
    {
        int i = 10;
        object oi = i;  //裝箱
        Console.WriteLine($"i: {i}, oi: {oi}");
        i = 12;
        oi = 15;
        Console.WriteLine($"i: {i}, oi: {oi}");
        int j = (int)oi;    //拆箱(顯式轉換)
        double d = (double)oi;  //將一個值拆箱為非原始類型，拋出InvalidCastException異常
    }
}