namespace FunWithGenericCollections;

public class Person : IDisposable
{
    public int Age { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Person() { }
    public Person(string firstName, string lastName, int age)
    {
        Age = age;
        FirstName = firstName;
        LastName = lastName;
    }
    public override string ToString()
    {
        return $"Name: {FirstName} {LastName}, Age: {Age}";
    }

    public void Dispose()
    {
        Console.WriteLine($"Disposing {FirstName} {LastName}");
    }
    //System.GC
    ~Person()
    {
        Console.WriteLine($"Finalizing {FirstName} {LastName}");
    }

}