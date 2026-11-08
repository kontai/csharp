using AutoLot.Dal.DataOperations;
using AutoLot.Dal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Npgsql;

//建立連線

//讀取設定檔

// 連線字串和密碼從設定檔 + 環境變數讀取（上兩回學的做法）
var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .AddEnvironmentVariables()
    .Build();

string? password =
    config["Postgresql:Password"] ?? throw new InvalidOperationException("無法取得密碼.");
var csb = new NpgsqlConnectionStringBuilder()
{
    Host = "127.0.0.1",
    Port = 15432,
    Username = "tai",
    Database = "autolot",
    Password = password,
};

//建立單獨的連線,所有的資料操作都透過這個連線
await using NpgsqlDataSource _dataSource = NpgsqlDataSource.Create(csb.ConnectionString);

/*
using var dbSource = NpgsqlDataSource.Create(connBuiler.ConnectionString);
using var conn = dbSource.CreateConnection();
conn.Open();
using var cmd = new NpgsqlCommand(
    "UPDATE inventory SET color = @newColor WHERE color = @oldColor",
    conn
);

cmd.Parameters.AddWithValue("newColor", "Midnight Black");
cmd.Parameters.AddWithValue("oldColor", "Black");
Console.WriteLine($"更新了 {cmd.ExecuteNonQuery()} 筆");

using var cmd2 = new NpgsqlCommand(
    "UPDATE inventory SET color = @newColor WHERE color = @oldColor",
    conn
);

cmd2.Parameters.AddWithValue("newColor", "Black");
cmd2.Parameters.AddWithValue("oldColor", "Midnight Black");
Console.WriteLine($"還原了 {cmd2.ExecuteNonQuery()} 筆");
*/

var Mydal = new InventoryDal(_dataSource);

InsertCarsFunc(Mydal);

//Mydal.DeleteCar(1);

// 新增一台測試車 → 改名 → 刪除
int testId = Mydal.InsertAuto(
    new Car
    {
        MakeId = 1,
        Color = "Gray",
        PetName = "TestCar",
    }
);
Mydal.UpdateCarPetName(testId, "Renamed");
Console.WriteLine($"改名後：{Mydal.GetCar(testId)?.PetName}"); // Renamed
Mydal.DeleteCar(testId);
Console.WriteLine($"刪除後：{Mydal.GetCar(testId)?.PetName ?? "找不到了"}");

void InsertCarsFunc(InventoryDal dal)
{
    // 新增：暱稱有單引號也沒問題了
    int newId = dal.InsertAuto(
        new Car
        {
            MakeId = 1,
            Color = "Red",
            PetName = "O'Malley",
        }
    );
    Console.WriteLine($"新增成功，新車 Id = {newId}");

    // 查詢單筆
    CarViewModel? car = dal.GetCar(newId);
    Console.WriteLine(car is null ? "找不到" : $"{car.PetName} 是一台 {car.Color} 的 {car.Make}");

    // 查詢全部
    foreach (var c in dal.GetAllInventory())
        Console.WriteLine($"#{c.Id} {c.Make, -6} {c.Color, -8} {c.PetName}");
}

void DeleteCarsFun(InventoryDal da, int id)
{
    try
    {
        if (da.DeleteCar(id)) { }
        {
            Console.WriteLine("刪除成功");
        }
    }
    catch (PostgresException ex)
    {
        Console.WriteLine("主程式catch");
        Console.WriteLine($"刪除失敗，找不到 Id = {id} 的車");
        Console.WriteLine(ex.SqlState, ex.Message);
    }
}
