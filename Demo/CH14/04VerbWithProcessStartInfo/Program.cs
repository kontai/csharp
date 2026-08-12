using System.Diagnostics;
using System.Runtime.InteropServices;

ProcessStartInfoVerb();
static void ProcessStartInfoVerb()
{
    ProcessStartInfo psi = null;

    try
    {

        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HelloWorld.docx");
        bool isFileExists = File.Exists(filePath);
        if (isFileExists)
        {
            psi = new ProcessStartInfo(filePath);
            Console.WriteLine("file path= {0}", filePath);
            int index = 0;
            foreach (var verb in psi.Verbs)
            {
                Console.WriteLine($"{index++}: {verb}");
            }
            psi.UseShellExecute = true;
            psi.WindowStyle = ProcessWindowStyle.Maximized;
            psi.Verb = "Edit";
            Process.Start(psi);
        }
        else
        {
            Console.WriteLine("File not found");
        }

    }
    catch (InvalidOperationException e)
    {
        Console.WriteLine(e.Message);
    }
}