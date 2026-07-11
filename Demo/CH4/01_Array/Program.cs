// ArrayMembers();
IndexAndRange();

void IndexAndRange()
{
    Index index = new Index();
    int[] arr1 = { 1, 2, 3, 4, 5 };
    for (int i = 0; i < arr1.Length; i++)
    {
        index = i;
        System.Console.WriteLine(arr1[index]);
    }
    System.Console.WriteLine("=====================");
    //反向索引
    for (int i = 1; i <= arr1.Length; i++)
    {
        index = ^i;
        System.Console.WriteLine(arr1[index]);
    }

    Range r = 0..2;
    foreach (var v in arr1[r])
    {
        System.Console.WriteLine(v);
    }

    var k = arr1.ElementAt(2);
    System.Console.WriteLine($"arr1[2]: {k}");

    System.Console.WriteLine(new string('=', 20));
}

void ArrayMembers()
{
    int[] arr1 = { 1, 2, 3, 4, 5 };
    System.Console.WriteLine($"Array Length: {arr1.Length}");
    int[] arr2 = new int[arr1.Length];
    arr1.CopyTo(arr2, 0);   //  CopyTo 是將arr1的值複製到arr2
    //    arr2 = arr1;    // '=' 是將arr1的位址指向arr2
    arr1[1] = 10;
    Console.Write("arr1: ");
    foreach (var i in arr1)
    {
        System.Console.Write("{0} ", i);
    }
    System.Console.WriteLine();

    Console.Write("arr2: ");
    foreach (var i in arr2)
    {
        System.Console.Write("{0} ", i);
    }

    System.Console.WriteLine();
    System.Console.WriteLine("arr1 Rank: {0}", arr1.Rank);
    Array.Clear(arr2, 1, 3);    //  清除arr2的值
    System.Console.WriteLine("(after Clear)arr2: ");
    foreach (var i in arr2)
    {
        System.Console.Write("{0} ", i);
    }


}
