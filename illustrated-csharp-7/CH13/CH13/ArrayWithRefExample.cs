using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH13
{
    internal class ArrayWithRefExample
    {
        static ref int PointToHighestPositive(int[] numbers)
        {
            int highest = 0;
            int indexOfHighes = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > highest)
                {
                    highest = numbers[i];
                    indexOfHighes = i;
                }
            }
            return ref numbers[indexOfHighes];
        }

        static void Main(string[] args)
        {
            int[] scores = { 2, 99 };
            Console.WriteLine($"Before: {scores[0]}, {scores[1]}");
            ref int highestScore = ref PointToHighestPositive(scores);
            highestScore = 0;
            Console.WriteLine($"After: {scores[0]}, {scores[1]}");

        }
    }
}
