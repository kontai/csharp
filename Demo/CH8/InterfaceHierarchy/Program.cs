//instance of BitmapImage
BitmapImage bmp = new BitmapImage();
//Console.WriteLine("bmp.DrawTimes(): {0}", bmp.DrawTimes());
Console.WriteLine("IAdvanceDraw.DrawTimes(): {0}", ((IAdvanceDraw)bmp).DrawTimes());
Console.WriteLine("IDraw.DrawTimes(): {0}", ((IDraw)bmp).DrawTimes());
class BitmapImage : IAdvanceDraw
{
    void IDraw.draw()
    {
        Console.WriteLine("Drawing....");
    }

    void IAdvanceDraw.DrawInBoundingBox(int top, int left, int bottom, int right)
    {
        Console.WriteLine("Drawing in a box...");
    }

    void IAdvanceDraw.DrawUpsideDown()
    {
        Console.WriteLine("Drawing upside down...");
    }

    //若想讓 IDraw 和 IAdvanceDraw 真的回傳不同的值,必須改用顯式接口實作
    //但這裡的值，與實際interface裡的定義的值不同，只是恰巧一樣
    //int IDraw.DrawTimes()=>5 ;
    //int IAdvanceDraw.DrawTimes() => 10;
    //public int DrawTimes() => 15;
}
internal interface IAdvanceDraw : IDraw
{
    void DrawInBoundingBox(int top, int left, int bottom, int right);

    void DrawUpsideDown();

    new int DrawTimes() => 10;
}

internal interface IDraw
{
    void draw();

    int DrawTimes() => 5;
}