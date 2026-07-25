using System.Collections;

namespace ForEachWithExtensionMethods;

internal static class GarageExtensions
{
    public static IEnumerator GetEnumerator(this Garage garage)
        => garage.CarsInGarage.GetEnumerator();
}