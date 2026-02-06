using GCProjNS;

Gc_Func();

void Gc_Func()
{
Console.WriteLine("***** Fun with System.GC *****");
Console.WriteLine("Estimated bytes on heap: {0}", GC.GetTotalMemory(false));
Console.WriteLine("This OS has {0} object generations.\n", (GC.MaxGeneration + 1));

Car refToMyCar = new Car("Zippy", 100);
Console.WriteLine(refToMyCar.ToString());
Console.WriteLine("\nGeneration of refToMyCar is: {0}", GC.GetGeneration(refToMyCar));

// 建立 50000 個物件
object[] tonsOfObjects = new object[50000];
for (int i = 0; i < 50000; i++)
{
    tonsOfObjects[i] = new object();
}

// 強制回收 Gen 0
Console.WriteLine("Force Garbage Collection");
GC.Collect(0, GCCollectionMode.Forced);
GC.WaitForPendingFinalizers();

Console.WriteLine("Generation of refToMyCar is: {0}", GC.GetGeneration(refToMyCar));

if (tonsOfObjects[9000] != null)
    Console.WriteLine("Generation of tonsOfObjects[9000] is: {0}", GC.GetGeneration(tonsOfObjects[9000]));
else
    Console.WriteLine("tonsOfObjects[9000] is no longer alive.");

Console.WriteLine("\nGen 0 has been swept {0} times", GC.CollectionCount(0));
Console.WriteLine("Gen 1 has been swept {0} times", GC.CollectionCount(1));
Console.WriteLine("Gen 2 has been swept {0} times", GC.CollectionCount(2));


}