using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using GenesisLib;
using Point = GenesisLib.Point;

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
        private readonly static string Step = Gen.STEP;

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
        public static double DoubleRound(double num) => Math.Round(num, 6);

        public static void RunPanelScript()
        {
            //hide mainwindow
            //mainWindow.Hide();
            mainWindow.Focusable = false;


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
                    Gen.COM($"open_entity,job={Job},type=step,name={workName},iconic=no");
            }
            else if (selStep=="" || selStep != workName)
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
                    //Gen.PAUSE($"{workName} is exist, delete id");
                    MessageBoxResult result = MessageBox.Show(
                        $"{workName} 已存在,是否刪除？",
                        "確認刪除",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        Gen.COM($"delete_entity,job={Job},type=step,name={workName}");
                    }
                    else
                    {
                        return;
                    }
                }

                Gen.COM($"create_entity,job={Job},is_fw=no,type=step,fw_type=form,name={workName},db=");
                Gen.COM($"open_entity,job={Job},type=step,name={workName},iconic=no");

                AutoPanel();
            }

            #endregion

            //setting unit
            Gen.COM("units,type=inch");

            #region clear layer , create layer pin inn via tent

            // clear all layer befor run script
            Gen.COM("affected_layer,mode=all,affected=yes");
            Gen.COM("sel_delete");
            Gen.COM("affected_layer,mode=all,affected=no");


            //Multiple layers,delete inn and pin layer if exists
            if (layers.SignalTMP.Count > 2)
            {
                if (!GenTools.Layer_IsExist(Job, workName, "inn"))
                    GenTools.Layer_Create("inn", "noard", GenTools.layerType["drill"]);
                if (!GenTools.Layer_IsExist(Job, workName, "pin"))
                    GenTools.Layer_Create("pin", "board", GenTools.layerType["drill"]);
            }

            if (!GenTools.Layer_IsExist(Job, workName, "via"))
                GenTools.Layer_Create("via", "misc", GenTools.layerType["doc"]);
            if (!GenTools.Layer_IsExist(Job, workName, "t1"))
                GenTools.Layer_Create("t1", "misc", GenTools.layerType["doc"]);

            #endregion

            // Create the profile
            Do_Patttern_Fill();

            MessageBoxResult resultMessage = MessageBox.Show(
                "執行完畢,是否關閉程式？",
                "成功結束啦..",
                MessageBoxButton.OK,
                MessageBoxImage.Question);
            //Finish the script
            if (resultMessage == MessageBoxResult.OK)
                Application.Current.Shutdown(); // Close the application
        }

        /// <summary>
        /// 內、外框鋪銅
        /// </summary>
        private static void Do_Patttern_Fill()
        {
            Gen.COM($"profile_rect,x1={-frame_dist_x},y1={-frame_dist_y},x2={frame_dist_x},y2={frame_dist_y}");


            string ccd_copper_ = "fill_copper_zz"; // Temporary layer name

            if (GenTools.Layer_IsExist(Job, Step, ccd_copper_))
            {
                Gen.COM($"delete_layer,layer={ccd_copper_}");
            }

            GenTools.Layer_Create(ccd_copper_, "misc", GenTools.layerType["sig"]);

            Gen.COM($"affected_layer,name={ccd_copper_},mode=single,affected=yes");

            GenTools.Layer_Pattern_Fill(ccd_copper_, 0, 0,
                100, 100,
                0.1, 0.1,
                frame_dist_x - 0.1, frame_dist_y - 0.1);

            Point p = new Point(x_min: 0, y_min: 0, x_max: frame_x, y_max: frame_y);
            Gen.PAUSE("check");
            Gen.COM($"affected_layer,name={ccd_copper_},mode=single,affected=yes");
            GenTools.Add_Rec_Line(p, GenTools.POS_NEG["N"]);
            Gen.COM("sel_contourize," +
                    "accuracy=0.25,break_to_islands=yes,clean_hole_size=3,clean_hole_mode=x_and_y,validate_result=no");
            GenTools.Clear_Layers();

            if (layers.Inner != null && layers.Inner.Count > 0)
            {
                Gen.COM($"affected_layer,name={ccd_copper_},mode=single,affected=yes");
                foreach (var inner in layers.Inner)
                {
                    Gen.COM("sel_copy_other," +
                            $"dest=layer_name,target_layer={inner}" +
                            $",invert=no,dx=0,dy=0,size=0,x_anchor=0,y_anchor=0,rotation=0,mirror=none");
                }

                GenTools.Clear_Layers();
            }

            //copper fill-outter layer
            //outter_pos_neg group
            if (mainWindow.outter_pos.IsChecked == true) //正片流程
            {
                GenTools.Layer_Pattern_Fill(layers.Outer,
                    -.1, -.1,
                    100, 100,
                    0.1, 0.1);
            }
            else //負片流程
            {
                Gen.COM($"affected_layer,name={ccd_copper_},mode=single,affected=yes");
                foreach (var outter in layers.Outer)
                {
                    Gen.COM("sel_copy_other," +
                            $"dest=layer_name,target_layer={outter}" +
                            $",invert=no,dx=0,dy=0,size=0,x_anchor=0,y_anchor=0,rotation=0,mirror=none");
                }

                GenTools.Clear_Layers();
            }

            //delete temporary layer
            Gen.COM($"delete_layer,layer={ccd_copper_}");
        }

        public static void AutoPanel()
        {
            string selStep = mainWindow.stpSlect.Text;
            //check datum is offset zero point
            Gen.INFO($"-t step -e {Job}/{selStep} -m script -d PROF_LIMITS");
            double prof_limit_xmin = DoubleRound(Math.Abs(double.Parse(Gen.GetInfo("gPROF_LIMITSxmin")[0])));
            double prof_limit_xmax = DoubleRound(Math.Abs(double.Parse(Gen.GetInfo("gPROF_LIMITSxmax")[0])));
            double prof_limit_ymin = DoubleRound(Math.Abs(double.Parse(Gen.GetInfo("gPROF_LIMITSymin")[0])));
            double prof_limit_ymax = DoubleRound(Math.Abs(double.Parse(Gen.GetInfo("gPROF_LIMITSymax")[0])));

            //absolute limits


            string auto_step = mainWindow.stpSlect.Text;
            string auto_angle = mainWindow.shipRotate.Text;
            if (auto_angle == "0")
            {
                Gen.COM($"sr_tab_add,line=0,step={auto_step},x={prof_limit_xmin},y={prof_limit_ymin}," +
                        $"nx={Xstep_num},ny={ystep_num},dx={Six + xstep_spec},dy={Siy + ystep_spec}");
            }
            else
            {
                Gen.COM($"sr_tab_add,line=0,step={auto_step},x={prof_limit_ymin} ,y= {prof_limit_xmax}," +
                        $"nx={Xstep_num},ny={ystep_num},dx={Six + xstep_spec},dy={Siy + ystep_spec},angle={auto_angle}");
            }
        }
    }
}