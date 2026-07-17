using System.Collections; // 引入System.Collections命名空间，提供集合相关的类和接口

// 创建MyCar类的实例
MyCar mc = new MyCar();
// 遍历ReversePrint方法返回的可枚举集合，isReverse参数为true
foreach (MyCar car in mc.ReversePrint(true))
{
    Console.WriteLine(car); // 输出每个MyCar对象的字符串表示
}

/// <summary>
/// MyCar类，表示汽车对象，包含汽车名称和最大速度属性
/// </summary>
internal class MyCar
{
    /// <summary>
    /// 汽车名称属性
    /// </summary>
    public string PetName { get; set; }

    /// <summary>
    /// 最大速度属性，单位为mph
    /// </summary>
    public int MaxSpeed { get; set; }

    // 私有字段，存储MyCar对象的数组
    private MyCar[] myCars = new MyCar[4];

    /// <summary>
    /// 无参构造函数，初始化myCars数组并创建4个MyCar实例
    /// </summary>
    public MyCar()
    {
        myCars[0] = new MyCar("Rusty", 90);
        myCars[1] = new MyCar("Clunker", 50);
        myCars[2] = new MyCar("Zippy", 30);
        myCars[3] = new MyCar("Fred", 40);
    }

    /// <summary>
    /// 带参构造函数，初始化汽车名称和最大速度
    /// </summary>
    /// <param name="petName">汽车名称</param>
    /// <param name="maxSpeed">最大速度</param>
    public MyCar(string petName, int maxSpeed)
    {
        PetName = petName;
        MaxSpeed = maxSpeed;
    }

    /// <summary>
    /// 反向遍历myCars数组的方法
    /// </summary>
    /// <param name="isReverse">是否反向遍历的标志</param>
    /// <returns>返回可枚举的MyCar集合</returns>
    public IEnumerable ReversePrint(bool isReverse)
    {
        if (isReverse == true) // 如果isReverse为true，则反向遍历数组
        {
            for (int i = myCars.Length - 1; i >= 0; i--)
            {
                yield return myCars[i]; // 使用yield返回数组中的每个元素
            }
        }
    }

    /// <summary>
    /// 重写ToString方法，返回汽车的字符串表示
    /// </summary>
    /// <returns>包含汽车名称和最大速度的字符串</returns>
    override public string ToString()
    {
        return $"{PetName} can go {MaxSpeed} mph";
    }
}
