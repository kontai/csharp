namespace CH20;

public class GroupByExample
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
            from student in students
            group student by student.Major;

        foreach (var q in query)    //枚舉分組
        {
            Console.WriteLine(q.Key);   //分組鍵   

            foreach (var g in q)    //枚舉分組中的項
            {
                Console.WriteLine($"    {g.LName},{g.FName} ");
            }
        }
    }
}