nullableMembers();

//#nullable disable   //關閉nullable警告

// p 是可為 null 的參考型別 (Person?)，這裡實際指派了一個有效的物件
Person? p = new Person { Name = "John", Age = 30 };

// p2 明確指派為 null，編譯器不會警告，因為型別宣告為 Person?
Person? p2 = null;

// p3 參考 p2，因此同樣是 null
Person? p3 = p2;

// 可為 null 的字串
string? anotherNullableString = null;

// null 條件運算子 (?.)：p 不為 null 時才存取 Name，否則整個運算式回傳 null
Console.WriteLine(p?.Name);

// p2 為 null，p2?.Name 會短路回傳 null，再用 ?? 運算子提供預設值 20
Console.WriteLine("Length of name= {0}", p2?.Name.Length ?? 20);    //p2.Name == null ? 20 : p2.Name.Length

// 與上一行等價的寫法，用三元運算子明確表達「null 就給 20，否則取長度」的邏輯
Console.WriteLine("Length of name= {0}", p2?.Name == null ? 20 : p2.Name.Length);

static void nullableMembers()
{
    // int? 是 Nullable<int>，可以額外儲存「沒有值」的狀態
    int? i = 20;

    // HasValue 判斷是否有實際數值（非 null）
    Console.WriteLine(i.HasValue);
    if (i.HasValue)
    {
        // Value 用來取出實際的數值，只有在 HasValue 為 true 時才能安全呼叫
        Console.WriteLine("i has value: {0}", i.Value);
    }
}

static void LocalNullableVariables()
{
    //Define some local nullable variables
    // 各種實質型別 (value type) 皆可透過 ? 後綴變成可為 null 的版本
    int? nullableInt = 10;
    double? nullbaleDouble = 3.14;
    bool? nullbaleBool = null;
    char? nullableChar = 'a';

    // 可為 null 的 int 陣列，每個元素都可以是 null 或實際的整數
    var arrayOfNullableInts = new int?[20];
}

class Person
{
    // required 表示建立物件時必須以物件初始設定式指定此屬性，避免 Name 為 null
    public required string Name;
    public int Age;
}