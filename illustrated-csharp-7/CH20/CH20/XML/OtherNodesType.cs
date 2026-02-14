using System.Xml.Linq;

namespace CH20.XML;

public class OtherNodesType
{
    public static void Main(string[] args)
    {
        XDocument xd = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XComment("This is a comment"),
            new XProcessingInstruction("xml-stylesheet", "href=\"style.css\" type=\"text/css\""),
            new XElement("rot",
                new XElement("first"),
                new XElement("second")
            )
        );
        xd.Save("other.xml");
        Console.WriteLine(xd);  //使用WriteLine，即使聲明語句包含在文擋文件中，也不會顯示
    }
}