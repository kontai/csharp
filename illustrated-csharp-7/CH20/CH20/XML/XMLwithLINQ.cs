using System.Xml.Linq;

namespace CH20.XML;

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
                    new XElement("PhoneNumber", "408-555-1000")),
                new XElement("Employee",
                    new XElement("Name", "Sally Jones"),
                    new XElement("PhoneNumber", "415-555-2000"),
                    new XElement("PhoneNumber", "415-555-2000"))
                )
            );


        //employees1.Save("EmployeesFile.xml");   //保存元素

        //XDocument employees2 = XDocument.Load("EmployeesFile.xml"); //顯示文檔

        Console.WriteLine(employees1);
        Console.WriteLine();

        XElement root = employees1.Element("Employees");    //獲取第一個名為"Employees"的子XElement
        IEnumerable<XElement> employees = root.Elements("Employee");
        foreach (var emp in employees)
        {
            XElement empNameNode = emp.Element("Name");
            Console.WriteLine(empNameNode.Value);

            IEnumerable<XElement> empPhone = emp.Elements("PhoneNumber");
            foreach (var phone in empPhone)
            {
                Console.WriteLine($"    {phone.Value}");
            }
        }

    }
}