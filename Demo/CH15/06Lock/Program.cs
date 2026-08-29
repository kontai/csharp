using MultsiThreadedPrinting;

Printer p = new Printer();

Thread[] threads = new Thread[5];

for (int i = 0; i < 5; i++)
{
    threads[i] = new Thread(new ThreadStart(p.PrintNumbers));
    threads[i].Name = $"Worker thread #{i}";
}

foreach (var worker in threads)
{
    worker.Start();
}
