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

        public CCD_Fid_Pad(double frame_x, double frame_y)
        {
            const double min_x = 0.0;
            const double min_y = 0.0;

            x = new List<double>()
            {
                min_x + 1.7,
                frame_x - 1.7,
                min_x + 1.7,
                frame_x - 0.65,
                min_x - 0.2,
                frame_x + 0.2,
                frame_x + 0.2,
                min_x - 0.2,
            };
            y = new List<double>()
            {
                 min_y - 0.3,
                 min_y - 0.3,
                 frame_y + 0.3,
                 frame_y + 0.3,
                 min_y + 1.65,
                 min_y + 1.5,
                 frame_y - 1.6,
                 frame_y - 1.55,
            };
        }
    }