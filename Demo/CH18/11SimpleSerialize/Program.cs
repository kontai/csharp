using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using SimpleSerialize;

Console.WriteLine("***** Fun with Object Serialization *****\n");

// 建立一個共用的收音機物件,稍後由多台車參照
var theRadio = new Radio
{
    StationPresets = new() { 89.3, 105.1, 97.1 },
    HasTweeters = true,
};

// 建立單一 JamesBondCar,內含自己的 Radio 物件
JamesBondCar jbc = new()
{
    CanFly = true,
    CanSubmerge = false,
    TheRadio = new()
    {
        StationPresets = new() { 89.3, 105.1, 97.1 },
        HasTweeters = true,
    },
};

// 建立四台車(CanFly / CanSubmerge 的四種組合),共用同一個 theRadio,用來示範集合序列化
List<JamesBondCar> myCars = new()
{
    new JamesBondCar
    {
        CanFly = true,
        CanSubmerge = true,
        TheRadio = theRadio,
    },
    new JamesBondCar
    {
        CanFly = true,
        CanSubmerge = false,
        TheRadio = theRadio,
    },
    new JamesBondCar
    {
        CanFly = false,
        CanSubmerge = true,
        TheRadio = theRadio,
    },
    new JamesBondCar
    {
        CanFly = false,
        CanSubmerge = false,
        TheRadio = theRadio,
    },
};

Person p = new Person { FirstName = "James", IsAlive = true };

// XML 序列化:將單一物件、另一種型別的物件、以及物件集合分別存檔
SaveAsXmlFormat(jbc, "CarData.xml");
Console.WriteLine("=> Saved car in XML format!");
SaveAsXmlFormat(p, "PersonData.xml");
Console.WriteLine("=> Saved person in XML format!");
SaveAsXmlFormat(myCars, "CarCollection.xml");
Console.WriteLine("=> Saved list of cars!");

// XML 反序列化:讀回檔案並與原物件比對輸出
JamesBondCar savedCar = ReadAsXmlFormat<JamesBondCar>("CarData.xml");
Console.WriteLine("Original Car:\n {0}", jbc.ToString());
Console.WriteLine("Read Car:\n {0}", savedCar.ToString());
List<JamesBondCar> savedCars = ReadAsXmlFormat<List<JamesBondCar>>("CarCollection.xml");
foreach (var item in savedCars)
{
    Console.WriteLine("Car:\t {0}", item.ToString());
}

//Json序列化
JsonSerializerOptions options = new()
{
    // 反序列化時,屬性名稱不區分大小寫
    PropertyNameCaseInsensitive = true,
    //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    // null 表示保留原本的 PascalCase 名稱,不轉成 camelCase (Jsom預設是camelCase)
    PropertyNamingPolicy = null,
    // 預設只處理屬性;設為 true 才會包含公開欄位(本範例的類別多為欄位)
    IncludeFields = true,
    // 輸出縮排格式,方便閱讀
    WriteIndented = true,
    // 數字寫出時轉成字串,讀入時允許從字串解析數字
    NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString,
};
SaveAsJsonFormat(options, jbc, "CarData.json");
Console.WriteLine("=> Saved car in JSON format!");
SaveAsJsonFormat(options, p, "PersonData.json");
Console.WriteLine("=> Saved person in JSON format!");

// 將物件序列化為 JSON 字串並寫入檔案
static void SaveAsJsonFormat<T>(JsonSerializerOptions options, T objGraph, string fileName) =>
    File.WriteAllText(fileName, System.Text.Json.JsonSerializer.Serialize(objGraph, options));

// 將物件序列化為 XML 並寫入檔案(FileMode.Create:檔案存在則覆寫)
static void SaveAsXmlFormat<T>(T obj, string fileName)
{
    XmlSerializer serializer = new XmlSerializer(typeof(T));
    // using 確保檔案串流使用完畢後會被關閉並釋放
    using (var writer = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
    {
        serializer.Serialize(writer, obj);
    }
}

// 從 XML 檔案讀取並反序列化為型別 T 的物件
static T ReadAsXmlFormat<T>(string fileName)
{
    XmlSerializer read = new XmlSerializer(typeof(T));

    using (var reader = new FileStream(fileName, FileMode.Open))
    {
        // Deserialize 回傳 object,需轉型為 T
        T obj = (T)read.Deserialize(reader);
        return obj;
    }
}

// 以下為非同步 JSON 序列化範例(目前 Program 並未呼叫)

// 非同步串流:逐一產生 0 ~ n-1 的數字
static async IAsyncEnumerable<int> PrintNumbers(int n)
{
    for (int i = 0; i < n; i++)
    {
        yield return i;
    }
}

// 非同步序列化:將含有 IAsyncEnumerable 的匿名物件直接寫到標準輸出串流
static async void SerializeAsync()
{
    Console.WriteLine("Async Serialization");
    // 取得主控台標準輸出串流,作為序列化的目的地
    using Stream stream = Console.OpenStandardOutput();
    var data = new { Data = PrintNumbers(3) };
    await JsonSerializer.SerializeAsync(stream, data);
    Console.WriteLine();
}

// 非同步反序列化:從記憶體串流中的 JSON 陣列逐筆讀出整數
static async void DeserializeAsync()
{
    Console.WriteLine("Async Deserialization");
    // 將 JSON 字串轉成 UTF-8 位元組,放入 MemoryStream
    var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes("[0,1,2,3,4]"));
    await foreach (int item in JsonSerializer.DeserializeAsyncEnumerable<int>(stream))
    {
        Console.Write(item);
    }
    Console.WriteLine();
}
