namespace CH9
{
    internal class LimitedInt
    {
        private const int MaxValue = 100;
        private const int MinValue = 0;

        public static implicit operator LimitedInt(int value)
        {
            LimitedInt li = new LimitedInt();
            li.TheValue = value;
            return li;
        }

        public static implicit operator int(LimitedInt li)
        {
            return li.TheValue;
        }


        private int theValue;

        public int TheValue
        {
            get { return theValue; }
            set
            {
                if (value < MinValue)
                {
                    theValue = 0;
                }
                else
                {
                    theValue = value > MaxValue ? MaxValue : value;
                }
            }
        }
    }

    internal class CustomerDefinedTransExample
    {
        public static void Main(string[] args)
        {
            LimitedInt l1 = 50;     //將50轉換為LimitedInt物件
            int val = l1;       //將LimitedInt物件轉換為int型態
            Console.WriteLine($"l1: {l1.TheValue},value: {val}");

            LimitedInt l2 = (LimitedInt)100;    //利用強制轉換，將int型態轉換為LimitedInt物件
            int val2 = (int)l2;
            Console.WriteLine($"l2: {l2.TheValue},value: {val2}");
        }
    }
}