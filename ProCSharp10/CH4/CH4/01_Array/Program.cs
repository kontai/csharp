using System;

//simpleArrays();
initWithValues();
multiDeamondArray();
JaggedMultidimensionalArray();

static void simpleArrays()
{
    int[] myArray = new int[20];
    foreach (var i in myArray)
    {
        Console.WriteLine(i);
    }
}

static void initWithValues()
{
    Console.WriteLine("=> Array of Objects.");
    // An array of objects can be anything at all

    string[] stringArray = new[] { "one", "two", "three" };
    Console.WriteLine($"stringArray has {stringArray.Length} elements.");

    int[] intArray = { 22, 33, 21, 0 };
    int[] intArray2 = new int[] { 22, 33, 21, 0 };
    Console.WriteLine($"intArray has {intArray.Length} elements.");
    Console.WriteLine();
}

static void multiDeamondArray()
{
    Console.WriteLine("=> Rectangular multidimensional array.");
    // A rectangular MD array.
    int[,] mArray = new int[3, 5];
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            mArray[i, j] += i + j;
        }
    }

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            Console.Write("{0} ", mArray[i, j]);
        }
    }

    Console.WriteLine();
    Console.WriteLine();
}

static void JaggedMultidimensionalArray()
{
    Console.WriteLine("=> Jagged multidimensional array.");
    // A jagged MD array (i.e., an array of arrays).
    int[][] jagArray = new int[5][];
    for (int i = 0; i < jagArray.Length; i++)
    {
        jagArray[i] = new int[i + 7];
    }

    for (int i = 0; i < jagArray.Length; i++)
    {
        for (int j = 0; j < jagArray[i].Length; j++)
        {
            Console.Write("{0} ", j);
        }

        Console.WriteLine();
    }
}