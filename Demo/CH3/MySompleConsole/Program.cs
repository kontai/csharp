using System.Xml.Serialization;

// parseTest();
// stringCompareTest();
refDemo();



static void parseTest()
{
    // int i = int.TryParse("123", out int resule) ? resule : 0;
    int g = int.Parse("123", 0);
    int i = int.TryParse("123", out int resule) ? resule : 0;   //如果解析成功，则返回解析结果，否则返回0
    System.Console.WriteLine("i={0}", i);


}

static void stringCompareTest()
{
    string s1 = "abc";
    string s2 = "abc";
    System.Console.WriteLine("s1==s2:{0}", s1 == s2);  //true
    System.Console.WriteLine("s1.Equals(s2):{0}", s1.Equals(s2));  //true
    /*
    C# 執行期（CLR）會維護一個稱為字串暫留池 (Intern Pool) 的表格。
    當編譯器遇到相同的字串常值（literal）時，不會為每個變數建立新的字串物件，
    而是讓所有相同內容的變數指向同一個已存在的字串實例
    */
    System.Console.WriteLine("ReferenceEquals(s1,s2):{0}", ReferenceEquals(s1, s2));  //true

}

static void refDemo()
{
    int[] smallArray = new int[] { 1, 2, 3, 4, 5 };
    int[] bigArray = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
    int index = 7;

    ref int i = ref (index < 5 ? ref smallArray[index] : ref bigArray[index - 5]);
    i = 0;
    System.Console.WriteLine("smallArray: {0}", string.Join(", ", smallArray));
    System.Console.WriteLine("bigArray: {0}", string.Join(", ", bigArray));
}