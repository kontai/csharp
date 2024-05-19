namespace CH20;

public class selectExample
{
    public static void Main(string[] args)
    {
        var students = new[]
        {
            new { LName = "Jones", FName = "Mary", Age = 19, Major = "history" },
            new { LName = "Smith", FName = "Bob", Age = 20, Major = "math" },
            new { LName = "Williams", FName = "Sally", Age = 21, Major = "english" },
            new { LName = "Brown", FName = "Joe", Age = 22, Major = "science" }
        };

        var query =
                    from s in students  //查詢整個數據
                    select s;
        foreach (var x in query)
        {
            Console.WriteLine($"x.LName = {x.LName}, x.FName = {x.FName}, x.Age = {x.Age}, x.Major = {x.Major}");
        }

        Console.WriteLine();

        var query2 =
            from s in students  //只選擇學生的姓氏
            select s.LName;
        foreach (var x in query2)
        {
            Console.WriteLine(x);
        }

        Console.WriteLine();

        var query3 =
            from s in students
            select new { s.LName, s.FName, s.Major };
        foreach (var q in query3)
        {
            Console.WriteLine($"{q.FName} {q.LName} -- {q.Major}");
        }
    }
}