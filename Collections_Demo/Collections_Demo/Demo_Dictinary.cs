var d = new Dictionary<string, int>();

d.Add("One", 1); // 加 "One" -> 1
d["Two"] = 2; // 加 "Two" -> 2（沒重複）
d["Two"] = 22; // 更新 "Two" -> 22（已存在）
d["Three"] = 3;

Console.WriteLine(d["Two"]); // 22
Console.WriteLine(d.ContainsKey("One")); // true（快）
Console.WriteLine(d.ContainsValue(3)); // true（慢）

int val = 0;
if (!d.TryGetValue("onE", out val)) // 區分大小寫
    Console.WriteLine("No val"); // "No val"

// 遍歷三種方式
foreach (KeyValuePair<string, int> kv in d)
    Console.WriteLine($"{kv.Key}; {kv.Value}"); // One; 1, Two; 22, Three; 3

foreach (string s in d.Keys) Console.Write(s); // OneTwoThree
Console.WriteLine();
foreach (int i in d.Values) Console.Write(i); // 1223