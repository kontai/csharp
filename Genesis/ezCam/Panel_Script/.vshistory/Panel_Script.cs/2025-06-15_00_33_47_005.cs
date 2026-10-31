using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Windows.Navigation;
using GenesisInterfaces;

namespace Panel_Script
{
    public class Panel_Script
    {
        private static string job;
        private static string step;
        public static string JOB
        {
            private set
            {
                job = Gen.JOB;
                if (job == null)
                {
                    return;
                }
            }

            get
            {
                if (job == null)
                {
                    job = Gen.JOB;
                }
                return job;
            }
        }

        public static string STEP { get; } = Gen.STEP;


        public static void panel_script()
        {
            if (job == null || step == null)
            {
                Console.WriteLine("need open a job/step.");
                return;
            }
        }
    }
}