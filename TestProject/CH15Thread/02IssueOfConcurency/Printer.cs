using System.Globalization;

namespace IssueOfConcurency;

public class Printer
{
    private object threadLock = new object();
 public void LazyPrinter()
 {
     lock (threadLock)
     {
         string tName = Thread.CurrentThread.Name;
         Console.WriteLine(tName);
         foreach (int c in Enumerable.Range(0, 10))
         {
             Random r = new Random();
             Console.WriteLine(c);
             Thread.Sleep(r.Next(10)*1000);
         }

         Console.WriteLine($"{tName} done!");
     }
         
     }
 
}