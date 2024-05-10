using System.Threading.Channels;

namespace CH18;

interface IMuIfc<T>
{
    T ReturnIt(T intValue);
}

class Simple : IMuIfc<int>, IMuIfc<string>  //非泛型接口
{
    public int ReturnIt(int intValue)  //實現int泛型接口
    {
        return intValue;
    }
    public string ReturnIt(string intValue)    //實現string泛型接口
    {
        return intValue;
    }
}
public class InterfaceGeneric
{
    static void Main(string[] args)
    {
        Simple trivial = new Simple();
        Console.WriteLine($"{trivial.ReturnIt(100)}");
        Console.WriteLine($"{trivial.ReturnIt("Hi There")}");
    }

}