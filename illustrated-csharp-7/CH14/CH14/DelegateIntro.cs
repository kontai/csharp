namespace CH14;

internal delegate void MyDel(int value); // 聲明委派型別

internal class DelegateIntro
{
    private void PrintLow(int value)
    {
        Console.WriteLine($"{value} - Low Value");
    }

    private void PrintHigh(int value)
    {
        Console.WriteLine($"{value} - High Value");
    }

    private static void Main(string[] args)
    {
        var intro = new DelegateIntro();
        MyDel del; //聲明委派變數

        //創建隨機整數生鈽器對象，並得到一個0到99之間的隨機整數
        var rand = new Random();
        var randomValue = rand.Next(99);

        //創建一僤包含PrintLow或PrintHigh的委派對象，並將其賦值給del變量
        del = randomValue < 50
            ? new MyDel(intro.PrintLow)
            : new MyDel(intro.PrintHigh);
        del(randomValue);



    }
}