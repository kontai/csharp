using System.Collections.Concurrent;
using System.Globalization;
using System.Text;
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

/*
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

//Range
Range range = 0..2; // C# 8 新增的語法，表示從索引 0 到 2（不包含 2）
Range range2 = ^2..;
Console.WriteLine(vowels[range]);
Console.WriteLine(vowels[range2]);

int[,] matrix = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i,j]=i * 3 + j;
    }
}

int id = 0;
foreach (var i in matrix)
{
    Console.WriteLine(i);
}

//out keyword
string a, b;
Split("Stevie Ray Vaughn", out a, out b);
Console.WriteLine(a); // 印出：Stevie Ray
Console.WriteLine(b); // 印出：Vaughn

void Split(string name, out string firstNames, out string lastName)
{
    int i = name.LastIndexOf(' '); // 找到名字裡最後一個空格
    firstNames = name.Substring(0, i); // 取前面部分（Stevie Ray）
    lastName = name.Substring(i + 1); // 取後面部分（Vaughn）
}

internal class ch2
{
    private static string x = "Old Value";

    private static ref string GetX() => ref x; // This method returns a ref

    private static void Main()
    {
        ref string xRef = ref GetX(); // Assign result to a ref local
        xRef = "New Value";
        Console.WriteLine(x); // New Value
    }
}
*/

StringBuilder sb=new();
StringBuilder sb2=new("Test");

Range str=..;
int[] arr = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
Console.WriteLine(arr[str]);