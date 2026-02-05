var tune = new LinkedList<string>();

//add elements
tune.AddFirst("do"); // "do"
tune.AddLast("so"); // "do" - "so"

tune.AddAfter(tune.First, "re"); // "do" - "re" - "so"
tune.AddAfter(tune.First.Next, "mi"); // "do" - "re" - "mi" - "so"
tune.AddBefore(tune.Last, "fa"); // "do" - "re" - "mi" - "fa" - "so"

string result = string.Join(" - ", tune); // "do - re - mi - fa - so"
Console.WriteLine(result);

//remove elements
tune.RemoveFirst(); // 移除 "do"，剩 "re" - "mi" - "fa" - "so"
tune.RemoveLast(); // 移除 "so"，剩 "re" - "mi" - "fa"

LinkedListNode<string> miNode = tune.Find("mi"); // 找 "mi" 的節點
tune.Remove(miNode); // 移除 "mi"，剩 "re" - "fa"
tune.AddFirst(miNode); // 放回頭，變 "mi" - "re" - "fa"

// Count, First, Last
Console.WriteLine(tune.Count); // 3
Console.WriteLine(tune.First.Value); // "mi"
Console.WriteLine(tune.Last.Value); // "fa"


//search elements
bool hasFa = tune.Contains("fa"); // true
