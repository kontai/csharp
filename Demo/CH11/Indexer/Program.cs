using System.Collections;

Person p = new Person();
p["tai"] = new Person("tai", 20);
p["jack"] = new Person("jack", 30);

Console.WriteLine("Name: {0}, Age: {1}", p["tai"].Name, p["tai"].Age);

internal class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    private Dictionary<string, Person> people = new Dictionary<string, Person>();

    public Person()
    {
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    //Indexer
    public Person this[string name]
    {
        get => (Person)people[name];
        set => people[name] = value;
    }
}