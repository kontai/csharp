
int res = NormalAddWrapper(1, 2);
Console.WriteLine(res);

int res2 = StaticAddWrapper(1, 2);
Console.WriteLine(res2);

static int StaticAddWrapper(int v1, int v2)
{
    return Add(v1, v2);
    static int Add(int x,int y) 
    {
        return x + y;
    }


}

Console.WriteLine(res2);

static int NormalAddWrapper(int x, int y)
{
    return Add();
    int Add()
    {
        return x + y;
    }
}