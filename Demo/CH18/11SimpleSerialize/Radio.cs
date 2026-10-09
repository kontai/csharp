namespace SimpleSerialize;

/// <summary>
/// 收音機類別,作為 Car 的成員,用來示範物件圖(object graph)的序列化。
/// </summary>
public class Radio
{
    // 是否有高音喇叭
    public bool HasTweeters;

    // 是否有重低音喇叭
    public bool HasSubWoofers;

    // 電台預設頻道清單(集合型別也能被序列化)
    public List<double> StationPresets;

    // 收音機型號編號(預設值)
    public string RadioId = "XF-552RR6";

    // 輸出收音機狀態,並將頻道清單以逗號串接成字串
    public override string ToString()
    {
        var presets = string.Join(",", StationPresets.Select(i => i.ToString()).ToList());
        return $"HasTweeters:{HasTweeters} HasSubWoofers:{HasSubWoofers} Station Presets:{presets}";
    }
}
