namespace CH18.variance.DelegateExample;

internal class Animal
{ public int NumberOfLegs = 4; }

internal class Dog : Animal
{ }

/*
協變就是對具體成員的輸出參數進行一次類型轉換，且類型轉換的準則是 “里氏替換原則”
協變的闗鍵字是"out"

里式替換原則(LSP):
子型態必須遵從父型態的行為進行設計。如果一個子型態可以完全替代父型態，而不影響程式的功能，那麼它符合 LSP。
*/

internal delegate T Factory<out T>();    //out闗鍵字，讓dogMaker

public class ConvarianceExample
{
    private static Dog MakeDog()
    {
        return new Dog();
    }

    private static void Main(string[] args)
    {
        //Animal a1 = new Animal();
        //Animal a2 = new Dog();
        //Console.WriteLine($"Number of dog legs: {a2.NumberOfLegs}");
        Factory<Dog> dogMaker = MakeDog;
        Factory<Animal> animalMaker = dogMaker;
    }
}