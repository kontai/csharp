using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace GenesisInterface
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
                foreach (var baseType in Gen.GetInfo("gBASE_TYPE"))
                {
                    if (baseType == base_name)
                    {
                        //if soldermask layer and board context then add to soldermask layer list
                        Gen.INFO($"-t layer -e {job}/{step}/{lyr} -m script -d CONTEXT");
                        if (Gen.GetInfo("gCONTEXT")[0] == "board")
                            layer.Add(lyr);
                    }
                }
            }
        }
    }
}