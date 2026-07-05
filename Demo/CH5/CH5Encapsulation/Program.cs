//using static System.Console;

using Point = MyPointNS.Point;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

//Car myCar = new Car();
//myCar.PetName = "Thunder";
//myCar.Speed = 159;
//myCar.Color = "Blue";
//myCar.show(20.0f);
//Point p1 = new();
//Console.WriteLine(p1.xPos);

//物件初始設定式(Object Initializer)
Car myCar2 = new Car { PetName = "Thunder", Speed = 159 };
//myCar2.Speed = 5;   //只讀屬性,只能在物件初始化時設定
Console.WriteLine(Car.constNum);    //const 常量成員，默認是靜態屬性

string foo = "Foo";
string bar = "Bar";
string foobar = $"{foo} {bar}";
Console.WriteLine(foobar);
Console.WriteLine(SayHello());


namespace MyPointNS
{
    readonly ref struct Point
    {
        public Point()
        {
        }
        readonly public int xPos = 10;
        readonly public int yPos = 20;

    }

}
class Car
{
    public const int constNum = 5;  //在編譯時，會將constNum 轉換為常數值
    public static readonly int constNum2 = 8; //靜態屬性，只能在宣告時或靜態建構函數中設定
    public string PetName { get; set; }
    public int Speed { get; init; } //只讀屬性,只能在物件初始化時設定
    public static string Color => "Yellow";
    public static int NumberOfCar { get; set; }
    public Car()
    {
        Console.WriteLine("無參構造函數調用");
    }

    static Car()
    {
        Console.WriteLine("靜態建構函數調用");
        constNum2 = 39;
    }

    public Car(string petName, int speed)
    {
        PetName = petName;
        Speed = speed;
    }

    public void show(float speed)
    {
        //Speed = (int)speed;
        string Quality = this switch
        {
            { Speed: > 100, PetName.Length: > 0 } => "Fast",
            { Speed: > 50, PetName.Length: > 0 } => "Safe Drive",
            _ => "Slow"
        };
        Console.WriteLine("Quality:{0}", Quality);

        Console.WriteLine($"PetName: {PetName}, Speed: {Speed}, Color: {Color}");
    }

}