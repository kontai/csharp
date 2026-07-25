namespace ForEachWithExtensionMethods;

class Car
{
    public int CurrentSpeed { get; set; } = 0;
    public string PetName { get; set; } = "";

    public Car() { }
    public Car(string name, int speed)
    {
        CurrentSpeed = speed;
        PetName = name;
    }
}