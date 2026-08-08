int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
int[] subsetAsIntArray =(from i in numbers where i < 1 select i).ToArray();

List<int> subsetAsListOfInts =(from i in numbers where i < 10 select i).ToList();

foreach (int i in subsetAsIntArray.DefaultIfEmpty(-1))  // DefaultIfEmpty() is used to handle the case when the subset is empty
{
    Console.WriteLine(i);
}

foreach (int i in subsetAsListOfInts)
{
    Console.WriteLine(i);
}