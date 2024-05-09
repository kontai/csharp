namespace CH18;

internal class MyStack<T>
{
    private T[] StackArray;
    private int StackPointer = 0;

    public void Push(T x)
    {
        if (!IsStackFull)
            StackArray[StackPointer++] = x;
    }

    public T Pop()
    {
        return (!IsStackEmpty) ? StackArray[--StackPointer] : StackArray[0];
    }

    private const int MaxStack = 10;
    private bool IsStackFull => StackPointer >= MaxStack;
    private bool IsStackEmpty => StackPointer <= 0;

    public MyStack()    //構造函數
    {
        StackArray = new T[MaxStack];
    }

    public void Print()
    {
        for (int i = StackPointer - 1; i >= 0; i--)
        {
            Console.WriteLine($"  Value: {StackArray[i]}");
        }
    }
}

public class StackGenericExample
{
    private static void Main(string[] args)
    {
        MyStack<int> StackInt = new MyStack<int>();
        MyStack<string> StackString = new MyStack<string>();

        StackInt.Push(3);
        StackInt.Push(5);
        StackInt.Push(7);
        StackInt.Push(0);
        StackInt.Print();

        StackString.Push("This is fun");
        StackString.Push("Hi There!  ");
        StackString.Print();
    }
}