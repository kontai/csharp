namespace CH12
{
    [Flags]
    internal enum CardDeckSettings : uint
    {
        SingleDeck = 0x01,           //位0
        LargePictures = 0x02,       //位1
        FancyNumbers = 0x04,    //位2
        Animation = 0x08             //位3
    }

    internal class MyClass
    {
        private bool UseSingleDeck = false,
             UseBigPics = false,
             UseFancyNumbers = false,
             UseAnimation = false,
             UseAnimationAndFancyNumbers = false;

        public void SetOptions(CardDeckSettings ops)
        {
            UseSingleDeck = ops.HasFlag(CardDeckSettings.SingleDeck);
            UseBigPics = ops.HasFlag(CardDeckSettings.LargePictures);
            UseFancyNumbers = ops.HasFlag(CardDeckSettings.FancyNumbers);
            UseAnimation = ops.HasFlag(CardDeckSettings.Animation);
            CardDeckSettings testFlags = CardDeckSettings.Animation | CardDeckSettings.FancyNumbers;
            UseAnimationAndFancyNumbers = ops.HasFlag(testFlags);
        }

        public void PrintOptions()
        {
            Console.WriteLine("Option settings:");
            Console.WriteLine("Use Single Deck                   - {0}", UseSingleDeck);
            Console.WriteLine("Use Large Pictures                - {0}", UseBigPics);
            Console.WriteLine("Use Fancy Numbers                 - {0}", UseFancyNumbers);
            Console.WriteLine("Show Animation                    - {0}", UseAnimation);
            Console.WriteLine("Show Animation And FancyNumbers   - {0}", UseAnimationAndFancyNumbers);
        }
    }

    internal class FlagExample
    {
        private static void Main()
        {
            var mc = new MyClass();
            CardDeckSettings ops = CardDeckSettings.SingleDeck
                                 | CardDeckSettings.FancyNumbers
                                 | CardDeckSettings.Animation;
            mc.SetOptions(ops);
            mc.PrintOptions();

            Console.WriteLine("//////////////////////////////");
            Console.WriteLine("second member of CardDeckSettings is {0}", Enum.GetName(typeof(CardDeckSettings), 2));
            foreach (var name in Enum.GetNames(typeof(CardDeckSettings)))
            {
                Console.WriteLine(name);
            }
        }
    }
}