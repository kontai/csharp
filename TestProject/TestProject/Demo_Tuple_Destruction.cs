//Destruction Tuple

var tuple = (1, 2, 3);

//Destructuring
var (a, b, c) = tuple;
Console.WriteLine($"a: {a}, b: {b}, c: {c}");

//Declaring a new tuple
(int d, int e, int f) = tuple;
Console.WriteLine($"d: {d}, e: {e}, f: {f}");

//Here’s another example, this time when calling a method, and with type inference (var)
var(name,age,sex) = GetTuple();
Console.WriteLine($"name: {name}, age: {age}, sex: {sex}");


(string,int,char)GetTuple()=>("tai",18,'M');