internal class SomeClass<T1, T2>    //泛型類
{
    public T1 SomeVar;
    public T2 OtherVar;
}

internal class Program
{
    private static void Main(string[] args)
    {
        var first = new SomeClass<short, int>();    //構造的類型
        var second = new SomeClass<int, long>();    //構造的類型
    }
}