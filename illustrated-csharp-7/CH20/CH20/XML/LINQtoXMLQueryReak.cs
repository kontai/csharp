using System.Xml.Linq;

namespace CH20.XML;

public class LINQtoXMLQueryReak
{
    public static void Main(string[] args)
    {
        XDocument xd = XDocument.Load("SimpleSample.xml");  //加載文擋
        XElement rt = xd.Element("MyElement");  //獲取根元素

        var xyz = from e in rt.Elements()   //選擇名稱包含5個元素的元素
                  where e.Name.ToString().Length == 5
                  select e;

        foreach (var x in xyz)
        {
            Console.WriteLine(x.Name.ToString());   //顯示所包含的元素
        }

        Console.WriteLine();

        foreach (var x in xyz)
        {
            Console.WriteLine("Name: {0}, color: {1}, size: {2}",
                x.Name,
                x.Attribute("color").Value,     //Attribute:獲取特性  Value:獲取特性的值
                x.Attribute("size").Value);
        }

    }
}