PointWithReadOnly p3 =
  new PointWithReadOnly(50, 60, "Point w/RO");
p3.Display();
p3.X = 100; // Allowed: X is not read-only
//p3.Name="tai";  // Not allowed: Name is read-only

internal struct PointWithReadOnly
{
    //Fields of the structure.
    public int X;

    public readonly int Y;
    public readonly string Name;

    //Display the current position and name.
    public readonly void Display()
    {
        Console.WriteLine($"X = {X}, Y = {Y}, Name = {Name}");
    }

    //A custom constructor.
    public PointWithReadOnly(int xPos, int yPos, string name)
    {
        X = xPos;
        Y = yPos;
        Name = name;
    }
}