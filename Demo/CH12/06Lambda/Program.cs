TraditionalDelegateSyntex();
AnonymousMethodSyntax();
LambdaExpressionSyntex();
LambdaStatementSyntex();
LinqSyntex();

//Methos I
static void TraditionalDelegateSyntex()
{
    List<int> list = new() { 1, 2, 5, 7, 23, 12, 3 };
    Predicate<int> isEven = IsEven;
    List<int> evenList = list.FindAll(isEven);
    foreach (var i in evenList)
    {
        Console.WriteLine(i);
    }
}
static bool IsEven(int x)
{
    return (x % 2) == 0;
}

static void AnonymousMethodSyntax()
{
    List<int> list = new() { 1, 2, 5, 7, 23, 12, 3 };
    List<int> evenList = list.FindAll(
        delegate (int x)
        {
            return (x % 2) == 0;
        }
        );
    foreach (var i in evenList)
    {
        Console.WriteLine(i);
    }
}

static void LambdaExpressionSyntex()
{
    List<int> list = new() { 1, 2, 5, 7, 23, 12, 3 };
    List<int> evenList = list.FindAll((x) => x % 2 == 0);
    foreach (var i in evenList)
    {
        Console.WriteLine(i);
    }
}

static void LambdaStatementSyntex()
{
    List<int> list = new() { 1, 2, 5, 7, 23, 12, 3 };
    list.FindAll((x) =>
    {
        //第一行:卬出目前檢查的數字
        Console.WriteLine("現在讀取的是: {0}", x);

        //第二行:進行邏輯運算
        bool isEven = (x % 2) == 0;

        //第三行:回傳結果
        return isEven;
    });

}

static void LinqSyntex()
{
    List<int> list = new() { 1, 2, 5, 7, 23, 12, 3 };
    List<int> evenList = list.Where(x => x % 2 == 0).ToList();
    evenList.ForEach(x => Console.WriteLine(x));
}