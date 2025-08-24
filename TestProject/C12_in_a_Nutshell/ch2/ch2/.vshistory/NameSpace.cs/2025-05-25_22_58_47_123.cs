namespace ch2.A
{
        public class NameSpace
        {
            static void Main(string[] args)
            {
                ch2.B.NameSpace2.Foo();
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