using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_OOP._04method
{
    internal class TestClass04
    {
        static void Main04(string[] args)
        {
            Student stu1 = new Student("tai", 01);
            stu1.StudentVoidShow(); //無參數 無返回值
            stu1.StudentVoidShow("sam", 02); //有參數 無返回值
            stu1.StudentStringShow();   //無參數 有返回值
            stu1.StudentStringShow("smith", 03);   //有參數 有返回值
            stu1.StudentStringShow(studentId:05,studentName:"james"); //有參數 有返回值(參數名稱:參數值)
            stu1.StudentDefaultShow();  //默認參數
            stu1.StudentDefaultShow("bob", 04);  //默認參數
            Student.StudentStaticString("jack",30); //靜態方法
        }

    }
}
