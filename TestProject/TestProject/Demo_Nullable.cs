#nullable disable annotations 

string s1 = null;
string? s2 = null;
Console.WriteLine(s1);

Console.WriteLine(s1!.Length);

class Foo
{
    string x;
}