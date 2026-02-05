namespace TestProject;

public class Demo_boxing_unboxing
{
    static void Main(string[] args)
    {
        object[] a1 = new string[3];
        //object[] a2 = new int[3];
        object o1 = 1; // Boxing
        Console.WriteLine($"o1.getType= {o1.GetType()}");
        MessageBox(IntPtr.Zero, "hello", "Extern Example", 0);

        int a = 2;
        object obj1 = a;

        string str = "Hello, World!";
        object obj2 = str; // Boxing of string
        obj2 = "Hello, Universe!"; // Unboxing of string (not really unboxing, just reassigning)
        Console.WriteLine($"str: {str}");
    }

    [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
    public static extern int MessageBox(IntPtr hWnd, string text, string caption, int options);
}