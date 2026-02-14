using System;
using static FunWithMethodOverloading.AddOperations;
<<<<<<< HEAD
System.Console.WriteLine("***** Fun with Method Overloading *****\n");
=======
Console.WriteLine("***** Fun with Method Overloading *****\n");
>>>>>>> 8d5109e7f4ef3226c879d8cc237a995adb1c4f4c
// Calls int version of Add()
Console.WriteLine(Add(10, 10));
// Calls long version of Add() (using the new digit separator)
Console.WriteLine(Add(900_000_000_000, 900_000_000_000));
// Calls double version of Add()
Console.WriteLine(Add(4.3, 4.4));
//Console.ReadLine();