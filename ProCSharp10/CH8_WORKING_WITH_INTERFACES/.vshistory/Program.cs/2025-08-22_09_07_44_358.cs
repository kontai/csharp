using System.Collections;
using SimpleInterfaces;

Garage garage=new Garage();
//foreach (var o in garage)
//{
//    Console.WriteLine(o);
//}
//IEnumerator enumerator= garage.GetEnumerator();
Garage carLot = new Garage();

// 1. 用預設的 foreach（正序）
//foreach (Car c in carLot)
//{
//  Console.WriteLine($"{c.PetName} is going {c.CurrentSpeed} MPH");
//}

// 2. 用我們自己定義的 named iterator（倒序）
foreach (Car c in carLot.GetTheCars(true))
{
  Console.WriteLine($"{c.PetName} is going {c.CurrentSpeed} MPH");
}
