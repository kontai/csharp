using Employees;
using RecordInheritance;

Console.WriteLine("***** The Employee Class Hierarchy *****\n");

// 建立 SalesPerson 物件


/*
Manager chucky = new Manager("Chucky", 50, 92, 100000, "333-23-2322", 9000);
chucky.GiveBonus(300);
chucky.DisplayStats();
Console.WriteLine();
SalesPerson fran = new SalesPerson("Fran", 43, 93, 3000, "932-32-3232", 31,2000);
fran.GiveBonus(200);
fran.DisplayStats();
*/


/*// 建立 Car 和 MiniVan 物件
Console.WriteLine("------------------------------------------");
Console.WriteLine("Record type inheritance!");
Car c = new Car("Honda","Pilot","Blue");
MiniVan m = new MiniVan("Honda","Pilot","Blue",10);

// 檢查 MiniVan 是否是 Car 的子類別
Console.WriteLine($"Checking MiniVan is-a Car: {m is Car}");
*/

Employee emp = new Manager("Chucky", 50, 92, 100000, "333-23-2322", 9000);
object frank = new Manager("Frank Zappa", 9, 3000, 40000, "111-11-1111", 5);

GivePromotion((Employee)frank);

Car imCar = (Car)emp;


    static void GivePromotion(Employee emp)
{
    Console.WriteLine("{0} was promoted!", emp.Name);
}

