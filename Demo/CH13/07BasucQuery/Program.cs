using FunWithLinqExpressions;
using System.ComponentModel.DataAnnotations;

Console.WriteLine("***** 體驗查詢表達式的威力 *****\n");

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

//AllItems(itemsInStock);

//GetNames(itemsInStock);

//Paging(itemsInStock);
//RangeItem(itemsInStock);
//ChunkItem(itemsInStock);
ChunkDelayExec(itemsInStock);

static void AllItems(ProductInfo[] itemsInStock)
{
    //var allProducts = itemsInStock.Select(s => s);
    var allProducts = from s in itemsInStock select s;

    foreach (var item in allProducts)
    {
        Console.WriteLine(item);
    }
}

static void GetNames(ProductInfo[] itemsInStock)
{
    var allNames = itemsInStock.Select(s => s.Name);
    //var allNames= from s in itemsInStock select s.Name;

    foreach (var item in allNames)
    {
        Console.WriteLine(item);
    }
}

static void Paging(ProductInfo[] itemsInStock)
{
    var pag1 = (from s in itemsInStock select s).Take(2);
    foreach (var item in pag1)
    {
        Console.WriteLine(item);
    }

    var pag2 = (from s in itemsInStock select s).Skip(2);
}

static void RangeItem(ProductInfo[] itemsInStock)
{
    var result = (from s in itemsInStock select s).Take(..3);
    foreach (var item in result)
    {
        Console.WriteLine(item);
    }
}

static void ChunkItem(IEnumerable<ProductInfo> itemsInStock)
{
    var result = itemsInStock.Chunk(2);
    int count = 0;
    foreach (var item in result)
    {
        display($"Chunk #{++count} 第{count}包", item);
    }
}

static void display(string message, IEnumerable<ProductInfo> itemsInStock)
{
    Console.WriteLine(message);
    foreach (var item in itemsInStock)
    {
        Console.WriteLine(item.ToString());
    }
}

static void ChunkDelayExec(IEnumerable<ProductInfo> itemsInStock)
{
    var source = Enumerable.Range(1, 10)
        .Select(n =>
        {
            Console.WriteLine($"讀取來源元素: {n}");
            return n;
        });

    // 這一行不會輸出任何東西，因為 Chunk 是延遲執行
    var chunks = source.Chunk(3);

    Console.WriteLine("開始列舉...");

    foreach (var chunk in chunks)
    {
        Console.WriteLine($"取得 chunk: [{string.Join(", ", chunk)}]");
    }
}