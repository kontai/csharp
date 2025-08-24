namespace Employees;

public class Employee
{
    // 公開屬性
    public string Name { get; set; }
    public int ID { get; set; }
    public int Age { get; set; }
    public float Pay { get; set; }
    public string SSN { get; set; } // 社會安全號碼
    public int NumberOfStockOptions { get; set; }

    // 建構函式
    public Employee()
    {
        // 預設建構函式
    }

    // 帶參數的建構函式
    public Employee(string name, int id, int age, float pay, string ssn, int numberOfStockOptions)
    {
        Name = name;
        ID = id;
        Age = age;
        Pay = pay;
        SSN = ssn; //SocialSecurityNumber
        NumberOfStockOptions = numberOfStockOptions;
    }

    public virtual void GiveBonus(float amount)
    {
        Pay += amount;
    }
    public virtual void DisplayStats()
{
    Console.WriteLine($"Name: {Name}");
    Console.WriteLine($"Id: {ID}");
    Console.WriteLine($"Age: {Age}");
    Console.WriteLine($"Pay: {Pay}");
    Console.WriteLine($"SSN: {SSN}");
}


    // 可選：覆寫 ToString() 方法以便於顯示員工資訊
    public override string ToString()
    {
        return $"Name: {Name}, ID: {ID}, Age: {Age}, Pay: {Pay:C}, SSN: {SSN}, Stock Options: {NumberOfStockOptions}";
    }
}