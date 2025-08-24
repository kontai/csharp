namespace ch2;

public class generic_demo
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello generic!");
        Type a1 = typeof(A<>);
        Type a2= typeof(A<,>);
    }

}

class A<TT>{}

class A<T1,T2>{}