namespace Employees;

partial class Employee
{
    // 屬性 (Properties)
    public string Name
    {
        get { return EmpName; }
        set
        {
            if (value.Length > 15)
                Console.WriteLine("Error! Name length exceeds 15 characters!");
            else
                EmpName = value;
        }
    }

    public int Id
    {
        get { return EmpId; }
        set { EmpId = value; }
    }

    public float Pay
    {
        get { return CurrPay; }
        set { CurrPay = value; }
    }

    public int Age
    {
        get { return EmpAge; }
        set { EmpAge = value; }
    }

    // 方法 (Methods)
    public void GiveBonus(float amount)
    {
        CurrPay += amount;
    }

    public void DisplayStats()
    {
        Console.WriteLine("Name: {0}", EmpName);
        Console.WriteLine("ID: {0}", EmpId);
        Console.WriteLine("Age: {0}", EmpAge);
        Console.WriteLine("Pay: {0}", CurrPay);
    }
}