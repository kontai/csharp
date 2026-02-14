using System.Threading.Channels;

namespace ch2;

public class Property_demo
{
    static void Main(string[] args)
    {
        Foo foo = new Foo(20.5M);
        Console.WriteLine(foo.X);
        var foo2 = new Foo(x: 20) { Duration = 10, Pitch = 20 };
        //foo.Pitch = 10; // This will cause a compile-time error because Pitch is init-only
        Note note = new Note() { Pitch = 10 };
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
            x = Math.Round(value, 2); // Round to 2 decimal places
        }
    }

    public int Pitch { get; init; } = 20;
    public int Duration { get; init; } = 100;

}

public class Note
{
    private  int _pitch;

    public int Pitch
    {
    get=>_pitch;
    init => _pitch = value; // Init-only property, can only be set during object initialization
    }
}