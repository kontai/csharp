namespace CarDelegate;

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

    public delegate void CarEngineHandler(string msgForCaller);

    private CarEngineHandler _carEngine;

    //subscription
    public void RegisterWithCarEngine(CarEngineHandler handler)
    {
        _carEngine += handler;  //Multicast delegate

        //_carEngine=Delegate.Combine(_carEngine, handler) as CarEngineHandler;
    }

    //unsubscription
    public void UnRegisterWithCarEngine(CarEngineHandler handler)
    {
        _carEngine -= handler;
        //_carEngine=Delegate.Remove(_carEngine, handler) as CarEngineHandler;
    }

    public void Accelerate(int delta)
    {
        if (_carIsDead)
        {
            _carEngine?.Invoke("Too late to accelerate. Car is dead!");
            return;
        }
        else
        {
            CurrentSpeed += delta;
        }
        if (10 == MaxSpeed - CurrentSpeed)
        {
            _carEngine?.Invoke("Slow down! You're going too fast!");
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