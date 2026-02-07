using System;

SystemArrayFunctionality();
static void SystemArrayFunctionality()
{
    Console.WriteLine("=> Working with System.Array.");
    // Initialize items at startup.
    string[] gothicBands = { "Tones on Tail", "Bauhaus", "Sisters of Mercy" };
    // Print out names in declared order.
    Console.WriteLine("-> Here is the array:");
    for (int i = 0; i < gothicBands.Length; i++)
    {
        // Print a name.
        Console.Write(gothicBands[i] + ", ");
    }
    Console.WriteLine("\n");
    // Reverse them...
    Array.Reverse(gothicBands);
    Console.WriteLine("-> The reversed array");

    // ... and print them.
    printArray(gothicBands);

    Console.WriteLine("\n");
    // Clear out all but the first member.
    Console.WriteLine("-> Cleared out all but one...");
    Array.Clear(gothicBands, 1, 2);

    // Print the results.
    printArray(gothicBands);
    Console.WriteLine();
}



static void printArray(string[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        // Print a name.
        Console.Write(arr[i] + ", ");
    }
    Console.WriteLine();
}