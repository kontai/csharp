using System;
using System.Collections.Specialized;


static void NamedParameter(int any,string label, int count, decimal price)
{
    Console.WriteLine($"the Label: {label}");
    Console.WriteLine($"Price: {price}");
    Console.WriteLine($"Count: {count}");
}

Console.WriteLine("Name parameter=>");
NamedParameter(20,count:1,price:1000M,label:"OOXX");
