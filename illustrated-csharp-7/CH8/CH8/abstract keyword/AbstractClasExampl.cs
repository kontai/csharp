using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH8
{
    internal class AbstractClasExampl
    {
    }

    internal abstract class AbClass //抽象类

    {
        public void IdentifyBase() //普通方法
        {
            Console.WriteLine("I am AbClass");
        }

        public abstract void IdentifyDerived(); //抽象方法
    }

    internal class DerivedClass : AbClass    //派生类
    {
        public override void IdentifyDerived()  //抽象方法的实现
        {
            Console.WriteLine("I am DerivedClass");
        }
    }

    internal class Program
    {
        private static void Main()
        {
            // AbClass a = new AbClass();   //错误,抽象类不能实例化
            // a. IdentifyDerived();

            DerivedClass b = new DerivedClass(); //实例化派生类
            b.IdentifyBase();    //调用继承的方法
            b.IdentifyDerived();    //调用“抽象”方法
        }
    }
}