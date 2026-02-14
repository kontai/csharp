using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_OOP
{
    internal class TestClass
    {
        static void Main2(string[] args)
        {
            course c1 = new course();
            c1.ClassName = "C#課程";
            c1.Price = 1000;
            c1.StartDate = new DateTime(2024,10,10);
            c1.showInfo();  //呼叫類別的方法(字段尚末初始化)
        }
    }
}
