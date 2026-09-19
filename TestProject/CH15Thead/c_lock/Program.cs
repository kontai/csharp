using c_lock;
// M1();
BigNumbers bigNumbers = new BigNumbers();
Parallel.ForEach(Enumerable.Range(1, 4), bigNumbers.InterLockPrintNumber);

void M1()
{
    Thread[]  threads = new Thread[10];
    BigNumbers bigNumbers = new BigNumbers();
    for (int i = 0; i < 10; i++)
    {
        threads[i]=new Thread(new ThreadStart(bigNumbers.PrintNumbers));
    }
    for (int i = 0; i < 10; i++)
    {
        threads[i].Start();
    }
}
