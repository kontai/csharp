namespace ch2;

public class as_is_operator
{
    static void Main(string[] args)
    {
        Stock s=new Stock { SharsOwned = "100" };
        Asset a = s;
        Console.WriteLine(s==a);

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