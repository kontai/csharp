using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _05_OOP._04method
{
     class Student
    {
        public Student(string studentName, int studentId)
        {
            StudentName = studentName;
            StudentId = studentId;
        }
        public string StudentName { get; set; }
        public int StudentId { get; set; }

        //無參數 無返回值
 public       void StudentVoidShow()
        {
            Console.WriteLine("無參數 無返回值");
            Console.WriteLine($"Student Name:{StudentName},Student Id:{StudentId:D2}");
            Console.WriteLine("-----------------------------------");
        }

        //有參數 無返回值
        public void StudentVoidShow(string studentName, int studentId)
        {
            Console.WriteLine("有參數 無返回值");
            Console.WriteLine($"Student Name:{studentName},Student Id:{studentId:D2}");
            Console.WriteLine("-----------------------------------");
        }

        //無參數 有返回值
        public string StudentStringShow()
        {
            Console.WriteLine("無參數 有返回值");
            Console.WriteLine($"Student Name:{StudentName},Student Id:{StudentId:D2}");
            Console.WriteLine("-----------------------------------");
            return StudentName;
        }

        //有參數 有返回值
        public string StudentStringShow(string studentName, int studentId)
        {
            Console.WriteLine("有參數 有返回值");
            Console.WriteLine($"Student Name:{StudentName},Student Id:{studentId:D2}");
            Console.WriteLine("-----------------------------------");
            return StudentName;
        }

        //默認參數
        public void StudentDefaultShow(string studentName="tai", int studetId=100)
        {
            Console.WriteLine("默認參數");
            Console.WriteLine($"Student Name:{studentName},Student Id:{studetId:D2}");
            Console.WriteLine("-----------------------------------");
        }

        //靜態方法
        public static void StudentStaticString(string studentName,int studentId)
        {
            Console.WriteLine("靜態方法");
            Console.WriteLine($"Student Name:{studentName},Student Id:{studentId:D2}");
            Console.WriteLine("-----------------------------------");
        }
    }
}
