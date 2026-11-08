namespace AutoLot.Dal.Models;

public class Car
{
    public int Id { get; set; }
    public int MakeId { get; set; }
    public string Color { get; set; } = string.Empty;
    public string PetName { get; set; } = string.Empty;
    public byte[] TimeStamp { get; set; }
}
