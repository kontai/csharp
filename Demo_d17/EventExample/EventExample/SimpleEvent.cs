using System.Timers;
using Timer = System.Timers.Timer;

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
