namespace CH18.variance.DelegateExample;
class Animal { public int NumberOfLegs = 4; }

class Dog : Animal { }

public class InvarianceExample
{
    delegate void Action<in T>(T a);

    static void ActionAnimal(Animal a)
    {
        Console.WriteLine($"Number of legs: {a.NumberOfLegs}");
    }
    static void Main(string[] args)
    {
        Action<Animal> act1 = ActionAnimal;
        Action<Dog> dog = act1;
        dog(new Dog());
    }
}