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

    public static explicit operator int(Person p)   //將person轉成int
    {
        return p.Age;
    }

    public static explicit operator Person(int i)   //將int轉成person
    {
        return new Person("Nemo", i);   //("Nemo" is latin for "No One".)
    }
}

public class ExplicitConvertExample
{
    private static void Main(string[] args)
    {
        Person bill = new Person("bill", 25);

        int age = (int)bill;    //使用顯式轉型將person轉成int
        Console.WriteLine($"Person Info: {bill.Name},{age}");

        Person anon = (Person)35;   //使用顯式轉型將int轉成person
        Console.WriteLine($"Person Info: {anon.Name}, {anon.Age}");
    }
}