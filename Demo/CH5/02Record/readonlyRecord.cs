using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace readOnlyRecord;

public readonly record struct ReadonlyWithPropertySyntax()
{
    public double X { get; init; } = default;
    public double Y { get; init; } = default;
    public double Z { get; init; } = default;

    public ReadonlyWithPropertySyntax(double x, double y, double z) : this()
    {
        X = x;
        Y = y;
        Z = z;
    }
    public void Deconstruct(out double x, out double y, out double z)
    {
        x = X; y = Y; z = Z;
    }

}
