using System.Collections;
using SimpleInterfaces;

Iclonable_fun();


void Iclonable_fun()
{

Point p3 = new Point(100, 100);
Point p4 = (Point)p3.Clone();  // 注意要轉型

p4.X = 0; // 改 p4，不會影響 p3

Console.WriteLine(p3); // X = 100, Y = 100
Console.WriteLine(p4); // X = 0,   Y = 100
}

void IEnumerable_fun()
{

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
}
