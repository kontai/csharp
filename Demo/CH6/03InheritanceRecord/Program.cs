using RecordInheritance;

Console.WriteLine("Record type inheritance!");
Car c = new Car("Honda", "Pilot", "Blue");
MiniVan m = new MiniVan("Honda", "Pilot", "Blue", 10);
Console.WriteLine($"Checking MiniVan is-a Car:{m is Car}");


//public class TestClass { }
//public record TestRecord { }

//Classes cannot inherit records
//public class Test2 : TestRecord { }

//Records types cannot inherit from classes
//public record Test2 : TestClass { }

//Inheritance for Record Types with Positional Parameters
PositionalCar pc = new PositionalCar("Honda", "Pilot", "Blue");
PositionalMiniVan pm = new PositionalMiniVan("Honda", "Pilot", "Blue", 10);
Console.WriteLine($"Checking PositionalMiniVan is-a PositionalCar:{pm is PositionalCar}");

//Nondestructive Mutation with Inherited Record Types
PositionalCar[] pc2 = new PositionalCar[]
{
    new PositionalCar("Honda", "Pilot", "Blue"),
    new PositionalCar("Honda", "Civic", "Red"),
    new PositionalCar("Honda", "Accord", "Black"),
    new PositionalMiniVan("Honda", "Pilot", "Blue", 10)
};

var (make1, model1, color1) = pc2[0];
var (make2, mdel2, color2, seating1) = (PositionalMiniVan)pc2[3];   // compile time ,tag is base class

//loop through the array and print the details of each car
foreach (var car in pc2)
{
    Console.WriteLine(car);
    if (car is PositionalMiniVan mv)
    {
        //change console color to red
        ConsoleColor oldColor = Console.ForegroundColor;
        ConsoleColor oldbackColor = Console.BackgroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"This is a mini van with {mv.seating} seats");
        Console.BackgroundColor = oldbackColor;
        Console.ForegroundColor = oldColor;
    }
}
