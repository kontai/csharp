namespace CH8_IComparaable;
public class Car : IComparable<Car>
{
    public int CarID { get; set; }
    public string PetName { get; set; }
    public int CurrentSpeed { get; set; }

    public Car(string name, int speed, int id)
    {
        PetName = name;
        CurrentSpeed = speed;
        CarID = id;
    }

    // 預設排序：用 CarID
    public int CompareTo(Car? other)
    {
        if (other == null) return 1;
        return this.CarID.CompareTo(other.CarID);
    }

    // 靜態屬性回傳對應的 PetNameComparer
    public static IComparer<Car> SortByPetName => new PetNameComparer();
}

