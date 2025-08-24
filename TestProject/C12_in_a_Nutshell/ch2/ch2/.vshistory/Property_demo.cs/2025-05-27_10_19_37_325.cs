using System.Threading.Channels;

namespace ch2;

public class Property_demo
{
    static void Main(string[] args)
    {
        Foo foo = new Foo(-20.5M);
        Console.WriteLine(foo.X);
    }
}

public class Foo
{
    public Foo(decimal x) => X = x; // Constructor that sets the property
    private decimal x;

    public decimal X
    {
        get => x;
        private set
        {
            x = Math.Abs(value); // Round to 2 decimal places
        }
    }
}