ref struct DisposableRefStruct
{
    public int X;
    public readonly int Y;
    public readonly string Name;

    public DisposableRefStruct(int xPos, int yPos, string name)
    {
        X = xPos;
        Y = yPos;
        Name = name;
    }

    //display the current position and name.
    public void display()
    {
        Console.WriteLine($"X = {X}, Y = {Y}, Name = {Name}");
    }

    public void Dispose()
    {
        Console.WriteLine("Disposed!");
    }
}


internal class Program
{
    private static void Main(string[] args)
    {
        using DisposableRefStruct drs = new DisposableRefStruct(10, 20, "Disposable Ref Struct");
        drs.display();

    }
}
