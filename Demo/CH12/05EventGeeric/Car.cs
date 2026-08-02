namespace CarEvent;

public class Car
{
    // Internal state data.
    public int CurrentSpeed { get; set; }

    public int MaxSpeed { get; set; } = 100;
    public string PetName { get; set; }

    // Is the car alive or dead?
    private bool _carIsDead;

    // Class constructors.
    public Car()
    { }

    public Car(string name, int maxSp, int currSp)
    {
        CurrentSpeed = currSp;
        MaxSpeed = maxSp;
        PetName = name;
    }

    //省略此行
    //public delegate void CarEngineHandler(Object sender, CarEventArgs msg);

    //使用EventHandler泛型類
    public event EventHandler<CarEventArgs> AboutToBlow;

    public event EventHandler<CarEventArgs> Exploded;

    public void Accelerate(int delta)
    {
        if (_carIsDead)
        {
            Exploded?.Invoke(this, new CarEventArgs("Too late to accelerate. Car is dead!"));
            return;
        }
        else
        {
            CurrentSpeed += delta;
        }
        if (10 == MaxSpeed - CurrentSpeed)
        {
            AboutToBlow?.Invoke(this, new CarEventArgs("Slow down! You're going too fast!"));
        }
        if (CurrentSpeed >= MaxSpeed)
        {
            _carIsDead = true;
        }
        else
        {
            Console.WriteLine("CurrentSpeed= {0}", CurrentSpeed);
        }
    }
}

public class CarEventArgs : EventArgs
{
    public readonly string message;

    public CarEventArgs(string msg)
    {
        message = msg;
    }
}