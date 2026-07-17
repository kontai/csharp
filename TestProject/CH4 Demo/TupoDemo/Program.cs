//Deconstructing Tuples
using System.Xml;

(int X, int Y) myTuple = (4, 5);
int x = 0;
int y = 0;
(x, y) = myTuple;
Console.WriteLine("X is:{0}",x);
Console.WriteLine("Y is {0}",y);

(int x1, int y1) = myTuple;
Console.WriteLine("x1 is {0}",x1);
Console.WriteLine("y1 is {0}",y1);

Point p1 = new Point(20, 30);

//print p1 coordinates
Console.WriteLine("X is {0}",p1.X);
Console.WriteLine("Y is {0}",p1.Y);

Console.WriteLine("p1 Quadrant: {0}", GetQuadrant1(p1));

DateTime today = DateTime.Now;
(int yr, int mon, int day) = today;
Console.WriteLine($"今年是{yr}年{mon}月{day}日");

static  string GetQuadrant1(Point p)
{
    return p switch
    {
        (0, 0) => "Ortgin",
        var (x, y) when x > 0 && y > 0 => "One",
        var (x, y) when x < 0 && y > 0 => "Two",
        var (x, y) when x < 0 && y < 0 => "Three",
        var (x, y) when x > 0 && y < 0 => "Four",
        _ => "Border"

    };
}

int v01 = 0;
int v02 = 0;
Foo(out v01,out v02);
Console.WriteLine($"v01:{v01},v02:{v02}");
void Foo(out int i,out int j)
{
    i = 20;j = 30;
}

struct Point
{
    public int X;
    public int Y;

    // A cutrom constructor
    public Point(int XPos,int YPos)
    {
        X=XPos;
        Y=YPos;
    }

    // A custom deconstruct method
    public void Deconstruct(out int XPos, out int YPos) => (XPos, YPos) = (X, Y);
}
