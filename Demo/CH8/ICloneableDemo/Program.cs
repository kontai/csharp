Point p1 = new Point(20, 30, "Home");
Point p2 = (Point)p1.Clone();
p2.dc.PetName = "Work";
Console.WriteLine("P1: {0}", p1);
Console.WriteLine("P2: {0}", p2);

// 這是一個描述座標點資訊的「參考型別 (Reference Type)」類別
public class PointDescription
{
    public string PetName { get; set; }
    public Guid PointID { get; set; } // GUID 是一組保證全球唯一的隨機亂碼

    public PointDescription()
    {
        PetName = "No-name";
        // 每次 new 這個物件時，自動產生一組新的隨機亂碼
        PointID = Guid.NewGuid();
    }
}

internal class Point : ICloneable
{
    public int X { get; set; }
    public int Y { get; set; }
    public PointDescription dc = new PointDescription();

    public Point()
    {
    }

    private Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point(int x, int y, string petName)
    {
        X = x;
        Y = y;
        dc.PetName = petName;
        dc.PointID = Guid.NewGuid();
    }

    //shadow copy
    //public object Clone() => this.MemberwiseClone();

    //deep copy
    public object Clone()
    {
        //創建一個的Point instance
        Point newPoint = new Point();

        //創建一僤新的PointDescription 
        PointDescription newPtDesc = new PointDescription();

        //將目前的PointDescription的值複製到新的PointDescription
        newPtDesc.PetName = this.dc.PetName;

        //創建guid
        newPtDesc.PointID = Guid.NewGuid();

        //將新的PointDescription 設定給新的Point instance
        newPoint.dc = newPtDesc;

        //大功告成!返回newPoint
        return newPoint;
    }

    public override string ToString()
    {
        return $"X: {X}, Y: {Y}, PetName: {dc.PetName}, PointID: {dc.PointID}";
    }
}