using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Npgsql;

Console.WriteLine("*** Fun With Data Reader***");

IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    //.AddUserSecrets<Program>()
    .AddEnvironmentVariables()
    .Build();

//string connString = @"Host=127.0.0.1;Port=15432;Database=autolot;Username=tai;Password=@@@";
var connStringBuilder = new NpgsqlConnectionStringBuilder();
connStringBuilder.Host = "127.0.0.1";
connStringBuilder.Port = 15432;
connStringBuilder.Database = "autolot";
connStringBuilder.Username = "tai";
connStringBuilder.Password =
    config["Postgresql:password"] ?? throw new InvalidOperationException("找不到密碼");

// 全域建立一次即可
using var dataSource = NpgsqlDataSource.Create(connStringBuilder);

//從連線池中取得一個連線,並在結束時自動釋放
using var command = dataSource.CreateCommand(
    "Select i.id, m.Name as Make, i.Color, i.Petname FROM Inventory"
        + " i INNER JOIN Makes m on m.Id = i.MakeId"
);

using var myDataReader = await command.ExecuteReaderAsync();
while (await myDataReader.ReadAsync())
{
    Console.WriteLine(
        $"-> Make: {myDataReader["Make"]}, PetName: {myDataReader 
["PetName"]}, Color: {myDataReader["Color"]}."
    );
}
