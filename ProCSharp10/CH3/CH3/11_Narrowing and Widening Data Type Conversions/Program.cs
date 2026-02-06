/*
 *
 * short si3 = si + si2;  // 編譯錯誤!
**錯誤原因:**

在 C# 中,當兩個 `short` 型別進行算術運算時,編譯器會自動將它們提升為 `int` 型別進行運算。因此 `si + si2` 的結果是 `int` 型別,不能直接賦值給 `short` 型別的變數。

**編譯錯誤訊息:**
```
Cannot implicitly convert type 'int' to 'short'. An explicit conversion exists (are you missing a cast?)
 */

using System;
using System.Runtime.CompilerServices;

func1();
func2();
void func1()
{
        short si=20;
        short si2=20;
        //short si3 = si + si2;
        short si3 = (short)(si + si2);
        int si4 = si + si2;
}

void func2()
{
    byte bval = 255;
    int ival = 0;
    //bval = ival;    //無法將類型'int'隱含轉換為'byte'
    ival = bval;
    Console.WriteLine(bval);
}
