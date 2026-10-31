using System.Data;
using System.Data.Common;
using Npgsql;
using Npgsql.Internal;

//PostgreSQL連線字串:host / port分開寫
var pg = new NpgsqlConnection(
    //"Host=172.20.85.218;Port=5432;Username=tai;Password=@@@;Database=autolot"
    "Host=127.0.0.1;Port=15432;Username=tai;Password=@@@;Database=autolot"
);
ShowServerInfo(pg);
GetPetName(pg);

static void ShowServerInfo(IDbConnection conn)
{
    conn.Open();
    using IDbCommand cmd = conn.CreateCommand();
    cmd.CommandText = "select version()"; //PostgreSQL的寫法
    Console.WriteLine(cmd.ExecuteScalar());
    string? ver = cmd.ExecuteScalar()?.ToString();
}

static void GetPetName(NpgsqlConnection conn)
{
    using var cmd = new NpgsqlCommand("CALL getpetname(@id,NULL)", conn);
    cmd.Parameters.Add(new NpgsqlParameter("id", 1));

    object? result = cmd.ExecuteScalar();
    Console.WriteLine(result is DBNull or null ? "(查無此車)" : result);
}
