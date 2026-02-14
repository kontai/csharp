using System.Text.RegularExpressions;
/*
 * 向前看（(?=...)/(?!...)）檢查匹配後
 * toward後看（(?<=...)/(?<!...)）檢查匹配前
 */

//Positive Lookahead
Console.WriteLine(Regex.Match("say 25 miles more", @"\d+\s(?=miles)").Value);
Console.WriteLine(Regex.Match("say 25 miles more", @"\d+\s(?=miles).*").Value);
//aleast 6 characters and at least one digit
string password = "2aaaaa";
Console.WriteLine(Regex.IsMatch(password, @"(?=.*\d).{6,}"));

//Nagative Lookahead
string regex = "(?i)good(?!.*(however|but))";
Console.WriteLine(Regex.Match("Good work! But...", regex).Success); // False
Console.WriteLine(Regex.Match("Good work! Thanks!", regex).Success); // True

//Lookbehind
string regex2 = "(?i)(?<!however.*)good";
Console.WriteLine(Regex.Match("However good, we...", regex2).Success); // False
Console.WriteLine(Regex.Match("Very good, thanks!", regex2).Success); // True
