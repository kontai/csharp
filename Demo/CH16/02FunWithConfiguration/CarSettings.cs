namespace _02FunWithConfiguration;

// 對應 appsettings.json 中 "CarSettings" 區段的強型別設定類別
// Options Pattern 要求屬性要有 public get/set，供組態繫結（Bind）時透過反射賦值
public class CarSettings
{
    public string CarName { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public int TopSpeed { get; set; }
}
