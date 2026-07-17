
using (MyResourceWrapper wrapper = new MyResourceWrapper())
{
    Console.WriteLine("***** Using wrapper! *****");
}

using MyResource resource = new MyResource();
Console.WriteLine("***** Using resource! *****");


//try
//{
//    Console.WriteLine("***** Using wrapper! *****");
//}
//finally
//{
//    wrapper.Dispose();
//}

internal class MyResourceWrapper : IDisposable
{
    public void Dispose()
    {
        // Just for a test.
        Console.WriteLine("***** In Dispose! *****");
    }
}

struct MyResource : IDisposable
{
    public void Dispose()
    {
        Console.WriteLine("***** In Dispose! *****");
    }
}



