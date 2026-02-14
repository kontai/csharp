using System.Net.WebSockets;
using System.Security.Claims;

namespace CH16;

public interface IIfc1
{
    void PrintOut(string s);
}

public interface IIfc2
{
    void PrintOut(string s);
}

public class MyBase
{
    //public void PrintOut(string str)
    //{
    //    Console.WriteLine("in MyBase: {0}", str);
    //}
}

public class Derived : MyBase, IIfc1, IIfc2
{
    //void PrintOut(string str)
    //{
    //    //空方法體
    //    Console.WriteLine("in Derived: {0}", str);
    //}
    void IIfc1.PrintOut(string str) //顯式接口成員實現
    {
        Console.WriteLine($"IIfc1: {str}");
    }

    void IIfc2.PrintOut(string str) //顯式接口成員實現
    {
        Console.WriteLine($"IIfc2: {str}");
    }

    public void Method1()
    {
        //        PrintOut("Method1");    //錯誤，基類沒有此方法, 且不能查接訪問顯式接口實現成員
        //       this.PrintOut("Method1");   //同上

        ((IIfc1)this).PrintOut("Method1"); //呼叫顯式接口實現成員
    }
}


public static class ExplicitIterfaceImp
{
    static void Main(string[] args)
    {
        Derived d = new Derived();

        IIfc1 ifc1 = d;
        IIfc2 ifc2 = d;

        //d.PrintOut("object");     //基類有同名方法，可以使用基類的方法，不用另外實現
        ifc1.PrintOut("object");
        ifc2.PrintOut("object");

        d.Method1();
    }
}