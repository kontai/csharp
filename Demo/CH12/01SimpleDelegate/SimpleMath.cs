using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMath;

public class SimpleMath
{
    public static int Add(int a, int b) => a + b;

    public static int Sub(int a, int b) => a - b;
    public static int SquareNumber(int a) => a * a;
}

public delegate int BinaryOps(int i, int j);

