using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Security.Policy;
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
        /// <summary>
        /// OUT_INNER 枚舉類型，用於表示外層或內層
        /// <para>
        /// OUTER: 外層
        /// </para>
        /// <para>
        /// INNER: 內層
        /// </para>
        /// </summary>
        enum OUT_INNER
        {
            OUTTER,
            INNER
        }

        private static MySymbols sym;
        static MainWindow mainWindow;
        private static readonly LayerCollection layers = MainWindow.layers;
        private static readonly int LayerCount = layers.SignalLayers.Count;
        static readonly string workName = "work";
        private readonly static string job = Gen.JOB;
        private readonly static string step = Gen.STEP;
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
        private static double min_x; //主板尺寸X (virtual size for static panel)
        private static double min_y; //主板尺寸Y (virtual size for static panel)
        private static double max_x; //最大尺寸X (virtual size for static panel)
        private static double max_y; //最大尺寸Y (virtual size for static panel)
        private static readonly double static_frame_width_x = 0.5; //固定板框虛擬寬度X
        private static readonly double static_frame_width_y = 0.5; //固定板框虛擬寬度Y
        private static Point Panel_Center = new Point();
        public static string Job => job;

        public static string Step => step;

        //gererate all fields property
        public static double Six => s_ix; //排板尺寸X

        public static double Siy => s_iy; //排板尺寸Y

        public static double Wix => w_ix; //下料尺寸X

        public static double Wiy => w_iy; //下料尺寸Y

        public static int Xstep_num => xstep_num; // 排板數量x
        public static int Ystep_num => ystep_num; // 排板數量y

        public static double Xstep_spec => xstep_spec; // 排板間距X

        public static double Ystep_spec => ystep_spec; // 排板間距Y

        public static double Frame_x => frame_x; //排板尺寸X(包括邊距)
        public static double Frame_y => frame_y; //排板尺寸Y(包括邊距)
        public static double Frame_Dist_x => frame_dist_x; //下料邊X
        public static double Frame_Dist_y => frame_dist_y; //下料邊Y
        public static double Min_x => min_x; //主板尺寸X (virtual size for static panel)
        public static double Min_y => min_y; //主板尺寸Y (virtual size for static panel)
        public static double Max_x => max_x; //最大尺寸X (virtual size for static panel)
        public static double Max_y => max_y; //最大尺寸Y (virtual size for static panel)

        static MyPanelScript()
        {
            //初始化
            layers = MainWindow.layers;
            mainWindow = Application.Current.MainWindow as MainWindow;
            double mm2Inch = mainWindow.unit_mminch.Text == "MM" ? 0.03937 : 1.0; //毫米轉英寸
            s_ix = GenTools.DoubleRound(double.Parse(mainWindow.six.Text) * mm2Inch);
            s_iy = GenTools.DoubleRound(double.Parse(mainWindow.siy.Text) * mm2Inch);
            w_ix = GenTools.DoubleRound(double.Parse(mainWindow.wix.Text) * mm2Inch);
            w_iy = GenTools.DoubleRound(double.Parse(mainWindow.wiy.Text) * mm2Inch);
            xstep_num = int.Parse(mainWindow.xstep_num.Text);
            ystep_num = int.Parse(mainWindow.ystep_num.Text);
            xstep_spec = GenTools.DoubleRound(double.Parse(mainWindow.xstep_spec.Text) * mm2Inch);
            ystep_spec = GenTools.DoubleRound(double.Parse(mainWindow.ystep_spec.Text) * mm2Inch);
        }

        //雙精度的四捨五入方法

        //GenTools. DoubleRound 方法將數字四捨五入到小數點後兩位

        public static void RunPanelScript()
        {
            //hide mainwindow
            //mainWindow.Hide();
            mainWindow.Focusable = false;

            Gen.PAUSE("test");

            string selStep = mainWindow.stpSlect.Text;

            #region open work step and check size

            //手動排板
            if (selStep == workName)
            {
                frame_x = Six;
                frame_y = Siy;

                // If the step already exists, open it
                frame_dist_x = GenTools.DoubleRound((Wix - s_ix) / 2.0);
                frame_dist_y = GenTools.DoubleRound((Wiy - s_iy) / 2.0);

                //判斷下料尺寸是否大於成型尺寸
                if (frame_dist_x < 0 || frame_dist_y < 0)
                {
                    Gen.PAUSE("Size not correct,please check");
                    // Exit the script if the size is not correct
                    return;
                }

                //開啟work step
                if (Step != workName)
                {
                    Gen.COM($"open_entity,job={Job},type=step,name={workName},iconic=no");
                }
            }

            //沒有選擇work step
            else if (selStep == "" || Step == "" || step == null)
            {
                Gen.PAUSE("Please select a step to run the script");
                return;
            }
            //自動排板
            else if (selStep != workName)
            {
                frame_x = GenTools.DoubleRound((Six * xstep_num) + ((xstep_num - 1) * xstep_spec));
                frame_dist_x = GenTools.DoubleRound((Wix - frame_x) / 2.0);
                frame_y = GenTools.DoubleRound((Siy * ystep_num) + ((ystep_num - 1) * ystep_spec));
                frame_dist_y = GenTools.DoubleRound((Wiy - frame_y) / 2.0);
                if (frame_dist_x < 0 || frame_dist_y < 0)
                {
                    Gen.PAUSE("Size not correct,please check");
                    // Exit the script if the size is not correct
                    return;
                }

                frame_x = GenTools.DoubleRound(frame_x);
                frame_dist_x = GenTools.DoubleRound(frame_dist_x);
                frame_y = GenTools.DoubleRound(frame_y);
                frame_dist_y = GenTools.DoubleRound(frame_dist_y);

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

            if (mainWindow.StaticFrame.IsChecked == true)
            {
                if (Frame_Dist_x > static_frame_width_x)
                {
                    min_x = -static_frame_width_x;
                    max_x = Frame_x + static_frame_width_x;
                }

                if (Frame_Dist_y > static_frame_width_y)
                {
                    min_y = -static_frame_width_y;
                    max_y = Frame_y + static_frame_width_y;
                }
            }
            else
            {
                min_x = 0;
                min_y = 0;
                max_x = Frame_x;
                max_y = Frame_y;
            }

            //板中心
            Panel_Center = new Point();
            Panel_Center.CenterPoint();

            #endregion

            //單位設定
            Gen.COM("units,type=inch");

            #region clear layer , create layer pin inn via tent

            //清空內容
            // clear all layer befor run script
            Gen.COM("affected_layer,mode=all,affected=yes");
            Gen.COM("sel_delete");
            Gen.COM("affected_layer,mode=all,affected=no");


            //多層板,建立inn,pin ,t1,v1
            if (LayerCount > 2)
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

            //create the frame
            Gen.COM(
                $"profile_rect,x1={-Frame_Dist_x},y1={-Frame_Dist_y},x2={Frame_x + Frame_Dist_x},y2={Frame_y + Frame_Dist_y}");

            //內、外框鋪銅
            Do_Patttern_Fill();

            //印刷PIN
            Tooling print_pin = new Tooling(LayerCount, min_x, min_y, max_x, max_y, 0, 0);

            Add_Pin_pad(print_pin, OUT_INNER.OUTTER);


            Add_Ten_Pad();


            //end of script
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
        /// 增加外層十字型PAD
        /// </summary>
        /// <returns></returns>
        private static void Add_Ten_Pad()
        {
            //外層十字型PAD
            List<double> ten_sym_pad_x = new List<double>()
            {
                GenTools.DoubleRound(max_x / 3),
                GenTools.DoubleRound(max_x / 3 * 2),
                GenTools.DoubleRound(max_x / 3),
                GenTools.DoubleRound(max_x / 3 * 2),
                min_x - 0.2,
                min_x - 0.2,
                GenTools.DoubleRound(max_x + 0.2),
                GenTools.DoubleRound(max_x + 0.2),
            };
            List<double> ten_sym_pad_y = new List<double>()
            {
                min_y - 0.2,
                min_y - 0.2,
                GenTools.DoubleRound(max_y + 0.2),
                GenTools.DoubleRound(max_y + 0.2),
                GenTools.DoubleRound(max_y / 3),
                GenTools.DoubleRound(max_y / 3 * 2),
                GenTools.DoubleRound(max_y / 3),
                GenTools.DoubleRound(max_y / 3 * 2 + 0.5),
            };
            foreach (string outer in layers.Outer)
            {
                Gen.COM($"affected_layer,name={outer},mode=single,affected=yes");
            }

            for (int i = 0; i < ten_sym_pad_x.Count; i++)
            {
                Gen.COM("add_pad" +
                        ",attributes=no" +
                        $",x={ten_sym_pad_x[i]},y={ten_sym_pad_y[i]}" +
                        $",symbol={sym.Pnl_Ten_Pad}" +
                        $",polarity=positive" +
                        $",angle=0" +
                        $",mirror=no" +
                        $",nx=1,ny=1,dx=0,dy=0,xscale=1,yscale=1 ");
            }

            GenTools.Clear_Layers();
        }

        private static void Add_L_Mark()
        {
            List<int> angle = new List<int>() { 0, 90, 180, 270 };


            List<double> l_mark_x = new List<double>()
            {
                min_x - 0.2,
                min_x - 0.2,
                max_x + 0.02,
                max_x + 0.02,
            };

            List<double> l_mark_y = new List<double>()
            {
                min_y - 0.2,
                max_y + 0.02,
                max_y + 0.02,
                min_y - 0.2,
            };

            //外層十字型PAD
            foreach (string outer in layers.Outer)
            {
                Gen.COM($"affected_layer,name={outer},mode=single,affected=yes");
            }

            for (int i = 0; i < l_mark_x.Count; i++)
            {
                Gen.COM("add_pad" +
                        ",attributes=no" +
                        $",x={l_mark_x[i]},y={l_mark_y[i]}" +
                        $",symbol={sym.Pnl_L_Mark}" +
                        $",polarity=positive" +
                        $",angle={angle[i]}" +
                        $",mirror=no" +
                        $",nx=1,ny=1,dx=0,dy=0,xscale=1,yscale=1 ");
            }

            List<double> l_mark_n_x = new List<double>()
            {
                -Frame_Dist_x,
                -Frame_Dist_x,
                Frame_x + Frame_Dist_x,
                Frame_x + Frame_Dist_x,
            };
            List<double> l_mark_n_y = new List<double>()
            {
                -Frame_Dist_y,
                Frame_y + Frame_Dist_y,
                Frame_y + Frame_Dist_y,
                -Frame_Dist_y,
            };

            for (int i = 0; i < l_mark_n_x.Count; i++)
            {
                Gen.COM("add_pad" +
                        ",attributes=no" +
                        $",x={l_mark_n_x[i]},y={l_mark_n_y[i]}" +
                        $",symbol={sym.Pnl_L_Mark_N}" +
                        $",polarity=negative" +
                        $",angle={angle[i]}" +
                        $",mirror=no" +
                        $",nx=1,ny=1,dx=0,dy=0,xscale=1,yscale=1 ");
            }

            GenTools.Clear_Layers();

            //v1,t1也增加L Mark(避免在v1,t1底過度片繪製過小)
            Gen.COM($"affected_layer,name=v1,mode=single,affected=yes");
            Gen.COM($"affected_layer,name=t1,mode=single,affected=yes");

            for (int i = 0; i < l_mark_n_x.Count; i++)
            {
                Gen.COM("add_pad" +
                        ",attributes=no" +
                        $",x={l_mark_n_x[i]},y={l_mark_n_y[i]}" +
                        $",symbol={sym.Pnl_L_Mark_N}" +
                        $",polarity=positive" +
                        $",angle={angle[i]}" +
                        $",mirror=no" +
                        $",nx=1,ny=1,dx=0,dy=0,xscale=1,yscale=1 ");
            }

            GenTools.Clear_Layers();
        }

        /// <summary>
        ///增加印刷PIN PAD
        /// </summary>
        /// <param name="print_pin">The print pin.</param>
        private static void Add_Pin_pad(Tooling print_pin, OUT_INNER out_inner)
        {
            if (out_inner == OUT_INNER.OUTTER)
            {
                //增加外框印刷PIN PAD
                foreach (string outer in layers.Outer)
                {
                    Gen.COM($"affected_layer,name={outer},mode=single,affected=yes");
                }

                for (int i = 0; i < print_pin.PrintPinOuterX.Count; i++)
                {
                    //CCD PAD
                    if (print_pin.Ccd_Pad_Loc.IndexOf(i) != -1)
                    {
                        string ccd_pad = "";
                        //外層正片
                        ccd_pad = mainWindow.outter_pos.IsChecked == true
                            ? sym.Pnl_Pin_Ccd_Pad_P
                            : sym.Pnl_Pin_Ccd_Pad_N;

                        Gen.COM("add_pad" +
                                ",attributes=no" +
                                $",x={print_pin.PrintPinOuterX[i]},y={print_pin.PrintPinOuterY[i]}" +
                                $",symbol={ccd_pad}" +
                                $",polarity=positive" +
                                $",angle=0,mirror=no" +
                                $",nx=1,ny=1,dx=0,dy=0" +
                                $",xscale=1,yscale=1");
                    }
                    else
                    {
                        Gen.COM("add_pad" +
                                ",attributes=no" +
                                $",x={print_pin.PrintPinOuterX[i]},y={print_pin.PrintPinOuterY[i]}" +
                                $",symbol=pnl_out_pin_pad" +
                                $",polarity=positive" +
                                $",angle=0,mirror=no" +
                                $",nx=1,ny=1,dx=0,dy=0" +
                                $",xscale=1,yscale=1");
                    }
                }
            }

            GenTools.Clear_Layers();
        }


        /// <summary>
        /// 內、外框鋪銅
        /// </summary>
        private static void Do_Patttern_Fill()
        {
            bool isMultiLyr = false;
            bool isNegOuter = false;
            if (layers.Inner != null && layers.Inner.Count > 0)
            {
                GenTools.Layer_Pattern_Fill(layers.Inner, 0, 0,
                    100, 100,
                    0.1, 0.1,
                    frame_dist_x - 0.08, frame_dist_y - 0.08);

                int isOdd = 0;
                foreach (var layer in layers.Inner)
                {
                    Gen.COM($"affected_layer,name={layer},mode=single,affected=yes");
                    isOdd++;
                    if (isOdd % 2 == 0)
                    {
                        GenTools.Add_CCD_Frame(Panel_Center.CenterX, Panel_Center.CenterY, sym.Pnl_Ccd_Inner_Frame_1);
                    }
                    else
                    {
                        GenTools.Add_CCD_Frame(Panel_Center.CenterX, Panel_Center.CenterY, sym.Pnl_Ccd_Inner_Frame_2);
                    }
                }

                isMultiLyr = true;
            }

            if (mainWindow.outter_pos.IsChecked == true) //正片流程
            {
                GenTools.Layer_Pattern_Fill(layers.Outer,
                    -.1, -.1,
                    100, 100,
                    0.1, 0.1);
                foreach (var layer in layers.Outer)
                {
                    Gen.COM($"affected_layer,name={layer},mode=single,affected=yes");
                }

                GenTools.Add_CCD_Frame(Panel_Center.CenterX, Panel_Center.CenterY, sym.Pnl_Ccd_Frame_P);
            }
            else //負片流程
            {
                GenTools.Layer_Pattern_Fill(layers.Outer, 0, 0,
                    100, 100,
                    0.1, 0.1,
                    frame_dist_x - 0.1, frame_dist_y - 0.1);

                foreach (var layer in layers.Outer)
                {
                    Gen.COM($"affected_layer,name={layer},mode=single,affected=yes");
                }

                GenTools.Add_CCD_Frame(Panel_Center.CenterX, Panel_Center.CenterY, sym.Pnl_Ccd_Frame_N);
                isNegOuter = true;
            }

            if (isNegOuter || isNegOuter)
            {
                string ccd_fill = "ccd_coooper_fill";
                if (GenTools.Layer_IsExist(Job, workName, ccd_fill))
                    Gen.COM($"delete_layer,layer={ccd_fill}");
                GenTools.Layer_Create(ccd_fill, "misc", GenTools.layerType["sig"]);
                Gen.COM($"affected_layer,name={ccd_fill},mode=single,affected=yes");

                Gen.COM("add_surf_strt,surf_type=feature");
                Gen.COM("add_surf_poly_strt,x=-4.1196490157,y=-4.7077494094");
                Gen.COM("add_surf_poly_seg,x=-4.1196490157,y=20.2099319882");
                Gen.COM("add_surf_poly_seg,x=17.7993241142,y=20.2099319882");
                Gen.COM("add_surf_poly_seg,x=17.7993241142,y=-4.707749409");
                Gen.COM("add_surf_poly_seg,x=-4.1196490157,y=-4.707749409");
                Gen.COM("add_surf_poly_end");
                Gen.COM($"add_surf_end,attributes=no,polarity={GenTools.POS_NEG["P"]}");


                Gen.COM("add_surf_strt,surf_type=feature");
                Gen.COM($"add_surf_poly_strt,x={-frame_dist_x - 0.2},y={-frame_dist_y - 0.2}");
                Gen.COM($"add_surf_poly_seg,x={-frame_dist_x - 0.2},y={frame_y + frame_dist_x + 0.2}");
                Gen.COM($"add_surf_poly_seg,x={frame_x + frame_dist_x + 0.2},y={frame_y + frame_dist_x + 0.2}");
                Gen.COM($"add_surf_poly_seg,x={frame_x + frame_dist_x + 0.2},y={-frame_dist_y - 0.2}");
                Gen.COM($"add_surf_poly_seg,x={-frame_dist_x - 0.2},y={-frame_dist_y - 0.2}");
                Gen.COM("add_surf_poly_end");
                Gen.COM($"add_surf_end,attributes=no,polarity={GenTools.POS_NEG["N"]}");

                Gen.COM("sel_contourize" +
                        ",accuracy=0.25,break_to_islands=yes" +
                        ",clean_hole_size=3,clean_hole_mode=x_and_y" +
                        ",validate_result=no");
                if (isMultiLyr)
                {
                    foreach (string layer in layers.Inner)
                    {
                        Gen.COM("sel_copy_other" +
                                $",dest=layer_name,target_layer={layer}" +
                                $",invert=no,dx=0,dy=0,size=0" +
                                $",x_anchor=0,y_anchor=0,rotation=0,mirror=none");
                    }
                }

                if (isNegOuter)
                {
                    foreach (string layer in layers.Outer)
                    {
                        Gen.COM("sel_copy_other" +
                                $",dest=layer_name,target_layer={layer}" +
                                $",invert=no,dx=0,dy=0,size=0" +
                                $",x_anchor=0,y_anchor=0,rotation=0,mirror=none");
                    }
                }

                Gen.COM($"delete_layer,layer={ccd_fill}");
                GenTools.Clear_Layers();
            }

            //增加內層導流條
            if (isMultiLyr)
            {
                Add_Inner_Strip();
            }
        }

        public static void AutoPanel()
        {
            string selStep = mainWindow.stpSlect.Text;

            //check datum is offset zero point
            Gen.INFO($"-t step -e {Job}/{selStep} -m script -d PROF_LIMITS");
            double prof_limit_xmin = GenTools.DoubleRound(Math.Abs(double.Parse(Gen.GetInfo("gPROF_LIMITSxmin")[0])));
            double prof_limit_xmax = GenTools.DoubleRound(Math.Abs(double.Parse(Gen.GetInfo("gPROF_LIMITSxmax")[0])));
            double prof_limit_ymin = GenTools.DoubleRound(Math.Abs(double.Parse(Gen.GetInfo("gPROF_LIMITSymin")[0])));
            double prof_limit_ymax = GenTools.DoubleRound(Math.Abs(double.Parse(Gen.GetInfo("gPROF_LIMITSymax")[0])));

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

        public static void Add_Inner_Strip()
        {
            GenTools.Clear_Layers();
            //創建tmp層

            //strip rule-4x each long side ,2x each short side

            double anchor_center_x = GenTools.DoubleRound((Frame_x / 2)) - frame_dist_x;
            double anchor_center_y = GenTools.DoubleRound((Frame_y / 2)) - frame_dist_y;

            double add_inner_copper_x1 = 0;
            double add_inner_copper_x12 = 0 - frame_dist_x;


            double add_inner_copper_y1 = 0 + 3.6;
            double add_inner_copper_y12 = add_inner_copper_y1 - 0.5;
            double add_inner_copper_y13 = add_inner_copper_y1 - 0.5 + 0.24;
            double add_inner_copper_y14 = add_inner_copper_y1 + 0.24;


            double add_inner_copper_y2 = 0 + 3.6 + 3;
            double add_inner_copper_y22 = add_inner_copper_y2 - 0.5;
            double add_inner_copper_y23 = add_inner_copper_y2 - 0.5 + 0.24;
            double add_inner_copper_y24 = add_inner_copper_y2 + 0.24;

            double add_inner_copper_y3 = Wiy - 3.6 - 3;
            double add_inner_copper_y32 = add_inner_copper_y3 - 0.5;
            double add_inner_copper_y33 = add_inner_copper_y3 - 0.5 + 0.24;
            double add_inner_copper_y34 = add_inner_copper_y3 + 0.24;

            double add_inner_copper_y4 = Wiy - 3.6;
            double add_inner_copper_y42 = add_inner_copper_y4 - 0.5;
            double add_inner_copper_y43 = add_inner_copper_y4 - 0.5 + 0.24;
            double add_inner_copper_y44 = add_inner_copper_y4 + 0.24;

            Gen.COM("affected_layer,name=,mode=all,affected=no");


            List<string> ccd_str_lyr = new List<string>() { "ccd_strip_tmp_1", "ccd_strip_tmp_2" };
            foreach (string ccd_s_lyr in ccd_str_lyr)
            {
                if (GenTools.Layer_IsExist(Job, workName, ccd_s_lyr))
                    Gen.COM($"delete_layer,layer={ccd_s_lyr}");
                GenTools.Layer_Create(ccd_s_lyr, "misc", GenTools.layerType["sig"]);
            }

            string tmp_01 = "t_m_01";

            if (GenTools.Layer_IsExist(Job, workName, tmp_01))
                Gen.COM($"delete_layer,layer={tmp_01}");
            GenTools.Layer_Create(tmp_01, "misc", GenTools.layerType["sig"]);

            Gen.COM($"affected_layer,name={tmp_01},mode=single,affected=yes");

            //左邊第一顆
            Gen.COM("add_surf_strt,surf_type=feature");
            Gen.COM($"add_surf_poly_strt,x={add_inner_copper_x1},y={add_inner_copper_y1}");
            Gen.COM($"add_surf_poly_seg,x={add_inner_copper_x12},y={add_inner_copper_y12}");
            Gen.COM($"add_surf_poly_seg,x={add_inner_copper_x12},y={add_inner_copper_y13}");
            Gen.COM($"add_surf_poly_seg,x={add_inner_copper_x1},y={add_inner_copper_y14}");
            Gen.COM($"add_surf_poly_seg,x={add_inner_copper_x1},y={add_inner_copper_y1}");
            Gen.COM("add_surf_poly_end");
            Gen.COM("add_surf_end,attributes = no,polarity = positive");


//左邊第二顆
            Gen.COM($"add_surf_strt, surf_type = feature");
            Gen.COM($"add_surf_poly_strt, x = {add_inner_copper_x12},y = {add_inner_copper_y2}");
            Gen.COM($"add_surf_poly_seg, x = {add_inner_copper_x1},y = {add_inner_copper_y22}");
            Gen.COM($"add_surf_poly_seg, x = {add_inner_copper_x1},y = {add_inner_copper_y23}");
            Gen.COM($"add_surf_poly_seg, x = {add_inner_copper_x12},y = {add_inner_copper_y24}");
            Gen.COM($"add_surf_poly_seg, x = {add_inner_copper_x12},y = {add_inner_copper_y2}");
            Gen.COM("add_surf_poly_end");
            Gen.COM("add_surf_end, attributes = no, polarity = positive");
//左邊第三顆
            Gen.COM($"add_surf_strt, surf_type = feature");
            Gen.COM($"add_surf_poly_strt, x = {add_inner_copper_x1},y = {add_inner_copper_y3}");
            Gen.COM($"add_surf_poly_seg, x = {add_inner_copper_x12},y = {add_inner_copper_y32}");
            Gen.COM($"add_surf_poly_seg, x = {add_inner_copper_x12},y = {add_inner_copper_y33}");
            Gen.COM($"add_surf_poly_seg, x = {add_inner_copper_x1},y = {add_inner_copper_y34}");
            Gen.COM($"add_surf_poly_seg, x = {add_inner_copper_x1},y = {add_inner_copper_y3}");
            Gen.COM("add_surf_poly_end");
            Gen.COM("add_surf_end, attributes = no, polarity = positive");

            //左邊第四顆

            Gen.COM($"add_surf_strt, surf_type = feature");
            Gen.COM($"add_surf_poly_strt, x = {add_inner_copper_x12},y = {add_inner_copper_y4}");
            Gen.COM($"add_surf_poly_seg, x = {add_inner_copper_x1},y = {add_inner_copper_y42}");
            Gen.COM($"add_surf_poly_seg, x = {add_inner_copper_x1},y = {add_inner_copper_y43}");
            Gen.COM($"add_surf_poly_seg, x = {add_inner_copper_x12},y = {add_inner_copper_y44}");
            Gen.COM($"add_surf_poly_seg, x = {add_inner_copper_x12},y = {add_inner_copper_y4}");
            Gen.COM("add_surf_poly_end");
            Gen.COM("add_surf_end, attributes = no, polarity = positive");

            Gen.COM($"sel_transform,mode=anchor" +
                    $",oper=mirror" +
                    $",duplicate=yes" +
                    $",x_anchor={Panel_Center.CenterX},y_anchor=0" +
                    $",angle=0,x_scale=1,y_scale=1" +
                    $",x_offset=0,y_offset=0");
            Gen.COM($"sel_copy_other" +
                    $",dest=layer_name,target_layer={ccd_str_lyr[0]}" +
                    $",invert=yes,dx=0,dy=0" +
                    $",size=0,x_anchor=0" +
                    $",y_anchor=0,mirror=none,rotation=0");
            Gen.COM($"sel_transform" +
                    $",mode=axis,oper=y_mirror,duplicate=no" +
                    $",x_anchor=-0.3927834646,y_anchor=11.1881" +
                    $",angle=180,x_scale=1,y_scale=1,x_offset=0,y_offset=0");
            Gen.COM($"sel_move_other" +
                    $",target_layer={ccd_str_lyr[1]}" +
                    $",invert=yes" +
                    $",dx=0,dy=0" +
                    $",size=0,x_anchor=0,y_anchor=0,rotation=0,mirror=none");
            GenTools.Clear_Layers();

            Gen.COM($"affected_layer,name={tmp_01},mode=single,affected=yes");

            double add_inner_copper_y5 = 0;
            double add_inner_copper_y52 = -frame_dist_y;


            double add_inner_copper_x5 = 2.6;
            double add_inner_copper_x52 = add_inner_copper_x5 + 0.5;
            double add_inner_copper_x53 = add_inner_copper_x5 + 0.5 + 0.24;
            double add_inner_copper_x54 = add_inner_copper_x5 + 0.24;


            double add_inner_copper_x6 = Wix - 2.8;
            double add_inner_copper_x62 = add_inner_copper_x6 - 0.5;
            double add_inner_copper_x63 = add_inner_copper_x6 - 0.5 - 0.24;
            double add_inner_copper_x64 = add_inner_copper_x6 - 0.24;

            //下方第一顆

            Gen.COM($"add_surf_strt, surf_type = feature");
            Gen.COM($"add_surf_poly_strt, x = {add_inner_copper_x5},y = {add_inner_copper_y5}");
            Gen.COM($"add_surf_poly_seg, x = {add_inner_copper_x52},y = {add_inner_copper_y52}");
            Gen.COM($"add_surf_poly_seg, x = {add_inner_copper_x53},y = {add_inner_copper_y52}");
            Gen.COM($"add_surf_poly_seg, x = {add_inner_copper_x54},y = {add_inner_copper_y5}");
            Gen.COM($"add_surf_poly_seg, x = {add_inner_copper_x5},y = {add_inner_copper_y5}");
            Gen.COM("add_surf_poly_end");
            Gen.COM("add_surf_end, attributes = no, polarity = positive");

            //下方第二顆

            Gen.COM($"add_surf_strt, surf_type = feature");
            Gen.COM($"add_surf_poly_strt, x = {add_inner_copper_x6},y = {add_inner_copper_y5}");
            Gen.COM($"add_surf_poly_seg, x = {add_inner_copper_x62},y = {add_inner_copper_y52}");
            Gen.COM($"add_surf_poly_seg, x = {add_inner_copper_x63},y = {add_inner_copper_y52}");
            Gen.COM($"add_surf_poly_seg, x = {add_inner_copper_x64},y = {add_inner_copper_y5}");
            Gen.COM($"add_surf_poly_seg, x = {add_inner_copper_x6},y = {add_inner_copper_y5}");
            Gen.COM("add_surf_poly_end");
            Gen.COM("add_surf_end, attributes = no, polarity = positive");

            Gen.COM($"sel_transform" +
                    $",mode=anchor,oper=y_mirror" +
                    $",duplicate=yes" +
                    $",x_anchor=0,y_anchor={Panel_Center.CenterY}" +
                    $",angle=0" +
                    $",x_scale=1,y_scale=1" +
                    $",x_offset=0,y_offset=0");
            Gen.COM($"sel_copy_other" +
                    $",dest=layer_name,target_layer={ccd_str_lyr[0]}" +
                    $",invert=yes" +
                    $",dx=0,dy=0" +
                    $",size=0,x_anchor=0,y_anchor=0" +
                    $",mirror=none,rotation=0");
            Gen.COM($"sel_transform" +
                    $",mode=axis,oper=y_mirror" +
                    $",duplicate=no" +
                    $",x_anchor=-0.3927834646,y_anchor=11.1881" +
                    $",angle=180" +
                    $",x_scale=1,y_scale=1" +
                    $",x_offset=0,y_offset=0");
            Gen.COM($"sel_move_other" +
                    $",target_layer={ccd_str_lyr[1]}" +
                    $",invert=yes" +
                    $",dx=0,dy=0,size=0" +
                    $",x_anchor=0,y_anchor=0" +
                    $",rotation=0,mirror=none");

            Gen.COM($"delete_layer,layer={tmp_01}");
            GenTools.Clear_Layers();

            /*   //去除不要的導流條(多餘?
            foreach (string ccd_s_l in ccd_str_lyr)
            {
                Gen.COM($"affected_layer,name={ccd_s_l},mode=single,affected=yes");
                // 去除不要的
                Gen.COM("clip_area_strt");
                Gen.COM($"clip_area_end" +
                        $",layers_mode=layer_name,layer={ccd_s_l}" +
                        $",area=profile,area_type=rectangle" +
                        $",inout=outside" +
                        $",contour_cut=no" +
                        $",margin=0" +
                        $@",feat_types=line\;pad\;surface\;arc\;text");

                Gen.COM("clip_area_strt");
                Gen.COM("clip_area_xy, x = 0, y = 0");
                Gen.COM($"clip_area_xy, x = {frame_x},y = {frame_y}");
                Gen.COM($"clip_area_end" +
                        $",layers_mode=layer_name,layer={ccd_s_l}" +
                        $",area=manual,area_type=rectangle" +
                        $",inout=inside" +
                        $",contour_cut=no,margin=0" +
                        $@",feat_types=line\;pad\;surface\;arc\;text");

                Gen.COM($"affected_layer, name = {ccd_s_l},mode = single,affected = no");
            }
            */

            //複製內層導流條到 iner layer
            int isOdd = 0;
            foreach (string inn_lyr in layers.Inner)
            {
                Gen.COM("affected_layer,name=,mode=all,affected=no");
                isOdd++;
                if (isOdd % 2 == 1)
                {
                    Gen.COM($"affected_layer,name={ccd_str_lyr[0]},mode=single,affected=yes");
                }
                else
                {
                    Gen.COM($"affected_layer,name={ccd_str_lyr[1]},mode=single,affected=yes");
                }

                Gen.COM($"sel_copy_other" +
                        $",dest=layer_name,target_layer={inn_lyr}" +
                        $",invert=no" +
                        $",dx=0,dy=0" +
                        $",size=0" +
                        $",x_anchor=0,y_anchor=0" +
                        $",mirror=none,rotation=0");
            }

            Gen.COM($"delete_layer,layer={ccd_str_lyr[0]}");
            Gen.COM($"delete_layer,layer={ccd_str_lyr[1]}");
            ccd_str_lyr = null;
        }
    }
}