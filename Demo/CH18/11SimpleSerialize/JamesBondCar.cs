using System.Xml.Serialization;

namespace SimpleSerialize;

// 指定 XML 根元素的命名空間為 "JamesBondCar"
[XmlRoot(Namespace = "JamesBondCar")]
public class JamesBondCar : Car
{
    // [XmlAttribute]:序列化成 XML 時,此欄位輸出為屬性(attribute)而非子元素
    [XmlAttribute]
    public bool CanFly;

    [XmlAttribute]
    public bool CanSubmerge;

    // 先輸出自身欄位,再呼叫基底類別 Car 的 ToString()
    public override string ToString() =>
        $"CanFly:{CanFly}, CanSubmerge:{CanSubmerge} {base.ToString()}";
}
