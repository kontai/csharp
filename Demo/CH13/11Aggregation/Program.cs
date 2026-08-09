using FunWithLinqExpressions;

double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2 };
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

//AggregationOps(winterTemps);
//AggregationOpsBySelector(itemsInStock);
//TestTupleAggregation();
TestRecordAggregation();
static void AggregationOps(double[] wTemps)
{
    double maxTemp = wTemps.Max();
    double minTemp = wTemps.Min();
    double averageTemp = wTemps.Average();
    double sumTemp = wTemps.Sum();
    Console.WriteLine($"Max: {maxTemp}\nMin: {minTemp}\nAverage: {averageTemp}\nSum: {sumTemp}");
}

static void AggregationOpsBySelector(ProductInfo[] productInfos)
{
    var maxStockItem = productInfos.MaxBy(g => g.NumberInStock);
    Console.WriteLine($"最多庫存的商品是: {maxStockItem.Name}");
}

//使用Tuple,Record回傳多個值
//寫法一:使用Tuple
static (double MaxTemp, double MinTemp, double AverageTemp) GetTemperatureStats(double[] temps)
{
    return (temps.Max(), temps.Min(), temps.Average());
}

static void TestTupleAggregation()
{
    double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2 };

    // 🌟 利用「解構 (Deconstruction)」優雅地接住三個回傳值！
    var (max, min, avg) = GetTemperatureStats(winterTemps);
    Console.WriteLine($"Tuple 結果 -> 最高:{max}, 最低:{min}, 平均:{avg}");
}

//寫法二:使用Record
static TempStatusDto GetTemperatureStatsRecord(double[] temps)
{
    return new TempStatusDto(temps.Max(), temps.Min(), temps.Average());
}

static void TestRecordAggregation()
{
    double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2 };
    var stats = GetTemperatureStatsRecord(winterTemps);

    // Record 內建了漂亮的 ToString() 格式，非常適合直接輸出或轉 JSON！
    Console.WriteLine($"Record 結果 -> {stats}");
}

public record TempStatusDto(double MaxTemp, double MinTemp, double AverageTemp);