using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panel_Script
{
    internal class HDI
    {
        //壓合順序
        private int stage;

        //壓合層數
        private string hdi_outer_uper;
        private string hdi_outer_lower;
        //壓內層合
        List<string> hdi_inner;
        //HDI孔
        private List<string> hdi_holes;

        //HDI PP數量
        private int hid_ppNUmber;

        public HDI(int stage, string hdi_outer_uper, string hdi_outer_lower, List<string> hdi_inner, List<string> hdi_holes, int hid_ppNUmber)
        {
            this.stage = stage;
            this.hdi_outer_uper = hdi_outer_uper;
            this.hdi_outer_lower = hdi_outer_lower;
            this.hdi_inner = hdi_inner;
            this.hdi_holes = hdi_holes;
            this.hid_ppNUmber = hid_ppNUmber;
        }

        public int Stage
        {
            get => stage;
            set => stage = value;
        }

        public string HdiOuterUper
        {
            get => hdi_outer_uper;
            set => hdi_outer_uper = value;
        }

        public string HdiOuterLower
        {
            get => hdi_outer_lower;
            set => hdi_outer_lower = value;
        }

        public List<string> HdiInner
        {
            get => hdi_inner;
            set => hdi_inner = value;
        }

        public List<string> HdiHoles
        {
            get => hdi_holes;
            set => hdi_holes = value;
        }

        public int HidPpNumber
        {
            get => hid_ppNUmber;
            set => hid_ppNUmber = value;
        }

    }
}