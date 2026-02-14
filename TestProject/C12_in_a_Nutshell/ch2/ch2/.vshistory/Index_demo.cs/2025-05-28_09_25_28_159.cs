using Microsoft.Win32.SafeHandles;

namespace ch2;

public class Index_demo
{
    static void Main(string[] args)
    {
        Sentence s01 = new Sentence();
        Console.WriteLine(s01[3]);
    }
}

class Sentence
{
    string[] words = "The quick brown fox".Split();

    public string this[int wordNum] // indexer
    {
        get { return words[wordNum]; }
        set { words[wordNum] = value; }
    }
}