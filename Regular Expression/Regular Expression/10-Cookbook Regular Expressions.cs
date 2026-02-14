// 社會安全號（SSN）（如 "123-45-6789"）

using System.Text.RegularExpressions;

string ssNum = @"\d{3}-\d{2}-\d{4}";
Console.WriteLine(Regex.IsMatch("123-45-6789", ssNum));

//電話號碼（如 "123-456-7890" 或 "(123) 456-7890"）
string phoneNum = @"(?x)(\d{3}[-\s] | \(\d{3}\)\s?)
                    \d{3}[-\s]?\d{4}";
Console.WriteLine(Regex.IsMatch("123-456-7890", phoneNum));

//從文本提取每行 name = value 格式，存 name 和 value
string r = @"(?m)^\s*(?'name'\w+)\s*=\s*(?'value'.*)\s*(?=\r?$)";
string text =
    @"id = 3
      secure = true
      timeout = 30";
foreach (Match m in Regex.Matches(text, r))
{
    Console.WriteLine($"Name: {m.Groups["name"].Value}, Value: {m.Groups["value"].Value}");
}

//密碼至少 6 字符，含數字、符號或標點
string passPattern = @"(?x)^(?=.* ( \d | \p{P} | \p{S} )).{6,}";

Console.WriteLine(Regex.IsMatch("abc12", passPattern)); // False（沒符號/標點）
Console.WriteLine(Regex.IsMatch("abcdef", passPattern)); // False（沒數字/符號/標點）
Console.WriteLine(Regex.IsMatch("ab88yz", passPattern)); // True（有數字）

//找長度 >= 80 的行
string rfind80 = @"(?m)^.{80,}(?=\r?$)";

string fifty = new string('x', 50); // 50 字符
string eighty = new string('x', 80); // 80 字符

string text2 = eighty + "\r\n" + fifty + "\r\n" + eighty;

Console.WriteLine(Regex.Matches(text2, rfind80).Count); // 2

//匹配各種數字日期格式（年月日順序可變），含時間和 AM/PM
string rDate = @"(?x)(?i)
    (\d{1,4}) [./-] 
    (\d{1,2}) [./-]
    (\d{1,4}) [\sT] 
    (\d+):(\d+):(\d+) \s? 
    (A\.?M\.?|P\.?M\.?)?"; // AM/PM（可選，大小寫不敏感）

string dateText = "01/02/2008 5:20:50 PM";

foreach (Group g in Regex.Match(dateText, rDate).Groups)
    Console.Write(g.Value + " ");
// 輸出: 01/02/2008 5:20:50 PM 01 02 2008 5 20 50 PM

Console.WriteLine("");