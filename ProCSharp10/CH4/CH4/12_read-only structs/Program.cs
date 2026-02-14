using System;
//entire struct read-on;y
internal readonly struct ReadOnlyPoint
{
    // Fields of the structure.
    public int X { get; }

    public int Y { get; }

    // Display the current position and name.
    public void Display()
    {
        Console.WriteLine($"X = {X}, Y = {Y}");
    }

    public ReadOnlyPoint(int xPos, int yPos)
    {
        X = xPos;
        Y = yPos;
    }
}