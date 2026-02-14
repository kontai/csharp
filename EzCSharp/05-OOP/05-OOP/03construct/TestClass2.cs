using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_OOP
{
    internal class TestClass2
    {
        static void Main03(string[] args)
        {
            course c1 = new course();
            course c2 = new course("C# 構迦齒數", 1200, new DateTime(2021, 09, 01));
            course c3 = new course()
            {
                ClassName = "C#的叉象初始化器",
                Price = 9100,
                StartDate = new DateTime(2024, 10, 10)
            };
            //c1.ClassName = "C#課程";
            //c1.Price = 1000;
            //c1.StartDate = new DateTime(2024,10,10);
            //c1.showInfo();  //呼叫類別的方法(字段尚末初始化)
            //c2.showInfo();
            c3.showInfo();
        }
    }
}
