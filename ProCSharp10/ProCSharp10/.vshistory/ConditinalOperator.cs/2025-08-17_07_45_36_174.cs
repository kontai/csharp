ConditionalRefExample();
static void ConditionalRefExample()
{
    var smallArray = new int[] { 1, 2, 3, 4, 5 };
    var largeArray = new int[] { 10, 20, 30, 40, 50 };
    int index = 7;

    // 這裡的 ?: 運算式不是回傳值，而是回傳「某個陣列位置的引用」
    ref int refValue = ref ((index < 5)
        ? ref smallArray[index]
        : ref largeArray[index - 5]);

    refValue = 0; // 這一行會改變 largeArray[2] 的值

    index = 2;
    // 同樣道理，這裡直接把 smallArray[2] 改成 100
    ((index < 5)
        ? ref smallArray[index]
        : ref largeArray[index - 5]) = 100;

    Console.WriteLine(string.Join(" ", smallArray));
    Console.WriteLine(string.Join(" ", largeArray));
}
