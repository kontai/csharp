namespace ForEachWithExtensionMethods;

class Garage
{
    // 車庫肚子裡有一個陣列
    public Car[] CarsInGarage { get; set; }

    public Garage()
    {
        CarsInGarage = new Car[4];
        CarsInGarage[0] = new Car("Rusty", 30);
        CarsInGarage[1] = new Car("Clunker", 55);
        CarsInGarage[2] = new Car("Zippy", 30);
        CarsInGarage[3] = new Car("Fred", 30);
    }
    // 🚨 注意：這裡完全沒有實作 IEnumerable，也沒有 GetEnumerator 方法！
}