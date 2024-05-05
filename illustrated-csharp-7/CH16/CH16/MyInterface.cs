namespace CH16;

/// <summary>
/// 聲明接口
/// </summary>
internal interface IIfct
{
    void PrintOut(string str); //隱式public訪問符
}

/// <summary>
/// 實作接口
/// </summary>
/// <seealso cref="CH16.IIfct" />
public class MyClass : IIfct
{
    public void PrintOut(string str)
    {
        Console.WriteLine($"Calling through: {str}");
    }
}

public class AnotherClass
{
}

internal class Program
{
    private static void Main(string[] args)
    {
        var mc = new MyClass();
        if (mc is IIfct)
            mc.PrintOut("Object");

        var ac = new AnotherClass();

        //IIfct ifc = (IIfct)mc;    //獲取接口的引用
        IIfct ifc = mc; //隱式類型轉換
        ifc.PrintOut("interface"); //使用接口的引用調用方法

        //IIfct iifc2 = (IIfct)ac;//錯誤，ac不是IIfct的子類別
        IIfct iifc2 = ac as IIfct; //as語句,判斷類對象是否為指定的接口,返回值是IIfct或null
        if (null != iifc2)
        {
            iifc2.PrintOut("is ingerface");
        }
    }
}