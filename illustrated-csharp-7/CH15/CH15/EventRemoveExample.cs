namespace CH15;

internal class Publisher
{
    public event EventHandler SimpleEvent;

    public void RaiseTheEvent()
    {
        SimpleEvent(this, EventArgs.Empty);
    }
}

internal class Subscriber
{
    public void MethodA(object o, EventArgs e)
    {
        Console.WriteLine("AAA");
    }

    public void MethodB(object o, EventArgs e)
    {
        Console.WriteLine("BBB");
    }
}

public class EventRemoveExample
{
    private static void Main(string[] args)
    {
        Publisher p = new Publisher();
        Subscriber s = new Subscriber();

        p.SimpleEvent += s.MethodA;
        p.SimpleEvent += s.MethodB;
        p.RaiseTheEvent();

        Console.WriteLine("\r\nRemoving Method B");
        p.SimpleEvent -= s.MethodB;
        p.RaiseTheEvent();
    }
}