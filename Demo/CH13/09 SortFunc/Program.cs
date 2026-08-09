using FunWithLinqExpressions;
using System.Security.Cryptography;

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

//ReverseProduct(itemsInStock);
OrderByProduct(itemsInStock);

static void ReverseProduct(ProductInfo[] productInfos)
{
    var res = (from s in productInfos select s).Reverse();
    foreach (var item in res)
    {
        Console.WriteLine(item);
    }
}

static void OrderByProduct(ProductInfo[] productInfos)
{
    //升序
    var res = from s in productInfos orderby s.Name ascending select s;

    //逆序
    var resDesc = from s in productInfos orderby s.Name descending select s;

    foreach (var item in resDesc)
    {
        Console.WriteLine(item);
    }
}