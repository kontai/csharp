using System.Reflection;
using System.Reflection.Metadata;

Console.WriteLine("***** Welcome to MyTypeViewer *****");
string typeName = "";
do
{
    Console.WriteLine("\nEnter a type name to evaluate");
    Console.Write("or enter Q to quit: ");
    // 取得型別名稱。
    typeName = Console.ReadLine();
    // 使用者是否要離開？
    if (typeName.Equals("Q", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }
    // 嘗試顯示型別。
    try
    {
        Type t = Type.GetType(typeName);
        if (t == null && typeName.Equals("System.Console", StringComparison.OrdinalIgnoreCase))
        {
            t = typeof(System.Console);
        }
        Console.WriteLine("");
        ListVariousStats(t);
        ListFields(t);
        ListProps(t);
        ListMethods(t);
        ListInterfaces(t);
    }
    catch
    {
        Console.WriteLine("Sorry, can't find type");
    }
} while (true);

// 顯示型別的方法名稱。
static void ListMethods(Type t)
{
    Console.WriteLine("***** Methods *****");
    //MethodInfo[]  mi=t.GetMethods();
    //var methodNames = from n in t.GetMethods() orderby n.Name select n.Name;
    // 使用 LINQ 擴充方法寫法：
    // var methodNames = t.GetMethods().OrderBy(m=>m.Name).Select(m=>m.Name);
    //foreach (var name in methodNames)
    //{
    //    Console.WriteLine("->{0}", name);
    //}

    var methods = t.GetMethods().OrderBy(n => n.Name);
    foreach (var m in methods)
    {
        // 取得回傳型別。
        string retVal = m.ReturnType.FullName;
        string paramInfo = "( ";
        // 取得參數。
        foreach (ParameterInfo pi in m.GetParameters())
        {
            paramInfo += string.Format("{0} {1} ", pi.ParameterType, pi.Name);
        }
        paramInfo += " )";
        // 現在顯示基本的方法簽章。
        Console.WriteLine("->{0} {1} {2}", retVal, m.Name, paramInfo);
    }

    //選取所有的 MethodInfo 物件本身
    /*    foreach (var m in methods)
        {
            Console.WriteLine(m);
        }
        Console.WriteLine();
    */
}

// 顯示型別的欄位名稱。
static void ListFields(Type t)
{
    Console.WriteLine("***** Fields *****");
    //  var fieldNames = from f in t.GetFields() orderby f.Name select f.Name;
    var fieldNames = t.GetFields().OrderBy(m => m.Name).Select(x => x.Name);
    foreach (var name in fieldNames)
    {
        Console.WriteLine("->{0}", name);
    }
    Console.WriteLine();
}

// 顯示型別的屬性名稱。
static void ListProps(Type t)
{
    Console.WriteLine("***** Properties *****");
    var propNames = from p in t.GetProperties() orderby p.Name select p.Name;
    //var propNames = t.GetProperties().Select(p=>p.Name);
    foreach (var name in propNames)
    {
        Console.WriteLine("->{0}", name);
    }
    Console.WriteLine();
}

// 顯示已實作的介面。
static void ListInterfaces(Type t)
{
    Console.WriteLine("***** Interfaces *****");
    var ifaces = from i in t.GetInterfaces() orderby i.Name select i;
    //var ifaces = t.GetInterfaces().OrderBy(i=>i.Name);
    foreach (Type i in ifaces)
    {
        Console.WriteLine("->{0}", i.Name);
    }
}

// 順便展示一下。
static void ListVariousStats(Type t)
{
    Console.WriteLine("***** Various Statistics *****");
    Console.WriteLine("Base class is: {0}", t.BaseType);
    Console.WriteLine("Is type abstract? {0}", t.IsAbstract);
    Console.WriteLine("Is type sealed? {0}", t.IsSealed);
    Console.WriteLine("Is type generic? {0}", t.IsGenericTypeDefinition);
    Console.WriteLine("Is type a class type? {0}", t.IsClass);
    Console.WriteLine();
}
