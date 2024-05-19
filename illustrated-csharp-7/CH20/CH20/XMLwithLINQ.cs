using System.Xml.Linq;

namespace CH20;

public class XMLwithLINQ
{
    private void show(params object[] args)
    {
        foreach (object arg in args)
        {
            Console.WriteLine(arg);
        }
    }

    public static void Main(string[] args)
    {
        XDocument employees1 = new XDocument( //創建XML文檔
            new XElement("Employees", //創建棖元素
                new XElement("Employee",
                    new XElement("Name", "Bob Smith"), //創建元素,元素名XName不可以空格
                    new XElement("ProneNumber", "408-555-1000")),
                new XElement("Employee",
                    new XElement("Name", "Sally Jones"),
                    new XElement("ProneNumber", "415-555-2000"),
                    new XElement("ProneNumber", "415-555-2000"))
                )
            );


        //employees1.Save("EmployeesFile.xml");   //保存元素

        //XDocument employees2 = XDocument.Load("EmployeesFile.xml"); //顯示文檔

        Console.WriteLine(employees1);
    }
}