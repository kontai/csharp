using Employees;

Console.WriteLine("***** The Employee Class Hierarchy *****\n");

// 建立 SalesPerson 物件
SalesPerson fred = new SalesPerson
{
    Name = "Fred",
    Age = 31,
    SalesNumber = 50
};

Console.WriteLine($"{fred.Name}, Age: {fred.Age}, Sales: {fred.SalesNumber}");
