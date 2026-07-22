using ForEachWithExtensionMethods;

Console.WriteLine("***** 體驗擴充方法支援 GetEnumerator 的威力 *****\n");
Garage carLot = new Garage();

// 🤯 魔法發生了！carLot 明明沒有實作 IEnumerable，卻可以跑 foreach！
// 因為 C# 9.0 編譯器看到了我們寫的 GarageExtensions 擴充方法。
foreach (Car c in carLot)
{
    Console.WriteLine("{0} is going {1} MPH", c.PetName, c.CurrentSpeed);
}