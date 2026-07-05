CarRecord myCar1 = new CarRecord("Ford", "Mustang", "Blue"); //readonly, immutable,initialize
//myCar1.Color = "Red";   //error, readonly property
Console.WriteLine($"{myCar1.Make} {myCar1.Model} {myCar1.Color}");


//deconstruct
CarRecord myCar = new("Honda", "Pilot", "Blue");

var (make, model, color) = myCar;
myCar.Deconstruct(out string a, out string b, out string c);
Console.WriteLine("*** fun with deconstruct ***");
Console.WriteLine($"{a} {b} {c}");

Console.WriteLine($"這是一台 {make} 的 {model}");


//with operator, create a new record with the same value as myCar, but with Color set to "Red"
CarRecord anotherCar = myCar with { Color = "Red" };
//compare two records
Console.WriteLine("*** compare two records ***");
Console.WriteLine("myCar == anotherCar: {0}", myCar == anotherCar); //false
Console.WriteLine("myCar.Equals(anotherCar): {0}", myCar.Equals(anotherCar)); //false
Console.WriteLine("ReferenceEquals(myCar, anotherCar): {0}", ReferenceEquals(myCar, anotherCar)); //false

// ✅ 自動解構！直接把車子的零件拆給三個變數

public record CarRecord(string Make, string Model, string Color);