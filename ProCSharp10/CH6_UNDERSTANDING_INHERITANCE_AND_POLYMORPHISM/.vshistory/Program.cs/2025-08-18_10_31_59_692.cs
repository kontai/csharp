using Employees;
using RecordInheritance;

Console.WriteLine("***** The Employee Class Hierarchy *****\n");

// 建立 SalesPerson 物件
SalesPerson fred = new SalesPerson
{
    Name = "Fred",
    Age = 31,
    SalesNumber = 50
};

Console.WriteLine($"{fred.Name}, Age: {fred.Age}, Sales: {fred.SalesNumber}");

Console.WriteLine("Record type inheritance!");

// 建立 Car 和 MiniVan 物件
Car c = new Car("Honda","Pilot","Blue");
MiniVan m = new MiniVan("Honda","Pilot","Blue",10);

// 檢查 MiniVan 是否是 Car 的子類別
Console.WriteLine("------------------------------------------");
Console.WriteLine($"Checking MiniVan is-a Car: {m is Car}");

