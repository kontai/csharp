int[] arr1 = { 1, 2, 6, 7, 9, 19 };
//Binary search
int? index = Array.BinarySearch(arr1, 7);
Action<int[]> f = (i) =>
{
    for (var i1 = 0; i1 < i.Length; i1++)
    {
        Console.Write($"{i1} ");
    }
};
f(arr1);
Console.WriteLine("");
Console.WriteLine($"index of 7: {index}");

//searching for an element in an array
Console.WriteLine(Array.IndexOf(arr1, 7));


//Predicate search
string[] names = { "John", "Peter", "Paul", "Mark", "James" };
string match = Array.Find(names, (s) => s.Contains("P"));
Console.WriteLine($"math: {match}");
