using System.Reflection;

ListAllAssembliesInAppDomain();
LazyLoadingTest();


//諞譯後,.exe或.dll出現的位置
string baseDir=AppDomain.CurrentDomain.BaseDirectory;


static void ListAllAssembliesInAppDomain()
{
    // 取得當前的 AppDomain
    AppDomain defaultAD = AppDomain.CurrentDomain;

    // 🌟 取得目前已經載入到記憶體中的所有組件 (DLL)
    Assembly[] loadedAssemblies = defaultAD.GetAssemblies();

    Console.WriteLine($"***** 載入到 {defaultAD.FriendlyName} 的組件有： *****\n");

    foreach (Assembly a in loadedAssemblies)
    {
        // 印出組件名稱與版本
        Console.WriteLine($"-> Name, Version: {a.GetName().Name} : {a.GetName().Version}");
    }
}

static void LazyLoadingTest()
{
    AppDomain defaultAD = AppDomain.CurrentDomain;
    Assembly[] loadedAssemblies = defaultAD
        .GetAssemblies()
        .OrderBy(g => g.GetName().Name)
        .ToArray();

    Console.WriteLine($"***** 延遲載入----增加LINQ組件");
    foreach (Assembly a in loadedAssemblies)
    {
        Console.WriteLine($"{a.GetName().Name} : {a.GetName().Version}");
    }
}
