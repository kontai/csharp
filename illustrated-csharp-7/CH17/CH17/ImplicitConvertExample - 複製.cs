namespace CH17;

internal class Person
{
    public string Name;
    public int Age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public static implicit operator int(Person p)   //將person轉成int
    {
        return p.Age;
    }

    public static implicit operator Person(int i)   //將int轉成person
    {
        return new Person("Nemo", i);   //("Nemo" is latin for "No One".)
    }
}

public class ImplicitConvertExample
{
    private static void Main(string[] args)
    {
        Person bill = new Person("bill", 25);

        int age = bill;
        Console.WriteLine($"Person Info: {bill.Name},{age}");

        Person anon = 35;
        Console.WriteLine($"Person Info: {anon.Name}, {anon.Age}");
    }
}