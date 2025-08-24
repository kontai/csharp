namespace ch2;

public class primary_constructor_parameters
{
    static void Main(string[] args)
    {
        Person p1 = new Person("kontai", "chou");
        p1.firstName="john";
        Console.WriteLine(p1.firstName);
    }
}

class Person(string firstName, string lastName)
{
    public  string firstName = firstName;
    public string lastName { get; }= lastName;
    public Person(string firstname)

}