using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Numerics;


MyPoint p1 = new MyPoint(1, 2);
MyPoint p2 = new MyPoint(3, 4);

BaseMath<MyPoint> bm = new BaseMath<MyPoint>();
MyPoint p3 = bm.Add(p1, p2);

Console.WriteLine(p3);

class MyPoint : IAdditionOperators<MyPoint, MyPoint, MyPoint>
{
    public int x;
    public int y;

    public MyPoint()
    {

    }
    public MyPoint(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public static MyPoint operator +(MyPoint p, MyPoint q)
    {
        return new MyPoint(p.x + q.x, p.y + q.y);
    }
    public override string ToString()
    {
        return "x: " + x + " y: " + y;
    }
}

class BaseMath<T> where T : IAdditionOperators<T, T, T>
{
    public T Add(T a, T b)
    {
        return a + b;
    }
}
