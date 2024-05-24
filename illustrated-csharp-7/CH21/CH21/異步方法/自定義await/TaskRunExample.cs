using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH21.異步方法.自定義await
{
    class MyClass
    {
        public int Get10()
        {
            return 10;
        }

        public async Task DoWorkAsync()
        {
            //Method I
            Func<int> ten = new Func<int>(Get10);
            int a = await Task.Run(ten);

            int b = await Task.Run(new Func<int>(Get10));

            int c = await Task.Run(() => { return 10; });

            Console.WriteLine($"{a} {b} {c}");
        }
    }
    internal class TaskRunExample
    {
        public static void Main(string[] args)
        {
            Task t = (new MyClass()).DoWorkAsync();
            //Thread.Sleep(200);
            t.Wait();
        }
    }
}
