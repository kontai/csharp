using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using GenesisLib;

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

        //HDI外層號碼
        private int out_upperNum;
        private int out_lowerNum;

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
        public HDI(int stage, string hdi_outer_uper, string hdi_outer_lower,
            List<string> hdi_holes, int hdi_cutEdgeX, int hdi_cutEdgeY, int hid_ppNUmber)
        {
            this.stage = stage;
            this.hdi_outer_uper = hdi_outer_uper;
            this.hdi_outer_lower = hdi_outer_lower;
            this.hdi_holes = hdi_holes;
            this.hdi_cutEdgeX = hdi_cutEdgeX;
            this.hdi_cutEdgeY = hdi_cutEdgeY;
            this.hid_ppNUmber = hid_ppNUmber;

            // 解析外層號碼
            Match matchsUp = Regex.Match(hdi_outer_uper, @"\w+(\d+)");
            if (matchsUp.Success)
                out_upperNum = int.Parse(matchsUp.Groups[1].Value);

            Match matchsLow = Regex.Match(hdi_outer_lower, @"\w+(\d+)");
            if (matchsLow.Success)
                out_lowerNum = int.Parse(matchsLow.Groups[1].Value);


            // 確認是否有內層
            if (out_lowerNum - out_upperNum + 1 > 2)
            {
                this.hdi_inner = new List<string>();
                this.hdi_inner=MainWindow.layers.InnerList.GetRange(out_upperNum,out_lowerNum-1);
            }
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
        //是否須增加鉚釘孔 Add_Hdi_mounting_holes()
        //是否須增加靶孔
        //是否須增加印刷PIN孔
        //增加廠料(正反面)

        public void AddHdiMountingHoles( int wix, int wiy,int mount_cnt,double offset)
        {
            if (out_lowerNum - out_lowerNum + 1 > 4 && HidPpNumber > 1)
            {
                foreach (var inn_lyr in HdiInner)
                {
                Gen.COM($"affected_layer,name={inn_lyr},mode=single,affected=yes");
                }

                //增加鉚釘孔PAD






                Gen.COM($"affected_layer,mode=all,affected=no");
            }
        }
    }