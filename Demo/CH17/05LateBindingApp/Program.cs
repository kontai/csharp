using System.Reflection;

Console.WriteLine("*** Fun With Late Binding ***");

Assembly asm = null;

try
{
    asm = Assembly.LoadFrom("03CarLibrary.dll");
}
catch (FileNotFoundException e)
{
    Console.WriteLine(e.Message);
    return;
}

if (asm != null)
{
    // CreateUsingLateBinding(asm);
    InvokeMethodWithArgsUsingLateBinding(asm);
}

void CreateUsingLateBinding(Assembly assembly)
{
    try
    {
        Type miniVan = assembly.GetType("CarLibrary.MiniVan"); //獲取MiniVan類型
        object car = Activator.CreateInstance(miniVan);
        Console.WriteLine("Create a instance using late binding");

        MethodInfo? methodInfo = miniVan.GetMethod("TurboBoost"); //獲取TurboBoost方法
        methodInfo?.Invoke(car, null); //調用TurboBoost方法
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

static void InvokeMethodWithArgsUsingLateBinding(Assembly asm)
{
    try
    {
        // 首先，取得跑車的中繼資料描述。
        Type sport = asm.GetType("CarLibrary.SportsCar");
        // 現在，建立這台跑車。
        object obj = Activator.CreateInstance(sport);
        // 用引數呼叫 TurnOnRadio()。
        MethodInfo mi = sport.GetMethod("TurnOnRadio");
        mi.Invoke(obj, new object[] { true, 2 });
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}