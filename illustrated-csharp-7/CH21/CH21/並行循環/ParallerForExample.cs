//using System.Threading.Channels;

namespace CH21.並行循環;

public class ParallerForExample
{
    public static void Main(string[] args)
    {
        Parallel.For(0, 150, i =>   //並行循環，從0到150
            Console.WriteLine($"The square of {i} is {i * i}"));

        const int maxValue = 50;
    }
}