using System.ComponentModel;
using System.Diagnostics;


//StartApplication(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe");
ProcessStartInfoApplication("msedge");

static void StartApplication(string appPath)
{
    try
    {
        Process.Start(appPath, "https://tw.yahoo.com");
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    Console.ReadLine(); //press Enter to kill
    KillApplication("msEdge");
}

static void ProcessStartInfoApplication(string appPath)
{
    ProcessStartInfo browser = null;
    ProcessStartInfo helloWorldConsole = null;
    try
    {
        browser = new ProcessStartInfo(appPath);
        browser.UseShellExecute = true;
        browser.Arguments = "https://tw.yahoo.com";
        browser.CreateNoWindow = true;

        helloWorldConsole = new ProcessStartInfo(@"D:\workspace\csharp\Demo\CH14\x64\Debug\DemoCppProj.exe");
        helloWorldConsole.CreateNoWindow = false;
        Process.Start(browser);
        Process.Start(helloWorldConsole);
    }
    catch (Win32Exception e)
    {
        Console.WriteLine(e.Message);
    }
    catch (InvalidOperationException e)
    {
        Console.WriteLine(e.Message);
    }
    Console.WriteLine("Press Enter to Continue...");
    Console.ReadLine();
    KillApplication(appPath);
}

static void KillApplication(string appName)
{
    try
    {
        foreach (var proc in Process.GetProcessesByName(appName))
        {
            Console.WriteLine($"{proc.Id} {proc.ProcessName} ");
            //proc.Kill();
        }
    }
    catch (InvalidOperationException e)
    {
        Console.WriteLine(e.Message);
    }
}