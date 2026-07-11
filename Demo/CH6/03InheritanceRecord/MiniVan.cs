using System;
using System.Collections.Generic;
using System.Text;

namespace RecordInheritance;

public sealed record MiniVan : Car
{
    public MiniVan(string make, string model, string color, int seating) : base(make, model, color)
    {
        Seating = seating;
    }

    public int Seating { get; set; }

}
