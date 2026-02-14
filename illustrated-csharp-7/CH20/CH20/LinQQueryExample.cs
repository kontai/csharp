namespace CH20;

public class LinQQueryExample
{
    private static void Main(string[] args)
    {
        int[] numbers = { 2, 5, 28, 31, 18, 17, 42 };

        var numQuery = from n in numbers        //查詢語法
                       where n < 20
                       select n;

        var numsMethod = numbers.Where(n => n < 20);        //方法語法

        var numCount = (                     //兩種形式的組合
            from n in numbers
            where n < 20
            select n).Count();

        foreach (var x in numQuery)
        {
            Console.Write($"{x}, ");
        }
        Console.WriteLine();

        foreach (var x in numsMethod)
        {
            Console.Write($"{x}, ");
        }
        Console.WriteLine();

        Console.WriteLine(numCount);
    }
}