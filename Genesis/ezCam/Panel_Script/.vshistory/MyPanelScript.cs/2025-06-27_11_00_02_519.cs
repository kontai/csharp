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
        private static string job;
        private static readonly double s_ix; // 用於存儲成型尺寸 X 坐標值
        private static double s_iy; // 用於存儲成型尺寸 Y 坐標值
        private static double w_ix; // 用於存儲下料尺寸 X 坐標值
        private static double w＿iy; // 用於存儲下料尺寸 Y 坐標值
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
        public static double Six => s_ix;

        public static double Siy => s_iy;

        public static double Wix => w_ix;

        public static double Wiy => w＿iy;

        public static int Xstep_num => xstep_num;

        public static int Ystep_num => ystep_num;

        public static double Xstep_spec => xstep_spec;

        public static double Ystep_spec => ystep_spec;

        public static double Frame_x => frame_x;
        public static double Frame_y => frame_y;
        public static double Frame_Dist_x => frame_dist_x;
        public static double Frame_Dist_y => frame_dist_y;

        static MyPanelScript()
        {
            layers = MainWindow.layers;
            mainWindow = Application.Current.MainWindow as MainWindow;
            s_ix = double.Parse(mainWindow.FindName("six").ToString());
            s_iy = double.Parse(mainWindow.FindName("siy").ToString());
            w_ix = double.Parse(mainWindow.FindName("wix").ToString());
            w＿iy = double.Parse(mainWindow.FindName("wiy").ToString());
            xstep_num = int.Parse(mainWindow.FindName("xstep_num").ToString());
            ystep_num = int.Parse(mainWindow.FindName("ystep_num").ToString());
            xstep_spec = double.Parse(mainWindow.FindName("xstep_spec").ToString());
            ystep_spec = double.Parse(mainWindow.FindName("ystep_spec").ToString());
        }


        public static void RunPanelScript()
        {
            string selStep = mainWindow.stpSlect.Text;

            #region open work step

            //是否自動排板
            if (selStep == workName)
            {
                if (Six > Wix || Siy > Wiy)
                {
                    Gen.PAUSE("Size not correct,please check");
                    // Exit the script if the size is not correct
                    return;
                }

                frame_x = Six;
                frame_y= Siy;

                // If the step already exists, open it
                frame_dist_x = (Wix - s_ix) / 2.0;
                frame_dist_y = (Wiy - s_iy) / 2.0;

                if (Step != workName)
                    Gen.COM($"COM open_entity,job={Job},type=step,name={workName},iconic=no");
            }
            else if (selStep != workName)
            {
                Gen.INFO($" -t job -e {Job} -m script -d STEPS_LIST");
                List<string> MyStepsList = new List<string>(Gen.GetInfo("gSTEPS_LIST"));
                if (MyStepsList.Contains(workName))
                {
                    Gen.PAUSE($"{workName} is exist! delete id?");
                    Gen.COM($"delete_entity,job={Job},type=step,name={workName}");
                }

                Gen.COM($"create_entity,job={Job},is_fw=no,type=step,fw_type=form,name={workName},db=");
                Gen.COM($"open_entity,job={Job},type=step,name={workName},iconic=no");
                frame_dist_x = (Wix - (Six * xstep_num) + (xstep_num - 1) * xstep_spec)
            }

            // Check if the current step is not "work",if "work" not exists, create it,then open it
            if (Step != "work")
            {
                Gen.INFO($" -t job -e {Job} -m script -d STEPS_LIST");
                List<string> MyStepsList = new List<string>(Gen.GetInfo("gSTEPS_LIST"));
                if (MyStepsList.Contains(workName))
                {
                    // If the step already exists, open it
                    Gen.COM($"COM open_entity,job={Job},type=step,name={workName},iconic=no");
                }
                else
                {
                    // If the step does not exist, create it
                    Gen.COM($"COM create_entity,job={Job},is_fw=no,type=step,name={workName},db=,fw_type=form");
                    //then open it
                    Gen.COM($"COM open_entity,job={Job},type=step,name={workName},iconic=no");
                }
            }

            #endregion

            //setting unit
            Gen.COM("units,type=inch");

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

            //auto panel
        }
    }
}