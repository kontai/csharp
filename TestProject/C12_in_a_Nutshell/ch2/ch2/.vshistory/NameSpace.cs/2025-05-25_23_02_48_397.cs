namespace ch2.A
{
    using B;    // Importing the B namespace

    public class NameSpace
    {
        static void Main(string[] args)
        {
            NameSpace2.Foo();
        }
    }
}

namespace ch2.B
{
    public class NameSpace2
    {
        public static void Foo() => Console.WriteLine("In Ch2.B.BaneSpace2 Foo()");
    }
}