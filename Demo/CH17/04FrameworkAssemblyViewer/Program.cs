using System.Reflection;

Console.WriteLine("***** The Framework Assembly Reflector App *****\n");

//載入Microsoft.EntityFrameworkCore.dll
var displayName =
    "Microsoft.EntityFrameworkCore, Version=10.0.0.0, Culture=neutral, PublicKeyToken=ADB9793829DDAE60";
Assembly asm = Assembly.Load(displayName);
DisplayInfo(asm);
Console.WriteLine("Done!");

static void DisplayInfo(Assembly a)
{
    AssemblyName asmNameInfo = a.GetName();
    Console.WriteLine("***** Info about Assembly *****");
    Console.WriteLine($"Asm Name: {asmNameInfo.Name}");
    Console.WriteLine($"Asm Version: {asmNameInfo.Version}");
    Console.WriteLine($"Asm Culture: {asmNameInfo.CultureInfo.DisplayName}");
    Console.WriteLine("\nHere are the public enums:");
    var publicEnums = a.GetTypes().Where(n => n.IsEnum && n.IsPublic);
    foreach (var pe in publicEnums)
    {
        Console.WriteLine(pe);
    }
}
