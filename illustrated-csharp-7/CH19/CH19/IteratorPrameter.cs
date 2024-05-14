namespace CH19;

using System;
using System.Collections.Generic;

internal class Spectrum
{
    private bool _listFromUVtoIR;
    private string[] colors = { "violet", "blue", "cyan", "green", "yellow", "orange", "red" };

    public Spectrum(bool listFromUVtoIR)
    {
        _listFromUVtoIR = listFromUVtoIR;
    }

    public IEnumerator<string> GetEnumerator()
    {
        return _listFromUVtoIR
            ? UVtoIR
            : IRtoUV;
    }

    public IEnumerator<string> UVtoIR
    {
        get
        {
            for (int i = 0; i < colors.Length; i++)
                yield return colors[i];
        }
    }

    public IEnumerator<string> IRtoUV
    {
        get
        {
            for (int i = colors.Length - 1; i >= 0; i--)
                yield return colors[i];
        }
    }
}

public class IteratorPrameter
{
    private static void Main()
    {
        Spectrum startUV = new Spectrum(true);
        Spectrum startIR = new Spectrum(false);

        foreach (string color in startUV)
            Console.Write($"{color} ");
        Console.WriteLine();

        foreach (string color in startIR)
            Console.Write($"{color} ");
        Console.WriteLine();
    }
}