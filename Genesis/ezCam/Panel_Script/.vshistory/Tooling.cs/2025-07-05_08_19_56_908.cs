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


        private double Mult_lyr;

        public Tooling(int layerCount, double frame_x, double frame_y, double offset_x, double offset_y)
        {
            Mult_lyr = layerCount > 2 ? 0.1 : 0;

            //intialize print points based on the frame size
            printPin_outer_x = new List<double>()
            {
                //順序：由左至右，由上至下
                //左下H
                0.25, 0.45, 0.65,
                //右下H
                frame_x - 0.4, frame_x - 0.2,
                // 左上H
                0.2, 0.4,
                //右上H
                frame_x - 0.4, frame_x - 0.2,
                //左上V
                -0.2, -0.2,
                //右上V
                frame_x + 0.2, frame_x + 0.2,
                //左下V
                -0.2, -0.2, -0.2,
                //右下V
                frame_x + 0.2, frame_x + 0.2,
            };

            printPin_outer_y = new List<double>()
            {
                //順序：由左至右，由上至下
                //左下H
                -0.2 - Mult_lyr, -0.2 - Mult_lyr, -0.2 - Mult_lyr,
                //右下H
                -0.2 - Mult_lyr, -0.2 - Mult_lyr,
                // 左上H
                frame_y + 0.2 + Mult_lyr, frame_y + 0.2 + Mult_lyr,
                //右上H
                frame_y + 0.2 + Mult_lyr, frame_y + 0.2 + Mult_lyr,
                //左上V
                frame_y, frame_y - 0.2,
                //右上V
                frame_y, frame_y - 0.2,
                //左下V
                0.45, 0.25, 0.05,
                //右下V
                0.2, 0,
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
        int ccd_pad(int index)
        {
            return ccd_pad_loc.IndexOf(index);
        }
    }
}