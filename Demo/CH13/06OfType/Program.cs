using System.Collections;

Foo();

static void Foo()
{
    // ArrayList 是非泛型集合，元素型別為 object，可以同時存放不同型別的資料
    ArrayList arrayList = new ArrayList();

    // 一次加入多種型別的元素：bool、int、string、匿名型別
    arrayList.AddRange(new object[]
    {
    true,
    2,3,4,5,6,7,8,
    "Words", "More Words",
    new {Make = "Toyota", Model = "Corolla"}
    });

    // OfType<T>() 會篩選出集合中型別符合 T 的元素，並回傳強型別的 IEnumerable<T>
    // 這裡只會篩選出 int 型別的元素，其餘型別（bool、string、匿名型別）會被忽略
    var myInts = arrayList.OfType<int>();

    // 走訪篩選後的整數集合並輸出
    foreach (var i in myInts)
    {
        Console.WriteLine(i);
    }
}