namespace CH14;

internal delegate void MyDel(int abc);

public class MyClass
{
    public void MyFunc(int x)
    { Console.WriteLine("MyFunc:" + x); }
}

internal static class SClass
{
    public static void Sfunc(int x)
    { Console.WriteLine("Sfunc:" + x); }
}

public class CombinDelegateExample
{
    private static void fooA(int x)
    { Console.WriteLine("fooA:" + x); }

    private static void fooB(int x)
    { Console.WriteLine("fooB:" + x); }

    private static void Main(string[] args)
    {
        MyDel delVar1 = CombinDelegateExample.fooA;
        MyDel delVar2 = CombinDelegateExample.fooB;

        MyDel aVar1 = new MyClass().MyFunc;
        MyDel aVar2 = SClass.Sfunc;

        //將上面兩個delegate合併成一個delegate
        MyDel delVar3 = delVar1 + delVar2;

        //為delVar3加入fooA的method
        delVar3 += aVar1;
        delVar3 += aVar2;
        delVar3 += delVar1;

        //打印delVar3的method數量
        Console.WriteLine(delVar3.GetInvocationList().Length);

        //如果在調用列表中的方法有多個實例，-=運算符會從列表最後開始中搜索，並且移除第一個匹配的實例
        delVar3 -= delVar1;

        //試著刪除委托中不存在的method將無效。
        //delVar3 -= Test;

        //調用方式I
        if (delVar3 != null)
        {
            delVar3(55);
        }

        //調用方式II
        delVar3?.Invoke(55);

        foreach (var x in delVar3.GetInvocationList())
        {
            Console.WriteLine(x.Method.Name);
            delVar3 -= (MyDel)x;
        }

        //try
        //{
        //    Console.WriteLine(delVar3.GetInvocationList().Length);
        //}
        //catch (NullReferenceException e)
        //{
        //    Console.WriteLine("空指針異常");
        //}
        //catch (Exception e)
        //{
        //    Console.WriteLine(e);
        //    throw;
        //}
    }
}