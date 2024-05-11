namespace CH18.variance.InterfaceExampl;

internal class Animal
{ public string Name; }

internal class Dog : Animal;

internal interface IMyIfc<out T>
{
    T GetFirst();
}

internal class SimpleReturn<T> : IMyIfc<T>
{
    public T[] items = new T[2];
    public T GetFirst() => items[0];
}

public class Program
{
    static void DoSomething(IMyIfc<Animal> returner)
    {
        Console.WriteLine(returner.GetFirst().Name);
    }
    private static void Main(string[] args)
    {
        SimpleReturn<Dog> dogReturner = new SimpleReturn<Dog>();    //實例化泛型類
        dogReturner.items[0] = new Dog() { Name = "Avonlea" };

        IMyIfc<Animal> animalReturner = dogReturner;
        DoSomething(dogReturner);

    }
}