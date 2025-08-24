MyCar myCar= new("Toyota", "Corolla", "Blue");
Car car = new("Toyota", "Corolla", "Blue");




record class Car
{
    public string Made { get; init; }
    public string Model { get; init; }
    public string Color { get; init; }

    public Car(string made, string model, string color)
    {
        Made = made;
        Model = model;
        Color = color;
    }
}

record MyCar(string Made,string Model,string Color);