using System.Runtime.InteropServices;

var outerVariable = 0;

Func<int, int, bool> func1 = (int i, int j) =>
{
    if (i > j)
        return true;
    else return false;
};
bool result = func1(0, 1);
Console.WriteLine("Result: {0}", result);

//使用(_,_)表示不使用参数
Func<int, int, bool> func2 = (_, _) =>
{
    outerVariable++;
    return true;
};

//傳入兩個參數，但實際上不使用
bool result2 = func2(20, 30);
Console.WriteLine("Result: {0}", result2);

