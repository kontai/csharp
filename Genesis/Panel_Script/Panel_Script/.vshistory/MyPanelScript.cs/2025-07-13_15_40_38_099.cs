using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Navigation;
using GenesisLib;
using Point = GenesisLib.Point;

//TODO: 固定板框min_x, min_y, max_x, max_y ,將裁板尺寸納入計算
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
        enum ENUM_PIN_LYR
        {
            OUTTER,
            INNER,
            SMSSTENTVIA,
            DRLINNGBX,
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
        private static readonly double static_frame_width_x = 0.8; //固定板框虛擬寬度X
        private static readonly double static_frame_width_y = 0.8; //固定板框虛擬寬度Y
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
                    min_x = -frame_dist_x + static_frame_width_x;
                    max_x = Frame_x + Frame_Dist_x - static_frame_width_x;
                }

                if (Frame_Dist_y > static_frame_width_y)
                {
                    min_y = -frame_dist_y + static_frame_width_y;
                    max_y = Frame_y + Frame_Dist_y - static_frame_width_y;
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

            //判斷一些必要層別
            if (!GenTools.Layer_IsExist(Job, Step, "gbx"))
            {
                Gen.PAUSE("gbx Layer not exist. please check");
                return;
            }

            if (!GenTools.Layer_IsExist(Job, Step, "drl"))
            {
                Gen.PAUSE("drl Layer not exist. please check");
                return;
            }

            //多層板,建立inn,pin ,t1,v1
            if (LayerCount > 2)
            {
                if (!GenTools.Layer_IsExist(Job, workName, "inn"))
                    GenTools.Layer_Create("inn", "noard", GenTools.layerType["drill"]);
                if (!GenTools.Layer_IsExist(Job, workName, "pin"))
                    GenTools.Layer_Create("pin", "board", GenTools.layerType["drill"]);
            }

            if (!GenTools.Layer_IsExist(Job, workName, "v1"))
                GenTools.Layer_Create("v1", "misc", GenTools.layerType["doc"]);
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

            Add_Pin_pad(print_pin, ENUM_PIN_LYR.OUTTER);


            Add_L_Mark();


            Add_SM_CCD();

            foreach (string outlayer_ in layers.Outer)
            {
                Gen.COM($"affected_layer,name={outlayer_},mode=single,affected=yes");
            }

            //增加切片孔PAS
            Gen.COM("add_pad" +
                    ",attributes=no" +
                    $",x={min_x - 0.2},y={min_y + 2.55},symbol={sym.Pnl_Mic_N}" +
                    $",polarity=positive,angle=0,mirror=no,nx=1,ny=1,dx=0,dy=0" +
                    $",xscale=1,yscale=1");

            Gen.COM("add_pad" +
                    ",attributes=no" +
                    $",x={max_x + 0.2},y={max_y - 2.55},symbol={sym.Pnl_Mic_N}" +
                    $",polarity=positive,angle=0,mirror=no,nx=1,ny=1,dx=0,dy=0" +
                    $",xscale=1,yscale=1");
            GenTools.Clear_Layers();

            //增加 sm,ss,tent,via pin pad
            Add_Pin_pad(print_pin, ENUM_PIN_LYR.SMSSTENTVIA);

            //增加內層PIN PAD
            Add_Pin_pad(print_pin, ENUM_PIN_LYR.INNER);

            //增加drl gbx 0.125孔徑
            Add_Pin_pad(print_pin, ENUM_PIN_LYR.DRLINNGBX);


            //增加內層切片孔PAS
            foreach (string inner in layers.Inner)
            {
                Gen.COM($"affected_layer,name={inner},mode=single,affected=yes");
            }

            Gen.COM("add_pad" +
                    ",attributes=no" +
                    $",x={min_x - 0.2},y={min_y + 2.55},symbol={sym.Pnl_Mic_Inn}" +
                    $",polarity=positive,angle=0,mirror=no,nx=1,ny=1,dx=0,dy=0" +
                    $",xscale=1,yscale=1");

            Gen.COM("add_pad" +
                    ",attributes=no" +
                    $",x={max_x + 0.2},y={max_y - 2.55},symbol={sym.Pnl_Mic_Inn}" +
                    $",polarity=positive,angle=0,mirror=no,nx=1,ny=1,dx=0,dy=0" +
                    $",xscale=1,yscale=1");
            GenTools.Clear_Layers();

            Add_CCD_Fid_Pad();

            Add_PN_DC();

            Add_Layer_Frame();

            Add_Ten_Pad();

            Add_Tenting_Text();

            if (layers.Inner.Count > 0)
            {
                Add_Dount_Lyr_Reg();
            }

            if (layers.SignalLayers.Count > 6)
            {
                Add_Mount_Hole();
            }

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


        //-------------------------------以下為自訂函數--------------------------------------------------------//

        private static void Add_Mount_Hole()
        {
            double mnt_pad_x1 = min_x - 0.35;
            double mnt_pad_x2 = max_x + 0.35;
            double mnt_pad_x3 = (max_x + min_x) / 2 + 2.15;
            double mnt_pad_x4 = (max_x + min_x) / 2 - 1.85;
            double mnt_pad_y1 = (max_y - min_y) / 2 - 0.1;
            double mnt_pad_y2 = max_y - 0.9;
            double mnt_pad_y3 = min_y + 0.9;
            double mnt_pad_y4 = (max_y - min_y) / 2 - 0.6;
            double mnt_pad_y5 = min_y + 0.9;
            double mnt_pad_y6 = max_y + 0.35;
            double mnt_pad_y7 = min_y - 0.35;
            List<double> mnt_pad_list_x = new List<double>()
            {
                mnt_pad_x1, mnt_pad_x1,
                mnt_pad_x1, mnt_pad_x2,
                mnt_pad_x2, mnt_pad_x2,
                mnt_pad_x3, mnt_pad_x3,
                mnt_pad_x4, mnt_pad_x4,
            };
            List<double> mnt_pad_list_y = new List<double>()
            {
                mnt_pad_y1, mnt_pad_y2,
                mnt_pad_y3, mnt_pad_y4,
                mnt_pad_y2, mnt_pad_y5,
                mnt_pad_y6, mnt_pad_y7,
                mnt_pad_y6, mnt_pad_y7,
            };
            List<int> mnt_dr_ang_list = new List<int>()
            {
                0, 0,
                0, 180,
                180, 180,
                90, 270,
                90, 270,
            };
            foreach (string inner_ in layers.InnerList)
            {
                Gen.COM($"affected_layer,name={inner_},mode=single,affected=yes");
            }

            string sym_ = "";
            for (int i = 0; i < mnt_pad_list_x.Count; i++)
            {
                Gen.COM("add_pad" +
                        $",attributes=no,x={mnt_pad_list_x[i]},y={mnt_pad_list_y[i]}" +
                        $",symbol={sym.Pnl_Inn_Mnt},polarity=positive,angle=0,mirror=no" +
                        $",nx=1,ny=1,dx=0,dy=0,xscale=1,yscale=1");
                if (i == 0 || i == 3)
                {
                    sym_ = $"{sym.Pnl_Inn_Mnt_Dr2}";
                }
                else
                {
                    sym_ = $"{sym.Pnl_Inn_Mnt_Dr}";
                }

                Gen.COM("add_pad" +
                        $",attributes=no,x={mnt_pad_list_x[i]},y={mnt_pad_list_y[i]}" +
                        $",symbol={sym_},polarity=negative,angle={mnt_dr_ang_list[i]}" +
                        $",mirror=no,nx=1,ny=1,dx=0,dy=0,xscale=1,yscale=1");
            }

            GenTools.Clear_Layers();

            foreach (string outer_ in layers.Outer)
            {
                Gen.COM($"affected_layer,name={outer_},mode=single,affected=yes");
            }

            for (int i = 0; i < mnt_pad_list_x.Count; i++)
            {
                string sym_dr = "";
                if (i == 0 || i == 3)
                {
                    sym_dr = $"{sym.Pnl_Inn_Mnt_Dr2_N}";
                }
                else
                {
                    sym_dr = $"{sym.Pnl_Inn_Mnt_Dr_N}";
                }

                Gen.COM("add_pad" +
                        $",attributes=no,x={mnt_pad_list_x[i]},y={mnt_pad_list_y[i]}" +
                        $",symbol={sym_dr},polarity=negative,angle={mnt_dr_ang_list[i]}" +
                        $",mirror=no,nx=1,ny=1,dx=0,dy=0,xscale=1,yscale=1");
            }

            GenTools.Clear_Layers();
        }


        /// <summary>
        /// 層間對準甜甜圈Adds the dount lyr reg.
        /// </summary>
        private static void Add_Dount_Lyr_Reg()
        {
            double f_x = (Wix - max_x - min_x) / 2;
            double f_y = (Wix - max_x - min_x) / 2;
            double add_symbol_donut_x1 = GenTools.DoubleRound(min_x - f_x / 4);
            double add_symbol_donut_x2 = GenTools.DoubleRound(max_x + f_x / 4);
            double add_symbol_donut_y1 = GenTools.DoubleRound(min_y - f_y / 2 + 0.3);
            double add_symbol_donut_y2 = GenTools.DoubleRound(max_y + f_y / 2 - 0.3);

            //double add_symbol_donut_x1 = GenTools.DoubleRound(-frame_dist_x + frame_dist_x / 4);
            //double add_symbol_donut_x2 = GenTools.DoubleRound(Six + frame_dist_x / 4);
            //double add_symbol_donut_y1 = GenTools.DoubleRound(-frame_dist_y+ (frame_dist_y/2)  + 0.3);
            //double add_symbol_donut_y2 = GenTools.DoubleRound(Siy + frame_dist_y / 2 - 0.3);
            List<double> sym_dount_x = new List<double>()
            {
                add_symbol_donut_x1, add_symbol_donut_x1,
                add_symbol_donut_x2, add_symbol_donut_x2,
            };

            List<double> sym_dount_y = new List<double>()
            {
                add_symbol_donut_y1, add_symbol_donut_y2,
                add_symbol_donut_y1, add_symbol_donut_y2,
            };

            int d_num = 1;
            int symbol_donut_add = 0;
            int symbol_donut_width = 0;
            int symbol_donut_height = 0;
            List<string> symbol_dounut_list = new List<string>();

            foreach (string inner in layers.Inner)
            {
                symbol_donut_add = (d_num - 1) * 25;
                symbol_donut_width = 80 + symbol_donut_add;
                symbol_donut_height = 60 + symbol_donut_add;

                symbol_dounut_list.Add(
                    $"{symbol_donut_width}x{symbol_donut_height}");
                d_num++;
            }

            symbol_donut_width += 5;
            int symbol_outer = symbol_donut_width;
            symbol_donut_width += 15;
            int symbol_biggest = symbol_donut_width;

            for (int i = 0; i < layers.Inner.Count; i++)
            {
                Gen.COM($"affected_layer,name={layers.Inner[i]},mode=single,affected=yes");
                for (int j = 0; j < sym_dount_x.Count; j++)
                {
                    Gen.COM(("add_pad" +
                             $",attributes=no,x={sym_dount_x[j]},y={sym_dount_y[j]}" +
                             $",symbol=r{symbol_biggest},polarity=negative" +
                             $",angle=0,mirror=no,nx=1,ny=1,dx=0,dy=0,xscale=1,yscale=1"));
                    Gen.COM(("add_pad" +
                             $",attributes=no,x={sym_dount_x[j]},y={sym_dount_y[j]}" +
                             $",symbol=donut_r{symbol_dounut_list[i]},polarity=positive" +
                             $",angle=0,mirror=no,nx=1,ny=1,dx=0,dy=0,xscale=1,yscale=1"));
                }

                Gen.COM($"affected_layer,name={layers.Inner[i]},mode=single,affected=no");
            }

            //外層donut
            symbol_donut_width += 25;
            symbol_donut_height += 25;
            foreach (string outer in layers.Outer)
            {
                Gen.COM($"affected_layer,name={outer},mode=single,affected=yes");
            }

            if (layers.SignalEmpty.Count > 0)
            {
                foreach (string empty_lyr in layers.SignalEmpty)
                {
                    Gen.COM($"affected_layer,name={empty_lyr},mode=single,affected=yes");
                }
            }

            for (int i = 0; i < sym_dount_x.Count; i++)
            {
                Gen.COM(("add_pad" +
                         $",attributes=no,x={sym_dount_x[i]},y={sym_dount_y[i]}" +
                         $",symbol=r{symbol_outer},polarity=negative" +
                         $",angle=0,mirror=no,nx=1,ny=1,dx=0,dy=0,xscale=1,yscale=1"));
            }

            GenTools.Clear_Layers();
        }

        /// <summary>
        ///增加外層負片字樣 Adds the tenting text.
        /// </summary>
        private static void Add_Tenting_Text()
        {
            if (mainWindow.outter_neg.IsChecked == true)
            {
                double add_tenting_x = max_x + 0.35;
                double add_tenting_y = min_y + 4.4;
                int tnt_ang = 0;
                string tnt_mir = "no";
                if (layers.Outer.Count > 0)
                {
                    foreach (string outerLyr in layers.Outer)
                    {
                        Gen.COM($"affected_layer,name={outerLyr},mode=single,affected=yes");
                        if (layers.Full_Layer_Side[outerLyr] == "top")
                        {
                            tnt_ang = 0;
                            tnt_mir = "no";
                        }
                        else if (layers.Full_Layer_Side[outerLyr] == "bottom")
                        {
                            tnt_ang = 180;
                            tnt_mir = "yes";
                        }

                        Gen.COM("add_pad" +
                                $",attributes=no,x={add_tenting_x},y={add_tenting_y}" +
                                $",symbol={sym.Pnl_Tenting_Process},polarity=negative" +
                                $",angle={tnt_ang},mirror={tnt_mir},nx=1,ny=1,dx=0,dy=0,xscale=1,yscale=1");

                        Gen.COM($"affected_layer,name={outerLyr},mode=single,affected=no");
                    }
                }
            }
        }

        /// <summary>
        /// 增加層別顯示框 Adds the layer frame.
        /// </summary>
        private static void Add_Layer_Frame()
        {
            double layer_frame_x = max_x + 0.3; //層別框架X
            double layer_frame_y = GenTools.DoubleRound((max_y - min_y) / 2 + 0.585); //層別框架Y


            double text_size_x = 0.05; //層別名稱文字X大小
            double text_size_y = 0.09; //層別名稱文字Y大小
            int text_angle = 270; //層別名稱文字角度
            double text_space_x = 0.008;
            double text_w_factor = 0.8333; //層別名稱文字寬度因子

            double layer_name_text_x = layer_frame_x - 0.073728 + 0.05; //層別名稱文字X
            double layer_name_text_y = layer_frame_y + 0.0576 - 0.02; //層別名稱文字Y

            double step_y = 0.0;

            double frame_width = 0.1152;
            string text_mirr = "no";
            if (layers.Outer.Count > 0)
            {
                foreach (var outer in layers.Outer)
                {
                    Gen.COM($"affected_layer,name={outer},mode=single,affected=yes");

                    Gen.COM("add_pad" +
                            ",attributes=no" +
                            $",x={layer_frame_x},y={layer_frame_y}" +
                            $",symbol={sym.Pnl_Layer_Text_Frame}" +
                            $",polarity=positive,angle=0,mirror=no" +
                            $",nx=1,ny=1,dx=0,dy=0,xscale=1,yscale=1");
                    if (layers.Full_Layer_Side[outer] == "top")
                    {
                        text_mirr = "no"; //奇數層別文字不鏡像
                        text_angle = 270; //奇數層別文字角度
                        layer_name_text_y = layer_frame_y + 0.0576 - 0.03 - 0.006 + step_y;
                        Gen.COM("add_text" +
                                ",attributes=no,type=string" +
                                $",x={layer_name_text_x},y={layer_name_text_y}" +
                                $",text=TS,x_size={text_size_x},x_space={text_space_x},y_size={text_size_y}" +
                                $",w_factor={text_w_factor},,polarity=positive" +
                                $",angle={text_angle},mirror={text_mirr},fontname=standard,ver=1");
                        step_y += frame_width;
                    }
                    else if (layers.Full_Layer_Side[outer] == "bottom")
                    {
                        double tmp_step_y = ((layers.Outer.Count - 1) + layers.InnerList.Count) * frame_width;
                        tmp_step_y = GenTools.DoubleRound(tmp_step_y);
                        text_mirr = "yes"; //偶數層別文字鏡像
                        text_angle = 90; //偶數層別文字角度

                        double bot_layer_name_text_y = layer_frame_y + 0.0576 - 0.02; //層別名稱文字Y
                        bot_layer_name_text_y = layer_frame_y + 0.0576 - 0.03 + 0.07 + tmp_step_y;
                        Gen.COM("add_text" +
                                ",attributes=no,type=string" +
                                $",x={layer_name_text_x},y={bot_layer_name_text_y}" +
                                $",text=BS,x_size={text_size_x},x_space={text_space_x},y_size={text_size_y}" +
                                $",w_factor={text_w_factor},,polarity=positive" +
                                $",angle={text_angle},mirror={text_mirr},fontname=standard,ver=1");
                    }

                    Gen.COM($"affected_layer,name={outer},mode=single,affected=no");
                }
            }

            for (int i = 0; i < layers.InnerList.Count; i++)
            {
                if ((i + 1) % 2 == 1)
                {
                    text_mirr = "no"; //奇數層別文字不鏡像
                    text_angle = 270; //奇數層別文字角度
                }
                else
                {
                    text_mirr = "yes"; //偶數層別文字鏡像
                    text_angle = 90; //偶數層別文字角度
                }

                if (layers.InnerList[i].Contains("e")) continue; //忽略空曝層

                Gen.COM($"affected_layer,name={layers.InnerList[i]},mode=single,affected=yes");

                //增加層別框架
                Gen.COM("add_pad" +
                        ",attributes=no" +
                        $",x={layer_frame_x},y={layer_frame_y}" +
                        $",symbol={sym.Pnl_Layer_Text_Frame}" +
                        $",polarity=positive,angle=0,mirror=no" +
                        $",nx=1,ny=1,dx=0,dy=0,xscale=1,yscale=1");

                string lyrNum = Regex.Match(layers.InnerList[i], @"\d+").Value;
                if (int.Parse(lyrNum) > 9)
                {
                    if (text_mirr == "no")
                    {
                        step_y += 0.003;
                        layer_name_text_y = layer_frame_y + 0.0576 - 0.03 - 0.006 + step_y;
                    }
                    else
                    {
                        step_y += 0.003;
                        layer_name_text_y = layer_frame_y + 0.0576 - 0.03 + 0.055 + step_y;
                    }
                }
                else
                {
                    if (text_mirr == "no")
                    {
                        layer_name_text_y = layer_frame_y + 0.0576 - 0.018 + step_y;
                    }
                    else
                    {
                        layer_name_text_y = layer_frame_y + 0.0576 - 0.018 + 0.043 + step_y;
                    }
                }
                /*
                 * #10+
COM add_text,attributes=no,type=string,x=13.8503924213,y=10.0751897638
                ,text=00,x_size=0.05,x_space=0.008,y_size=0.09,w_factor=0.8333333135
                ,polarity=positive,angle=270,mirror=no,fontname=standard,ver=1
#1-9
COM add_text,attributes=no,type=string,x=13.8501105315,y=10.0937919291
                ,text=0,x_size=0.06,x_space=0.008,y_size=0.09,w_factor=0.8333333135
                ,polarity=positive,angle=270,mirror=no,fontname=standard,ver=1
#pad
COM add_pad,attributes=no,x=13.801538189,y=10.1156823819,symbol=lay-2
                ,polarity=positive,angle=0,mirror=no,nx=1,ny=1,dx=0,dy=0,xscale=1,yscale=1
                 */

                //增加層別名稱文字
                Gen.COM("add_text" +
                        ",attributes=no,type=string" +
                        $",x={layer_name_text_x},y={layer_name_text_y}" +
                        $",text={lyrNum},x_size={text_size_x},x_space={text_space_x},y_size={text_size_y}" +
                        $",w_factor={text_w_factor},,polarity=positive" +
                        $",angle={text_angle},mirror={text_mirr},fontname=standard,ver=1");

                step_y += frame_width;

                Gen.COM($"affected_layer,name={layers.InnerList[i]},mode=single,affected=no");
            }
        }

        /// <summary>
        ///板邊增加廠料 Adds the pn dc.
        /// </summary>
        private static void Add_PN_DC()
        {
            List<List<string>> LayerList = new List<List<string>>()
            {
                layers.Outer, layers.SolderMask, layers.SilkScreen, new List<string>() { "gbx", "v1", "t1" },
                layers.InnerList
            };
            for (int i = 0; i < LayerList.Count; i++)
            {
                double pn_dc_clearance_box_x = max_x + 0.215; //廠料內縮
                double pn_dc_clearance_box_y = min_y + 2.47; //廠料內縮

                double add_job_date_x = max_x + 0.25;
                double add_job_date_y = min_y + 2.1;

                double x_size = 0.09; //廠料字體大小
                double y_size = 0.09; //廠料字體大小
                double w_factor = 1.25; //廠料字體寬度因子
                //double text_loc_x = GenTools.DoubleRound(x_size / 2);
                //double text_loc_y = GenTools.DoubleRound(y_size / 2);

                double text_angle = 270; //廠料文字角度
                string mirror_text = "no"; //廠料文字鏡像

                List<string> text_lalyer = LayerList[i];

                switch (i)
                {
                    // 0: outer layer
                    case 0:
                        if (text_lalyer.Count > 0)
                        {
                            foreach (string outer in layers.Outer)
                            {
                                string lyr_text = "";
                                Gen.COM($"affected_layer,name={outer},mode=single,affected=yes");
                                if (layers.Full_Layer_Side[outer] == "top")
                                {
                                    text_angle = 270;
                                    mirror_text = "no"; //廠料文字鏡像
                                    add_job_date_y = min_y + 2.1;
                                    lyr_text = "$$JOB TOP $$DATE-MMDDYY";
                                }
                                else if (layers.Full_Layer_Side[outer] == "bottom")
                                {
                                    text_angle = 90;
                                    mirror_text = "yes"; //廠料文字鏡像
                                    lyr_text = "$$JOB BOT $$DATE-MMDDYY";
                                    double text_len = 23; //廠料文字長度
                                    text_len = GenTools.DoubleRound(text_len * 0.09);
                                    add_job_date_y = min_y + 1.985 + text_len;
                                }

                                Gen.COM("add_pad" +
                                        $",attributes=no,x={pn_dc_clearance_box_x},y={pn_dc_clearance_box_y + 0.7}" +
                                        $",symbol=rect189x2252,polarity={GenTools.POS_NEG["P"]},angle=0,mirror=no" +
                                        $",nx=1,ny=1,dx=0,dy=0,xscale=1,yscale=1");

                                Gen.COM("add_text" +
                                        ",attributes=no,type=string" +
                                        $",x={add_job_date_x},y={add_job_date_y}" +
                                        $",text={lyr_text},x_size={x_size},y_size={y_size}" +
                                        $",w_factor={w_factor}" +
                                        $",polarity={GenTools.POS_NEG["N"]}" +
                                        $",angle={text_angle},mirror={mirror_text},fontname=standard,ver=1");

                                Gen.COM($"affected_layer,name={outer},mode=single,affected=no");
                            }
                        }

                        break;
                    // 1: solder mask layer
                    case 1:
                        if (text_lalyer.Count > 0)
                        {
                            foreach (string sm in layers.SolderMask)
                            {
                                string lyr_text = "";
                                Gen.COM($"affected_layer,name={sm},mode=single,affected=yes");
                                if (layers.Full_Layer_Side[sm] == "top")
                                {
                                    text_angle = 270;
                                    mirror_text = "no"; //廠料文字鏡像
                                    add_job_date_y = min_y + 2.1;
                                    lyr_text = @"$$JOB TOP MASK $$DATE-MMDDYY";
                                }
                                else if (layers.Full_Layer_Side[sm] == "bottom")
                                {
                                    text_angle = 90;
                                    mirror_text = "yes"; //廠料文字鏡像
                                    lyr_text = @"$$JOB BOT MASK $$DATE-MMDDYY";
                                    double text_len = 23; //廠料文字長度
                                    text_len = GenTools.DoubleRound(text_len * 0.09);
                                    add_job_date_y = min_y + 2.435 + text_len;
                                }

                                Gen.COM("add_text" +
                                        ",attributes=no,type=string" +
                                        $",x={add_job_date_x},y={add_job_date_y}" +
                                        $",text={lyr_text},x_size={x_size},y_size={y_size}" +
                                        $",w_factor={w_factor}" +
                                        $",polarity={GenTools.POS_NEG["P"]}" +
                                        $",angle={text_angle},mirror={mirror_text},fontname=standard,ver=1");

                                Gen.COM($"affected_layer,name={sm},mode=single,affected=no");
                            }
                        }

                        break;
                    // 2: silk screen layer
                    case 2:
                        if (text_lalyer.Count > 0)
                        {
                            foreach (string ss in layers.SilkScreen)
                            {
                                string lyr_text = "";
                                Gen.COM($"affected_layer,name={ss},mode=single,affected=yes");
                                if (layers.Full_Layer_Side[ss] == "top")
                                {
                                    text_angle = 270;
                                    mirror_text = "no"; //廠料文字鏡像
                                    add_job_date_y = min_y + 2.1;
                                    lyr_text = @"$$JOB TOP SILK $$DATE-MMDDYY";
                                }
                                else if (layers.Full_Layer_Side[ss] == "bottom")
                                {
                                    text_angle = 90;
                                    mirror_text = "yes"; //廠料文字鏡像
                                    lyr_text = @"$$JOB BOT SILK $$DATE-MMDDYY";
                                    double text_len = 23; //廠料文字長度
                                    text_len = GenTools.DoubleRound(text_len * 0.09);
                                    add_job_date_y = min_y + 2.435 + text_len;
                                }

                                Gen.COM("add_text" +
                                        ",attributes=no,type=string" +
                                        $",x={add_job_date_x},y={add_job_date_y}" +
                                        $",text={lyr_text},x_size={x_size},y_size={y_size}" +
                                        $",w_factor={w_factor}" +
                                        $",polarity={GenTools.POS_NEG["P"]}" +
                                        $",angle={text_angle},mirror={mirror_text},fontname=standard,ver=1");

                                Gen.COM($"affected_layer,name={ss},mode=single,affected=no");
                            }
                        }

                        break;
                    // 3: gbx layer
                    case 3:
                    {
                        if (text_lalyer.Count > 0)
                        {
                            foreach (string gbx_v1_t1 in LayerList[3])
                            {
                                Gen.COM($"affected_layer,name={gbx_v1_t1},mode=single,affected=yes");
                                string lyr_text = "";

                                if (gbx_v1_t1 == "gbx")
                                {
                                    lyr_text = @"$$JOB PAD $$DATE-MMDDYY";
                                }
                                else if (gbx_v1_t1 == "v1" || gbx_v1_t1 == "t1")
                                {
                                    lyr_text = @"$$JOB VIA $$DATE-MMDDYY";
                                }

                                Gen.COM("add_text" +
                                        ",attributes=no,type=string" +
                                        $",x={add_job_date_x},y={add_job_date_y}" +
                                        $",text={lyr_text},x_size={x_size},y_size={y_size}" +
                                        $",w_factor={w_factor}" +
                                        $",polarity={GenTools.POS_NEG["P"]}" +
                                        $",angle={text_angle},mirror={mirror_text},fontname=standard,ver=1");

                                Gen.COM($"affected_layer,name={gbx_v1_t1},mode=single,affected=no");
                            }
                        }
                    }
                        break;
                    //TODO: HDI板需調整
                    // 4: inner layer
                    case 4:
                        if (text_lalyer.Count > 0)
                        {
                            //var dataGridRow = mainWindow.laminationParametersDataGrid.Items[0] as DataGridRow;
                            int lamCount = mainWindow.laminationParametersDataGrid.Items.Count; //獲取內層數量
                            if (lamCount == 1)
                            {
                                string lyr_text = "";
                                int lyr_count = 1;
                                for (int j = 0; j < layers.InnerList.Count; j++)
                                {
                                    Gen.COM($"affected_layer,name={layers.InnerList[j]},mode=single,affected=yes");
                                    add_job_date_x = max_x + 0.25;
                                    add_job_date_y = min_y + 1.4;
                                    lyr_count++;
                                    string lyrNum = Regex.Match(layers.InnerList[j], @"\d+").Value;
                                    if (layers.InnerList[j][0] == 'e')
                                    {
                                        lyr_text = $"$$JOB L{lyrNum}E $$DATE-MMDDYY";
                                    }
                                    else
                                    {
                                        lyr_text = $"$$JOB L{lyrNum} $$DATE-MMDDYY";
                                    }

                                    if (lyr_count % 2 == 0)
                                    {
                                        text_angle = 270;
                                        mirror_text = "no"; //廠料文字鏡像
                                    }
                                    else
                                    {
                                        text_angle = 90;
                                        mirror_text = "yes"; //廠料文字鏡像
                                        double text_len = 23; //廠料文字長度
                                        text_len = GenTools.DoubleRound(text_len * 0.09);
                                        add_job_date_y = min_y + 1.195 + text_len;
                                    }

                                    Gen.COM("add_pad" +
                                            $",attributes=no,x={pn_dc_clearance_box_x},y={pn_dc_clearance_box_y}" +
                                            $",symbol=rect189x2252,polarity=negative,angle=0,mirror=no" +
                                            $",nx=1,ny=1,dx=0,dy=0,xscale=1,yscale=1");
                                    Gen.COM("add_text" +
                                            ",attributes=no,type=string" +
                                            $",x={add_job_date_x},y={add_job_date_y}" +
                                            $",text={lyr_text},x_size={x_size},y_size={y_size}" +
                                            $",w_factor={w_factor}" +
                                            $",polarity={GenTools.POS_NEG["P"]}" +
                                            $",angle={text_angle},mirror={mirror_text},fontname=standard,ver=1");
                                    Gen.COM($"affected_layer,name={layers.InnerList[j]},mode=single,affected=no");
                                }
                            }
                        }


                        break;
                }
            }
        }

        /// <summary>
        /// 防焊CCD光學點PAD
        /// </summary>
        private static void Add_CCD_Fid_Pad()
        {
            List<int> sm_ccd_pad_ang = new List<int>() { 0, 180, 0, 180, 270, 270, 90, 90 };

            List<double> ccd_fid_pad_x = new List<double>()
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
            List<double> ccd_fid_pad_y = new List<double>()
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
            List<List<string>> out_sm_ccd_lyr = new List<List<string>>() { layers.Outer, layers.SolderMask };
            for (int i = 0; i < out_sm_ccd_lyr.Count; i++)
            {
                string ccd_sym = "";
                if (i == 0)
                {
                    if (out_sm_ccd_lyr[i].Count > 0)
                    {
                        ccd_sym = sym.Pnl_Ccd_Out_Fid;
                    }
                }
                else if (i == 1)
                {
                    if (out_sm_ccd_lyr[i].Count > 0)
                        ccd_sym = sym.Pnl_Ccd_Sm_Fid;
                }

                foreach (var workLyr in out_sm_ccd_lyr[i])
                {
                    Gen.COM($"affected_layer,name={workLyr},mode=single,affected=yes");
                }

                for (int j = 0; j < ccd_fid_pad_x.Count; j++)
                {
                    Gen.COM("add_pad" +
                            ",attributes=no" +
                            $",x={ccd_fid_pad_x[j]},y={ccd_fid_pad_y[j]}" +
                            $",symbol={ccd_sym}" +
                            $",polarity=positive,angle={sm_ccd_pad_ang[j]}" +
                            $",mirror=no,nx=1,ny=1,dx=0,dy=0,xscale=1,yscale=1");
                }

                foreach (var workLyr in out_sm_ccd_lyr[i])
                {
                    Gen.COM($"affected_layer,name={workLyr},mode=single,affected=no");
                }
            }
        }

        /// <summary>
        /// 增加C防焊CCD孔+pad
        /// </summary>
        private static void Add_SM_CCD()
        {
            if (layers.Outer.Count > 0)
            {
                foreach (string outer in layers.Outer)
                {
                    Gen.COM($"affected_layer,name={outer},mode=single,affected=yes");
                }

                //運算符重載
                Gen.COM($" add_pad" +
                        $",attributes=no" +
                        $",x={min_x - 0.2362},y={Panel_Center.CenterY - 4.9213}" +
                        $",symbol=r144,polarity={GenTools.POS_NEG["N"]}" +
                        $",angle=0,mirror=no,nx=1,ny=1,dx=0,dy=0,xscale=1,yscale=1");
                Gen.COM($" add_pad" +
                        $",attributes=no" +
                        $",x={min_x - 0.2362},y={Panel_Center.CenterY + 5.1181}" +
                        $",symbol=r144,polarity={GenTools.POS_NEG["N"]}" +
                        $",angle=0,mirror=no,nx=1,ny=1,dx=0,dy=0,xscale=1,yscale=1");
                GenTools.Clear_Layers();
            }

            string[] drlgbx = { "drl", "gbx" }; //程式一開始已經測試是否存在這兩個層別
            foreach (string dg in drlgbx)
            {
                Gen.COM($"affected_layer,name={dg},mode=single,affected=yes");
            }

            Gen.COM($" add_pad" +
                    $",attributes=no" +
                    $",x={min_x - 0.2362},y={Panel_Center.CenterY - 4.9213}" +
                    $",symbol=r125,polarity={GenTools.POS_NEG["P"]}" +
                    $",angle=0,mirror=no,nx=1,ny=1,dx=0,dy=0,xscale=1,yscale=1");
            Gen.COM($" add_pad" +
                    $",attributes=no" +
                    $",x={min_x - 0.2362},y={Panel_Center.CenterY + 5.1181}" +
                    $",symbol=r125,polarity={GenTools.POS_NEG["P"]}" +
                    $",angle=0,mirror=no,nx=1,ny=1,dx=0,dy=0,xscale=1,yscale=1");
            GenTools.Clear_Layers();
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
                GenTools.DoubleRound(Frame_x / 3),
                GenTools.DoubleRound(Frame_x / 3 * 2),
                GenTools.DoubleRound(Frame_x / 3),
                GenTools.DoubleRound(Frame_x / 3 * 2),
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
                GenTools.DoubleRound(Frame_y / 3),
                GenTools.DoubleRound(Frame_y / 3 * 2),
                GenTools.DoubleRound(Frame_y / 3),
                GenTools.DoubleRound(Frame_y / 3 * 2 + 0.5),
            };


            List<List<string>> ccd_fid_layers =
                new List<List<string>>() { layers.Outer, layers.SolderMask, layers.SilkScreen };

            List<string> padList = new List<string>()
            {
                sym.Pnl_Ten_Pad,
                sym.Pnl_Ten_Pad_Sm,
                sym.Pnl_Ten_Pad_Ss
            };
            for (int i = 0; i < ccd_fid_layers.Count; i++)
            {
                if (ccd_fid_layers[i].Count > 0)
                {
                    foreach (var ccd_fid_lyr in ccd_fid_layers[i])
                    {
                        Gen.COM($"affected_layer,name={ccd_fid_lyr},mode=single,affected=yes");
                    }

                    for (int j = 0; j < ten_sym_pad_x.Count; j++)
                    {
                        Gen.COM("add_pad" +
                                ",attributes=no" +
                                $",x={ten_sym_pad_x[j]},y={ten_sym_pad_y[j]}" +
                                $",symbol={padList[i]}" +
                                $",polarity=positive" +
                                $",angle=0" +
                                $",mirror=no" +
                                $",nx=1,ny=1,dx=0,dy=0,xscale=1,yscale=1 ");
                    }

                    GenTools.Clear_Layers();
                }
            }
        }

        /// <summary>
        ///  增加板角L型標記
        /// </summary>
        private static void Add_L_Mark()
        {
            List<int> angle = new List<int>() { 0, 90, 180, 270 };


            List<double> l_mark_x = new List<double>()
            {
                -0.02,
                -0.02,
                Frame_x + 0.02,
                Frame_x + 0.02,
            };

            List<double> l_mark_y = new List<double>()
            {
                -0.02,
                Frame_y + 0.02,
                Frame_y + 0.02,
                -0.02,
            };

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


            if (layers.Outer.Count > 0)
            {
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
            }


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
        private static void Add_Pin_pad(Tooling print_pin, ENUM_PIN_LYR out_inner_smsstentvia)
        {
            if (out_inner_smsstentvia == ENUM_PIN_LYR.OUTTER)
            {
                if (layers.Outer.Count > 0)
                {
                    //增加外框印刷PIN PAD
                    foreach (string outer in layers.Outer)
                    {
                        Gen.COM($"affected_layer,name={outer},mode=single,affected=yes");

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
                                        $",symbol={sym.Pnl_Out_Pin_Pad}" +
                                        $",polarity=positive" +
                                        $",angle=0,mirror=no" +
                                        $",nx=1,ny=1,dx=0,dy=0" +
                                        $",xscale=1,yscale=1");
                            }
                        }
                    }
                }
            }
            else if (out_inner_smsstentvia == ENUM_PIN_LYR.SMSSTENTVIA ||
                     out_inner_smsstentvia == ENUM_PIN_LYR.DRLINNGBX)
            {
                string sym_ = "";
                if (out_inner_smsstentvia == ENUM_PIN_LYR.SMSSTENTVIA)
                {
                    if (layers.SmsstentviaList.Count > 0)
                    {
                        foreach (string smsstentvia in layers.SmsstentviaList)
                        {
                            Gen.COM($"affected_layer,name={smsstentvia},mode=single,affected=yes");
                        }

                        sym_ = "donut_r180x150";
                    }
                }
                else if (out_inner_smsstentvia == ENUM_PIN_LYR.DRLINNGBX)
                {
                    string[] drlgbx = { "drl", "gbx" };
                    foreach (string dg in drlgbx)
                    {
                        Gen.COM($"affected_layer,name={dg},mode=single,affected=yes");
                    }

                    sym_ = "r125";
                }

                for (int i = 0; i < print_pin.PrintPinOuterX.Count; i++)
                {
                    Gen.COM("add_pad" +
                            ",attributes=no" +
                            $",x={print_pin.PrintPinOuterX[i]},y={print_pin.PrintPinOuterY[i]}" +
                            $",symbol={sym_}" +
                            $",polarity=positive" +
                            $",angle=0,mirror=no" +
                            $",nx=1,ny=1,dx=0,dy=0" +
                            $",xscale=1,yscale=1");
                }
            }
            else if (out_inner_smsstentvia == ENUM_PIN_LYR.INNER)
            {
                if (layers.Inner.Count > 0)
                {
                    foreach (string inner in layers.Inner)
                    {
                        Gen.COM($"affected_layer,name={inner},mode=single,affected=yes");
                    }

                    List<string> in_pad_sym = new List<string>()
                    {
                        sym.Pnl_Inn_Pin_Pad_N,
                        sym.Pnl_Inn_Pin_Pad_P,
                    };
                    for (int s = 0; s < in_pad_sym.Count; s++)
                    {
                        for (int i = 0; i < print_pin.PrintPinInnerX.Count; i++)
                        {
                            Gen.COM("add_pad" +
                                    ",attributes=no" +
                                    $",x={print_pin.PrintPinInnerX[i]},y={print_pin.PrintPinInnerY[i]}" +
                                    $",symbol={in_pad_sym[s]}" +
                                    $",polarity=positive" +
                                    $",angle=0,mirror=no" +
                                    $",nx=1,ny=1,dx=0,dy=0" +
                                    $",xscale=1,yscale=1");
                        }
                    }
                }

                GenTools.Clear_Layers();

                ////增加內層INN孔
                Gen.COM($"affected_layer,name=inn,mode=single,affected=yes");
                for (int i = 0; i < print_pin.PrintPinInnerX.Count; i++)
                {
                    Gen.COM("add_pad" +
                            ",attributes=no" +
                            $",x={print_pin.PrintPinInnerX[i]},y={print_pin.PrintPinInnerY[i]}" +
                            $",symbol=r125" +
                            $",polarity=positive" +
                            $",angle=0,mirror=no" +
                            $",nx=1,ny=1,dx=0,dy=0" +
                            $",xscale=1,yscale=1");
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
            else if (mainWindow.outter_neg.IsChecked == true) //負片流程
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

            if (isMultiLyr || isNegOuter)
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
                Gen.COM($"add_surf_poly_seg,x={-frame_dist_x - 0.2},y={frame_y + frame_dist_y + 0.2}");
                Gen.COM($"add_surf_poly_seg,x={frame_x + frame_dist_x + 0.2},y={frame_y + frame_dist_y + 0.2}");
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
                    Gen.COM($"affected_layer,name={ccd_fill},mode=single,affected=yes");
                    foreach (string layer in layers.Inner)
                    {
                        Gen.COM("sel_copy_other" +
                                $",dest=layer_name,target_layer={layer}" +
                                $",invert=no,dx=0,dy=0,size=0" +
                                $",x_anchor=0,y_anchor=0,rotation=0,mirror=none");
                    }

                    GenTools.Clear_Layers();
                }

                if (isNegOuter)
                {
                    Gen.COM($"affected_layer,name={ccd_fill},mode=single,affected=yes");
                    foreach (string layer in layers.Outer)
                    {
                        Gen.COM("sel_copy_other" +
                                $",dest=layer_name,target_layer={layer}" +
                                $",invert=no,dx=0,dy=0,size=0" +
                                $",x_anchor=0,y_anchor=0,rotation=0,mirror=none");
                    }

                    GenTools.Clear_Layers();
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

            double add_inner_copper_y3 = Frame_y - 3.6 - 3;
            double add_inner_copper_y32 = add_inner_copper_y3 - 0.5;
            double add_inner_copper_y33 = add_inner_copper_y3 - 0.5 + 0.24;
            double add_inner_copper_y34 = add_inner_copper_y3 + 0.24;

            double add_inner_copper_y4 = Frame_y - 3.6;
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