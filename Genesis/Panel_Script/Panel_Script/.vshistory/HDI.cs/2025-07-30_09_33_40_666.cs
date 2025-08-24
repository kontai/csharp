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

        //裁板尺寸
        private int hdi_cutEdgeX;
        private int hdi_cutEdgeY;

        //HDI PP數量
        private int hid_ppNUmber;

        /// <summary>
        /// Initializes a new instance of the <see cref="HDI"/> class.
        /// </summary>
        /// <param name="stage">壓合順序.</param>
        /// <param name="hdi_outer_uper">HDI外層top</param>
        /// <param name="hdi_outer_lower">HDI外層bot</param>
        /// <param name="hdi_inner">內層</param>
        /// <param name="hdi_holes">HDI孔層</param>
        ///<param name="hdi_cutEdge">裁板尺寸</param>
        /// <param name="hid_ppNUmber">PP數量</param>



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

        public int HdiCutEdgeX
        {
            get => hdi_cutEdgeX;
            set => hdi_cutEdgeX = value;
        }

        public int HdiCutEdgeY
        {
            get => hdi_cutEdgeY;
            set => hdi_cutEdgeY = value;
        }

        public int HidPpNumber
        {
            get => hid_ppNUmber;
            set => hid_ppNUmber = value;
        }

        //TODO:
        //是否須增加鉚釘孔(pinxx-xx字樣)
        //是否須增加靶孔
        //是否須增加印刷PIN孔
        //增加廠料(正反面)
    }
}