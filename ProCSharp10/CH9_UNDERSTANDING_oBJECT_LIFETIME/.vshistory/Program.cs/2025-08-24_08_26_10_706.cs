using GCProjNS;

Gc_Func();
void Gc_Func()
{
    Console.WriteLine("***** Fun with System.GC *****");

// 印出堆積上大概用了多少記憶體
Console.WriteLine("Estimated bytes on heap: {0}",
  GC.GetTotalMemory(false));

// 注意：MaxGeneration 是 0-based，所以要 +1 才能顯示正確代數
Console.WriteLine("This OS has {0} object generations.\n",
 (GC.MaxGeneration + 1));

Car refToMyCar = new Car("Zippy", 100);
Console.WriteLine(refToMyCar.ToString());

// 看 refToMyCar 這個物件現在在哪一代
Console.WriteLine("Generation of refToMyCar is: {0}",
  GC.GetGeneration(refToMyCar));


}