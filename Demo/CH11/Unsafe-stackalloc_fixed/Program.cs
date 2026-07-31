//Sa();
//UnSafeAlloc();
sizofUnsafePoint();


static unsafe void UnSafeAlloc()
{

    PointRef prf = new PointRef() { x = 10, y = 20 };
    fixed (int* p = &prf.x)
    {
        *p = 2;
    }
    Console.WriteLine("Point is: {0}", prf);


}

static unsafe void sizofUnsafePoint()
{
    Console.WriteLine("Point的大小: {0}", sizeof(PointRef));
}

static unsafe void Sa()
{
    char* text = stackalloc char[27];
    for (int i = 0; i < 26; i++)
    {
        *(text + i) = (char)(i + 65);
    }
    *(text + 26) = '\0';
    Console.WriteLine(new string(text));
}

class PointRef
{
    public int x;
    public int y;
    public override string ToString() => $"({x}, {y})";
}


