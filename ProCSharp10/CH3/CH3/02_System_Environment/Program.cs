//local method within the top-level statements
<<<<<<< HEAD

=======
using System;
>>>>>>> 74806036cd0bd06043a96e84d89456abddd353bf
using System.Collections.Specialized;

ShowEnvironmentDetails();

static void ShowEnvironmentDetails()
{
    //Print out the drivers ont this machine
    foreach (var drive in Environment.GetLogicalDrives())
    {
        Console.WriteLine("Drive: {0}", drive);
    }
    Console.WriteLine("=================");

    //Print out the OS version
    Console.WriteLine("OS: {0}", Environment.OSVersion);
    Console.WriteLine("=================");

    //Print out the Processor Count
    Console.WriteLine("Number of processors: {0}", Environment.ProcessorCount);
    Console.WriteLine("=================");

    //Print out the .NET version
    Console.WriteLine(".NET Core Version: {0}", Environment.Version);

    //Print out executable path
    Console.WriteLine("Process Path: {0}",Environment.ProcessPath);
}