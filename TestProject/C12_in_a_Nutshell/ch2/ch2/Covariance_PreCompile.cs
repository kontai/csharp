using System.Reflection.Metadata.Ecma335;

namespace ch2;

public class Covariance_PreCompile
{
    static void Main(string[] args)
    {
    }
}

class MaxClass<T>
{
    public static T Max<T>(T a, T b) where T : IComparable<T>
        => a.CompareTo(b) > 0 ? a : b;
}