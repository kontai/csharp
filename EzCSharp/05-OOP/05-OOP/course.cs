using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 對象的屬性與方法
 */

namespace _05_OOP
{
    class course : IComparable<course>
    {
        //無參構造方法
        public course()
        {
            ClassName = "C#";
            Price = 1000;
            StartDate = new DateTime(2024, 10, 11);
        }

        //有參構造方法
        public course(string className, int price)
        {
            this.className = className;
            this.price = price;
        }

        //有參構造方法(於型參列表後以this調用其它構造方法)
        public course(string className, int price, DateTime startDate) : this(className, price)
        {
            //this.className = className;
            //this.price = price;
            this.StartDate = startDate;
        }


        private string className;  //課程名稱
        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }
        //public int Price { get; set; }  //課程價格
        private int price;
        public int Price { get => price; set => price = value; }  //課程價格

        public DateTime StartDate { get; set; } = new DateTime(); //開課日期




        public void showInfo()
        {
            Console.WriteLine("課程名稱:{0}", className);
            Console.WriteLine("課程價格:{0}", Price);
            Console.WriteLine("開課日期:{0}", StartDate);
        }


        public int CompareTo(course other)
        {
            return price.CompareTo(other.price);
        }
    }
}
