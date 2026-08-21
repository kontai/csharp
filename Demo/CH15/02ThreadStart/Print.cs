namespace SimpleThreadDemo
{
    class Print
    {
        public void LazyFunc()
        {
            Thread currentThread = Thread.CurrentThread;
            currentThread.Name = "background thread";

            Console.WriteLine("*** 現在執行的執行緒名稱為: " + currentThread.Name + " ***");

            foreach (int i in Enumerable.Range(1, 10))
            {
                Console.WriteLine("i: {0}", i);
                Thread.Sleep(2000);
            }
        }
    }
}
