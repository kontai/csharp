using System.Text.RegularExpressions;

string find = @"\bcat\b"; // 整詞 "cat"（\b 字詞邊界）
string replace = "dog";
Console.WriteLine(Regex.Replace("catapult the cat", find, replace));

// 輸出: catapult the dog

string text = "10 plus 20 makes 30";
Console.WriteLine(Regex.Replace(text, @"\d+", @"<$0>"));

/*
 * 用群組參考（$1、$2 或 ${name}）：
 * 數字群組：$1、$2... 參考括號捕獲的順序（從 1 開始）。
 * 命名群組：${name} 參考命名群組（如 'tag'、'text'）。
 * 例子（改 XML 元素，把內容移到屬性）：
 */

//<msg>hello</msg> to <msg value="hello"/>
string xml = "<msg>hello</msg>";
string rfind = @"<(?<tag>\w+?).*?>(?<text>.*?)</\k<tag>>";
string rreplace = @"<${tag} value=""${text}""/>";
Console.WriteLine(Regex.Replace(xml, rfind, rreplace));

/*
 * MatchEvaluator 委派
 * 功能：Regex.Replace 有過載接受 MatchEvaluator 委派，每次匹配時調用，替換邏輯交給 C# 碼。
 * 為啥有用？**正則語法不夠時，C# 處理更強大。
 * 例子（數字乘 10）：
 */

string text2 = "10 plus 20 makes 30";
//Console.WriteLine(Regex.Replace(text2, @"\d+", m => (int.Parse(m.Value) * 10).ToString()));
Console.WriteLine(Regex.Replace(text2,
    @"\d+",
    m => (int.Parse(m.Value) * 10).ToString()));