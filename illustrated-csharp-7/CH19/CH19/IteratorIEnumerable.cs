using System.Collections;
using System.Threading.Tasks.Sources;

namespace CH19;

internal class MyClass
{
    public IEnumerator<string> GetEnumerator()
    {
        IEnumerable<string> myEnumerable = BlackAndWhite();
        return myEnumerable.GetEnumerator();
    }

    public IEnumerable<string> BlackAndWhite()      //可枚舉類型迭代器
    {
        yield return "black";
        yield return "gray";
        yield return "white";
    }
}

public class IteratorIEnumerable
{
    private static void Main(string[] args)
    {
        MyClass mc = new MyClass();
        foreach (var shade in mc)   //使用類對象(類實現了GetEnumerator，類為可枚舉)
        {
            Console.WriteLine(shade);
        }

        foreach (var shade in mc.BlackAndWhite())   //使用類枚舉方法(不實現GetEnumerator方法，讓類不可枚舉)
        {
            Console.WriteLine(shade);
        }

    }
}