class Base { }

//sealed 修饰符，表示类不能被继承,適合用於工具類
sealed class sealClass : Base { }

//class extendClass : sealClass { }   // error, cannot inherit from sealed class
//class extendString:String { }  // error, cannot inherit from sealed class
struct Point { }    //implicit sealed

//class extendPoint : Point { }  // error, cannot inherit from struct