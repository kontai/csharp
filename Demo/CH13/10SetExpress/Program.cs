List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

// 🌟 1. 差集 Except (我有你沒有的)
// 從 myCars 中扣掉 yourCars 裡也有的車
var carDiff = myCars.Except(yourCars);
// 結果: Yugo
Console.WriteLine("***carDiff***");
show(carDiff);

// 🌟 2. 交集 Intersect (我們都有的)
var carIntersect = myCars.Intersect(yourCars);
// 結果: Aztec, BMW
Console.WriteLine("***carIntersect***");
show(carIntersect);

// 🌟 3. 聯集 Union (合併，並自動「剔除重複」！)
var carUnion = myCars.Union(yourCars);
// 結果: Yugo, Aztec, BMW, Saab (BMW 和 Aztec 只會出現一次)

Console.WriteLine("***carUnion***");
show(carUnion);

// 🌟 4. 串接 Concat (無腦接在一起，保留所有重複)
var carConcat = myCars.Concat(yourCars);
// 結果: Yugo, Aztec, BMW, BMW, Saab, Aztec
Console.WriteLine("***carConcat***");
show(carConcat);

var carDistinct = carConcat.Distinct();
Console.WriteLine("***carDistinct***");
show(carDistinct);

CustomSet();

static void show(IEnumerable<string> cars)
{
    var currentColor = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Yellow;
    foreach (var car in cars)
    {
        Console.WriteLine(car);
    }
    Console.ForegroundColor = currentColor;
}

static void CustomSet()
{
    // 我們有兩批人 (使用 Tuple 來示範)
    var first = new (string Name, int Age)[] { ("Francis", 20), ("Lindsey", 30), ("Ashley", 40) };
    var second = new (string Name, int Age)[] { ("Claire", 30), ("Pat", 30), ("Drew", 33) };

    // ==========================================
    // 🌟 ExceptBy (自訂條件差集)
    // 邏輯：從 first 裡面，剔除掉那些「年紀跟 second 裡面任何人一樣」的人。
    // ==========================================
    // 參數 1：要被剔除的「鍵值清單」 (這裡我們抽出 second 裡面的所有年齡)
    // 參數 2：如何從 first 的物件身上取得鍵值 (指定用 Age 來比對)
    var exceptResult = first.ExceptBy(second.Select(x => x.Age), p => p.Age);
    // 結果: Francis(20), Ashley(40)。 (因為 Lindsey 的 30 歲被對面的 Claire/Pat 給抵銷掉了)

    // ==========================================
    // 🌟 IntersectBy (自訂條件交集)
    // 邏輯：找出 first 裡面，年紀跟 second 裡面的人「一樣」的人。
    // ==========================================
    var intersectResult = first.IntersectBy(second.Select(x => x.Age), person => person.Age);
    // 結果: Lindsey(30)

    // ==========================================
    // 🌟 UnionBy (自訂條件聯集)
    // 邏輯：兩包合併，但如果遇到「年紀相同」的，只保留「第一個出現的」！
    // ==========================================
    var unionResult = first.UnionBy(second, person => person.Age);
    // 結果: 
    // Francis (20)
    // Lindsey (30) -> 🌟 它代表了 30 歲的這個群組，後面的 Claire(30) 和 Pat(30) 都被剔除掉了！
    // Ashley (40)
    // Drew (33)

    var distinctResult = first.DistinctBy(x => x.Age);
    foreach (var person in distinctResult)
    {
        Console.WriteLine(person);
    }
}