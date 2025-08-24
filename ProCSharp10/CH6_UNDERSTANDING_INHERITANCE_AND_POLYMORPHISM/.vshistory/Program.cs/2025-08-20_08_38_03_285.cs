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


/*
try
{
    Car imCar = (Car)frank; //編譯時不會報錯，但執行時會報錯
}
catch (InvalidCastException e)
{
    Console.WriteLine(e.Message);
    throw;
}
*/

//使用 as 關鍵字進行安全轉換
Car inotCar = frank as Car;
if(inotCar== null)
{
    Console.WriteLine("Frank is not a car!");
}

// c# 7 使用 is 關鍵字進行類型檢查
if (frank is Employee jj)
{
    Console.WriteLine(jj);
}

//c# 9 is not
if (frank is not Car)
{
    Console.WriteLine($"emp is not a car !");
}

// fallback pattern

Employee emp2 = new Employee();
if (emp2 is SalesPerson)
{
    Console.WriteLine("emp2 is Sales");
}else if (emp2 is Manager)
{
    Console.WriteLine("emp2 is Manager");
} else if( emp2 is var _)   //catch-all pattern
{
    Console.WriteLine("emp2 is something else");
}

GivePromotion((Employee)frank);

static void GivePromotion(Employee emp)
{
    Console.WriteLine($"{emp.Name} was promoted!");

    switch (emp)
    {
        case SalesPerson s:
            Console.WriteLine($"{s.Name} made {s.SalesNumber} sale(s)!");
            break;

        case Manager m:
            Console.WriteLine($"{m.Name} had {m.StockOptions} stock options...");
            break;

        default:
            Console.WriteLine("Unknown employee type");
            break;
    }

    Console.WriteLine();
}

