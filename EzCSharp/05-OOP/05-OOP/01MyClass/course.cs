using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 對象的屬性與方法
 */


#if false 
namespace _05_OOP._01MyClass
{
    class course
    {
        private string className;  //課程名稱
        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }
        //public int Price { get; set; }  //課程價格
        private int price;
        public int Price { get=>price; set=>price=value; }  //課程價格

        public DateTime StartDate { get; set; }=new DateTime(); //開課日期




        public void showInfo()
        {
            Console.WriteLine("課程名稱:{0}", className);
            Console.WriteLine("課程價格:{0}", Price);
            Console.WriteLine("開課日期:{0}", StartDate);
        }
    }
}
#endif
