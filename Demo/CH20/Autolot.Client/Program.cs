using AutoLot.Dal.DataOperations;
using AutoLot.Dal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
// using AutoLot.Dal.BulkImport;   // 本章後面才會建立，先註解掉
using Npgsql;

// 讀取 appsettings.json + 環境變數（密碼放在環境變數 Postgres__Password 或 SqlServer__Password）
var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .AddEnvironmentVariables()
    .Build();

InventoryDal dal = CreateDal(config);

// ① 列出所有車
List<CarViewModel> list = dal.GetAllInventory();
Console.WriteLine(" ************** All Cars ************** ");
Console.WriteLine($"{"Id", -4}{"Make", -8}{"Color", -10}Pet Name"); // 用對齊格式取代 \t
foreach (var itm in list)
{
    Console.WriteLine($"{itm.Id, -4}{itm.Make, -8}{itm.Color, -10}{itm.PetName}");
}
Console.WriteLine();

// ② 找顏色排第一的車；顏色相同時再依 Id 排序，結果才固定
int firstId = list.OrderBy(x => x.Color).ThenBy(x => x.Id).Select(x => x.Id).First();
CarViewModel? car = dal.GetCar(firstId);
if (car is null)
{
    Console.WriteLine($"找不到 Id = {firstId} 的車");
    return;
}
Console.WriteLine(" ************** First Car By Color ************** ");
Console.WriteLine($"{car.Id, -4}{car.Make, -8}{car.Color, -10}{car.PetName}");

// ③ 刪除 5 號車：應該會失敗（Orders 有相關資料）
try
{
    dal.DeleteCar(5);
    Console.WriteLine("Car deleted.");
}
catch (Exception ex)
{
    Console.WriteLine($"An exception occurred: {ex.Message}");
}

// ④ 新增：InsertAuto 直接傳回新 Id，不必再用暱稱回頭找
int newId = dal.InsertAuto(
    new Car
    {
        Color = "Blue",
        MakeId = 5,
        PetName = "TowMonster",
    }
);
CarViewModel? newCar = dal.GetCar(newId);
Console.WriteLine(" ************** New Car ************** ");
Console.WriteLine($"{newCar?.Id, -4}{newCar?.Make, -8}{newCar?.Color, -10}{newCar?.PetName}");

// ⑤ 刪掉剛新增的測試車，資料庫恢復原狀
dal.DeleteCar(newId);

// ⑥ 呼叫預存程序查暱稱
var petName = dal.LookUpPetName(car.Id);
Console.WriteLine(" ************** Look Up Pet Name ************** ");
Console.WriteLine($"Car pet name: {petName}");
Console.Write("Press enter to continue...");

// 依照你的 DAL 版本選擇其中一種寫法：
static InventoryDal CreateDal(IConfiguration config)
{
    // ── PostgreSQL 版 DAL（建構函式接受連線字串）──
    var csb = new Npgsql.NpgsqlConnectionStringBuilder(config["Postgres:ConnectionString"])
    {
        Password = config["Postgres:Password"],
    };
    //return new InventoryDal(csb.ConnectionString);

    // ── 如果你的 PostgreSQL 版 DAL 改成接受 NpgsqlDataSource（Npgsql 7 以上）──
    var dataSource = Npgsql.NpgsqlDataSource.Create(csb.ConnectionString);
    return new InventoryDal(dataSource); // dataSource 整個程式只建立一次

    //── SQL Server 版 DAL ──
    //var csb = new Microsoft.Data.SqlClient.SqlConnectionStringBuilder(config["SqlServer:ConnectionString"])
    //{ Password = config["SqlServer:Password"] };
    //return new InventoryDal(csb.ConnectionString);
}
