//work with string

//Length
string name = "John Doe";
Console.WriteLine(name.Length); // Output: 8

//Compare
//如果name1和name2相等，返回0；如果name1在字典顺序中排在name2之前，返回一个负数；如果name1在字典顺序中排在name2之后，返回一个正数。
string name1="JOhn";
string name2="John";
System.Console.WriteLine(string.Compare(name1,name2)); 

//Contains
string sentence = "Hello, world! How are you?";
bool containsHello = sentence.Contains("Hello");
bool containsGood = sentence.Contains("good");
System.Console.WriteLine(containsHello); // Output: True
System.Console.WriteLine(containsGood); // Output: False

//Equals
string str1 = "Hello";
string str2 = "hello";
bool equals = str1.Equals(str2, StringComparison.OrdinalIgnoreCase);    //StringComparison.OrdinalIgnoreCase不区分大小写
System.Console.WriteLine(equals); // Output: True

//Substring-- 返回子字符串
string str = "Hello, world!";
string substring = str.Substring(7);
System.Console.WriteLine(substring); // Output: "world!"

//Insert 
string strIns1 = "Hello, ";
string strIns2 = "world!";
string result = strIns1.Insert(7, strIns2);
System.Console.WriteLine(result); // Output: "Hello, world!"

//Concat
System.Console.WriteLine(string.Concat(strIns1, strIns2));

//Padleft,padright
string strPad = "Hello";
string paddedStr = strPad.PadLeft(10);
System.Console.WriteLine(paddedStr); // Output: "Hello      "
System.Console.WriteLine(strPad.PadRight(10));

//Remove
string strRemove = "Hello, world!";
string removedStr = strRemove.Remove(7);
System.Console.WriteLine(removedStr); // Output: "Hello"

//Replace()
string replacedStr = strRemove.Replace("world", "universe");
System.Console.WriteLine(replacedStr); // Output: "Hello, universe!"

//split-- 依据分隔符,返回字符串数组
string strSplit = "Hello, world!";
string[] splitStr = strSplit.Split(',');
System.Console.WriteLine(splitStr[0]); // Output: "Hello"
System.Console.WriteLine(splitStr[1]); // Output: " world!"

//Trim-- 去除字符串两端的空格
string strTrim = "   Hello, world!   ";
string trimmedStr = strTrim.Trim();
System.Console.WriteLine(trimmedStr); // Output: "Hello, world!"
