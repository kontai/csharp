using System.Collections;

/// <summary>
/// Initializes a new instance of the <see cref="$Program"/> class.
/// Description: 使用 LINQ 查詢來投影 TempProjectItem 物件
/// 好處是可以將查詢分成多個步驟,並且可以重複使用 TempProjectItem 物件
/// </summary>

string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

// 使用 LINQ 查詢來投影 TempProjectItem 物件
IEnumerable<TempProjectItem> temp = from n in names
                                    select new TempProjectItem()
                                    {
                                        Original = n,
                                        // 移除母音字母
                                        Vowelless = n.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", "")
                                    };

// 使用 LINQ 查詢來篩選和排序 TempProjectItem 物件
IOrderedEnumerable<TempProjectItem> query =
    from n in temp
    where n.Vowelless.Length > 2
    orderby n
    select n;


// 定義 TempProjectItem 類別
class TempProjectItem
{
    public string Original;
    public string Vowelless;
}