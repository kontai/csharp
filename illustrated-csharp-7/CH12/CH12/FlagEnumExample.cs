namespace CH12
{

    [Flags]         //持牲，使用中括號括起來
    internal enum CardDeckSettings : uint
    {
        SingleDeck = 0x01,          //使用16進制設定位
        LargePictures = 0x02,
        FancyNumber = 0x04,
        Animation = 0x08
    }

    internal class FlagEnumExample
    {
        public static void Main(string[] args)
        {
            CardDeckSettings ops = CardDeckSettings.SingleDeck | CardDeckSettings.LargePictures | CardDeckSettings.FancyNumber;     //設置了三個flag
            Console.WriteLine($"flag Animation is set:\t {ops.HasFlag(CardDeckSettings.Animation)}");
            Console.WriteLine($"flag SingleDeck is set:\t {ops.HasFlag(CardDeckSettings.SingleDeck)}");

            //測試testFlags所有標志都是包含在ops中
            CardDeckSettings testFlags = CardDeckSettings.Animation | CardDeckSettings.FancyNumber;
            CardDeckSettings testFlags2 = CardDeckSettings.SingleDeck | CardDeckSettings.FancyNumber | CardDeckSettings.LargePictures;
            bool useFlagWithinCardecksettins = ops.HasFlag(testFlags);
            Console.WriteLine(useFlagWithinCardecksettins);
            useFlagWithinCardecksettins = ops.HasFlag(testFlags2);
            Console.WriteLine(useFlagWithinCardecksettins);

            // 利用泣運算子'&'測試是否有設定FancyNumber
            bool useFanncyNumbers = (ops & CardDeckSettings.FancyNumber) == CardDeckSettings.FancyNumber;
            Console.WriteLine(useFanncyNumbers);
        }
    }
}