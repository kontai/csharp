using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using GenesisLib;

namespace Panel_Script
{
    public static class MyPanelScript
    {
        static MainWindow mainWindow;
        private static readonly LayerCollection layers = MainWindow.layers;
        static readonly string workName = "work";
        private readonly static string job = Gen.JOB;
        private static readonly double s_ix; // 用於存儲成型尺寸 X 坐標值
        private static double s_iy; // 用於存儲成型尺寸 Y 坐標值
        private static double w_ix; // 用於存儲下料尺寸 X 坐標值
        private static double w_iy; // 用於存儲下料尺寸 Y 坐標值
        private static int xstep_num;
        private static int ystep_num;
        private static double xstep_spec;
        private static double ystep_spec;
        private static double frame_x; //排板尺寸X
        private static double frame_y; //排板尺寸Y
        private static double frame_dist_x; //下料邊X
        private static double frame_dist_y; //下料邊Y

        public static string Job => job;
        public static string Step => Gen.STEP;

        //gererate all fields property
        public static double Six => DoubleRound(s_ix);

        public static double Siy => DoubleRound(s_iy);

        public static double Wix => DoubleRound(w_ix);

        public static double Wiy => DoubleRound(w_iy);

        public static int Xstep_num => xstep_num;

        public static int Ystep_num => ystep_num;

        public static double Xstep_spec => xstep_spec;

        public static double Ystep_spec => ystep_spec;

        public static double Frame_x => DoubleRound(frame_x);
        public static double Frame_y => DoubleRound(frame_y);
        public static double Frame_Dist_x => DoubleRound(frame_dist_x);
        public static double Frame_Dist_y => DoubleRound(frame_dist_y);

        static MyPanelScript()
        {
            layers = MainWindow.layers;
            mainWindow = Application.Current.MainWindow as MainWindow;
            s_ix = DoubleRound(double.Parse(mainWindow.six.Text));
            s_iy = DoubleRound(double.Parse(mainWindow.siy.Text));
            w_ix = DoubleRound(double.Parse(mainWindow.wix.Text));
            w_iy = DoubleRound(double.Parse(mainWindow.wiy.Text));
            xstep_num = int.Parse(mainWindow.xstep_num.Text);
            ystep_num = int.Parse(mainWindow.ystep_num.Text);
            xstep_spec = DoubleRound(double.Parse(mainWindow.xstep_spec.Text));
            ystep_spec = DoubleRound(double.Parse(mainWindow.ystep_spec.Text));
        }

        //Tools: Round a double to 4 decimal places
        public static double DoubleRound(double num) => Math.Round(num, 4);

        public static void RunPanelScript()
        {
            string selStep = mainWindow.stpSlect.Text;

            #region open work step and check size

            //是否自動排板
            if (selStep == workName)
            {
                frame_x = Six;
                frame_y = Siy;

                // If the step already exists, open it
                frame_dist_x = DoubleRound((Wix - s_ix) / 2.0);
                frame_dist_y = DoubleRound((Wiy - s_iy) / 2.0);

                if (frame_dist_x < 0 || frame_dist_y < 0)
                {
                    Gen.PAUSE("Size not correct,please check");
                    // Exit the script if the size is not correct
                    return;
                }

                if (Step != workName)
                    Gen.COM($"COM open_entity,job={Job},type=step,name={workName},iconic=no");
            }
            else if (selStep != workName)
            {
                frame_x = (Six * xstep_num) + ((xstep_num - 1) * xstep_spec);
                frame_dist_x = (Wix - frame_x) / 2.0;
                frame_y = (Siy * ystep_num) + ((ystep_num - 1) * ystep_spec);
                frame_dist_y = (Wiy - frame_y) / 2.0;
                if (frame_dist_x < 0 || frame_dist_y < 0)
                {
                    Gen.PAUSE("Size not correct,please check");
                    // Exit the script if the size is not correct
                    return;
                }

                frame_x = DoubleRound(frame_x);
                frame_dist_x = DoubleRound(frame_dist_x);
                frame_y = DoubleRound(frame_y);
                frame_dist_y = DoubleRound(frame_dist_y);

                Gen.INFO($" -t job -e {Job} -m script -d STEPS_LIST");
                List<string> MyStepsList = new List<string>(Gen.GetInfo("gSTEPS_LIST"));
                if (MyStepsList.Contains(workName))
                {
                    Gen.PAUSE($"{workName} is exist, delete id");
                    Gen.COM($"delete_entity,job={Job},type=step,name={workName}");
                }

                Gen.COM($"create_entity,job={Job},is_fw=no,type=step,fw_type=form,name={workName},db=");
                Gen.COM($"open_entity,job={Job},type=step,name={workName},iconic=no");

                AutoPanel();
            }

            #endregion

            //setting unit
            Gen.COM("units,type=inch");

            #region clear layer and remove pin inn

            // clear all layer befor run script
            Gen.COM("affected_layer,mode=all,affected=yes");
            Gen.COM("sel_delete");
            Gen.COM("affected_layer,mode=all,affected=no");


            //Multiple layers,delete inn and pin layer if exists
            if (layers.SignalTMP.Count > 2)
            {
                Gen.INFO($"-t layer -e {Job}/{Step}/inn -d EXISTS -m script,units=inch");
                if (Gen.GetInfo("gEXISTS")[0] == "yes") Gen.COM("delete_layer,layer=inn");
                Gen.INFO($"-t layer -e {Job}/{Step}/pin -d EXISTS -m script,units=inch");
                if (Gen.GetInfo("gEXISTS")[0] == "yes") Gen.COM("delete_layer,layer=pin");
                Gen.COM(
                    $"create_layer,layer=inn,context=board,type=drill,polarity=positive,ins_layer=,location=before");
                Gen.COM(
                    $"create_layer,layer=pin,context=board,type=drill,polarity=positive,ins_layer=,location=before");
            }

            #endregion

            //setting panel size
            //Gen.COM($"COM panel_size,width={Wix},height={Wiy}");
        }

        public static void AutoPanel()
        {
            string auto_step = mainWindow.stpSlect.Text;
            string auto_angle = mainWindow.shipRotate.Text;
            if (auto_angle == "0")
            {
                Gen.COM($"sr_tab_add,line=0,step={auto_step},x={Frame_Dist_x},y={Frame_Dist_y}," +
                        $"nx={Xstep_num},ny={ystep_num},dx={Six + xstep_spec},dy={Siy + ystep_spec}");
            }
            else
            {
                Gen.COM($"sr_tab_add,line=0,step={auto_step},x={Frame_Dist_x},y={Frame_Dist_y + Siy}," +
                        $"nx={Xstep_num},ny={ystep_num},dx={Six + xstep_spec},dy={Siy + ystep_spec},angle={auto_angle}");
            }
        }
    }
}