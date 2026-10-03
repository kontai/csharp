using System.Reflection;
using System.Runtime.Loader;
using CommonSnappableTypes;

Console.WriteLine("***** Welcome to MyTypeViewer *****");
string typeName = "";
do
{
    Console.WriteLine("\nEnter a snapin to load");
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
        LoadExternalModule(typeName);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Sorry, can't find snapin");
    }
} while (true);
static void DisplayCompanyData(Type t)
{
    //取得[CompanyInfo]資料。
    var compInfo = t.GetCustomAttributes(false).Where(ci => (ci is CompanyInfoAttribute));
    foreach (CompanyInfoAttribute c in compInfo)
    {
        Console.WriteLine($"More info about {c.CompanyName} can be found at {c.CompanyUrl}");
    }
}
static void LoadExternalModule(string assemblyName)
{
    Assembly theSnapInAsm = null;
    try
    {
        // 動態載入選定的組件。
        theSnapInAsm = Assembly.LoadFrom(assemblyName);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred loading the snapin: {ex.Message}");
        return;
    }
    // 取得組件中所有相容於 IAppFunctionality 的類別。
    var theClassTypes = theSnapInAsm
        .GetTypes()
        .Where(t => t.IsClass && (t.GetInterface("IAppFunctionality") != null))
        .ToList();
    if (!theClassTypes.Any())
    {
        Console.WriteLine("Nothing implements IAppFunctionality!");
    }
    // 現在，建立物件並呼叫 DoIt() 方法。
    foreach (Type t in theClassTypes)
    {
        // 用延遲繫結建立該型別。
        IAppFunctionality itfApp = (IAppFunctionality)theSnapInAsm.CreateInstance(t.FullName, true);
        itfApp?.Doit();
        // 顯示公司資訊。
        DisplayCompanyData(t);
    }
}
