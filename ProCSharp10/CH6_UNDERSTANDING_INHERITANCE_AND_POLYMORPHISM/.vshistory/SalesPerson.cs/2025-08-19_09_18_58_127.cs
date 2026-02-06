namespace Employees;

class SalesPerson : Employee
{
    public int SalesNumber { get; set; }

    /// <summary>
    /// Gives the bonus.(業務員的加薪額度會根據銷售數量放大。)
    /// </summary>
    /// <param name="amount">The amount.</param>
    public override void GiveBonus(float amount)
    {
        int salesBonus = 0;
        if (SalesNumber >= 0 && SalesNumber <= 100)
            salesBonus = 10;
        else if (SalesNumber <= 200)
            salesBonus = 15;
        else
            salesBonus = 20;

        base.GiveBonus(amount * salesBonus);
    }

    public override void DisplayStats()
    {
        base.DisplayStats();
            Console.WriteLine($"Number of SaolesNumber: {SalesNumber}");

    }
}