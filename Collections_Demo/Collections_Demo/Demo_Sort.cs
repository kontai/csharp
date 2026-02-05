int[] arr = { 2, 3, 22, 31, 5, 6 };
Array.Sort(arr);    //2,3,5,6,22,31
//Array.Reverse(arr); //31,22,6,5,3,2
//Array.Reverse(arr, 1, 3); //31,5,6,22,3,2

Array.Sort(arr, (x, y) => x % 2 == y % 2 ? 0 : x % 2 == 1 ? -1 : 1);
foreach (var i in arr)
{
    Console.WriteLine(i);
}

int[] arr2 = new int[2];


try
{

    Array.ConstrainedCopy(arr, 0, arr2, 0, 3);
}
catch (ArrayTypeMismatchException e)
{
    Console.WriteLine(e);
    throw;
}

//AsReadOnly
IReadOnlyCollection<int> readOnly = Array.AsReadOnly(arr);
//readOnly[0] = 5; //throws exception
