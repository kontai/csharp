var words = new List<string>(); // 創建 string 列表

words.Add("melon"); // 加 "melon"
words.Add("avocado"); // 加 "avocado"
words.AddRange(["banana", "plum"]); // 加一堆 ["banana", "plum"]
words.Insert(0, "lemon"); // 開頭插 "lemon"
words.InsertRange(0, ["peach", "nashi"]); // 開頭插 ["peach", "nashi"]

words.Remove("melon"); // 移除 "melon"
words.RemoveAt(3); // 移除第 4 個元素
words.RemoveRange(0, 2); // 移除前 2 個
words.RemoveAll(s => s.StartsWith('n')); // 移除開頭是 "n" 的

Console.WriteLine(words[0]); // 第一個
Console.WriteLine(words[^1]); // 最後一個
foreach (string s in words) Console.WriteLine(s); // 所有
List<string> subset = words.GetRange(1, 2); // 拿中間 2 個

string[] wordsArray = words.ToArray(); // 轉成陣列
string[] existing = new string[1000];
words.CopyTo(0, existing, 998, 2); // 複製前 2 個到 existing 最後

List<string> upperCaseWords = words.ConvertAll(s => s.ToUpper()); // 轉大寫
List<int> lengths = words.ConvertAll(s => s.Length); // 轉長度