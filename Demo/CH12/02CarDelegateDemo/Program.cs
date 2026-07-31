namespace CarDelegate;

internal class Program
{
    public static void Main()
    {
        Car car = new Car("Zippy", 100, 50);
        //car.RegisterWithCarEngine(new Car.CarEngineHandler(CarMessageFun));
        //Moethod Group Conversion
        car.RegisterWithCarEngine(CarMessageFun);

        //Car.CarEngineHandler handler2 = new Car.CarEngineHandler(CarMessageFun2);
        Car.CarEngineHandler handler2 = CarMessageFun2;
        car.RegisterWithCarEngine(handler2);

        //第一次，所有都會執行
        Console.WriteLine("*** Mutiple Delegates ***");
        for (int i = 0; i < 5; i++)
        {
            car.Accelerate(20);
        }
        Console.WriteLine();

        car.UnRegisterWithCarEngine(handler2);
        //第二次，只有CarMessageFun
        for (int i = 0; i < 5; i++)
        {
            car.Accelerate(20);
        }
    }

    private static void CarMessageFun(string msg)
    {
        Console.WriteLine("*** Messae From Car Object ***");
        Console.WriteLine("=> {0}", msg);
        Console.WriteLine("******************************");
    }

    private static void CarMessageFun2(string msg)
    {
        //轉成全大寫
        Console.WriteLine("=> {0}", msg.ToUpper());
    }
}