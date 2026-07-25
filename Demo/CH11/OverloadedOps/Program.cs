using OverloadedOps;
using System.Security.Cryptography.X509Certificates;

// Adding and subtracting two points?
//BinaryOperatorsFun();
//UnaryOperatorFun();
//EqualityOperatorFun();
ComparisonOperatorFun();

static void BinaryOperatorsFun()
{
    Console.WriteLine("***** Fun with Overloaded Operators *****\n");
    // Make two points.
    Point ptOne = new Point(100, 100);
    Point ptTwo = new Point(40, 40);
    Console.WriteLine("ptOne = {0}", ptOne);
    Console.WriteLine("ptTwo = {0}", ptTwo);

    //pseudo-code:Point p3 = Point.operator +(ptOne, ptTwo);
    Point p3 = ptOne + ptTwo;
    Point p4 = ptOne - ptTwo;
    Console.WriteLine("p3 = {0}", p3);
    Console.WriteLine("p4 = {0}", p4);
    Console.WriteLine();

    // Prints [110, 110].
    Point biggerPoint = ptOne + 10;
    Console.WriteLine("ptOne + 10 = {0}", biggerPoint);
    // Prints [120, 120].
    Console.WriteLine("10 + biggerPoint = {0}", 10 + biggerPoint);
    Console.WriteLine();

    //如果重载了+-的二元運算符，那么C#编译器会自动生成对应的+=和-=运算符。
    p3 += ptTwo;
    Console.WriteLine("p3 += ptTwo = {0}", p3);

    biggerPoint += 20;
    Console.WriteLine("biggerPoint += 20 = {0}", biggerPoint);
}

static void UnaryOperatorFun()
{
    // Applying the ++ and -- unary operators to a Point.
    Point ptFive = new Point(1, 1);
    Console.WriteLine("++ptFive = {0}", ++ptFive);  // [2, 2]
    Console.WriteLine("--ptFive = {0}", --ptFive);  // [1, 1]
                                                    // Apply same operators as postincrement/decrement.
    Point ptSix = new Point(20, 20);
    Console.WriteLine("ptSix++ = {0}", ptSix++);    // [20, 20]
    Console.WriteLine("ptSix-- = {0}", ptSix--);    // [21, 21]
}

static void EqualityOperatorFun()
{
    Point ptOne = new Point(100, 100);
    Point ptTwo = new Point(40, 40);
    Console.WriteLine("ptOne == ptTwo : {0}", ptOne == ptTwo);
    Console.WriteLine("ptOne != ptTwo : {0}", ptOne != ptTwo);
}

static void ComparisonOperatorFun()
{
    Point ptOne = new Point(100, 100);
    Point ptTwo = new Point(40, 40);
    Console.WriteLine("ptOne: {0},ptTwo: {1}", ptOne, ptTwo);
    Console.WriteLine("ptOne > ptTwo : {0}", ptOne > ptTwo);
    Console.WriteLine("ptOne < ptTwo : {0}", ptOne < ptTwo);
    Console.WriteLine("ptOne >= ptTwo : {0}", ptOne >= ptTwo);
    Console.WriteLine("ptOne <= ptTwo : {0}", ptOne <= ptTwo);

}