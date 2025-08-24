using System.Threading.Channels;

namespace SimpleGC;

class MyResourceWrapper : IDisposable
{
    private bool isDispose;

    public void Dispose()
    {
        CleanUp(true); // true 表示使用者呼叫
        GC.SuppressFinalize(this); // 避免被 Finalize 呼叫
    }

    void CleanUp(bool disposing)
    {
        if (!isDispose)
        {
            if (disposing)
            {
                // 清理管理型資源（例如其他 IDisposable 物件）
            }
            // 清理非管理型資源

            isDispose = true;
        }
    }

    // Clean up unmanaged resources here.
    // Beep when destroyed (testing purposes only!)
    ~MyResourceWrapper()
    {
                CleanUp(false); // false 表示由 GC 呼叫 Finalizer

        //Console.Write("clear...l");
    }
}