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
        List<string> hdi_inner;
        private List<string> hdi_holes;
    }
}