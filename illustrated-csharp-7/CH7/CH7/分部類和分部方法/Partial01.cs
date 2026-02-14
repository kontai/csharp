using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH7.分部類和分部方法
{
    internal class Partial01
    {
        static void Main(string[] args)
        {
            var mc = new MyClass();
            mc.Add(5, 6);
        }
    }

    partial class MyClass
    {
        //必须是 void
        partial void PrintSum(int x, int y); //定义分部方法,partial是上下文关键字,没有实现部分
        public void Add(int x, int y)
        {
            PrintSum(x, y);
        }
    }
}
