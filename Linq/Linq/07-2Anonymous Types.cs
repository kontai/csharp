string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

// 
var intermediate = from n in names
                   select new
                   {
                       Original = n,
                       Vowelless = n.Replace("a", "").Replace("e", "").Replace("i", "")
                           .Replace("o", "").Replace("u", "")
                   };

// 使用 LINQ 查詢來篩選和排序 TempProjectItem 物件
IEnumerable<string> query =
    from n in intermediate
    where n.Vowelless.Length > 2
    orderby n
    select n.Original;

//使用let闗鍵字
//編譯器把 let 轉成臨時匿名型別（anonymous type），包含範圍變數（n）和新變數（vowelless）。
//跟之前匿名型別例子類似，但這裡自動生成，結構包含 n 和 vowelless。
//結果等價於用匿名型別投影：

query = from n in names
        let vowelless = n.Replace("a", "").Replace("e", "").Replace("i", "")
            .Replace("o", "").Replace("u", "")
        where vowelless.Length > 2
        orderby vowelless
        select n;