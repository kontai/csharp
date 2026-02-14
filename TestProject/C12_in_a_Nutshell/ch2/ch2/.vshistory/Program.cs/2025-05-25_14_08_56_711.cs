using System.Threading.Channels;

//float x = 1.0f;

////x * 10 times
//Console.WriteLine(x + x + x + x + x + x + x + x + x + x);

//decimal m = 1M / 6;
//Console.WriteLine(m);
//Console.WriteLine(1.0 / 6.0);

//string xml = @"<customer id=""123""></customer>";

//Console.WriteLine(xml);

//string raw =            """
//               {
//                  "Name" : "Joe",
//                    "Name" : "Joe"
//               }

//               """;

//Console.WriteLine(raw);

string personName = "Joe";
string rawJson = $$"""
{
    "Name" : "{{personName}}"
}
""";
Console.WriteLine(rawJson);
// 注意這裡用了四個 $ 符號，因為 JSON 內容裡面可能有 { }，用來區分。
// 這裡的 {{{ }}} 可能就是原始字串內插的特殊語法。

Console.WriteLine("The Text 5");

bool b = true;
// (b ? 1 : 0) 意思是如果 b 是 true 就取 1，否則取 0
Console.WriteLine($"The answer in binary is {(b ? 1 : 0)}"); // 會印出：The answer in binary is 1
char[] vowels = new char[]{ 'a', 'e', 'i', 'o', 'u' };
char[] vowels2 = ['a', 'e', 'i', 'o', 'u']; // C# 12 新增的語法，使用 [] 來定義陣列

Index first = 0;
Index last = ^1; // C# 8 新增的語法，^1 表示從結尾開始倒數第一個元素

Console.WriteLine($"first of voewls is {vowels[first]}");
Console.WriteLine($"last of voewls is {vowels[last]}");
