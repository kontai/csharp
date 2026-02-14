namespace ch2;

public class Covariance_demo
{
    static void Main(string[] args)
    {
        Stack<Bear> bear = new Stack<Bear>();
        IPoppable<Animal> animal = bear; // 將 Stack<Bear> 轉換為 IPoppable<Animal>，這是合法的，因為 Bear 是 Animal 的子類型

        ZooCleaner.Wash(bear);
        //ZooCleaner.Wash(animal);    //無法通過編譯,因為 Stack<Animal> 不是 Stack<Bear> 的子類型

        //Array
        Bear[] bears = new Bear[3];
        Animal[] animals = bears;
        animals[0] = new Camel(); //這行會在運行時引發 InvalidCastException，因為 Camel 不是 Bear 的子類型
    }
}

public interface IPoppable<out T>
{
    T Pop();
}

public class Animal
{
}

class Bear : Animal
{
}

class Camel : Animal
{
}

public class Stack<T> : IPoppable<T>
{
    private int position;
    private T[] data = new T[100];
    public void Push(T obj) => data[position++] = obj;
    public T Pop() => data[--position];
}

public class ZooCleaner
{
    //public static void Wash<T>(Stack<T> animals) where T :Animal
    public static void Wash(IPoppable<Animal> animals)
    {
        while (animals.Pop() is Animal animal)
        {
            Console.WriteLine($"Washing {animal.GetType().Name}");
        }
    }
}