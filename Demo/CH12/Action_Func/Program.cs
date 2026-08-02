// Action是一个委托类型，它表示一个没有返回值的方法
Action<string> actShow = msg =>
{
    Console.WriteLine($"*** Action Delegate ***\n=> {msg}\n******************************");
};

//Func是一个委托类型，它表示一个有返回值的方法,Func的最后一个参数是返回值
Func<int, int, int> addFun = Add;

var result = addFun(20, 30);
Console.WriteLine("*** Fun with Func ***");
Console.WriteLine($"Result: {result}");

static int Add(int x, int y) => x + y;