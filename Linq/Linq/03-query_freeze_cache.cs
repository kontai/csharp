var numbers = new List<int>() { 1, 2 };

IEnumerable<int> query = numbers.Select(n => n * 10); // 建查詢，但不執行
foreach (int n in query) Console.Write(n + "|"); // 10|20|

numbers.Clear(); // 清空 numbers，變空列表 {}
foreach (int n in query) Console.Write(n + "|"); // <什麼也沒印>

// 這是因為 query 是 IEnumerable<int>，它是一個查詢，不是一個列表


/**************************************************************************************/
numbers = new List<int> { 1, 2 };
query = numbers.Select(n => n * 10); // 建查詢，但不執行
List<int> list = query.ToList(); // 立即執行查詢，將結果存入 list
numbers.Clear();
