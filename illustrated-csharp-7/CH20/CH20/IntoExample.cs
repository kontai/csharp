namespace CH20;

public class IntoExample
{
    public static void Main(string[] args)
    {
        var groupA = new[] { 3, 4, 5, 6 };
        var groupB = new[] { 4, 5, 6, 7 };

        var query =
            from a in groupA
            join b in groupB on a equals b
            into goupAandB  //查詢延續
            from c in goupAandB
            select c;

        foreach (var v in query)
        {
            Console.WriteLine($"{v}");
        }
    }
}