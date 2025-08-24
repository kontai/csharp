var res=getTuple();
Console.WriteLine(res.a);
Console.WriteLine(res.b);
Console.WriteLine(res.c);


(int a, string b, int c) getTuple()
{
    return (1, "haha", 2);
}