nullableMembers();

//#nullable disable   //關閉nullable警告
Person? p = new Person { Name = "John", Age = 30 };
Person? p2 = null;
Person? p3 = p2;

string? anotherNullableString = null;

Console.WriteLine(p?.Name);

Console.WriteLine("Length of name= {0}", p2?.Name.Length ?? 20);    //p2.Name == null ? 20 : p2.Name.Length
Console.WriteLine("Length of name= {0}", p2?.Name == null ? 20 : p2.Name.Length);

static void nullableMembers()
{
    int? i = 20;
    Console.WriteLine(i.HasValue);
    if (i.HasValue)
    {
        Console.WriteLine("i has value: {0}", i.Value);
    }
}

static void LocalNullableVariables()
{
    //Define some local nullable variables
    int? nullableInt = 10;
    double? nullbaleDouble = 3.14;
    bool? nullbaleBool = null;
    char? nullableChar = 'a';
    var arrayOfNullableInts = new int?[20];
}

class Person
{
    public required string Name;
    public int Age;
}