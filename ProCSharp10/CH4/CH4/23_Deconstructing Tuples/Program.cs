using System.Security.Cryptography.X509Certificates;

Point p = new Point(7, 5);
var pointValues = p.Deconstruct();
Console.WriteLine($"X is: {pointValues.XPos}");
Console.WriteLine($"Y is: {pointValues.YPos}");
int x1 = 0;
int y1 = 0;
(x1, y1) = p;
var res = p switch
{

    (0, 0) => "Origin",
    var (x, y) when x > 0 && y > 0 => "One",
    var (x, y) when x < 0 && y > 0 => "Two",
    var (x, y) when x < 0 && y < 0 => "Three",
    var (x, y) when x > 0 && y < 0 => "Four",
    var (_, _) => "Border",
};
Console.WriteLine(res);


internal struct Point
{
    // Fields of the structure.
    public int X;

    public int Y;

    // A custom constructor.
    public Point(int XPos, int YPos)
    {
        X = XPos;
        Y = YPos;
    }

    public (int XPos, int YPos) Deconstruct() => (X, Y);

    //
    public void Deconstruct(out int x, out int y)
    {
        x = X; y = Y;
        Console.WriteLine("Deconstruct() called.");
    }
}