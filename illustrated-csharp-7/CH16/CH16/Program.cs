internal interface IInfo
{
    string GetName();

    string GetAge();
}

internal class CA : IInfo
{
    public string Name;
    public int Age;

    public string GetName()
    { return Name; }

    public string GetAge()
    { return Age.ToString(); }
}

internal class CB : IInfo
{
    public string First;
    public string Last;
    public double PersonAge;

    public string GetName()
    { return First + " " + Last; }

    public string GetAge()
    { return PersonAge.ToString(); }
}

internal class Program
{
    private static void PrintInfo(IInfo item)
    {
        Console.WriteLine("Name: {0},Age: {1}", item.GetName(), item.GetAge());
    }

    private static void Main(string[] args)
    {
        CA a = new CA() { Name = "John Joe", Age = 35 };
        CB b = new CB() { First = "Jame", Last = "Doe", PersonAge = 33 };

        PrintInfo(a);
        PrintInfo(b);
    }
}