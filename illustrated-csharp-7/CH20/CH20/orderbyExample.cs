namespace CH20;

public class orderbyExample
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

        var query = from student in students
                    orderby student.Age
                    select student;
        foreach (var s in query)
        {
            //Console.WriteLine($"{s.LName},{s.FName}:\t{s.Age},{s.Major}");
        }
    }
}
