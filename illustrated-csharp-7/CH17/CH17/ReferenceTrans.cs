namespace CH17;

internal class A
{ public int Field1; }

internal class B : A
{ public int Field2; }

public class ReferenceTrans
{
    private static void Main(string[] args)
    {
        B myVal1 = new B();
        A myVal2 = (A)myVal1;   //顯式類型轉換
        //A myVAl3 = myVal1;  //子類轉父類，可以不用顯式轉換
        Console.WriteLine(myVal1.Field1);
        Console.WriteLine(myVal2.Field2);   //即使實際指向B類型的對象，它也看不到B擴展A的部分

        //A myVal4 = new A();
        //B myVal5 = (B)myVal4;   //父類轉子類，需要顯式轉換;但是會報錯，因為A沒有Field2
        //Console.WriteLine(myVal5.Field1);

    }
}