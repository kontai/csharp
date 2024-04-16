using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

/*
 * 多播(multicast)委託
 */
namespace DelegetExample
{

    internal class Progream2
    {
        public static void Main(string[] args)
        {
            Student stu1 = new Student() { ID = 1, PenColor = ConsoleColor.Yellow };
            Student stu2 = new Student() { ID = 1, PenColor = ConsoleColor.Green };
            Student stu3 = new Student() { ID = 1, PenColor = ConsoleColor.Red };
            Action action1 = new Action(stu1.DoHomework);
            Action action2 = new Action(stu2.DoHomework);
            Action action3 = new Action(stu3.DoHomework);
            //action1.Invoke();
            //action2.Invoke();
            //action3.Invoke();

            // 多播(multicast)委託
            //執行順序按照封裝順序執行
            action1 += action2;
            action1 += action3;
            action1.Invoke();
        }

    }

    class Student
    {
        public int ID { get; set; }
        public ConsoleColor PenColor { get; set; }

        public void DoHomework()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = this.PenColor;
                Console.WriteLine("Student {0} doing homework {1} hours(s).", this.ID, i);
                Thread.Sleep(500);
            }
        }
    }
}
