namespace ch2;

public class as_is_operator
{
    static void Main(string[] args)
    {
        Stock s = new Stock();
        Asset a = s;

        Console.WriteLine($"a.x={a.x}\na.y={a.y}");
        a.Foo();
        s.Foo();

    }
}

public class Asset
{
    public int x = 10;
    public int y = 20;


    public void Foo()
    {
        Console.WriteLine("Asset.Foo()");
    }
}
public class Stock: Asset
{
    public new int x = 100;
    public new int y = 200;

    public new void Foo()
    {
        Console.WriteLine("Stock.Foo()");
    }
}