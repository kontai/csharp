namespace Employees;

class Manager : Employee
{
    public Manager(string name, int id, int age, float pay, string ssn, int numberOfStockOptions)
        : base(name, id, age, pay, ssn, numberOfStockOptions)
    {
        StockOptions = 0; // 預設股票期權數量為0
    }

    public int StockOptions { get; set; }

    /// <summary>
    /// Gives the bonus. (經理除了加薪，還會隨機獲得一些股票期權。)
    /// </summary>
    /// <param name="amount">The amount.</param>
    public override sealed void GiveBonus(float amount)
    {
        base.GiveBonus(amount);
        Random r = new Random();
        StockOptions += r.Next(100);
    }

    public override void DisplayStats()
    {
        base.DisplayStats();
        Console.WriteLine($"Number of Stock Options: {StockOptions}");
    }
}