namespace CH20;

/*
 *
 *  public static int Count<T>(this IEnumerable<T> source)
 *  public T First<T>(this IEnumerable<T> source)
 *  public IEnumerable<T> Where<T>(this IEnumerable<T> source, ...)
 *
 */

public class StandartQueryExample
{
    private static int[] numbers = new int[] { 2, 4, 6 };

    public static void Main(string[] args)
    {
        //方法語法
        var total1 = Enumerable.Sum(numbers);
        var howMany1 = Enumerable.Count(numbers);
        Console.WriteLine($"Totla:{total1},Count:{howMany1}");

        //擴展語法
        int total2 = numbers.Sum();  //標準查詢的集合對象必須繼承IEnumberable<T>接口
        int howMany2 = numbers.Count();
        Console.WriteLine($"Totla:{total2},Count:{howMany2}");

        //方法語法調用如擴展語法調用在語義上是完全相等的，只是語法不同。

        //組合查詢表達式和標準表達式
        int howMany3 =
            (from n in numbers
             where n < 7
             select n).Count();

        Console.WriteLine($"Count: {howMany3}");

        int[] intArray = new int[] { 3, 4, 5, 6, 7, 8, 9 };

        //使用LINQ預定義委托類型(Func,Action)
        Func<int, bool> myDel = new Func<int, bool>(IsOdd); //委托對象
        var countOddDel = intArray.Count(myDel);
        Console.WriteLine($"Cont of odd numbers: {countOddDel}");

        //將委托作為參數(使用Lambda方式)
        var countOdd = intArray.Count(n => n % 2 == 1); //尋找奇數的Lambda表達式
        Console.WriteLine($"Cont of odd numbers: {countOdd}");

        //使用匿名方法(很Low , 建議使用Lambda表達式)
        Func<int, bool> myDel2 = delegate (int x)
        {
            return x % 2 == 1;
        };

        var countOdd2 = intArray.Count(myDel2);
        Console.WriteLine($"Cont of odd numbers: {countOdd2}");
    }

    private static bool IsOdd(int x)
    {
        return x % 2 == 1;
    }
}