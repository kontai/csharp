using System;
using System.Text;

class String02
{

    static void Main4(string[] args)
    {
        string strText = "我正在學習";
        strText += ".NET平台";
        strText += "與C#開發語言";

        Console.WriteLine(strText);

        //StringBuilder
        StringBuilder sb=new StringBuilder("我正在學習");
        sb.Append(".NET平台");
        sb.Append("與C#開發語言");

        Console.WriteLine(sb);

    }


}
