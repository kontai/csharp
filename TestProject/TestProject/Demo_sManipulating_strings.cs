string left3 = "12345".Substring(0, 3);
string mid3 = "12345".Substring(1, 3);

Console.WriteLine($"left3={left3}");
Console.WriteLine($"left3={mid3}");

//omit length
string end3 = "12345".Substring(2);
Console.WriteLine($"end3={end3}");

//padleft
string star = new string("").PadLeft(20, '*');
Console.WriteLine($"star: {star}");
int[] arr = new int[] { };
