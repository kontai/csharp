namespace Employees;
// SalesPerson (業務員) "是一種" Employee (員工)
// 業務員的專屬功能：記錄他們賣出了多少業績 (SalesNumber)
class SalesPerson : Employee
{
    public SalesPerson()
    {

    }
    public SalesPerson(string name, int id, float pay, int age, int salesNumber) : base(name, id, pay, age)
    {
        SalesNumber = salesNumber;
    }
    public int SalesNumber { get; set; }

}