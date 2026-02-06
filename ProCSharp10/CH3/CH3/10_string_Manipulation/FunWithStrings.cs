using System;

BasicStringFunctionality();
StringConcatentation();
escapeChar();
verbatimString();

//string靜態函數
static void BasicStringFunctionality()
{
    Console.WriteLine("=> Basic String functionality:");
    string firstName = "Freddy";
    Console.WriteLine("Value of firstName: {0}", firstName);
    Console.WriteLine("firstName has {0} characters.", firstName.Length);
    Console.WriteLine("firstName in uppercase: {0}", firstName.ToUpper());
    Console.WriteLine("firstName in lowercase: {0}", firstName.ToLower());
    Console.WriteLine("firstName contains the letter y?: {0}",
      firstName.Contains("y"));

    //replace created a new string,firstName didn't change
    Console.WriteLine("New first name: {0}", firstName.Replace("dy", ""));
    Console.WriteLine("After replace,firstName: {0}", firstName);
    Console.WriteLine();
}

//字符串拼接
static void StringConcatentation()
{
    //using operation +
    Console.WriteLine("=> String concatenation:");
    string s1 = "Programming the ";
    string s2 = "PsychoDrill (PTP)";
    string s3 = s1 + s2;
    Console.WriteLine(s3);

    //using string function Concat()
    string s4 = string.Concat(s1, s2);
    Console.WriteLine(s4);
    Console.WriteLine();
}

static void escapeChar()
{
    string str = "The tab\tabc";
    Console.WriteLine("The tab abc");
    Console.WriteLine("The tab  abc");
    Console.WriteLine("The tab   abc");
    Console.WriteLine("The tab    abc");
    Console.WriteLine(str);
    string nl = Environment.NewLine;
}

static void stringInterpolation()
{
    Console.WriteLine("=> String interpolation:\a");
    // Some local variables we will plug into our larger string
    int age = 4;
    string name = "Soren";

    // Using curly-bracket syntax.
    string greeting = string.Format("Hello {0} you are {1} years old.", name, age);
    Console.WriteLine(greeting);

    // Using string interpolation
    string greeting2 = $"Hello {name} you are {age} years old.";
    Console.WriteLine(greeting2);
}

void verbatimString()
{
    string myLongString = @"This is a very
     very
          very
               long string";
    Console.WriteLine(myLongString);

    string path = @"c:\abc\def\the_file.1";
    Console.WriteLine(path);

    //interpolation + verbatim string
    string interp = "interpolation";
    string myLongString2 = @$"This is a very
   very
         long string with {interp}";
    Console.WriteLine(myLongString2);
}