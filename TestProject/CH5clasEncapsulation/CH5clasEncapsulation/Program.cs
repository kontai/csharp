Car car1 = new Car("Tesla", 20, new(10, 20));
car1.ShowStatus();

public struct Location
{
    public int X;
    public int Y;

    public Location(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public class Car
{
    private readonly string _petName;
    private readonly double _currSpeed;
    private Location _loc;

    public Car()
    {
        _loc = new Location(10, 20);
        Console.WriteLine("default constractor is called.");
    }

    public Car(string petName, double currSpeed, Location loc)
    {
        this._petName = petName;
        this._currSpeed = currSpeed;
        this._loc = loc;
    }

    public void ShowStatus()
    {
        Console.WriteLine("Car name is {0}", _petName);
        Console.WriteLine("Car speed is {0}", _currSpeed);
        Console.WriteLine("Car location is {0}", _loc.X);
    }
}