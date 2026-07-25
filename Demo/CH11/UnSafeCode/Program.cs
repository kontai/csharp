using System.Runtime.InteropServices;

unsafe
{
    int val = 20;
    int* p = &val;
    *p = 30;
    Console.WriteLine("*p: {0}", *p);
    Console.WriteLine("Address of p: {0:h}", (int)p);

}