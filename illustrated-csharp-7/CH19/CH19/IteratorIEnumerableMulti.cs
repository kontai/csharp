﻿namespace CH19;

using System;
using System.Collections.Generic;

internal class Spectrum
{
    private string[] colors = { "violet", "blue", "cyan", "green", "yellow", "orange", "red" };

    public IEnumerable<string> UVtoIR()
    {
        for (int i = 0; i < colors.Length; i++)
            yield return colors[i];
    }

    public IEnumerable<string> IRtoUV()
    {
        for (int i = colors.Length - 1; i >= 0; i--)
            yield return colors[i];
    }
}

public class IteratorIEnumerableMulti
{
    private static void Main()
    {
        Spectrum spectrum = new Spectrum();

        foreach (string color in spectrum.UVtoIR())
            Console.Write($"{color} ");
        Console.WriteLine();

        foreach (string color in spectrum.IRtoUV())
            Console.Write($"{color} ");
        Console.WriteLine();
    }
}