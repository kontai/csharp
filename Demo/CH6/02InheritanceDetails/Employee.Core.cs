namespace Employees;

internal partial class Employee
{
    // 欄位資料 (Field data)
    protected string EmpName;

    protected int EmpId;
    protected float CurrPay;
    protected int EmpAge;

    // 建構函式 (Constructors)
    public Employee()
    { }

    public Employee(string name, int id, float pay)
        : this(name, id, pay, 0) { }

    public Employee(string name, int id, float pay, int age)
    {
        EmpName = name;
        EmpId = id;
        CurrPay = pay;
        EmpAge = age;
    }
}