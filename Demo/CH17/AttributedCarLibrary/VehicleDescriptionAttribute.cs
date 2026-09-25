namespace AttributedCarLibrary;

//規定 [VehicleDescription] 屬性只能在類別或結構上被套用一次
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
public sealed class VehicleDescriptionAttribute : Attribute
{
    public string Description { get; set; }

    public VehicleDescriptionAttribute(string description) => Description = description;

    public VehicleDescriptionAttribute() { }
}
