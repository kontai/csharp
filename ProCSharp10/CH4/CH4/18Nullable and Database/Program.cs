// --- 呼叫端 ---
DatabaseReader dr = new DatabaseReader();

// 情境 A: 讀取到 null
int? i = dr.GetIntFromDatabase();

// 檢查方式 1: 使用 .HasValue 屬性 (這是最標準的做法)
if (i.HasValue)
{
    Console.WriteLine("Value of 'i' is: {0}", i.Value);
}
else
{
    Console.WriteLine("Value of 'i' is undefined."); // 這行會被執行
}

// 情境 B: 讀取到數值
bool? b = dr.GetBoolFromDatabase();

// 檢查方式 2: 使用 C# 運算子 != null (這其實是語法糖，底層也是檢查 HasValue)
if (b != null)
{
    Console.WriteLine("Value of 'b' is: {0}", b.Value); // 這行會被執行
}
else
{
    Console.WriteLine("Value of 'b' is undefined.");
}

internal class DatabaseReader
{
    // 模擬資料庫欄位
    // numericValue 模擬資料庫裡的 NULL (例如使用者沒填年齡)
    public int? numericValue = null;

    // boolValue 模擬資料庫裡的 True (例如訂閱狀態)
    public bool? boolValue = true;

    // 回傳型別必須是 int? (可為空)，因為資料庫可能沒資料
    public int? GetIntFromDatabase()
    { return numericValue; }

    public bool? GetBoolFromDatabase()
    { return boolValue; }
}