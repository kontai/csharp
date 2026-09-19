using System.Diagnostics.CodeAnalysis;
using CarLibrary;

SportsCar sportsCar = new SportsCar("Honda", 200, 50) { PetName = "scar" };

//獲取Type的三種方式
Type typ1 = sportsCar.GetType();
Type type2 = typeof(SportsCar);
Type? type3 = Type.GetType("CarLibrary.SportsCar", false, true); //false:不嘗試載入assembly, true:忽略大小寫

Type[] types = { typ1, type2, type3 };

foreach (var item in types)
{
    Console.WriteLine(item);
}
