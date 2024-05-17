namespace CH20.查詢主體中片段;

public class fromExample
{
    public static void Main(string[] args)
    {
        var GroupA = new[] { 3, 4, 5, 6 };
        var GroupB = new[] { 6, 7, 8, 9 };

        var someInts =
            from a in GroupA    //必須的第一個from子句
            from b in GroupB    //查詢主體的第一個子句
            where a > 4 && b <= 8
            select new { a, b, sum = a * b };   //匿名類型對象

        foreach (var x in someInts)
        {
            Console.WriteLine(x);
        }
    }
}