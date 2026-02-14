namespace CH20.查詢主體中片段;

public class letExample
{
    public static void Main(string[] args)
    {
        var GroupA = new[] { 3, 4, 5, 6 };
        var GroupB = new[] { 6, 7, 8, 9 };

        var ints =
            from a in GroupA
            from b in GroupB
            where a + b == 12
            select new { a, b };

        foreach (var x in ints)
        {
            Console.WriteLine(x);
        }

        Console.WriteLine();

        var someInts =
            from a in GroupA
            from b in GroupB
            let sum = a + b //在新變量保存結果
            where sum == 12
            select new { a, b, sum };

        foreach (var x in someInts)
        {
            Console.WriteLine(x);
        }
    }
}