using System.Runtime.InteropServices;

Console.WriteLine("***** 體驗泛型結構的樂趣 *****\n");

// ==========================================
// 測試 1：使用 int (整數)
// ==========================================
Point<int> p = new Point<int>(10, 10);
Console.WriteLine("p.ToString()={0}", p.ToString());
p.ResetPoint(); // int 的 default 會變成 0
Console.WriteLine("p.ToString()={0}", p.ToString());
Console.WriteLine();

// ==========================================
// 測試 2：使用 double (浮點數)
// ==========================================
Point<double> p2 = new Point<double>(5.4, 3.3);
Console.WriteLine("p2.ToString()={0}", p2.ToString());
p2.ResetPoint(); // double 的 default 也會變成 0
Console.WriteLine("p2.ToString()={0}", p2.ToString());
Console.WriteLine();

// ==========================================
// 測試 3：使用 string (字串)
// ==========================================
Point<string> p3 = new Point<string>("i", "3i");
Console.WriteLine("p3.ToString()={0}", p3.ToString());
p3.ResetPoint(); // string 的 default 會變成 null！
Console.WriteLine("p3.ToString()={0}", p3.ToString());

HoldResponse(p);
HoldResponse(p3);

static void HoldResponse<T>(Point<T> p)
{
    switch (p)
    {
        case Point<int> pint:
            Console.WriteLine("p is a Point<int>");
            break;
        case Point<string> pstring:
            Console.WriteLine("p is a Point<string>");
            break;
        case var _:
            Console.WriteLine("p is a Point<T>");
            break;
    }

}

internal class Point<T>
{
    private T _xpos;
    private T _ypos;

    public Point()
    {
        ResetPoint();
    }

    public Point(T x, T y)
    {
        _xpos = x;
        _ypos = y;
    }

    public T X
    {
        get => _xpos;
        set
        {
            _xpos = value;
        }
    }

    public T Y
    {
        get => _ypos;
        set
        {
            try
            {

                _ypos = value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    //set the generic parameter to default value
    public void ResetPoint()
    {
        _xpos = default;
        _ypos = default;
    }

    virtual public string ToString()
    {
        return string.Format("({0}, {1})", _xpos, _ypos);
    }

}
