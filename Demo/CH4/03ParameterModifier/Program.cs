// int j;
// ParameterModifier_out(out j);
/*
int k = 20;
ParameterModifier_out(out int j);   // 這樣可以省略predefined type,since c#7
ParameterModifier_in(in  k);   // in 參數只能讀取,不能修改

ParameterModifier_ref(ref k);   // ref 參數可以讀取,也可以修改
Console.WriteLine(k);

 ParameterModifier_params(1.2,2.3,3.4,4.5);
 ParameterModifier_params( new  double[]{1.2,2.3,3.4,4.5});
 ParameterModifier_params();
 */
namedParameterModifier(str1: "Hello", str2: "World", "c#");

void namedParameterModifier(string str1, string str2, string lang)
{
    Console.WriteLine($"{str1} {str2}");
}

void ParameterModifier_params(params double[] values)
{
    System.Console.WriteLine($"give {values.Length} values");
    double sum = 0;
    if (values.Length == 0)
    {
        Console.WriteLine("no values");
        return;
    }
    foreach (var i in values)
    {
        Console.WriteLine(i);
        sum += i;
    }
    Console.WriteLine($"sum: {sum}");
    Console.WriteLine($"average: {sum / values.Length}");
}


void ParameterModifier_ref(ref int k)
{
    k = 15;
}

void ParameterModifier_in(in int inValue)
{
    int i = inValue;   // 可以讀取,但不能修改
    // inValue = 200;   // error, in 參數不能修改
}


void ParameterModifier_out(out int outValue)
{
    outValue = 100;
}