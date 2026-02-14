namespace ch2;

public class primary_constructor_parameters
{
    static void Main(string[] args)
    {

    }
}

class Person(string firstName, string lastName, int age)
{
    private readonly string firstName = firstName;
    public string lastName { get; }= lastName;

}