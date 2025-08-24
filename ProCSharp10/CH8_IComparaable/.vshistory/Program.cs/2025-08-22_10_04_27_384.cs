using CH8_IComparaable;

Car[] myAutos =
{
    new Car("Rusty", 80, 1),
    new Car("Mary", 40, 234),
    new Car("Viper", 40, 34),
    new Car("Mel", 40, 4),
    new Car("Chucky", 40, 5)
};

Console.WriteLine("== 原始順序 ==");
foreach (Car c in myAutos)
    Console.WriteLine("{0} {1}", c.CarID, c.PetName);

// 預設排序（用 CarID）
Array.Sort(myAutos);
Console.WriteLine("\n== 依 CarID 排序 ==");
foreach (Car c in myAutos)
    Console.WriteLine("{0} {1}", c.CarID, c.PetName);

// 使用 PetNameComparer 排序
//Array.Sort(myAutos, new PetNameComparer());
Array.Sort(myAutos,Car.SortByPetName);
Console.WriteLine("\n== 依 PetName 排序 ==");
foreach (Car c in myAutos)
    Console.WriteLine("{0} {1}", c.CarID, c.PetName);