using CarEvent;

Car myCar = new Car("Zippy", 100, 20);
myCar.AboutToBlow += CarMessageFun;
myCar.Exploded += CarMessageFun;

for (int i = 0; i < 5; i++)
{
    myCar.Accelerate(20);
}

static void CarMessageFun(string msg)
{
    Console.WriteLine("*** Messae From Car Object ***");
    Console.WriteLine("=> {0}", msg);
    Console.WriteLine("******************************");
}