using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace GenesisLib
{
    public sealed class GenTools
    {
        public static string GEN_DIR =>
            System.Environment.GetEnvironmentVariable("GENESIS_DIR") ??
            Environment.GetEnvironmentVariable("EZCAM_DIR);");

        /// <summary>
        /// The layer type
        /// key:sig, sm, ss, drl, pwr_gnd, sp, rout, doc
        /// </summary>
        public readonly static Dictionary<string, string> layerType = new Dictionary<string, string>()
        {
            { "sig", "signal" },
            { "sm", "solder_mask" },
            { "ss", "silk_screen" },
            { "drill", "drill" },
            { "pwr_gnd", "power_ground" },
            { "sp", "solder_paste" },
            { "rout", "rout" },
            { "doc", "document" }
        };

        /// <summary>
        /// P: positive N:negative
        /// </summary>
        public readonly static Dictionary<string, string> POS_NEG = new Dictionary<string, string>()
        {
            { "P", "positive" }, { "N", "negative" }
        };

        public static string CONTOURIZE = @"sel_contourize,accuracy=0.25,break_to_islands=yes,clean_hole_size=3,
clean_hole_mode=x_and_y,validate_result=no";
        //param1: target_layer, param2: invert, param3: resize
        //        public static string COPY_LAYER = @"sel_copy_other,dest=layer_name,target_layer={0},invert={1},
        //dx=0,dy=0,size={2},x_anchor=0,y_anchor=0,rotation=0,mirror=none";

        //清除所有图层
        public static void Clear_Layers()
        {
            Gen.COM("clear_layers");
            Gen.COM("affected_layer,mode=all,affected=no");
            Gen.COM("filter_reset, filter_name = popup");
        }

        public static bool Layer_IsExist(string job, string step, string layer)
        {
            Gen.INFO($"-t layer -e {job}/{step}/{layer} -d EXISTS -m script,units=inch");
            return Gen.GetInfo("gEXISTS")[0] == "yes" ? true : false;
        }

        public static void Layer_Create(string layer, string context, string type) =>
            Gen.COM(
                $"create_layer,layer={layer},context={context},type={type},polarity=positive,ins_layer=,location=before");


        public static void Layer_Pattern_Fill(
            List<string> layers,
            double step_mg_x, double step_mg_y, //下料邊往的銅
            double step_max_dist_x, double step_max_dist_y, //下料邊往內鋪銅最大距離
            double sr_mg_x, double sr_mg_y, //sr往外的的內縮銅箔距離
            double sr_max_dist_x = 0f, double sr_max_dist_y = 0f) //限制sr margin往外鋪銅最大距離(0=不限制)
        {
            if (layers != null && layers.Count > 0)
            {
                foreach (var layer in layers)
                {
                    Gen.COM($"affected_layer,name={layer},mode=single,affected=yes");
                }

                Gen.COM($"sr_fill,polarity=positive," +
                        $"step_margin_x={step_mg_x}" +
                        $",step_margin_y={step_mg_y}" +
                        $",step_max_dist_x={step_max_dist_x}" +
                        $",step_max_dist_y={step_max_dist_y}" +
                        $",sr_margin_x={sr_mg_x}" +
                        $",sr_margin_y={sr_mg_y}" +
                        $",sr_max_dist_x={sr_max_dist_x}" +
                        $",sr_max_dist_y={sr_max_dist_y}" +
                        ",nest_sr=no,consider_feat=no,consider_drill=no,consider_rout=no,dest=affected_layers,attributes=no");

                Clear_Layers();
            }
        }

        public static double DoubleRound(double num) => Math.Round(num, 6);

        public static void Layer_Pattern_Fil_Singlel(
            string layer,
            double step_mg_x, double step_mg_y, //下料邊往的銅
            double step_max_dist_x, double step_max_dist_y, //下料邊往內鋪銅最大距離
            double sr_mg_x, double sr_mg_y, //sr往外的的內縮銅箔距離
            double sr_max_dist_x = 0f, double sr_max_dist_y = 0f) //限制sr margin往外鋪銅最大距離(0=不限制)
        {
            if (layer != null)
            {
                Gen.COM($"affected_layer,name={layer},mode=single,affected=yes");

                Gen.COM($"sr_fill,polarity=positive," +
                        $"step_margin_x={step_mg_x}" +
                        $",step_margin_y={step_mg_y}" +
                        $",step_max_dist_x={step_max_dist_x}" +
                        $",step_max_dist_y={step_max_dist_y}" +
                        $",sr_margin_x={sr_mg_x}" +
                        $",sr_margin_y={sr_mg_y}" +
                        $",sr_max_dist_x={sr_max_dist_x}" +
                        $",sr_max_dist_y={sr_max_dist_y}" +
                        $"nest_sr=no,consider_feat=no,consider_drill=no,consider_rout=no,dest=affected_layers,attributes=no");

                Clear_Layers();
            }
        }

        public static void Add_CCD_Frame(double CenterX, double CenterY, string mySym)
        {
            Gen.COM("add_pad" +
                    $",attributes=no,x={CenterX},y={CenterY}" +
                    $",symbol={mySym}" +
                    $",polarity={GenTools.POS_NEG["P"]},angle=0" +
                    ",mirror=no,nx=1,ny=1,dx=0,dy=0" +
                    ",xscale=1,yscale=1");
            Clear_Layers();
        }

        //查找层 base_name=層屬性 , layer=容器, exp: "solder_mask" , "signal"
        public static void Find_Layer(string job, string step, string base_name, List<string> layer)
        {
            Gen.INFO($"-t step -e {job}/{step} -m script -d LAYERS_LIST");

            //info layer list
            foreach (var lyr in Gen.GetInfo("gLAYERS_LIST"))
            {
                Gen.INFO($"-t layer -e {job}/{step}/{lyr} -m script -d BASE_TYPE");
                //info base type
                var baseType = Gen.GetInfo("gBASE_TYPE")[0];

                if (baseType == base_name)
                {
                    //if soldermask layer and board context then add to soldermask layer list
                    Gen.INFO($"-t layer -e {job}/{step}/{lyr} -m script -d CONTEXT");
                    if (Gen.GetInfo("gCONTEXT")[0] == "board")
                        layer.Add(lyr);
                }
            }
        }

        public static void Add_Line(string xs, string ys, string xe, string ye, string polarity)
        {
            Gen.COM($"add_line,attributes=no,xs={xs},ys={ys},xe={xe},ye={ye}" +
                    $",symbol=r200,polarity={polarity}" +
                    ",bus_num_lines=0,bus_dist_by=pitch,bus_distance=0,bus_reference=left");
        }

        public static void Add_Rec_Line(Point p, string polarity)
        {
            Gen.COM($"add_line,attributes=no,xs={p.XMin},ys={p.YMin},xe={p.XMin},ye={p.YMax}" +
                    $",symbol=r200,polarity={polarity}" +
                    ",bus_num_lines=0,bus_dist_by=pitch,bus_distance=0,bus_reference=left");
            Gen.COM($"add_line,attributes=no,xs={p.XMin},ys={p.YMax},xe={p.XMax},ye={p.YMax}" +
                    $",symbol=r200,polarity={polarity}" +
                    ",bus_num_lines=0,bus_dist_by=pitch,bus_distance=0,bus_reference=left");

            Gen.COM($"add_line,attributes=no,xs={p.XMax},ys={p.YMax},xe={p.XMax},ye={p.YMin}" +
                    $",symbol=r200,polarity={polarity}" +
                    ",bus_num_lines=0,bus_dist_by=pitch,bus_distance=0,bus_reference=left");

            Gen.COM($"add_line,attributes=no,xs={p.XMax},ys={p.YMin},xe={p.XMin},ye={p.YMin}" +
                    $",symbol=r200,polarity={polarity}" +
                    ",bus_num_lines=0,bus_dist_by=pitch,bus_distance=0,bus_reference=left");
        }

        public static LayerCollection FindAllLayers(string job, string step)
        {
            var layers = new LayerCollection();

            Gen.INFO($"-t step -e {job}/{step} -m script -d LAYERS_LIST");

            foreach (var lyr in Gen.GetInfo("gLAYERS_LIST"))
            {
                Gen.INFO($"-t layer -e {job}/{step}/{lyr} -m script -d CONTEXT");

                // Check if the context is 'board'
                if (Gen.GetInfo("gCONTEXT")[0] == "board")
                {
                    Gen.INFO($"-t layer -e {job}/{step}/{lyr} -m script -d BASE_TYPE");
                    string baseType = Gen.GetInfo("gBASE_TYPE")[0];
                    // Check the base type and add to the corresponding list

                    Gen.INFO($"-t layer -e {job}/{step}/{lyr} -m script -d SIDE");
                    string lyrSide = Gen.GetInfo("gSIDE")[0];

                    switch (baseType)
                    {
                        case "signal":
                        case "mixed":
                        case "power_ground":
                            // Check if the signal layer is empty
                            if (lyr.Contains("e"))
                            {
                                layers.SignalEmpty.Add(lyr);
                            }
                            else
                            {
                                layers.SignalLayers.Add(lyr);
                            }

                            layers.InnerList.Add(lyr);
                            layers.Full_Layer_Side.Add(lyr, lyrSide);
                            break;
                        case "solder_mask":
                            layers.SolderMask.Add(lyr);
                            layers.SmsstentviaList.Add(lyr);
                            layers.Full_Layer_Side.Add(lyr, lyrSide);
                            break;

                        case "silk_screen":
                            layers.SilkScreen.Add(lyr);
                            layers.SmsstentviaList.Add(lyr);
                            layers.Full_Layer_Side.Add(lyr, lyrSide);
                            break;
                        case "drill":

                            if (lyr.Contains("-") || lyr.Contains("_"))
                            {
                                layers.BlindDrill.Add(lyr);
                            }
                            else
                            {
                                layers.Drill.Add(lyr);
                            }

                            break;
                    }
                }
            }

            layers.SmsstentviaList.Add("v1");
            layers.SmsstentviaList.Add("t1");

            #region collection of signal layer

            layers.InnerList.RemoveAt(0);
            layers.InnerList.RemoveAt(layers.InnerList.Count - 1);

            int signalCount = layers.SignalLayers.Count;
            if (signalCount > 0)
            {
                try
                {
                    // 添加第一層作為外層
                    layers.Outer.Add(layers.SignalLayers[0]);

                    if (signalCount > 1)
                    {
                        // 添加最後一層作為外層
                        layers.Outer.Add(layers.SignalLayers[signalCount - 1]);

                        // 如果有內層（超過2層），則添加中間的層作為內層
                        if (signalCount > 2)
                        {
                            layers.Inner.AddRange(layers.SignalLayers.GetRange(1, signalCount - 2));
                        }
                    }
                }
                catch (Exception ex)
                {
                    // 適當的錯誤處理
                    throw new InvalidOperationException("處理信號層時發生錯誤", ex);
                }
            }

            #endregion

            return layers;
        }


        public static void FindAllLayers(string job,
            string step,
            out List<string> outer,
            out List<string> signalEmpty,
            out List<string> inner,
            out List<string> sm,
            out List<string> ss,
            out List<string> drill,
            out List<string> blind_drill
        )
        {
            //intialize all collection
            outer = new List<string>();
            signalEmpty = new List<string>();
            inner = new List<string>();
            sm = new List<string>();
            ss = new List<string>();
            drill = new List<string>();
            blind_drill = new List<string>();

            List<string> signalTMP = new List<string>();
            Gen.INFO($"-t step -e {job}/{step} -m script -d LAYERS_LIST");

            //info layer list
            foreach (var lyr in Gen.GetInfo("gLAYERS_LIST"))
            {
                Gen.INFO($"-t layer -e {job}/{step}/{lyr} -m script -d CONTEXT");
                if (Gen.GetInfo("gCONTEXT")[0] == "board")
                {
                    Gen.INFO($"-t layer -e {job}/{step}/{lyr} -m script -d BASE_TYPE");
                    //info base type
                    var baseType = Gen.GetInfo("gBASE_TYPE")[0];
                    // Check the base type and add to the corresponding list

                    switch (baseType)
                    {
                        case "signal":
                        case "mixed":
                        case "power_ground":
                            //if soldermask layer and board context then add to soldermask layer list

                            // Check if the signal layer is empty
                            if (lyr.Contains("e"))
                            {
                                signalEmpty.Add(lyr);
                                break;
                            }

                            // If the signal layer is not empty, add it to the signalEmpty list
                            signalTMP.Add(lyr);
                            break;

                        case "solder_mask":
                            sm.Add(lyr);
                            break;

                        case "silk_screen":
                            ss.Add(lyr);
                            break;

                        case "drill":
                            //if drill name contains "-"  or "_" then add to drill
                            if (lyr.Contains("-") || lyr.Contains("_"))
                            {
                                blind_drill.Add(lyr);
                            }
                            else
                            {
                                drill.Add(lyr);
                            }

                            break;
                    }
                }

                #region collection of signal layer

                int signalCount = signalTMP.Count; // Count of signal layers
                if (signalCount > 0)
                {
                    outer.Add(signalTMP[0]);
                    if (signalCount > 1)
                    {
                        outer.Add(signalTMP[signalCount - 1]);
                        if (signalCount > 2)
                        {
                            for (int i = 1; i < signalCount - 1; i++)
                            {
                                inner.Add(signalTMP[i]);
                            }
                        }
                    }
                }

                #endregion
            }
        }
    }
}