using System.Text.RegularExpressions;

/****************************** Numbered Groups ******************************/
Match m = Regex.Match("206-465-1918", @"(\d{3})-(\d{3}-\d{4})");

Console.WriteLine(m.Groups[1]); // 206（第一群，區碼）
Console.WriteLine(m.Groups[2]); // 465-1918（第二群，本地號）
Console.WriteLine(m.Groups[0]); // 206-465-1918（第 0 群，整個匹配）
Console.WriteLine(m); // 206-465-1918（同 Groups[0]）

foreach (Match m2 in Regex.Matches("pop pope peep", @"\b(\w)\w+\1\b"))
    Console.Write(m2 + " ");
Console.WriteLine("");

/****************************** Named Groups ******************************/
//定義：(?'group-name'group-expr) 或 (?<group-name>group-expr)。
//參考：\k'group-name' 或 \k<group-name>。

var named = Regex.Matches("pop pope peep",
    @"\b" +
    @"(?'letter'\w)" +      //letter 群名
    @"\w+" +
    @"\k'letter'" +
    @"\b");
foreach (Match m3 in named)
    Console.Write(m3 + " ");

Console.WriteLine("");

string regFind =
    @"<(?'tag'\w+?).*>" + // 懶匹配開頭標籤，命名 'tag'
    @"(?'text'.*?)" + // 懶匹配內容，命名 'text'
    @"</\k'tag'>"; // 匹配結尾標籤，用 'tag'

Match m4 = Regex.Match("<h1>hello</h1>", regFind);
Console.WriteLine(m4.Groups["tag"].Value); // h1
Console.WriteLine(m4.Groups["text"].Value); // hello
