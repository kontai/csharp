Console.WriteLine("***** Fun with Nullable Value Types *****\n");
DatabaseReader dr = new DatabaseReader();
// If the value from GetIntFromDatabase() is null,
// assign local variable to 100.
int myData = dr.GetIntFromDatabase() ?? 100;    //如果函數返回值是null,則賦值100;
Console.WriteLine("Value of myData: {0}", myData);
func();
//Null-Coalescing Assignment Operator 
static void func()
{
    //Null-coalescing assignment operator
int? nullableInt = null;
nullableInt ??= 12;
nullableInt ??= 14;
Console.WriteLine(nullableInt);
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
