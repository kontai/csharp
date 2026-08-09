using FunWithLinqExpressions;

ProductInfo[] itemsInStock = new[]
{
    new ProductInfo{ Name = "Mac's Coffee", Description = "Coffee with TEETH", NumberInStock = 24 },
    new ProductInfo{ Name = "Milk Maid Milk", Description = "Milk cow's love", NumberInStock = 100 },
    new ProductInfo{ Name = "Pure Silk Tofu", Description = "Bland as Possible", NumberInStock = 120 },
    new ProductInfo{ Name = "Crunchy Pops", Description = "Cheezy, peppery goodness", NumberInStock = 2 },
    new ProductInfo{ Name = "RipOff Water", Description = "From the tap to your wallet", NumberInStock = 100 },
    new ProductInfo{ Name = "Classic Valpo Pizza", Description = "Everyone loves pizza!", NumberInStock = 73 },
    new ProductInfo{ Name = "Mr. Goodbar", Description = "Movie Theater Nutrition", NumberInStock = 50 },
};

TryNotGetEnumeratedCount(itemsInStock);

static void TryNotGetEnumeratedCount(ProductInfo[] productInfos)
{
    // select s 只是原樣投影每個元素，查詢結果底層仍然是陣列，
    // 因此 LINQ 不需要真的走訪整個序列就能推算出元素個數
    var result = from s in productInfos select s;

    // TryGetNonEnumeratedCount 會嘗試在「不列舉序列」的前提下取得元素數量
    // （例如底層是 ICollection、陣列等已知長度的型別時才會成功）
    if (result.TryGetNonEnumeratedCount(out int count))
    {
        Console.WriteLine($"Count: {count}");
    }
    else
    {
        Console.WriteLine("Unable to get count");
    }

    // GetProduct 是用 yield return 實作的迭代器方法，回傳的是延遲執行的 IEnumerable<T>
    // 這種序列沒有已知長度，必須實際列舉才能算出個數，
    // 所以 TryGetNonEnumeratedCount 這裡會失敗（回傳 false）
    bool newResult = GetProduct(productInfos).TryGetNonEnumeratedCount(out int newCount);
    if (newResult)
    {
        Console.WriteLine($"New Count: {newCount}");
    }
    else
    {
        Console.WriteLine("Unable to get new count");
    }
}


static IEnumerable<ProductInfo> GetProduct(ProductInfo[] productInfos)
{
    // 使用 yield return 建立一個延遲執行的迭代器
    // 呼叫端每列舉一次，才會執行一次迴圈本體並回傳一個元素
    for (int i = 0; i < productInfos.Length; i++)
    {
        yield return productInfos[i];
    }
}
