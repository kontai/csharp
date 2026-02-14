using System.Text.RegularExpressions;

Console.WriteLine(Regex.Match("Not now", "^[Nn]o").Value); // No
Console.WriteLine(Regex.Match("f = 0.2F", "[Ff]$").Value); // F

string fileNames = "a.txt" + "\r\n" + "b.docx" + "\r\n" + "c.txt";
string r = @".+\.txt(?=\r?$)"; // 匹配行尾 ".txt"，正向前看確保 \r?（可有可無）
foreach (Match m in Regex.Matches(fileNames, r, RegexOptions.Multiline))
    Console.Write(m + " "); // a.txt c.txt

// OUTPUT: a.txt c.txt
Console.WriteLine("");

Console.WriteLine(Regex.Match("x", "$").Length); // 0