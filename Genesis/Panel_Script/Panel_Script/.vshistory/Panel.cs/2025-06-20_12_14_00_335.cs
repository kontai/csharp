using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Windows.Navigation;
using GenesisInterfaces;

namespace Panel_Script
{
    public static class Panel
    {
        static string job;
        static string step;

        public static string Job
        {
            set => job = value;
            get => job;
        }

        public static string Step 
        {
            set => step = value;
            get => step;
        }
        public static void RunPanelScript(
                string six, siy, wix, wiy)
        {
            xstep_num.Text, ystep_num.Text, xstep_spec.Text, ystep_spec.Text,

            }

    }
}