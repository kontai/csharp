using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH21.await的異常處理
{
    internal class ExceptAwait
    {
        public static void Main(string[] args)
        {
            Task t = Badasync();
            t.Wait();
            Console.WriteLine($"Task Status : {t.Status}");
            Console.WriteLine($"Task IsFaulted: {t.IsFaulted}");
        }
        static async Task Badasync()
        {
            try
            {
                await Task.Run(() => { throw new Exception(); });
            }
            catch (Exception e)
            {

                Console.WriteLine("Exception in BadAsync");
            }
        }
    }
}
