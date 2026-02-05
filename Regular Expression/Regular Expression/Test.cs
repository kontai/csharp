using System.Text.RegularExpressions;

Console.WriteLine(Regex.Match("say 25 miles more", @"\d+\s(?=miles)").Value);

