using System.Threading.Channels;

//float x = 1.0f;

////x * 10 times
//Console.WriteLine(x + x + x + x + x + x + x + x + x + x);

//decimal m = 1M / 6;
//Console.WriteLine(m);
//Console.WriteLine(1.0 / 6.0);

//string xml = @"<customer id=""123""></customer>";

//Console.WriteLine(xml);

//string raw =            """
//               {
//                  "Name" : "Joe",
//                    "Name" : "Joe"
//               }

//               """;

//Console.WriteLine(raw);

string personName = "Joe";
string rawJson = $$""" 
{
    "Name" : "{{personName}}" 
}
""";
Console.WriteLine(rawJson);
// 注意這裡用了四個 $ 符號，因為 JSON 內容裡面可能有 { }，用來區分。
// 這裡的 {{{ }}} 可能就是原始字串內插的特殊語法。
