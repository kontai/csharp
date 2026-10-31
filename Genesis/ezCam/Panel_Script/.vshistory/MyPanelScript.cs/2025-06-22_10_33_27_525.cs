using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Windows.Navigation;
using GenesisLib;

namespace Panel_Script
{
    public static class MyPanelScript
    {
        private static string job;
        private static string step;
        private static double s_ix; // 用於存儲成型尺寸 X 坐標值
        private static double s_iy; // 用於存儲成型尺寸 Y 坐標值
        private static double w_ix; // 用於存儲下料尺寸 X 坐標值
        private static double w＿iy; // 用於存儲下料尺寸 Y 坐標值
        private static int xstep_num;
        private static int ystep_num;
        private static double xstep_spec;
        private static double ystep_spec;

        public static string Job
        {
            set => job = value;
            get => job;
        }

        /// <summary>
        /// Gets or sets the current step in the process.
        /// </summary>
        public static string Step=>Gen.STEP;

        //gererate all fields property
        public static double Six
        {
            set => s_ix = value;
            get => s_ix;
        }

        public static double Siy
        {
            set => s_iy = value;
            get => s_iy;
        }

        public static double Wix
        {
            set => w_ix = value;
            get => w_ix;
        }

        public static double Wiy
        {
            set => w＿iy = value;
            get => w＿iy;
        }

        public static int Xstep_num
        {
            set => xstep_num = value;
            get => xstep_num;
        }

        public static int Ystep_num
        {
            set => ystep_num = value;
            get => ystep_num;
        }

        public static double Xstep_spec
        {
            set => xstep_spec = value;
            get => xstep_spec;
        }

        public static double Ystep_spec
        {
            set => ystep_spec = value;
            get => ystep_spec;
        }

        public static void Initialize()
        {
            Six = 1;
            Siy = 1;
            Wix = 1;
            Wiy = 1;
            Xstep_num = 1;
            Ystep_num = 1;
            Xstep_spec = 2.0;
            Ystep_spec = 2.0;
        }

        public static void RunPanelScript()
        {

        }
    }
}