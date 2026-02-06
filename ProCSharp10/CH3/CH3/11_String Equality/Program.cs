using System;
using System.Diagnostics;
using System.Text;

StringEquality();
StringEqualitySpecifyingCompareRules();
StringsAreImmutable();
stringConcatSpeedTest();
FunWithStringBuilder();

static void StringEquality()
{
    Console.WriteLine("=> String equality:");
    string s1 = "Hello!";
    string s2 = "Yo!";
    Console.WriteLine("s1 = {0}", s1);
    Console.WriteLine("s2 = {0}", s2);
    Console.WriteLine();
    // Test these strings for equality.
    Console.WriteLine("s1 == s2: {0}", s1 == s2);
    Console.WriteLine("s1 == Hello!: {0}", s1 == "Hello!");
    Console.WriteLine("s1 == HELLO!: {0}", s1 == "HELLO!");
    Console.WriteLine("s1 == hello!: {0}", s1 == "hello!");
    Console.WriteLine("s1.Equals(s2): {0}", s1.Equals(s2));
    Console.WriteLine("Yo!.Equals(s2): {0}", "Yo!".Equals(s2));
    Console.WriteLine();
    Console.WriteLine("==========================================");
}

static void StringEqualitySpecifyingCompareRules()
{
    Console.WriteLine("=> String equality (Case Insensitive:");
    string s1 = "Hello!";
    string s2 = "HELLO!";
    Console.WriteLine("s1 = {0}", s1);
    Console.WriteLine("s2 = {0}", s2);
    Console.WriteLine();
    // Check the results of changing the default compare rules.
    Console.WriteLine("Default rules: s1={0},s2={1}s1.Equals(s2): {2}", s1, s2,
  s1.Equals(s2));
    Console.WriteLine("Ignore case: s1.Equals(s2, StringComparison.OrdinalIgnoreCase): {0}",
      s1.Equals(s2, StringComparison.OrdinalIgnoreCase));
    Console.WriteLine("Ignore case, Invariant Culture: s1.Equals(s2, StringComparison InvariantCultureIgnoreCase): {0}", s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase));
    Console.WriteLine();
    Console.WriteLine("Default rules: s1={0},s2={1} s1.IndexOf(\"E\"): {2}", s1, s2, s1.IndexOf("E"));
    Console.WriteLine("Ignore case: s1.IndexOf(\"E\", StringComparison.OrdinalIgnoreCase): {0}", s1.IndexOf("E", StringComparison.OrdinalIgnoreCase));
    Console.WriteLine("Ignore case, Invariant Culture: s1.IndexOf(\"E\", StringComparison.InvariantCultureIgnoreCase): {0}", s1.IndexOf("E", StringComparison.InvariantCultureIgnoreCase));
    Console.WriteLine();
    Console.WriteLine("==========================================");
}

//string 不可改變
static void StringsAreImmutable()
{
    Console.WriteLine("=> Immutable Strings:");
    // Set initial string value.
    string s1 = "This is my string.";
    Console.WriteLine("s1 = {0}", s1);
    // Uppercase s1?
    string upperString = s1.ToUpper();
    Console.WriteLine("upperString = {0}", upperString);
    // Nope! s1 is in the same format!
    Console.WriteLine("s1 = {0}", s1);
    Console.WriteLine("==========================================");
}

//see in ILDASM
static void StringsAreImmutable2()
{
    //Console.WriteLine("=> Immutable Strings 2:");
    string s2 = "My other string";
    s2 = "New string value";
}

static void stringConcatSpeedTest()
{
    string s = "";
    const int SIZE = 59999;

    Stopwatch sw = new Stopwatch();

    //字符串拼接
    sw.Start();
    for (int i = 0; i < SIZE; i++)
    {
        s += i;
    }
    sw.Stop();
    Console.WriteLine($"字符串拼接 0~{SIZE},共計花費 {sw.ElapsedMilliseconds}ms");

    sw.Reset();

    sw.Start();
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < SIZE; i++)
    {
        sb.Append(i);
    }

    string sbStr = sb.ToString();
    sw.Stop();
    Console.WriteLine($"使用StringBuilder拼接 0~{SIZE},共計花費 {sw.ElapsedMilliseconds}ms");
    Console.WriteLine("==========================================");
}

static void FunWithStringBuilder()
{
    Console.WriteLine("=> Using the StringBuilder:");
    StringBuilder sb = new StringBuilder("**** Fantastic Games ****");
    sb.Append("\n");
    sb.AppendLine("Half Life");
    sb.AppendLine("Morrowind");
    sb.AppendLine("Deus Ex" + "2");
    sb.AppendLine("System Shock");
    Console.WriteLine(sb.ToString());
    sb.Replace("2", " Invisible War");
    Console.WriteLine(sb.ToString());
    Console.WriteLine("sb has {0} chars.", sb.Length);
    Console.WriteLine();
}