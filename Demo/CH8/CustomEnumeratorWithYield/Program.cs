using CustomEnumeratorWithYield;
using System.Collections;
using System.Runtime.CompilerServices;
MyCar mycar = new MyCar();
foreach (MyCar car in mycar)
{
    Console.WriteLine("{0} can go {1} mph", car.PetName, car.MaxSpeed);
}

internal class MyCar
{
    public string PetName { get; set; }
    public int MaxSpeed { get; set; }

    private MyCar[] myCars = new MyCar[4];

    public MyCar()
    {
        myCars[0] = new MyCar("Rusty", 90);
        myCars[1] = new MyCar("Clunker", 50);
        myCars[2] = new MyCar("Zippy", 30);
        myCars[3] = new MyCar("Fred", 40);

    }
    public MyCar(string petName, int maxSpeed)
    {
        PetName = petName;
        MaxSpeed = maxSpeed;
    }

    public IEnumerator GetEnumerator()
    {
        return interYieldReturn();

        IEnumerator interYieldReturn()
        {
            foreach (MyCar mycar in myCars)
            {
                yield return mycar;
            }
        }
    }
}