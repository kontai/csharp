using (MyResource ms = new MyResource())
{
    Console.WriteLine("*** fun with GC ***");
}

internal class MyResource : IDisposable
{
    private bool _isDisaposed = false;

    public void Dispose()
    {
        Console.WriteLine("Dispose() called");
        CleanUp(true);
        GC.SuppressFinalize(this);  // prevent finalizer from running
    }

    ~MyResource()
    {
        Console.WriteLine("Finalizer called");
        CleanUp(false);
    }

    private void CleanUp(bool disaposed)
    {
        if (!_isDisaposed)  // prevent double clean up
        {
            if (disaposed)
            {
                // clean managed resource
                Console.WriteLine("Clean up managed resource");
            }

            //clean unmanaged resource,example: IntPtr, FileStream, etc
            Console.WriteLine("Clean up unmanaged resource");
        }
        this._isDisaposed = true;
    }
}