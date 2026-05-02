StringEqualitySpecifyingCompareRules();

static void StringEqualitySpecifyingCompareRules()
{
    Console.WriteLine("=> String equality (Case Insensitive - 不區分大小寫):");
    string s1 = "Hello!";
    string s2 = "HELLO!";
    Console.WriteLine("s1 = {0}", s1);
    Console.WriteLine("s2 = {0}", s2);
    Console.WriteLine();

    // 1. 測試 Equals() 變更規則的結果
    // 輸出: False (預設區分大小寫)
    Console.WriteLine("Default rules: s1={0},s2={1} s1.Equals(s2): {2}", s1, s2, s1.Equals(s2));

    // 輸出: True (忽略大小寫，使用二進位序數比對，效能最佳)
    Console.WriteLine("Ignore case: s1.Equals(s2, StringComparison.OrdinalIgnoreCase): {0}",
        s1.Equals(s2, StringComparison.OrdinalIgnoreCase));

    // 輸出: True (忽略大小寫，使用固定英文語系規則比對)
    Console.WriteLine("Ignore case, Invariant Culture: s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase): {0}",
        s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase));

    Console.WriteLine();

    // 2. 測試 IndexOf() 尋找字元位置 (尋找大寫 "E" 在 s1 "Hello!" 中的索引)
    // 輸出: -1 (找不到，因為預設區分大小寫，s1 只有小寫 'e')
    Console.WriteLine("Default rules: s1={0},s2={1} s1.IndexOf(\"E\"): {2}", s1, s2, s1.IndexOf("E"));

    // 輸出: 1 (找到了！在索引 1 的位置，忽略大小寫)
    Console.WriteLine("Ignore case: s1.IndexOf(\"E\", StringComparison.OrdinalIgnoreCase): {0}",
        s1.IndexOf("E", StringComparison.OrdinalIgnoreCase));

    // 輸出: 1 (內聯語系忽略大小寫，同樣能找到)
    Console.WriteLine("Ignore case, Invariant Culture: s1.IndexOf(\"E\", StringComparison.InvariantCultureIgnoreCase): {0}",
        s1.IndexOf("E", StringComparison.InvariantCultureIgnoreCase));

    Console.WriteLine();
}