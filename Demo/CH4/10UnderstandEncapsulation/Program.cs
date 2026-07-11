using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using staticModNS;

/*
#region Encapsulation
Motocycle moto1 = new Motocycle(20);
Motocycle moto2 = new Motocycle("jack");
Motocycle moto3 = new Motocycle();
Motocycle[] arr = new Motocycle[] { moto1, moto2, moto3 };

//print all motocycle
foreach (var moto in arr)
{
    moto.showMoto();
}
#endregion
*/

Console.WriteLine("** Fun with static **");
staticMod.PrintDate();
staticMod.PrintTime();
class Motocycle
{
    public int driverIntensity;
    public string driverName;

    //Constructor chaining
    public Motocycle() { }
    public Motocycle(int intensity) : this(intensity, "") => Console.WriteLine("in intensity");
    public Motocycle(string driverName) : this(0, driverName) => Console.WriteLine("in driverName");
    public Motocycle(int intensity = 0, string driverName = "")
    {
        Console.WriteLine("in intensity and driverName");
        this.driverIntensity = intensity > 10 ? 10 : intensity;
        this.driverName = driverName;
    }

    public void showMoto()
    {
        Console.WriteLine("Driver name:{0}\nDriver intensity:{1}", driverName, driverIntensity);
    }

}