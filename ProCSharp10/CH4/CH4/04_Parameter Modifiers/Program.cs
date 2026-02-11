// 範例：同時取得加法與乘法結果

using System;
using System.IO;
using System.Linq;

static void AddAndMultiply(int a, int b, out int added, out int mult)
{
    added = a + b; // 必須賦值！
    mult = a * b;  // 必須賦值！
}

// 呼叫端
int ans1, ans2; // 不需要初始化
AddAndMultiply(10, 20, out ans1, out ans2);
Console.WriteLine($"Add: {ans1}, Mult: {ans2}");
AddAndMultiply(99,100,out ans1,out _);  //discarding out parameter '_'

// 範例：交換字串 (Swap)
static void SwapStrings(ref string s1, ref string s2)
{
    string tempStr = s1;
    s1 = s2;
    s2 = tempStr;
}

// 呼叫端
string str1 = "Hello";
string str2 = "World";
// 呼叫時也必須加上 ref
SwapStrings(ref str1, ref str2);
Console.WriteLine($"{str1} {str2}"); // 輸出 "World Hello"
    
// 範例：計算任意數量的平均值
static double CalculateAverage(params double[] values)
{
    double sum = 0;
    if (values.Length == 0) return sum;

    for (int i = 0; i < values.Length; i++)
        sum += values[i];

    return (sum / values.Length);
}

// 呼叫端
// 你可以傳一個陣列，也可以直接傳一堆數字
double avg = CalculateAverage(4.0, 3.2, 5.7, 64.22, 87.2);
Console.WriteLine($"Average: {avg}");

