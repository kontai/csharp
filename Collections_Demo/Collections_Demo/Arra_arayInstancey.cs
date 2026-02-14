/**
 * 動態創建數組
 */
Array arrayInstance = Array.CreateInstance(typeof(string), 5);
arrayInstance.SetValue("hello", 0);
arrayInstance.SetValue("world", 1);
Console.WriteLine(arrayInstance.GetValue(0));

Console.WriteLine(arrayInstance.Length);

string[] toString = (string[])arrayInstance;
foreach (var se in toString)
{
    Console.WriteLine(se);
}


FirstElementIndex(toString);

void FirstElementIndex(Array arr)
{
    Console.WriteLine($"{arr.Rank} -Dimension");
    int[] index = new int[arr.Rank];
    Console.WriteLine(arr.GetValue(index));
}