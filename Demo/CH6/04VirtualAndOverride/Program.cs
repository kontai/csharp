Console.WriteLine("Hello, World!");

Employee ep = new SalesEmployee();
ep.show();

abstract class Employee
{
    private int _bonus;

    public Employee()
    {
        _bonus = 100;
    }

    public virtual int GetBonus(int amount)
    {
        return 100;
    }
    public virtual void show()
    {
        Console.WriteLine("In base class");
    }
}

class SalesEmployee : Employee
{
    public override int GetBonus(int saleNum)
    {
        int Pay = 0;
        if (saleNum > 0 && saleNum < 100)
        {
            Pay = 10;
        }
        else if (saleNum >= 100 && saleNum < 200)
        {
            Pay = 15;
        }
        else
        {
            Pay = 20;
        }
        return Pay;
    }

    public override void show()
    {
        Console.WriteLine("In derived class");
    }
}
