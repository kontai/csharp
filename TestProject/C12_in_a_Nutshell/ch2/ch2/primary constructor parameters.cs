namespace ch2;

public class primary_constructor_parameters
{
    static void Main(string[] args)
    {
        Person p1 = new Person("kontai", "chou");
        p1.firstName="john";
        Console.WriteLine(p1.firstName);
         (string firstName, string lastName) = p1;
        Console.WriteLine($"firstName:{firstName} , lastName: {lastName}");
        string p_name = nameof(p1);
        Console.WriteLine($"p1 naem is {p_name}");
    }
}

class Person(string firstName, string lastName)
{
    public  string firstName = firstName;
    public string lastName { get; }= lastName;

    //diconstructor
    public void Deconstruct(out string firstName, out string lastName)
    {
        firstName = this.firstName;
        lastName = this.lastName;
    }



}