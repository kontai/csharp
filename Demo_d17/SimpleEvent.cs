using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Win32;


namespace EventExample
{
    internal class SimpleEvent
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            Boy boy = new Boy();
            Girl girl = new Girl();

            timer.Elapsed += boy.Action;
            timer.Elapsed += girl.Action;
            timer.Start();
            Console.ReadLine();

        }

    }

    class Boy
    {
        public void Action(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("boy event");
        }
    }

    class Girl
    {
        public void Action(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("girl event");
        }
    }
}
