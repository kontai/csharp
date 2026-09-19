//MiniVan.cs
namespace CarLibrary;

public class MiniVan : Car
{
    public MiniVan() { }

    public MiniVan(string name, int maxSpeed, int currentSpeed)
        : base(name, maxSpeed, currentSpeed) { }

    public override void TurboBoost()
    {
        // 廂型休旅車的渦輪性能很差！
        State = EngineStateEnum.EngineDead;
        Console.WriteLine("Eek! Your engine block exploded!");
    }
}
