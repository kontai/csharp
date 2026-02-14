using System.Threading.Channels;

namespace ch2;

public class Property_demo
{
    static void Main(string[] args)
    {
    Foo foo=new Foo(20);
    Console.WriteLine(foo.X);
    }
}

public class Foo
{
    public Foo(int x)=> X = x; // Constructor that sets the property
    private decimal x;
    public decimal X
    {
        get => x;
        private set
        {
            x=Math.Round(value, 2); // Round to 2 decimal places
        }
    }
}
