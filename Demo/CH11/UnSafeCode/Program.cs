/*
unsafe
{
    int val = 20;
    int* p = &val;
    *p = 30;
    Console.WriteLine("*p: {0}", *p);
    Console.WriteLine("Address of p: {0:h}", (int)p);
}
*/

int va1 = 10, va2 = 20; 

// c/c++ unsafe code
//Console.WriteLine("****** Unsafe Swap ***");
//unsafe { unSafeSwap(&va1, &va2); }

//C#
SafeSwap(ref va1, ref va2);
Console.WriteLine("****** Safe Swap ***");

Console.WriteLine("va1: {0}, va2: {1}", va1, va2);

static unsafe void unSafeSwap(int* a,int* b)
{
    int tmp = *a;
    *a = *b;
    *b = tmp;
}

static void SafeSwap(ref int a, ref int b)
{
    int tmp = a;
    a = b;
    b = a;
}

internal unsafe struct Node
{
    public int data;
    public Node* next;
    public Node* prev;
};

internal struct Node2
{
    public int data;
    public unsafe Node* next;
    public unsafe Node* prev;
}