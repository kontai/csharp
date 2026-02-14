using System.Xml.Linq;

namespace CH20.XML;

public class LinQtoXmlQueryReakAnnoy
{
    public static void Main(string[] args)
    {
        XDocument xd = XDocument.Load("SimpleSample.xml");  //加載文擋
        XElement rt = xd.Element("MyElement");  //獲取根元素

        var xyz = from e in rt.Elements()
                  select new { e.Name, color = e.Attribute("color") };  //創建匿名類型

        foreach (var x in xyz)
        {
            Console.WriteLine(x);
        }

        Console.WriteLine();
        foreach (var x in xyz)
        {
            Console.WriteLine("{0,-6}, color:{1,-7}", x.Name, x.color.Value);
        }


    }
}