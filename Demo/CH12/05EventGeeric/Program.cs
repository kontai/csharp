using CarEvent;

Car myCar = new Car("Zippy", 100, 20);
myCar.AboutToBlow += CarMessageFun;
myCar.Exploded += CarMessageFun;

for (int i = 0; i < 5; i++)
{
    myCar.Accelerate(20);
}

static void CarMessageFun(Object sender,CarEventArgs e)
{
    Console.WriteLine($"{sender}  says: {e.message}");
    if(sender is Car car)
    {
        Console.WriteLine($"The current speed is {car.CurrentSpeed}");
    }
}

