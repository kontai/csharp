int a = 10, b = 90;
Console.WriteLine("交換前: {0}, {1}", a, b);

// 呼叫時，明確告訴編譯器：這次的 T 是 int！
//Swap<int>(ref a, ref b);
//Inference the type
Swap(ref a, ref b);

Console.WriteLine("交換後: {0}, {1}", a, b);
Console.WriteLine();
string s1 = "Hello", s2 = "There";
Console.WriteLine("交換前: {0} {1}!", s1, s2);

// 呼叫時，明確告訴編譯器：這次的 T 是 string！
//Ingerence the type
//Swap<string>(ref s1, ref s2);
Swap(ref s1, ref s2);

//只有在泛型方法**「至少有一個參數」時，推導機制才會生效。
//如果方法沒有參數，編譯器就沒有線索可以猜，這時你必須**手動提供佔位符

Console.WriteLine("交換後: {0} {1}!", s1, s2);

static void Swap<T>(ref T x, ref T y)
{
    // 定义一个临时变量temp，用于存储x的值
    T temp = x;
    // 将x的值设置为y的值
    x = y;
    // 将y的值设置为原始x的值（存储在temp中）
    y = temp;
}
