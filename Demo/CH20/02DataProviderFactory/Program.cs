using System.Data.Common;
using System.Data.Odbc;
using DataProviderFactory;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Npgsql;

Console.WriteLine("***** Fun with Data Provider Factories *****\n");

var (provider, connectionString) = GetProviderFromConfiguration();
DbProviderFactory factory = GetDbProviderFactory(provider);

// CreateConnection() 的回傳型別是 DbConnection?，用 ?? 確保不是 null
using DbConnection connection =
    factory.CreateConnection() ?? throw new InvalidOperationException("工廠無法建立連線物件");
Console.WriteLine($"Your connection object is a: {connection.GetType().Name}");

connection.ConnectionString = connectionString;
connection.Open();

if (connection is SqlConnection sqlConn)
{
    // 只有 SQL Server 才有的功能：開啟連線統計
    sqlConn.StatisticsEnabled = true;
}
else if (connection is NpgsqlConnection npgConn)
{
    // 只有 PostgreSQL 才有的資訊
    Console.WriteLine($"PostgreSql版本: {npgConn.PostgreSqlVersion}");
}

// 命令物件也要 using 釋放（原書沒有寫）
using DbCommand command =
    factory.CreateCommand() ?? throw new InvalidOperationException("工廠無法建立命令物件");
Console.WriteLine($"Your command object is a: {command.GetType().Name}");
command.Connection = connection;

// 加上 ORDER BY，讓輸出順序固定；這句 SQL 在 SQL Server 和 PostgreSQL 都能跑
command.CommandText =
    "SELECT i.Id, m.Name FROM Inventory i INNER JOIN Makes m ON m.Id = i.MakeId ORDER BY i.Id";

using DbDataReader dataReader = command.ExecuteReader();
Console.WriteLine($"Your data reader object is a: {dataReader.GetType().Name}");
Console.WriteLine("\n***** Current Inventory *****");
while (dataReader.Read())
{
    // 用欄位位置（0、1）取值，避免 PostgreSQL 欄位名稱被轉成小寫的問題
    Console.WriteLine($"-> Car #{dataReader.GetInt32(0)} is a {dataReader.GetString(1)}.");
}

static DbProviderFactory GetDbProviderFactory(DataProviderEnum provider) =>
    provider switch
    {
        DataProviderEnum.SqlServer => SqlClientFactory.Instance,
        DataProviderEnum.Odbc => OdbcFactory.Instance,
        DataProviderEnum.Postgresql => NpgsqlFactory.Instance, // 新增這一行就好
        // 不回傳 null，直接拋出例外，錯誤訊息比 NullReferenceException 清楚
        _ => throw new ArgumentOutOfRangeException(
            nameof(provider),
            $"不支援的資料提供者：{provider}"
        ),
    };

static (DataProviderEnum Provider, string ConnectionString) GetProviderFromConfiguration()
{
    IConfiguration config = new ConfigurationBuilder()
        .SetBasePath(AppContext.BaseDirectory) // 用 exe 所在的資料夾找設定檔
        .AddJsonFile("appsettings.json", optional: false) // 找不到檔案就直接報錯
        .AddUserSecrets<Program>()
        .Build();

    string? providerName = config["ProviderName"];
    string? pass = config["Postgresql:password"];

    // ignoreCase: true → "sqlserver" 也能接受
    // Enum.IsDefined → 擋掉 "99" 這種數字字串（TryParse 會把它當成合法值）
    if (
        Enum.TryParse(providerName, ignoreCase: true, out DataProviderEnum provider)
        && Enum.IsDefined(provider)
    )
    {
        string connStr =
            config[$"{provider}:ConnectionString"]
            ?? throw new InvalidOperationException($"找不到 {provider} 的連線字串");
        // 連線字串的參數分隔符號是分號 ; 不是逗號
        if (!string.IsNullOrEmpty(pass))
        {
            connStr = connStr.TrimEnd(';') + $";Password={pass}";
        }
        // 不要印出含密碼的連線字串
        Console.WriteLine($"使用資料提供者：{provider}");

        return (provider, connStr);
    }
    throw new InvalidOperationException($"無效的資料提供者設定值：{providerName}");
}
