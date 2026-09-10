using _02FunWithConfiguration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

// 第一步：跟原本一樣，先用 ConfigurationBuilder 組出 IConfiguration
IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile("appsettings.development.json", true, true)
    .Build();

//UsingOption();
Console.WriteLine($"My car's name is {config["CarName"]}");

Console.WriteLine($"My car object is a {config["CarSettings:Color"]}");
Console.WriteLine($"My car {config["CarName"]} top speed is {config["CarSettings:TopSpeed"]}");

IConfigurationSection section = config.GetSection("CarSettings");
Console.WriteLine($"my car object is a {section["Color"]}");
Console.WriteLine($"my car {config["CarName"]} top speed is {section["TopSpeed"]}");

CarSettings c = new CarSettings();
section.Bind(c);
Console.WriteLine($"My car object is a {c.Color}");
Console.WriteLine($"My car {config["CarName"]} top speed is {c.TopSpeed}");

CarSettings? carFromGet = section.Get(typeof(CarSettings)) as CarSettings;
Console.WriteLine($"my car object is a {carFromGet?.Color}");
Console.WriteLine($"my car {config["CarName"]} top speed is {carFromGet?.TopSpeed}");

//ErrorOnUnknownConfiguration: 如果設為 true，當 config 裡有未知的設定時，會拋 InvalidOperationException
try
{
    carFromGet = section.Get<CarSettings>(t => t.ErrorOnUnknownConfiguration = true);
}
catch (InvalidOperationException e)
{
    Console.WriteLine($"An exception occurred: {e.Message}");
}

//GetRequiredSection: 如果找不到指定的 section，會拋 InvalidOperationException
try
{
    config.GetRequiredSection("Car2").Bind(c);
}
catch (InvalidOperationException e)
{
    Console.WriteLine($"An exception occurred: {e.Message}");
}
void UsingOption()
{
    // 第二步：建立一個最小的 DI 容器（ServiceCollection），
    // 因為 Options Pattern 本質上是建立在依賴注入之上的一套機制，
    // 即使是主控台應用程式，沒有內建 Generic Host，也可以自行組出一個 ServiceProvider 來使用它。
    var services = new ServiceCollection();

    // 第三步：向容器註冊 CarSettings 的組態繫結。
    // Configure<T>() 會在容器內部註冊一個 IOptions<CarSettings>，
    // 並且把 config 裡 "CarSettings" 這個區段的內容，透過反射自動繫結到 CarSettings 的屬性上。
    services.Configure<CarSettings>(config.GetSection(nameof(CarSettings)));

    // 第四步：建立 ServiceProvider，並解析出 IOptions<CarSettings>
    using ServiceProvider provider = services.BuildServiceProvider();
    IOptions<CarSettings> carSettingsOptions = provider.GetRequiredService<IOptions<CarSettings>>();

    // IOptions<T>.Value 拿到的是繫結完成的強型別物件，不用再逐一用索引子或 GetValue<T>() 手動轉型
    CarSettings carSettings = carSettingsOptions.Value;

    Console.WriteLine("=== 使用 Options Pattern (IOptions<CarSettings>) ===");
    Console.WriteLine($"My car's name is {carSettings.CarName}");
    Console.WriteLine($"My car's color is {carSettings.Color}");
    Console.WriteLine($"My car's top speed is {carSettings.TopSpeed}");

    // 對照組：如果組態裡完全沒有 "CarSettings" 這個區段，
    // Configure<T>() 不會拋例外，只會把 CarSettings 的屬性維持在預設值（string 為 ""，int 為 0）
    var emptyServices = new ServiceCollection();
    emptyServices.Configure<CarSettings>(config.GetSection("NonExistentSection"));
    using ServiceProvider emptyProvider = emptyServices.BuildServiceProvider();
    CarSettings emptyCarSettings = emptyProvider.GetRequiredService<IOptions<CarSettings>>().Value;

    Console.WriteLine();
    Console.WriteLine("=== 區段不存在時的預設值 ===");
    Console.WriteLine($"CarName is empty? {emptyCarSettings.CarName == string.Empty}");
    Console.WriteLine($"TopSpeed default value: {emptyCarSettings.TopSpeed}");
}
