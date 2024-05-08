namespace CH17;

internal class Employee : Person
{ }

internal class Person
{
    public string Name;
    public int Age;

    public static implicit operator int(Person p)   //將person轉成int
    {
        return p.Age;
    }
}

public class MultiStepUserDefinedConversion
{
    private static void Main(string[] args)
    {
        Employee bill = new Employee();

        if (bill is Person) //檢查bill是否為Person類型
        {
            bill.Name = "William";
            bill.Age = 25;
            float fVar = bill;  //Employee to Person to int to float

            Console.WriteLine($"Person Info: {bill.Name}, {fVar}");

            Person p;
            p = bill as Person;
            if (bill != null)
            {
                Console.WriteLine($"Person Info: {p.Name}, {p.Age}");
            }
        }
    }
}