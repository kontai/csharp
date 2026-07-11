namespace Employees;
// Manager (經理) "是一種" Employee (員工)
// 經理除了有員工的基本資料，還特權擁有一項專屬資料：股票選擇權 (StockOptions)
class Manager : Employee
{
    // 自動實作屬性：記錄經理分到多少股票
    public int StockOptions { get; set; }
}