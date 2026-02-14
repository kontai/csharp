using System.Text;

foreach (EncodingInfo info in Encoding.GetEncodings())
{
    Console.WriteLine(info.Name);
}

Encoding utf8 = Encoding.GetEncoding("UTF-8");
