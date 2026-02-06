namespace SimpleGC;

class MyResourceWrapper
{
    public MyResourceWrapper()
    {
        
    }
    // Clean up unmanaged resources here.
    // Beep when destroyed (testing purposes only!)
  ~MyResourceWrapper() => Console.Beep();
}