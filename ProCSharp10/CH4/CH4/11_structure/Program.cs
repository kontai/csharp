using System;
using System.Security.Cryptography.X509Certificates;

internal struct Point
{
    //public int X;
    //public int Y;

    //Using Field Initializers in Structs (C# 10.0)
    //在C#10.0之前，結構體不能有無參數的建構函數，因此無法直接在定義中給欄位賦值。
    // C#10.0開始，結構體可以有無參數的建構函數，允許開發者自定義結構體的初始化行為。
    public int X=5;
      public int Y=5;


    //在c#10.0之前，結構體不能有無參數的建構函數，必須使用預設建構函數來初始化所有欄位。
    // C#10.0開始，結構體可以有無參數的建構函數，允許開發者自定義結構體的初始化行為。
    //但 , Point point=default; 仍然會使用預設建構函數來初始化欄位為0。
    //public Point()
    //{
    //    X = 1;
    //    Y = 1;
    //}

    // Constructor to initialize the fields
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Increment()
    {
        X++;
        Y++;
    }

    public void Decrement()
    {
        X--;
        Y--;
    }

    public void Display()
    {
        Console.WriteLine("X={0} , Y={1} ", X, Y);
    }
}

internal class Program
{
    private static void Summary()
    {
        // 情境 A：使用 new
        Point p1 = new Point();
        // 結果：會呼叫你的建構子，X = 5。

        // 情境 B：使用 default 關鍵字
        Point p2 = default;
        // 結果：**跳過**你的建構子，直接將記憶體填零。X = 0。

        // 情境 C：陣列初始化
        Point[] points = new Point[10];
        // 結果：這 10 個 Point 全部都是用 default 初始化的。
        // 也就是說，這 10 個點的 X 都是 0，而不是 5。
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("=====My First Structure======");
        Point p1 = new Point { X = 10, Y = 20 };
        p1.Display(); // 輸出: X=10 , Y=20
        p1.Increment();
        p1.Display(); // 輸出: X=11 , Y=21
        p1.Decrement();
        p1.Display(); // 輸出: X=10 , Y=20
        Console.WriteLine();

        Point p2;
        p2.X = 5;
        //p2.Display();   //X,Y都需要被初始化才能使用

        Console.WriteLine("=====Create Structure======");
        Console.WriteLine();
        Point p3 = new Point();
        p3.Display();   // using default constructor, output: X=0 , Y=0
        Console.WriteLine();

        Console.WriteLine("=====Custom Structure======");
        Point p4 = new Point(15, 25);
        p4.Display();   // using parameterized constructor, output: X=15 , Y=25

        Console.WriteLine("=====default Structure======");
        Point p5 = default;
        p5.Display();

        Console.WriteLine("=====another default Structure======");
        Point p6 = default(Point);
        p5.Display();
    }
}