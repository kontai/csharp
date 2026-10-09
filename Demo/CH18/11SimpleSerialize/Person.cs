using System.Text.Json.Serialization;

namespace SimpleSerialize;

/// <summary>
/// 示範公開欄位、私有欄位與屬性在序列化時的差異。
/// </summary>
public class Person
{
    // 一個公開欄位。
    [JsonPropertyOrder(1)] // 序列化時的順序(由小到大)
    public bool IsAlive = true;

    // 一個私有欄位。(不會被 XmlSerializer 與預設的 System.Text.Json 序列化)
    private int PersonAge = 21;

    // 公開屬性／私有資料。
    private string _fName = string.Empty;

    // 順序值 -1 小於 IsAlive 的 1,所以 JSON 輸出時 FirstName 會排在最前面
    [JsonPropertyOrder(-1)]
    public string FirstName
    {
        get { return _fName; }
        set { _fName = value; }
    }

    // 輸出所有資訊(包含私有欄位 PersonAge)
    public override string ToString() =>
        $"IsAlive:{IsAlive} FirstName:{FirstName} Age:{PersonAge} ";
}
