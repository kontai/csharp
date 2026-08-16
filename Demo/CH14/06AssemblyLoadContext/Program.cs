using System.Runtime.Loader; // 🌟 這是使用 AssemblyLoadContext 必須 using 的命名空間

LoadAdditionalAssembliesDifferentContexts();

static void LoadAdditionalAssembliesDifferentContexts()
{
    // 組裝目標 DLL 的絕對路徑
    var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Car.dll");

    // 🌟 建立第一個無塵室 (Context 1)
    AssemblyLoadContext lc1 = new AssemblyLoadContext("NewContext1", isCollectible: false);
    // 在 Context 1 中載入 DLL，並建立 Car 物件
    var cl1 = lc1.LoadFromAssemblyPath(path);
    var c1 = cl1.CreateInstance("Car");

    // 🌟 建立第二個無塵室 (Context 2)
    AssemblyLoadContext lc2 = new AssemblyLoadContext("NewContext2", isCollectible: false);
    // 在 Context 2 中「再次」載入同一個 DLL，並建立 Car 物件
    var cl2 = lc2.LoadFromAssemblyPath(path);
    var c2 = cl2.CreateInstance("Car");

    Console.WriteLine("*** 在不同的 Context 中載入相同的組件 ***");

    // ⚔️ 比較它們是否相等？
    Console.WriteLine($"Assembly1 == Assembly2 嗎？ {cl1 == cl2}"); // False！
    Console.WriteLine($"Class1 == Class2 嗎？ {c1.Equals(c2)}"); // False！

    var cl3 = lc1.LoadFromAssemblyPath(path);
    var c3 = cl3.CreateInstance("Car");
    // ⚔️ 比較它們是否相等？
    Console.WriteLine($"Assmbly1==Assembly3 嗎？ {cl1 == cl3}"); // True！
    Console.WriteLine($"Class1==Class3 嗎? {c1.Equals(c3)}"); // True！
}
