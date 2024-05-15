namespace CH20;

class Others
{
    public static string Name = "Mary Jones";
}
public class AnonymousClass
{
    static void Main(string[] args)
    {
        string Major = "History";

        //匿名類，無類名，變量類型一定要是var
        //var student = new { Name = "Mary Jones", Age = 15, Major = "History" };

        //匿名類成員有三種聲明方式
        var student = new
        {
            Age = 15,   //賦值表達式
            Others.Name,    //成員訪問表達式
            Major   //標識符
        };

        Console.WriteLine($"{student.Name}, Age {student.Age}, Major: {student.Major}");
    }
}