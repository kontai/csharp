using System.Threading.Channels;

namespace CH18;

interface IMuIfc<T>
{
    T ReturnIt(T intValue);
}


// 泛型接口的實現必須唯一(S如果是int,則會發生衝突)
/*      
class Simple<S> : IMuIfc<int>, IMuIfc<S>
{
    public int ReturnIt(int intValue)
    {
        return intValue;
    }

    public S ReturnIt(S intValue)
    {
        return intValue;
    }
}
*/

class Simple : IMuIfc<int>, IMuIfc<string>  //非泛型接口
{
    public int ReturnIt(int intValue)  //實現int泛型接口
    {
        return intValue;
    }
    public string ReturnIt(string stringValue)    //實現string泛型接口
    {
        return stringValue;
    }

    public S ReturnIt(S sValue)
    {
        return sValue;
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