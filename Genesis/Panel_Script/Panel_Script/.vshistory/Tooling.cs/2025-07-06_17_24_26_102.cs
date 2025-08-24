using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Documents;

namespace Panel_Script
{
    public class Tooling
    {
        private List<double> printPin_outer_x;
        private List<double> printPin_outer_y;

        private List<double> printPin_inner_x;
        private List<double> printPin_inner_y;

        private readonly List<int> ccd_pad_loc = new List<int>() { 2, 4, 5, 8 };

        public List<double> PrintPinOuterX => printPin_outer_x;
        public List<double> PrintPinOuterY => printPin_outer_y;

        public List<double> PrintPinInnerX => printPin_inner_x;

        public List<double> PrintPinInnerY => printPin_inner_y;

        public List<int> Ccd_Pad_Loc=> ccd_pad_loc;


        private double Mult_lyr;

        public Tooling(int layerCount, double min_x, double min_y, double max_x, double max_y, double offset_x, double offset_y)
        {
            Mult_lyr = layerCount > 2 ? 0.1 : 0;

            //intialize print points based on the frame size
            printPin_outer_x = new List<double>()
            {
                //順序：由左至右，由上至下
                //左下H
                min_x+0.25,min_x+ 0.45,min_x+ 0.65,
                //右下H
                max_x - 0.4, max_x - 0.2,
                // 左上H
                min_x+0.2, min_x+0.4,
                //右上H
                max_x - 0.4, max_x - 0.2,
                //左上V
                min_x-0.2,min_x -0.2,
                //右上V
                max_x + 0.2, max_x + 0.2,
                //左下V
                min_x - 0.2, min_x-0.2,min_x -0.2,
                //右下V
                max_x + 0.2, max_x + 0.2,
            };

            printPin_outer_y = new List<double>()
            {
                //順序：由左至右，由上至下
                //左下H
                min_y-0.2 - Mult_lyr,min_y -0.2 - Mult_lyr,min_y -0.2 - Mult_lyr,
                //右下H
                min_y-0.2 - Mult_lyr, min_y-0.2 - Mult_lyr,
                // 左上H
                max_y + 0.2 + Mult_lyr, max_y + 0.2 + Mult_lyr,
                //右上H
                max_y + 0.2 + Mult_lyr, max_y + 0.2 + Mult_lyr,
                //左上V
                max_y, max_y - 0.2,
                //右上V
                max_y, max_y - 0.2,
                //左下V
                min_y+0.45, min_y+0.25,min_y+ 0.05,
                //右下V
                min_y+0.2,min_y+ 0,
            };


            //inner print points
            printPin_inner_x = new List<double>()
            {
                //左下H
                printPin_outer_x[0] + offset_x,
                printPin_outer_x[1] + offset_x,
                printPin_outer_x[2] + offset_x,
                //r右下H
                printPin_outer_x[3] - offset_x,
                printPin_outer_x[4] - offset_x,
                // 左上H
                printPin_outer_x[5] + offset_x,
                printPin_outer_x[6] + offset_x,
                //右上H
                printPin_outer_x[7] - offset_x,
                printPin_outer_x[8] - offset_x,
            };
            printPin_inner_y = new List<double>()
            {
                //左下H
                printPin_outer_y[0] - offset_y,
                printPin_outer_y[1] - offset_y,
                printPin_outer_y[2] - offset_y,
                //右下H
                printPin_outer_y[3] - offset_y,
                printPin_outer_y[4] - offset_y,
                // 左上H
                printPin_outer_y[5] + offset_y,
                printPin_outer_y[6] + offset_y,
                //右上H
                printPin_outer_y[7] + offset_y,
                printPin_outer_y[8] + offset_y,
            };
        }

        //return the index of the ccd pad location,-1 if not found
        int ccd_pad(int index) => ccd_pad_loc.IndexOf(index);
    }
}