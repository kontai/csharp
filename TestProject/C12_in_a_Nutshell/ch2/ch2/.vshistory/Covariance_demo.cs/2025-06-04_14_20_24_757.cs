namespace ch2;

public class Covariance_demo
{
    static void Main(string[] args)
    {

        Stack<Bear> bear = new Stack<Bear>();
        Stack<Animal> animal = new Stack<Animal>();
        //Stack<Animal> animal = Bear;
        //bear.Push(new Camel());

        ZooCleaner.Wash(bear);
        //ZooCleaner.Wash(animal);    //無法通過編譯,因為 Stack<Animal> 不是 Stack<Bear> 的子類型
    }

}

class Animal{}

class Bear:Animal{}

class Camel:Animal{}

public class Stack<T>
{
    private int position;
    private T[] data = new T[100];
    public void Push(T obj) => data[position++] = obj;
    public T Pop() => data[--position];
}

class ZooCleaner
{
public static void Wash<T>(Stack<T> animals) where T :Bear
    {
        while (animals.Pop() is Animal animal)
        {
            Console.WriteLine($"Washing {animal.GetType().Name}");
        }
    }
}