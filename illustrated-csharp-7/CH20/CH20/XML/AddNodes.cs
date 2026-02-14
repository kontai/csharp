using System.Xml.Linq;

namespace CH20.XML;

public class AddNodes
{
    public static void Main(string[] args)
    {
        XDocument xd = new XDocument( //創建XML樹
            new XElement("root",
                new XElement("first")
                )
            );
        Console.WriteLine("Original tree"); //顯示樹
        Console.WriteLine(xd);
        Console.WriteLine();

        XElement rt = xd.Element("root"); //獲取第一個元素
        rt.Add(new XElement("second")); //添加子元素
        rt.Add(new XElement("third"),   //添加三個子元素
            new XComment("Important Comment"),
            new XElement("fourth")
            );
        Console.WriteLine("Modified tree");
        Console.WriteLine(xd);  //顯示Modified tree
    }
}