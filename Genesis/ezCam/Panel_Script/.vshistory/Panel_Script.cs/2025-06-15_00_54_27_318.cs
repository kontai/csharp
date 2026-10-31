using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Windows.Navigation;
using GenesisInterfaces;

namespace Panel_Script
{
    public class PanelScript
    {
        private static string job;
        private static string step;

        public static string JOB
        {
            get
            {
                if (job == null)
                {
                    job = Gen.JOB;
                }

                return job;
            }
        }

        public static string STEP
        {
            get
            {
                if (step == null)
                {
                    step = Gen.STEP;
                }

                return step;
            }
        }


    }
}