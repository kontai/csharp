using System.Text.RegularExpressions;

// Example 1 - Match a single character
// Console.WriteLine(Regex.Match("color", @"colou?r").Success); // True
// Console.WriteLine(Regex.Match("colour", @"colou?r").Success); // True
// Console.WriteLine(Regex.Match("colouur", @"colou?r").Success); // False

// Match a single character
Match m = Regex.Match("any colour you like", @"colou?r");
Console.WriteLine(m.Success); // True if "colour" or "color" is found
Console.WriteLine(m.Index); // Index of the match
Console.WriteLine(m.Length); // Length of the match
Console.WriteLine(m.Value); // Value of the match
Console.WriteLine(m.ToString()); // String representation of the match

// NextMatch() method returns the next match in the input string
Match m1 = Regex.Match("One color? There are two colours in my head!", @"colou?rs?");
Match m2 = m1.NextMatch();

Console.WriteLine(m1); // color（第一個匹配）
Console.WriteLine(m2); // colours（第二個匹配）

// Matches all occurrences of the regular expression in the input string
foreach (Match mm in Regex.Matches("One color? There are two colours in my head!", @"colou?rs?"))
    Console.WriteLine(mm); // color, colours

// IsMatch() method determines whether the regular expression pattern matches the input string
Console.WriteLine(Regex.IsMatch("Jenny", "Jen(ny|nifer)?")); // True (Jen, Jenny, Jennifer)

// Match with a timeout 防止惡意或錯誤正則表達式無窮迴圈
TimeSpan ts = new TimeSpan(0, 0, 0, 0, 500);
Match m3 = Regex.Match("One color? There are two colours in my head!", @"colou?rs?", RegexOptions.IgnoreCase, ts);