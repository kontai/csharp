namespace CH15;

//發佈者
public class Increment
{
    public delegate void Handler();

    //聲明事件
    //使用event修飾詞,並且指定型別
    //EventHandler是一個委托類型(BCL中，專用於系統事件)
    //可用逗號方式來擁有多個事件
    public event EventHandler? MyEvent, MyEvent2, OtherEvent;

    //使用自定義委托類型聲明事件
    public event Handler CounterDozen;

    //可以使用static闗鍵字，讓事件成為靜態的
    //public static event EventHandler? CounterDozen;

    public void DoCount()
    {
        Console.WriteLine("Counting...");

        for (int i = 1; i < 100; i++)
        {
            if (i % 12 == 0 && CounterDozen != null)        //判斷事件處理程序列表不为空
            {
                //呼叫事件
                //CounterDozen?.Invoke(this, EventArgs.Empty);
                CounterDozen();     //每增加12個，就觸發事件
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

        //註冊事件(方法簽名和返回值必須和委托相同)
        //可以是實例方法、靜態方法、匿名方法或Lambda表達式
        //incrementer.CounterDozen += incrementDozerCount;
        //incrementer.CounterDozen += () => { Console.WriteLine("Dozen event handler"); };
        //incrementer.CounterDozen += delegate { DozensCount++; };
        incrementer.CounterDozen += () => DozensCount++;
    }

    /// <summary>
    /// Increments the dozer count.
    /// This method is called by the CounterDozen event handler.
    /// </summary>
    private void incrementDozerCount()
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