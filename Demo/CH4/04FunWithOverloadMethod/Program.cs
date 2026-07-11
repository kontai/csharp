using System.Threading.Channels;
using static _04FunWithOverloadMethod.AddOperations;

Console.WriteLine("****Fun With Method Overloading****");

//Calls int verion of Add()
Console.WriteLine(Add(1, 2));

// Calls double verion of Add()
Console.WriteLine(Add(1.2, 2.3));

// Calls string verion of Add()
Console.WriteLine(Add("Hello ", "World!"));

// Calls long verion of Add()
Console.WriteLine(Add(10000000000, 2000000000000000));

int a = 10;
int b = 20;
Console.WriteLine(Add(a, b));
