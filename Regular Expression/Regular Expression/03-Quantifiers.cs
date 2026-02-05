using System.Text.RegularExpressions;

Regex bp = new Regex(@"\d{2,3}/\d{2,3}", RegexOptions.Compiled);
Console.WriteLine(bp.Match("It used to be 160/110").Value);
Console.WriteLine(bp.Match("Now it's only 115/75").Value);

string html = "<i>By default</i> quantifiers are <i>greedy</i> creatures";
foreach (Match m in Regex.Matches(html, @"<i>.*</i>"))
    Console.WriteLine(m);
Console.WriteLine("*********************");
foreach (Match m in Regex.Matches(html, @"<i>.*?</i>"))
    Console.WriteLine(m);