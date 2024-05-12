using System.Collections;
using System.Drawing;

namespace CH19;

internal class ColorEnumerator : IEnumerator
{
    private string[] colors;
    private int position = -1;  //當前位置

    public ColorEnumerator(string[] _colors)
    {
        colors = new string[_colors.Length];
        for (int i = 0; i < _colors.Length; i++)
        {
            colors[i] = _colors[i];
        }
    }
    public bool MoveNext()
    {
        if (position < colors.Length - 1)
        {
            position++;
            return true;
        }
        return false;
    }

    public void Reset()
    {
        position = -1;
    }

    public object Current
    {
        get
        {
            if (position < -1)
            {
                throw new InvalidOperationException();
            }
            if (position >= colors.Length)
            {
                throw new InvalidOperationException();
            }
            return colors[position];
        }
    }
}

class Spectrum : IEnumerable
{
    string[] colors = { "violet", "blue", "green", "yellow", "orange", "red" };
    public IEnumerator GetEnumerator()
    {
        return new ColorEnumerator(colors);
    }
}

public class IEnumExample
{
    static void Main(string[] args)
    {
        Spectrum spectrum = new Spectrum();
        foreach (var color in spectrum)
        {
            Console.WriteLine(color);
        }
    }
}