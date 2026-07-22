int a = 123;
long b = a; //implicit conversion
int c = (int)b; //explicit conversion

//Implicit cast between derived to base.
Base myBaseType;
myBaseType = new Derived();
//Must eplicitly cast to store base reference
//in derived type.
Derived myDerivedType = (Derived)myBaseType;

Base myBaseType2 = new();
//Error: System.InvalidCastException: Unable to cast object of type 'Base' to type 'Derived'
//Derived myDerivedType2 = (Derived)myBaseType2;  

//safely cast using 'as' keyword, which returns null if cast fails
Derived myDerivedType2 = myBaseType2 as Derived;
internal class Base
{ }

internal class Derived : Base
{ }