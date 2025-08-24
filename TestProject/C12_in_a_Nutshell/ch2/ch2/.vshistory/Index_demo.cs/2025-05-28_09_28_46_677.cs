using Microsoft.Win32.SafeHandles;

namespace ch2;

public class Index_demo
{
    static void Main(string[] args)
    {
        Sentence s01 = new Sentence();
        /*        Console.WriteLine(s01[3]);
                s01[3] = "lazy"; // change the word at index 3
        */
        Console.WriteLine(s01[^1]);
        Console.WriteLine(s01[..2]);
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

    // Indexer using Index and Range types
    public string this[Index index] => words[index];
    public string[] this[Range rangs] => words[rangs];
}