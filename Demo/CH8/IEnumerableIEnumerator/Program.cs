using System.Collections;

Car cars = new Car();

foreach (Car car in cars)
{
    Console.WriteLine(car);
}

internal class Car : IEnumerable
{
    private Car[] cars = new Car[4];
    private string v1;
    private int v2;

    public string PetName { get; set; }
    public int MaxSpeed { get; set; }

    public Car()
    {
        cars[0] = new Car("Rusty", 100);
        cars[1] = new Car("Clunker", 50);
        cars[2] = new Car("Zippy", 201);
        cars[3] = new Car("Fred", 150);
    }

    public Car(string petname, int maxspeed)
    {
        PetName = petname;
        MaxSpeed = maxspeed;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return cars.GetEnumerator();
    }

    public override string? ToString()
    {
        return $"Car PetName: {PetName}, MaxSpeed: {MaxSpeed}";
    }
}