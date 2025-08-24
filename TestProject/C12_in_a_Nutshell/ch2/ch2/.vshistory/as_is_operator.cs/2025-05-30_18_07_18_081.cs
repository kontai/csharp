namespace ch2;

public class as_is_operator
{
    static void Main(string[] args)
    {
        Stock s=new Stock { SharsOwned = "100" };
        Asset a = s;
        Console.WriteLine(s==a);
        Stock s2 = (Stock)a;    // Explicit cast from Asset to Stock
        Stock s3=a as Stock;
        if(a is Stock k && int.Parse(k.SharsOwned)>1)
            {
            Console.WriteLine($"k is a stock with {k.SharsOwned} shares owned.");
        }
        else
        {
            Console.WriteLine("a is not a Stock or has no shares owned.");
        }

        s.SharsOwned= "200"; // s still in scope

        Console.WriteLine($"a.x={a.x}\na.y={a.y}");

    }
}

public class Asset
{
    public int x = 10;
    public int y = 20;

    public string Name { get; set; }
    public virtual decimal Liability => 0;  // Default implementation, can be overridden
}
public class Stock: Asset
{
    public int x = 100;
    public int y = 200;
    public string SharsOwned { get; set; }
    public override decimal Liability => 0b01;
}