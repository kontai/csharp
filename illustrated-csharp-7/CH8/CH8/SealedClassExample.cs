using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH8
{
    internal class SealedClassExample
    {
        class A
        {
            public virtual void F()
            {
                Console.WriteLine("A.F");
            }
            public virtual void G()
            {
                Console.WriteLine("A.G");
            }
        }
        class B : A
        {
            //重写虚方法F
            public sealed override void F()
            {
                Console.WriteLine("B.F");
            }
            //重写虚方法G
            public override void G()
            {
                Console.WriteLine("B.G");
            }
        }
        class C : B
        {
            //以下是错误的，因为类B中的方法F是密封的，不能再被重写
            //public override void F()
            //{
            //    Console.WriteLine("C.F");
            //}

            //以下是方法重写是正确的
            public override void G()
            {
                Console.WriteLine("C.G");
            }
        }
        static void Main(string[] args)
        {
            new A().F();//A.F
            new A().G();//A.G
            new B().F();//B.F
            new B().G();//B.G
            new C().F();//B.F  只能输出类B中对该方法的实现
            new C().G();//C.G
            //Console.ReadLine();
        }
    }
}
