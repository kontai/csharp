using Employees;

Console.WriteLine("***** The Employee Class Hierarchy *****\n");

SalesPerson fred = new SalesPerson
{
    Age = 31,
    Name = "Fred",
    SalesNumber = 50
};

SalesPerson jason = new SalesPerson("jason", 2, 50, 31, 50);
