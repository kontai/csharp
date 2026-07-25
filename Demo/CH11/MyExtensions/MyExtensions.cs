using System.Reflection;

namespace MyExtensionMethods;

internal static class MyExtensions
{
    // This method allows any object to display the assembly
    // it is defined in.
    public static void DisplayDefiningAssembly(this object obj)
    {
        Console.WriteLine("{0} lives here: => {1}\n",
          obj.GetType().Name,
          Assembly.GetAssembly(obj.GetType()).GetName().Name);
    }

    // This method allows any integer to reverse its digits.
    // For example, 56 would return 65.
    public static int ReverseDigits(this int i)
    {
        // Translate int into a string, and then
        // get all the characters.
        char[] digits = i.ToString().ToCharArray();
        // Now reverse items in the array.
        Array.Reverse(digits);
        // Put back into string.
        string newDigits = new string(digits);
        // Finally, return the modified string back as an int.
        return int.Parse(newDigits);
    }

    //Better revers digits! 👍🎉
    public static int MyReversDigits(this int i)
    {
        int sign = Math.Sign(i);  //store sign
        int tmp = Math.Abs(i);  //remove sign
        int res = 0;    //result
        while (tmp > 0)
        {
            res = res * 10 + tmp % 10;
            tmp /= 10;
        }
        return res * sign;

    }
}