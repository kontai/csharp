using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;

(string, int, double) tp1 = ("Hello", 1, 2.3);
Console.WriteLine("tp1.item1:{0}\ntp1.item2{1}\ntp1.item3{2}\n", tp1.Item1, tp1.Item2, tp1.Item3);


//named field 
(string name, int age) p1 = ("kontai", 20);
(string, int) p2 = (name: "jack", age: 30);
var p3 = (name: "jack", age: 30);

var p4 = getPerson();
//print p4
Console.WriteLine("p4.name:{0}\np4.age:{1}\n", p4.name, p4.age);

Console.WriteLine(switchType());

Location loc = new Location(20, 30);

//tuple deconstruct
(int i, int j) = loc;

//print i and j
Console.WriteLine("**** tuple deconstruct ****");
Console.WriteLine("i:{0}\nj:{1}\n", i, j);



//tuple with return
static (string name, int age) getPerson()
{
    return ("kontai", 20);
}

//tuple with switch
static string switchType()
{
    object j = 2;
    return j switch
    {
        int => "int",
        string => "string",
        _ => "default"

    };
}

//tuple with out parameter
public struct Location
{
    int X;
    int Y;

    public Location(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);

}

