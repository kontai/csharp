using System.Collections;
using SimpleInterfaces;

public class Garage : IEnumerable
{
    private Car[] carArray = new Car[4];

    public Garage()
    {
        carArray[0] = new Car("FeeFee", 200);
        carArray[1] = new Car("Clunker", 90);
        carArray[2] = new Car("Zippy", 30);
        carArray[3] = new Car("Fred", 30);
    }

    // 直接用陣列的 GetEnumerator()
    //public IEnumerator GetEnumerator()
    //  => carArray.GetEnumerator();

    //IEnumerator IEnumerable.GetEnumerator()
    //    => carArray.GetEnumerator();

    public IEnumerable GetTheCars(bool returnReversed)
    {
        //throw new Exception("This will get called.");
        return ActualImplementation();

        IEnumerable ActualImplementation(){
            if(!returnReversed)
            {

            foreach (var car in carArray)
            {
                yield return car;
            }
            }
            else
            {
                for (var i = carArray.Length; i > 0; i--)
                {
                    yield return carArray[i-1];
                }
            }
        }
    }
}