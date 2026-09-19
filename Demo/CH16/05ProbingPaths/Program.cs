Console.WriteLine("*** Fun with Probing Paths ***");
Console.WriteLine($"TRUSTED_PLATFORM_ASSEMBLIES: ");

//非 Windows 平台請改用 ':' 分隔
var list = AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES").ToString().Split(';');
foreach (var dir in list)
{
    Console.WriteLine(dir);
}
Console.WriteLine($"數量: {list.Length}");
Console.WriteLine();
Console.WriteLine($"PLATFORM_RESOURCE_ROOTS: {AppContext.GetData("PLATFORM_RESOURCE_ROOTS")}");
Console.WriteLine();
Console.WriteLine(
    $"NATIVE_DLL_SEARCH_DIRECTORIES: {AppContext.GetData("NATIVE_DLL_SEARCH_DIRECTORIES")}"
);
Console.WriteLine();
Console.WriteLine($"APP_PATHS: {AppContext.GetData("APP_PATHS")}");
Console.WriteLine();
Console.WriteLine($"APP_NI_PATHS: {AppContext.GetData("APP_NI_PATHS")}");
Console.WriteLine();
