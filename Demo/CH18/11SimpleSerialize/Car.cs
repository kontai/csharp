namespace SimpleSerialize;

/// <summary>
/// 汽車基底類別,JamesBondCar 繼承自此類別。
/// 公開欄位會被 XmlSerializer 與 System.Text.Json(IncludeFields = true 時)序列化。
/// </summary>
public class Car
{
    // 汽車內的收音機(物件圖中的子物件,序列化時會一併輸出)
    public Radio TheRadio = new Radio();

    // 是否為掀背車
    public bool IsHatchBack;

    // 輸出汽車資訊,並串接收音機的資訊
    public override string ToString() => $"IsHatchback:{IsHatchBack} Radio:{TheRadio.ToString()}";
}
