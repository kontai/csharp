using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH8
{
    internal class ConstracorInitializeExample
    {
        public static void Main(string[] args)
        {
            MyClass myClass1 = new MyClass("tai", 23);
            //MyClass myClass2 = new MyClass(123);

            //Console.WriteLine(myClass1.UserName);
            //Console.WriteLine(myClass2.UserName);
        }
    }

    class MyClass
    {
        private readonly int firstVar;
        private readonly double secondVar;

        public string UserName;
        public int UserIdNumber;

        /// <summary>
        /// Prevents a default instance of the <see cref="MyClass"/> class from being created.
        /// 當公共構迦函數無法一次初始化全部字段時，可以將其設置為私有構造函數
        /// 然後在其它構造函數中使用它
        /// </summary>
        private MyClass()   ///私有構造函數執行其他構造函數初始化
        {
            firstVar = 20;
            secondVar = 30.5;
            Console.WriteLine("MyClass() is called");
        }

        public MyClass(string firUsrName) : this() //使用構造函數初始化語句
        {
            UserName = firUsrName;
            UserIdNumber = -1;
            Console.WriteLine("MyClass(string firUsrName) : this() is called");
        }

        public MyClass(int idNumber) : this() //使用構造函數初始化語句
        {
            UserName = "Anonymous";
            UserIdNumber = idNumber;
            Console.WriteLine("MyClass(int idNumber) : this() is called");
        }

        public MyClass(string firUsrName, int idNumber) : this(firUsrName)
        {
            UserIdNumber = idNumber;
            Console.WriteLine("MyClass(string firUsrName, int idNumber) : this(firUsrName) is called");
        } //使用構造函數初始化語句

    }
}
