using System.Threading.Channels;

float x = 1.0f;

//x * 10 times
Console.WriteLine(x + x + x + x + x + x + x + x + x + x);

decimal m = 1M / 6;
Console.WriteLine(m);
Console.WriteLine(1.0 / 6.0);

string xml = @"<customer id=""123""></customer>";

Console.WriteLine(xml);

string raw = """
             {
                 "Name" : "Joe"
             }

             """;

Console.WriteLine(raw);

