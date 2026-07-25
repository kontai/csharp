using InterfaceExtensions;
using MyExtensionMethods;

Console.WriteLine("***** Fun with Extension Methods *****\n");

//The int has assumed a new identity!
int myInt = 12345678;
myInt.DisplayDefiningAssembly();

//Use new integer functionality.
Console.WriteLine("Value of myInt: {0}", myInt);
Console.WriteLine("Reversed digits of myInt: {0}", myInt.ReverseDigits());
Console.WriteLine("my Reversed digits of myInt: {0}", myInt.MyReversDigits());

Console.WriteLine("***** 體驗擴充介面的威力 *****\n");

// 1. System.Array (陣列) 實作了 IEnumerable，所以它能逼逼叫！
string[] data = { "Wow", "this", "is", "sort", "of", "annoying" };
data.PrintDataAndBeep();

Console.WriteLine();

// 2. List<T> (泛型清單) 也實作了 IEnumerable，所以它也能逼逼叫！
List<int> myInts = new List<int>() { 10, 15, 20 };
myInts.PrintDataAndBeep();
