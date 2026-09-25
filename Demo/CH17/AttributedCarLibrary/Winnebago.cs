//Winnebago.cs
using System.Reflection;
using System.Reflection;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

//[assembly: ] 組件屬性,用來描述整個組件
[assembly: CLSCompliant(true)]

namespace AttributedCarLibrary;

[VehicleDescription("A very long, slow, but feature-rich auto")]
public class Winnebago
{
    public ulong notCompliant; //error: CLSCompliant attribute

    //[VehicleDescription("My Rock CD Player")] //error: Vehiclescription only used on classes,struct
    public void PlayMusic(bool On)
    {
        //....
    }
}
