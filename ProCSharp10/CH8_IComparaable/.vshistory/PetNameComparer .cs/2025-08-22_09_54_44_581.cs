namespace CH8_IComparaable;

public class PetNameComparer:IComparer<Car>
{
    public int Compare(Car? x, Car? y)
    {
        if (x == null || y == null)
            throw new ArgumentException("Both Argument moust Car object");

        return string.Compare(x.PetName, y.PetName,StringComparison.OrdinalIgnoreCase);
    }
}