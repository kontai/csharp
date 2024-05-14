int[] numbers = { 2, 12, 5, 15 };
IEnumerable<int> lowNums;
lowNums = from n in numbers
          where n < 10
          select n;
foreach (int x in lowNums)
{
    Console.Write($"{x} ");
}
