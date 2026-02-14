using System.Collections.Generic;
using System.Windows.Documents;

namespace Panel_Script
{
    public class Tooling
    {
        static List<double> printPin_two_x;
        static List<double> printPin_two_y;
        private List<double> printPin_Three＿ｘ;
        private List<double> printPin_Three＿y;
        private double Mult_lyr;

        public Tooling(int layerCount, double frame_x, double frame_y)
        {
            Mult_lyr = layerCount > 2 ? 0.1 : 0;

            //intialize print points based on the frame size
            printPin_two_x = new List<double>()
            {
                //順序：由左至右，由上至下
                //左下H
                0.25,0.45,
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
                -0.2, -0.2,
                //右下V
                frame_x + 0.2, frame_x + 0.2,
            };

            printPin_two_y = new List<double>()
            {
                //順序：由左至右，由上至下
                //左下H
                -0.2 - Mult_lyr, -0.2 - Mult_lyr,
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
                0.25,0.05,
                //右下V
                0.2, 0,
            };
            printPin_Three＿ｘ=new List<double>()
            {
                //順序：由左至右，由上至下
                //左下H
                0.65,
                //左下V
                -0.2,
            };
            printPin_Three＿y=new List<double>()
            {
                //順序：由左至右，由上至下
                //左下H
                -0.2 - Mult_lyr,
                //左下V
                0.45,
            };
        }
    }
}