// \b 
using System.Text.RegularExpressions;

foreach (Match m in Regex.Matches("Wedding in Sarajevo", @"\b\w+\b"))
    Console.WriteLine(m);

// 輸出:
// Wedding
// in
// Sarajevo
Console.WriteLine(Regex.Matches("Wedding in Sarajevo", @"\bin\b").Count);
Console.WriteLine(Regex.Matches("Wedding in Sarajevo", @"in").Count);

//正向前看結合
string text = "Don't loose (sic) your cool";
Console.Write(Regex.Match(text, @"\b\w+\b\s(?=\(sic\))").Value); // loose
