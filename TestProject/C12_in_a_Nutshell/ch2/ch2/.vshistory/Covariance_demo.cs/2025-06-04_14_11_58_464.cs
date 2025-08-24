namespace ch2;

public class Covariance_demo
{
    static void Main(string[] args)
    {

        Stack<Bear> bear = new Stack<Bear>();
        Stack<Animal> animal = Bear;
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