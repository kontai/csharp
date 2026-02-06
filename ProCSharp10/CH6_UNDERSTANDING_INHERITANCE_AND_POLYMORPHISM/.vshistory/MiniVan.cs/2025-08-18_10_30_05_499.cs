namespace RecordInheritance;

// sealed record 不能再被繼承
public sealed record MiniVan : Car
{
    public int Seating { get; init; }

    public MiniVan(string make, string model, string color, int seating)
        : base(make, model, color)
    {
        Seating = seating;
    }
}
