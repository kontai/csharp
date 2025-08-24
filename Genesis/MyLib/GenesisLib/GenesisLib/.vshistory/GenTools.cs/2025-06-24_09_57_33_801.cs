using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace GenesisLib
{
    public sealed class GenTools
    {
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


        //查找层 base_name=層屬性 , layer=容器, exp: "solder_mask" , "single_layer"
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
                    var baseType = Gen.GetInfo("gBASE_TYPE")[0];
                    // Check the base type and add to the corresponding list

                    switch (baseType)
                    {
                        case "signal":
                            // Check if the signal layer is empty
                            if (lyr.Contains("e"))
                            {
                                layers.SignalEmpty.Add(lyr);
                            }
                            else
                            {
                                layers.SignalTMP.Add(lyr);
                            }

                            break;
                        case "solder_mask":
                            layers.SolderMask.Add(lyr);
                            break;

                        case "silk_screen":
                            layers.SilkScreen.Add(lyr);
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

                    #region collection of signal layer

                    int signalCount = layers.SignalTMP.Count; // Count of signal layers
                    if (signalCount > 0)
                    {
                        layers.Outer.Add(layers.SignalTMP[0]);
                        if (signalCount > 1)
                        {
                            layers.Outer.Add(layers.SignalTMP[signalCount - 1]);
                            if (signalCount > 2)
                            {
                                for (int i = 1; i < signalCount - 1; i++)
                                {
                                    layers.Inner.Add(layers.SignalTMP[i]);
                                }
                            }
                        }
                    }

                    #endregion
                }
            }

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