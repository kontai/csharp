using System.Text.Json.Serialization;
using System.Xml.Serialization;
using ApplyingAttributes;

HorseAndBuggy horseAndBuggy = new HorseAndBuggy();
Console.WriteLine("Hello World!");

namespace ApplyingAttributes
{
    public class Motocycle
    {
        [JsonIgnore]
        public flaot weigtOfCurrentPassengers;

        public bool hasRadioSystem;
        public bool hasHeadSet;
        public bool hasSissyBar;
    }

    public class flaot { }

    //method I
    // [XmlRoot(Namespace = "http://www.example.com"),Obsolete("Use another Vehicle !")]

    //method II
    [XmlRoot(Namespace = "http://www.example.com")]
    [Obsolete("Use another Vehicle !")]
    public class HorseAndBuggy
    {
        //.......
    }
}
