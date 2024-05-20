using System.Xml.Linq;

namespace CH20.XML;

public class XAttributeExample
{
    public static void Main(string[] args)
    {
        XDocument xd = new XDocument(
            new XElement("root",
            new XAttribute("color", "red"),     //特性構造函數
            new XAttribute("size", "large"),    //特性構造函數
            new XElement("first"),
            new XElement("second")
                )
            );
        Console.WriteLine(xd);      //顯示XML樹
        Console.WriteLine();

        XElement rt = xd.Element("root");       //獲取元素

        XAttribute color = rt.Attribute("color");   //獲取特性
        XAttribute size = rt.Attribute("size");     //獲取特性

        Console.WriteLine($"color is {color.Value}");   //顯示特性值
        Console.WriteLine($"size is {size.Value}");     //顯示特性值
        Console.WriteLine();

        //移除特性1--使用Remove方法
        //rt.Attribute("color").Remove();     //移除color特性
        //rt.Attribute("size").Remove();      //移除size特性

        //移除特性2--使用SetAttributeValue方法
        rt.SetAttributeValue("size", "medium");  //改變特性值
        rt.SetAttributeValue("width", "narrow");    //增加特性
        rt.SetAttributeValue("color", null);    //移除特性


        Console.WriteLine(xd);
    }
}