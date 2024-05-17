namespace CH20.查詢主體中片段;

public class whereExample
{
    public static void Main(string[] args)
    {
        var GroupA = new[] { 3, 4, 5, 6 };
        var GroupB = new[] { 6, 7, 8, 9 };

        var someInts =
            from int a in GroupA
            from int b in GroupB
            let sum = a + b
            where sum >= 11     //條件一
            where a == 4    //條件二
            select new { a, b, sum };

        foreach (var x in someInts)
        {
            Console.WriteLine(x);
        }
    }
}