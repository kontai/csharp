namespace CH15;

//發佈者
public class Increment
{
    public delegate void Handler();

    public event EventHandler CounterDozen;


    public void DoCount()
    {
        Console.WriteLine("Counting...");

        for (int i = 1; i < 100; i++)
        {
            if (i % 12 == 0 && CounterDozen != null)
            {
                CounterDozen(this, null);
            }
        }
    }
}
//--------------------------------------------------------------------------------------------------------

//訂閱者
internal class Dozens
{
    public int DozensCount { get; private set; }

    public Dozens(Increment incrementer)
    {
        DozensCount = 0;
        incrementer.CounterDozen += incrementDozerCount;
        //incrementer.CounterDozen += (object source, EventArgs args) => DozensCount++;
    }

    /// <summary>
    /// Increments the dozer count.
    /// This method is called by the CounterDozen event handler.
    /// </summary>
    private void incrementDozerCount(object source, EventArgs args)     //形式參數與返回類型必須與EventHandler聲明一致
    {
        DozensCount++;
    }
}
//--------------------------------------------------------------------------------------------------------

internal class Program
{
    private static void Main(string[] args)
    {
        Increment increment = new Increment();
        Dozens dozensCounter = new Dozens(increment);
        increment.DoCount();
        Console.WriteLine("Number of dozens: {0}", dozensCounter.DozensCount);
    }
}