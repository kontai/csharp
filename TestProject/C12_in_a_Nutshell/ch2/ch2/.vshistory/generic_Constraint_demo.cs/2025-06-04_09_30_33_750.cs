namespace ch2;

public class generic_Constraint_demo
{
    static void Main(string[] args)
    {
        SomeClass s1 = new SomeClass();
        GenericClass<SomeClass,SomeClass> g1=new GenericClass<SomeClass, SomeClass>();
        g1.Foo(20); // This will work because SomeClass is a subclass of SomeClass and implements Interface1
    }
}

class SomeClass:Interface1
{
}

interface Interface1
{
}

/// <summary>
/// Represents a generic class with type constraints on its type parameters.Generic class with constraints
/// </summary>
/// <remarks>This class enforces specific constraints on its type parameters to ensure compatibility with certain
/// behaviors. Use this class when working with types that meet the specified constraints.</remarks>
/// <typeparam name="T">The type of the first generic parameter. Must be a subclass of <see cref="SomeClass"/> and implement <see
/// cref="Interface1"/>.</typeparam>
/// <typeparam name="U">The type of the second generic parameter. Must have a parameterless constructor.</typeparam>
class GenericClass<T, U> where T : SomeClass, Interface1
    where U : new()
{

  public  void Foo<T>(T a)where T:notnull{
        Console.WriteLine(a);
    }
}