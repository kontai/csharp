string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

// Progressive Queries
IEnumerable<string> query = names
    .Select(n => n.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", "")) // 移除母音
    .Where(n => n.Length > 2) // 過濾長度大於2的字串
    .OrderBy(n => n); // 依字母順序排序

Console.WriteLine("{0} (x{1})", string.Join(",", query), query.Count());

// 錯誤的查詢
query = from n in names
        where n.Length > 2
        orderby n
        select n.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", "");

Console.WriteLine("{0} (x{1})", string.Join(",", query), query.Count()); //Tm,Dck,Hrry,Mry,Jy

// 正確的查詢
query = from n in names
        select n.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", ""); // 移除母音

query = from n in query
        where n.Length > 2 // 過濾長度大於2的字串
        orderby n // 依字母順序排序
        select n;

Console.WriteLine("{0} (x{1})", string.Join(",", query), query.Count());

// 正確的查詢,使用into闗鍵字,將select結果傳給下一個查詢部份
query = from n in names
        select n.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", "")
    into noVowel //投影（移除母音）後，把結果存到 noVowel（像中間變數）
        where noVowel.Length > 2
        orderby noVowel
        select noVowel;

Console.WriteLine("{0} (x{1})", string.Join(",", query), query.Count());
/*
 為啥 into 不影響性能？
雖然 into 看起來像「重啟」查詢，但在最終的流暢語法裡還是單一鏈（chain）。
沒有內在性能損失（no intrinsic performance hit），因為編譯器合併成同一個查詢。
用 into 不會扣分（nor do you lose any points），只是語法選擇。

但是，into 有一個範圍規則（Scoping Rules）
into 會在查詢中引入新的範圍（scope），所以不能在同一個查詢中使用相同的變數名稱。
這是因為 into 會在查詢中引入新的範圍（scope），所以不能在同一個查詢中使用相同的變數名稱。
例如 where n.Length > 2 orderby n select n 會報錯，因為 n 已經在 into 後的範圍被覆蓋了。
 */

// 正確的查詢,使用let關鍵字,將select結果傳給下一個查詢部份
query = from n in names
        let noVowel = n.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", "")
        where noVowel.Length > 2
        orderby noVowel
        select noVowel;