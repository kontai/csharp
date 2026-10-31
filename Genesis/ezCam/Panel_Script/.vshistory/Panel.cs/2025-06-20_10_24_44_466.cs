using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Windows.Navigation;
using GenesisInterfaces;

namespace Panel_Script
{
    public static class Panel
    {
        private static readonly string job;
        private static readonly string step;

        public static string JOB
        {
            set => job = value;
            get => job;
        }

        public static   string STEP
        {
            set => step = value;
            get => step;
        }
        public static void RunPanelScript(
                string JOB, string STEP,string six, siy, wix, wiy){

            }

    }
}