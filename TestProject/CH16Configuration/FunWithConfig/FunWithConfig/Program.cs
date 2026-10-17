using System.Threading.Channels;
using Microsoft.Extensions.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        IConfiguration iconfig = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("MySetting.json")
            .Build();
        Console.WriteLine(iconfig["Carname"]);
    }
}
