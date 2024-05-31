//using System.Threading.Channels;

namespace CH21.並行循環;

public class ParallerForExample
{
    public static void Main(string[] args)
    {
        //以並行運行循環
        /*
        Parallel.For(0, 150, i =>   //並行循環，從0到150
            Console.WriteLine($"The square of {i} is {i * i}"));

        const int maxValue = 50;
        */

        const int maxVlaue = 50;
        int[] squares = new int[maxVlaue];
        Parallel.For(0, maxVlaue, i => squares[i] = i * i);
    }
}