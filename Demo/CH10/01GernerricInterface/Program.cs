Car car1 = new Car("Zippy", 150);
Car car2 = new Car("Rusty", 100);
Console.WriteLine("car1 > car2? {0}", car1.CompareTo(car2));

internal class Car : IComparable<Car>
{
    public string PetName { get; set; }
    public int MaxSpeed { get; set; }

    public Car()
    {
    }

    public Car(string petName, int maxSpeed)
    {
        PetName = petName;
        MaxSpeed = maxSpeed;
    }

    public int CompareTo(Car? other)
    {
        if (this.MaxSpeed > other.MaxSpeed) return 1;
        if (this.MaxSpeed < other.MaxSpeed) return -1;
        return 0;
    }
}