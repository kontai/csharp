Console.WriteLine("*** Simple Thread Proj ***");

ConcurencyFunc();



#region 並行  
void ConcurencyFunc()
{
    int values = 0;

    Thread th01=new Thread(new ThreadStart(SimpleFunc));
    Thread th02=new Thread(SimpleFunc);
    Thread th03=new Thread(SimpleFunc);

    th01.Start();
    th02.Start();
    th03.Start();
    Console.WriteLine("Main Thread Done!");
    th01.Join();
    th02.Join();
    th03.Join();
    Console.WriteLine("values= {0}",  values);

    void SimpleFunc()
    {
        for (int i = 0; i < 100; i++)
        {
            Thread.Sleep(1);
            // values += 1;
            //with interlock
            Interlocked.Increment(ref values);    //原子性(讀寫同一資原時，不必加鎖)
            Console.WriteLine($"{Environment.CurrentManagedThreadId} - {values}");
        }
    }
}
#endregion
