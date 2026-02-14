using System.Collections.Generic;
using System.Windows.Documents;

namespace Panel_Script
{
    public struct CCD_Fid_Pad
    {
        private List<double> x;
        private List<double> y;

        public List<double> X => x;
        public List<double> Y => y;

        public CCD_Fid_Pad( double min_x,double min_y,double max_x,double max_y)
        {

            x = new List<double>()
            {
                // 左下H
                min_x + 1.7,
                // 右下H
                max_x - 1.7,
                // 左上H
                min_x + 1.7,
                // 右上H
                max_x - 0.65,
                // 左下V
                min_x - 0.2,
                // 右下V
                max_x + 0.2,
                // 右上V
                max_x + 0.2,
                //左上V
                min_x - 0.2,
            };
            y = new List<double>()
            {
                // 左下H
                min_y - 0.3,
                // 右下H
                min_y - 0.3,
                // 左上H
                max_y + 0.3,
                // 右上H
                max_y + 0.3,
                // 左下V
                min_y + 1.65,
                // 右下V
                min_y + 1.5,
                // 右上V
                max_y - 1.6,
                // 左上V
                max_y - 1.55,
            };
        }
    }
}