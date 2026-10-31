using System;
using System.Collections.Generic;

namespace GenesisLib
{
    public class LayerCollection
    {
        public List<string> SignalTMP { get; } = new List<string>();
        public List<string> Outer { get; } = new List<string>();
        public List<string> SignalEmpty { get; } = new List<string>();
        public List<string> Inner { get; } = new List<string>();
        public List<string> SolderMask { get; } = new List<string>();
        public List<string> SilkScreen { get; } = new List<string>();
        public List<string> Drill { get; } = new List<string>();
        public List<string> BlindDrill { get; } = new List<string>();
    }
}