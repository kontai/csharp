namespace CH17;

public class CheckExample
{
    static void Main(string[] args)
    {
        ushort sh = 2000;
        byte sb;

        sb = unchecked((byte)sh);   //大多數重要的位丟失了!
        Console.WriteLine($"sb: {sb}");

        sb = checked((byte)sh); //檢查是否會有溢位，有的話，拋出OverflowException異常
        Console.WriteLine($"sb: {sb}");

    }
}