using System.Xml.Linq;

namespace CH20.XML;

public class LINQtoXMKQuery
{
    public static void Main(string[] args)
    {
        XDocument xd = new XDocument(
            new XElement("MyElement",
                new XElement("first",
                new XAttribute("color", "red"),
                new XAttribute("size", "small")),
            new XElement("second",
                new XAttribute("color", "red"),
                new XAttribute("size", "medium")),
            new XElement("third",
                new XAttribute("color", "blue"),
                new XAttribute("size", "large"))
                )
        );
        Console.WriteLine(xd);
        xd.Save("SimpleSample.xml");
    }
}