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

        s.SharsOwned= "200"; // s still in scope,

    }
}

public class Asset
{
    public string Name { get; set; }
}
public class Stock: Asset
{
    public string SharsOwned { get; set; }

}