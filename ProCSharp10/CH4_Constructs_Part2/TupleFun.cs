var res = FunWithTuple();
Console.WriteLine(res.a);
Console.WriteLine(res.b);
Console.WriteLine(res.c);


static (int a, string b, int c) FunWithTuple()
{
    return (1, "haha", 2);
}

static string TupleAndSwitch(Person p)
{
    return p switch
    {
        { age: < 18 } => "未成年人",
        { age: >= 18, name: "张三" } => "成年人，名字是张三",
        { age: >= 18, name: "李四" } => "成年人，名字是李四",
        _ => "其他情况"
    };
}

class Person
{
    public int age = 20;
    public string name = "tai";
}