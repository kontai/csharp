using System.Text.RegularExpressions;

Regex r = new Regex(@"sausages?", RegexOptions.Compiled); // 編譯模式
Console.WriteLine(r.Match("sausage").Success); // True
Console.WriteLine(r.Match("sausages").Success); // True

Console.WriteLine(Regex.Match("a", "A", RegexOptions.IgnoreCase).Success); // True
Console.WriteLine(Regex.Match("AAAa", @"(?i)a (?i) a"));   //(?i)忽略大小寫, (?i)a(?i)a 匹配 aA, Aa, AA, aa