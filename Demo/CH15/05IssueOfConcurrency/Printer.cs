using System;
using System.Collections.Generic;
using System.Text;

namespace MultsiThreadedPrinting;

internal class Printer
{
    public void PrintNumbers()
    {
        Console.WriteLine(
            "*** Worker Number #{0} is executing PrintNumber()",
            Thread.CurrentThread.Name
        );

        foreach (short number in Enumerable.Range(1, 10))
        {
            Random r = new Random();
            //💤隨機等待0~4秒
            Thread.Sleep(1000 * r.Next(5));
            Console.Write($"{number},");
        }
    }
}
