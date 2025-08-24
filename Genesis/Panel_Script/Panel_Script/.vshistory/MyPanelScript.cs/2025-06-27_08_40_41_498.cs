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
        private static List<string> stepList;

        public static string Job
        {
            set => job = value;
            get => job;
        }

        /// <summary>
        /// Gets or sets the current step in the process.
        /// </summary>
        public static string Step => Gen.STEP;

        //gererate all fields property
        public static double Six => s_ix;

        public static double Siy
        {
            set => s_iy = value;
            get => s_iy;
        }

        public static double Wix
        {
            set => w_ix = value;
            get => w_ix;
        }

        public static double Wiy
        {
            set => w＿iy = value;
            get => w＿iy;
        }

        public static int Xstep_num
        {
            set => xstep_num = value;
            get => xstep_num;
        }

        public static int Ystep_num
        {
            set => ystep_num = value;
            get => ystep_num;
        }

        public static double Xstep_spec
        {
            set => xstep_spec = value;
            get => xstep_spec;
        }

        public static double Ystep_spec
        {
            set => ystep_spec = value;
            get => ystep_spec;
        }

        static MyPanelScript()
        {
            mainWindow = Application.Current.MainWindow as MainWindow;
            s_ix = double.Parse(mainWindow.FindName("six").ToString());
            s_iy = double.Parse(mainWindow.FindName("siy").ToString());
            Wix = double.Parse(mainWindow.FindName("wix").ToString());
            Wiy = double.Parse(mainWindow.FindName("wiy").ToString());
            xstep_num = int.Parse(mainWindow.FindName("xstep_num").ToString());
            ystep_num = int.Parse(mainWindow.FindName("ystep_num").ToString());
            xstep_spec = double.Parse(mainWindow.FindName("xstep_spec").ToString());
            ystep_spec = double.Parse(mainWindow.FindName("ystep_spec").ToString());

            // Initialize stepList with the ComboBox from MainWindow
            stepList = mainWindow.FindName("stepList") as List<string>;
        }


        public static void RunPanelScript()
        {
            string stpSlectText = mainWindow.stpSlect.Text;

            #region open work step

            // Check if the current step is not "work",if "work" not exists, create it,then open it
            if (Step != "work")
            {
                if (stepList.Contains(workName))
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

            // clear all layer befor run script
            Gen.COM("affected_layer,mode=all,affected=yes");
            Gen.COM("sel_delete");
            Gen.COM("affected_layer,mode=all,affected=no");

            //auto panel
            if()
        }

    }
}