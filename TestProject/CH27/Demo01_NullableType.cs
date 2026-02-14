namespace CH27
{
    internal class Demo01_NullableType
    {
        static void Main(string[] args)
        {
            int? myNInt = 39;   // Nullable type
            int myInt = (int)myNInt;    // Unbox
            var hasValue = myNInt.HasValue;
            if (hasValue)
            {
                Console.WriteLine($"Nullable type: {nameof(myNInt)} has a value: {hasValue}");
                Console.WriteLine($"Value: {myNInt.Value}");
            }

            int? myN = 20;
            Console.WriteLine("{0}", myN ?? myInt); //myN is null? return myInt else return myN

        }
    }
}