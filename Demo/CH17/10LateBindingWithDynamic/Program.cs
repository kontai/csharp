using System.Reflection;
using Microsoft.CSharp.RuntimeBinder;

//AddWithReflection();
AddWithDynamic();

static void AddWithReflection()
{
    Assembly asm = Assembly.LoadFrom("MathLibrary");
    try
    {
        // 取得 SimpleMath 型別的中繼資料。
        Type math = asm.GetType("MathLibrary.SimpleMath");
        // 即時建立一個 SimpleMath。
        object obj = Activator.CreateInstance(math);
        // 取得 Add 的資訊。
        MethodInfo mi = math.GetMethod("Add");
        // 呼叫方法（帶有參數）。
        object[] args = { 10, 70 };
        Console.WriteLine("Result is: {0}", mi.Invoke(obj, args));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void AddWithDynamic()
{
    Assembly asm = Assembly.LoadFrom("MathLibrary");
    try
    {
        // 取得 SimpleMath 型別的中繼資料。
        Type math = asm.GetType("MathLibrary.SimpleMath");
        // 即時建立一個 SimpleMath。
        dynamic obj = Activator.CreateInstance(math);
        // 請注意，我們現在能多麼輕鬆地呼叫 Add()。
        Console.WriteLine("Result is: {0}", obj.Add(10, 70));
    }
    catch (RuntimeBinderException ex)
    {
        Console.WriteLine(ex.Message);
    }
}
