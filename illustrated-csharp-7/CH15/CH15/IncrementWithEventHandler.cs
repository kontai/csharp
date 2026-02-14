namespace CH15;

//自定義類繼承EventArgs
public class IncrementEventArgs : EventArgs
{
    public int IteratorCount { get; set; }
}

//發佈者
public class Increment
{
    //使用泛型(自定義類繼承EventArgs)作為形式參數
    public event EventHandler<IncrementEventArgs> CounterDozen;

    public void DoCount()
    {
        Console.WriteLine("Counting...");
        IncrementEventArgs args = new IncrementEventArgs();

        for (int i = 1; i < 100; i++)
        {
            if (i % 12 == 0 && CounterDozen != null)
            {
                args.IteratorCount = i; //賦值
                CounterDozen(this, args); //自定義EventArgs
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
    private void incrementDozerCount(object source, IncrementEventArgs e) //形式參數與返回類型必須與EventHandler聲明一致
    {
        Console.WriteLine($"Incremented at interation: {e.IteratorCount} in {source.ToString}");
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