using LinqOverCollections;

GetFastCars();
static void GetFastCars()
{
    List<Car> myCars = new List<Car>() 
    {
        new Car { PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW" },
        new Car { PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW" },
        new Car { PetName = "Mary", Color = "Black", Speed = 55, Make = "VW" },
        new Car { PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo" },
        new Car { PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford" }
    };

    // 🌟 在 LINQ 中建立複合條件 (&&)
    // 找出：速度 > 90 且 廠牌是 BMW 的車
    var fastCars = from c in myCars 
                   where c.Speed > 90 && c.Make == "BMW" 
                   select c;

    foreach (var car in fastCars)
    {
        Console.WriteLine("{0} 開太快啦！", car.PetName); // 只會印出 Henry
    }
}