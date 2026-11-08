using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using NpgsqlTypes;

namespace AutoLot.Dal.DataOperations; // 修正拼字：AutoLot

public class InventoryDal
{
    private readonly string _connectionString;
    private readonly NpgsqlDataSource _dataSource;

    // 不提供「寫死密碼」的無參數建構函式，強迫呼叫端傳入連線字串
    public InventoryDal(string connectionString) =>
        _connectionString =
            connectionString ?? throw new ArgumentNullException(nameof(connectionString));

    public InventoryDal(NpgsqlDataSource dataSource) => _dataSource = dataSource;

    private const string SelectSql =
        @"SELECT i.Id, i.MakeId, i.Color, i.PetName, m.Name AS Make
          FROM Inventory i
          INNER JOIN Makes m ON m.Id = i.MakeId";

    public List<CarViewModel> GetAllInventory()
    {
        // 每個方法自己建立、自己釋放連線；連線集區會重複利用底層連線，不會變慢
        //using var connection = new NpgsqlConnection(_connectionString);
        //connection.Open();
        //using var command = new NpgsqlCommand(SelectSql + " ORDER BY i.Id", connection);

        using var command = _dataSource.CreateCommand(SelectSql + " ORDER BY i.Id");
        using NpgsqlDataReader reader = command.ExecuteReader(); // 出例外也會被 using 關閉

        var inventory = new List<CarViewModel>();
        while (reader.Read())
        {
            inventory.Add(MapCar(reader));
        }
        return inventory;
    }

    public CarViewModel? GetCar(int id) // 找不到時回傳 null，所以標成 CarViewModel?
    {
        //using var connection = new NpgsqlConnection(_connectionString);
        //connection.Open();
        //using var command = new NpgsqlCommand(SelectSql + " WHERE i.Id = @id", connection);
        using var command = _dataSource.CreateCommand(SelectSql + " WHERE i.Id = @id");
        command.Parameters.Add("@id", NpgsqlDbType.Integer).Value = id; // 參數化查詢

        using NpgsqlDataReader reader = command.ExecuteReader();
        return reader.Read() ? MapCar(reader) : null; // 只讀一筆，用 if 不用 while
    }

    public int InsertAuto(Car car)
    {
        //using var connection = new NpgsqlConnection(_connectionString);
        //connection.Open();
        const string sql =
            @"INSERT INTO Inventory (MakeId, Color, PetName)
              VALUES (@makeId, @color, @petName)
                RETURNING Id";
        //using var command = new NpgsqlCommand(sql, connection);
        using var command = _dataSource.CreateCommand(sql);
        command.Parameters.Add("@makeId", NpgsqlDbType.Integer).Value = car.MakeId;
        command.Parameters.Add("@color", NpgsqlDbType.Varchar, 50).Value = car.Color;
        command.Parameters.Add("@petName", NpgsqlDbType.Varchar, 50).Value = car.PetName;

        return (int)command.ExecuteScalar()!; // 有 OUTPUT，所以用 ExecuteScalar 取新 Id
    }

    // 保留書中「三個參數」的版本，內部轉呼叫強型別版本
    public int InsertAuto(string color, int makeId, string petName) =>
        InsertAuto(
            new Car
            {
                Color = color,
                MakeId = makeId,
                PetName = petName,
            }
        );

    // 把「讀取器的一列」轉成 CarViewModel，避免在每個方法重複寫
    private static CarViewModel MapCar(NpgsqlDataReader reader) =>
        new()
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id")),
            MakeId = reader.GetInt32(reader.GetOrdinal("MakeId")),
            Color = reader.GetString(reader.GetOrdinal("Color")),
            PetName = reader.GetString(reader.GetOrdinal("PetName")),
            Make = reader.GetString(reader.GetOrdinal("Make")),
        };

    public bool DeleteCar(int id)
    {
        //using var connection = new NpgsqlConnection(_connectionString);
        //connection.Open();
        //using var command = new NpgsqlCommand(sql, connection);
        using var command = _dataSource.CreateCommand("DELETE FROM inventory WHERE id=@id");
        command.Parameters.Add(new NpgsqlParameter<int>("id", id));
        try
        {
            return command.ExecuteNonQuery() > 0;
        }
        catch (PostgresException ex) when (ex.SqlState == PostgresErrorCodes.ForeignKeyViolation)
        {
            throw new InvalidOperationException($"車子 {id} 已有訂單，無法刪除。", ex);
            return false;
        }
        catch (PostgresException ex)
        {
            // 其他資料庫端錯誤
            Console.WriteLine($"Postgres 錯誤 [{ex.SqlState}]: {ex.MessageText}");
            return false;
        }
        catch (NpgsqlException ex)
        {
            // 網路中斷、連線超時等非資料庫回傳的連線層級錯誤
            Console.WriteLine($"網路或連線層錯誤: {ex.Message}");
            return false;
        }
    }

    public void UpdateCarPetName(int id, string newPetName)
    {
        //var connection = new NpgsqlConnection(_connectionString);
        //connection.Open();

        //var command = new NpgsqlCommand(sql, connection);
        using var command = _dataSource.CreateCommand(
            "UPDATE inventory SET petname=@newPetName WHERE Id=@id"
        );
        //command.Parameters.AddWithValue("id", id);    //包裝成object
        //command.Parameters.AddWithValue("petname", newPetName); //包裝成object
        command.Parameters.Add(new NpgsqlParameter<int>("id", id));
        command.Parameters.Add(new NpgsqlParameter<string>("newPetName", newPetName));
        command.ExecuteNonQuery();
    }
}
