TimerCallback tb = new TimerCallback(CallBackTimer);
Timer _ = new Timer(tb, "Current Time ", 0, 1000);
Console.WriteLine("Hit Enter key to terminate...");
Console.ReadLine();

static void CallBackTimer(Object? obj)
{
    Console.WriteLine("{0} {1}", obj, DateTime.Now.ToLocalTime());
}
