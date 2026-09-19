// 別忘了匯入 CarLibrary 命名空間！
using CarLibrary;

Console.WriteLine("***** C# CarLibrary Client App *****");

// 建立一台跑車。
SportsCar viper = new SportsCar("Viper", 240, 40);
viper.TurboBoost();

// 建立一台廂型休旅車。
MiniVan mv = new MiniVan();
mv.TurboBoost();
Console.WriteLine("Done. Press any key to terminate");

//Console.ReadLine();

var internalClassInstance = new MyInternalClass();
