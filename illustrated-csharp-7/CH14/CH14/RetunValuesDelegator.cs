namespace CH14;

internal delegate int MyDel(); //聲明有返回值的方法

internal delegate void MyDelRef(ref int x); //參數是引用的方法

internal class MyClass
{
    private int IntValue = 5;

    public int Add2()
    {
        IntValue += 2;
        return IntValue;
    }

    public int Add3()
    {
        IntValue += 3;
        return IntValue;
    }
}

public class RetunValuesDelegator
{
    public void Add4(ref int x)
    {
        x += 2;
    }

    public void Add5(ref int x)
    {
        x += 3;
    }

    private static void Main(string[] args)
    {
        var mc = new MyClass();
        MyDel mDel = mc.Add2;
        mDel += mc.Add3; //創建並初始化委托
        mDel += mc.Add2; //增加方法
        mDel += mc.Add3; //增加方法
        Console.WriteLine($"mDel ={mDel()}");

        //有返回值的委托，且調用列表有一個以上的方法時，
        //只會回傳最後一個方法的返回值。

        ////////////////////////////////////////////////////////////////////////////////

        var rvd = new RetunValuesDelegator();

        //MyDelRdf帶有引用參數的方法
        MyDelRef RDel = rvd.Add4;
        RDel += rvd.Add5;
        RDel += rvd.Add4;

        var x = 5;
        RDel?.Invoke(ref x);
        Console.WriteLine($"Value: {x}");
    }
}