namespace InterfaceExtensions;

static class AnnoyingExtensions
{
    // 🌟 擴充介面：只要你實作了 IEnumerable (能跑 foreach)，你就能用！
    public static void PrintDataAndBeep(this System.Collections.IEnumerable iterator)
    {
        foreach (var item in iterator)
        {
            Console.WriteLine(item);
            Console.Beep(); // 發出系統逼逼聲
        }
    }
}