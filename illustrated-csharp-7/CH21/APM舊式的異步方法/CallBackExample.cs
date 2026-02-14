using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace APM舊式的異步方法
{
    delegate long MyDel(int first, int second);
    public class CallBackExample
    {
        static long Sum(int x, int y)
        {
            Console.WriteLine("             Inside Sum");
            Thread.Sleep(100);
            return x + y;
        }

        static void CallWhenDone(IAsyncResult iar)
        {
            Console.WriteLine("             Inside CallWhenDone");
            var ar = (AsyncResult)iar;
            MyDel del = (MyDel)ar.AsyncDelegate;

            long result = del.EndInvoke(iar);
            Console.WriteLine("             The result is: {0}.", result);
        }

        public static void Main(string[] args)
        {
            MyDel del = new MyDel(Sum);
            Console.WriteLine("Before BeginInvok");
            IAsyncResult iar = del.BeginInvoke(3, 5, CallWhenDone, null);
            Console.WriteLine("Doing more work in Main.");
            Thread.Sleep(500);
            Console.WriteLine("Done with Main. Exiting.");


        }

    }
}