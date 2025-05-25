using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace GenesisInterface
{
    class Program
    {
        public void tomb_stone( double trim_size,double ts_size)
        {
            #region Initialization

            string job = Gen.JOB;
            string step = Gen.STEP;
            if (step != null && job != null)
            {
                Console.WriteLine($"\n** JOB: {job} **\n** STEP:{step} **");
            }
            else
            {
                Gen.PAUSE("must choose a step");
                return;
            }

            #endregion


            Gen.INFO("-t root -m script -d JOBS_LIST");

            //JOBS_LIST
            List<string> jobList = new List<string>();

            foreach (var se in Gen.GetInfo("gJOBS_LIST"))
            {
                jobList.Add(se);
            }

            //刮除多少on 1pad防焊
            //const double trim_size = 2;
            //墓碑大小
            //const double ts_size = 1;
            //layer list
            List<string> layerList = new List<string>();
            //soldermask layer
            List<string> soldermaskLayer = new List<string>();
            List<string> signalLayer = new List<string>();

            Gen.INFO($"-t step -e {job}/{step} -m script -d LAYERS_LIST");

            //info layer list
            foreach (var lyr in Gen.GetInfo("gLAYERS_LIST"))
            {
                Gen.INFO($"-t layer -e {job}/{step}/{lyr} -m script -d BASE_TYPE");
                //info base type
                foreach (var baseType in Gen.GetInfo("gBASE_TYPE"))
                {
                    //find soldermask layer
                    if (baseType == "solder_mask")
                    {
                        //if soldermask layer and board context then add to soldermask layer list
                        Gen.INFO($"-t layer -e {job}/{step}/{lyr} -m script -d CONTEXT");
                        if (Gen.GetInfo("gCONTEXT")[0] == "board")
                            soldermaskLayer.Add(lyr);
                    }
                    //find signal layer
                    else if (baseType == "signal")
                    {
                        Gen.INFO($"-t layer -e {job}/{step}/{lyr} -m script -d CONTEXT");
                        if (Gen.GetInfo("gCONTEXT")[0] == "board")
                            signalLayer.Add(lyr);
                    }
                }
            }


            //將外層加入
            List<string> outlayer = new List<string>();
            outlayer.Add(signalLayer.First());
            outlayer.Add(signalLayer.Last());

            //close all layers

            int count = 0;
            foreach (var lyr in soldermaskLayer)
            {
                GenTools.Clear_Layers();
                Gen.COM("filter_reset,filter_name=popup");

                count++;
                //防焊層備份
                string bak_lyr = $"{lyr}_bak";
                Gen.INFO($"-t layer -e {job}/{step}/{bak_lyr} -m script -d EXISTS");
                if (Gen.GetInfo("gEXISTS").First() == "yes")
                {
                    Gen.COM($"delete_layer,layer={bak_lyr}");
                }

                //工作外層pad 1:1備份
                string out_lyr_pad = "";

                //產生tombstone層
                string tomb_lyr = $"{lyr}_tomb_lyr{count}";

                //創建一個新的pad層,存放外層pad
                if (count == 1)
                    out_lyr_pad = outlayer.First() + "_workpad";
                else
                {
                    out_lyr_pad = outlayer.Last() + "_workpad";
                }

                //墓碑層,以現有防焊工作層為基礎
                string tombstone = $"{bak_lyr}_tomb{count}";
                Gen.INFO($"-t layer -e {job}/{step}/{tombstone} -m script -d EXISTS");
                if (Gen.GetInfo("gEXISTS").First() == "yes")
                {
                    Gen.COM($"delete_layer,layer={tombstone}");
                }

                //存在則刪除
                Gen.INFO($"-t layer -e {job}/{step}/{out_lyr_pad} -m script -d EXISTS");
                if (Gen.GetInfo("gEXISTS").First() == "yes")
                {
                    Gen.COM($"delete_layer,layer={out_lyr_pad}");
                }


                //重置filter
                Gen.COM("filter_reset,filter_name=popup");

                //先備份,如果有舊的備份,先刪除

                Gen.COM($"affected_layer,name={lyr},mode=single,affected=yes");
                Gen.COM(@"sel_copy_other,dest=layer_name,target_layer=" + bak_lyr + @",invert=no,
                dx=0,dy=0,size=0,x_anchor=0,y_anchor=0,rotation=0,mirror=none");

                //將pad選取
                Gen.COM("filter_set,filter_name=popup,update_popup=no,polarity=positive,feat_types=pad");
                Gen.COM("filter_area_strt");
                Gen.COM(@"filter_area_end,layer=,filter_name=popup,operation=select, 
                    area_type=none,inside_area=no,intersect_area=no");


                //將防焊正pad複製到tmp層(沒有削的)
                Gen.COM(@"sel_copy_other,dest=layer_name,target_layer=" + tomb_lyr + @",invert=no,
                dx=0,dy=0,size=1.5,x_anchor=0,y_anchor=0,rotation=0,mirror=none");

                GenTools.Clear_Layers();

                Gen.COM($"affected_layer,name={bak_lyr},mode=single,affected=yes");
                Gen.COM($"sel_copy_other,dest=layer_name,target_layer={tombstone}," +
                        "invert=no,dx=0,dy=0,size=0,x_anchor=0,y_anchor=0,rotation=0,mirror=none");

                GenTools.Clear_Layers();
                Gen.COM($"affected_layer,name={tombstone},mode=single,affected=yes");
                Gen.COM(GenTools.CONTOURIZE);
                GenTools.Clear_Layers();

                //選擇外層
                if (count == 1)
                    Gen.COM($"affected_layer,name={outlayer.First()},mode=single,affected=yes");
                else
                    Gen.COM($"affected_layer,name={outlayer.Last()},mode=single,affected=yes");

                Gen.COM("filter_reset,filter_name=popup");
                Gen.COM("filter_set,filter_name=popup,update_popup=no,feat_types=pad");

                //過濾被防焊覆蓋的外層pad
                Gen.COM($"sel_ref_feat,layers={tomb_lyr},use=filter,mode=cover,pads_as=shape," +
                        "f_types=pad,polarity=positive,include_syms=,exclude_syms=,on_multiple=all");


                //複製到備份層 out_lyr_pad=1:1 pad
                Gen.COM($"sel_copy_other,dest=layer_name,target_layer={out_lyr_pad}," +
                        "invert=no,dx=0,dy=0,size=0,x_anchor=0,y_anchor=0,rotation=0,mirror=none");


                //存放防焊接觸的導體
                string touch_sm_obj = $"{out_lyr_pad}__2_{count}";

                Gen.INFO($"-t layer -e {job}/{step}/{touch_sm_obj} -m script -d EXISTS");
                if (Gen.GetInfo("gEXISTS").First() == "yes")
                {
                    Gen.COM($"delete_layer,layer={touch_sm_obj}");
                }

                //選取防焊覆蓋的導體
                Gen.COM("filter_reset,filter_name=popup");
                Gen.COM(@"filter_set,filter_name=popup,update_popup=no,polarity=positive,
                        feat_types=line\;surface\;arc\;text");
                Gen.COM($"sel_ref_feat,layers={tomb_lyr},use=filter,mode=touch,pads_as=shape," +
                        "f_types=pad,polarity=positive,include_syms=,exclude_syms=,on_multiple=all");
                Gen.COM(@"sel_copy_other,dest=layer_name,target_layer=" + touch_sm_obj + @",invert=no,
                dx=0,dy=0,size=0,x_anchor=0,y_anchor=0,rotation=0,mirror=none");

                GenTools.Clear_Layers();
                Gen.COM($"affected_layer,name={touch_sm_obj},mode=single,affected=yes");
                //Gen.COM(GenTools.CONTOURIZE);

                //複製到墓碑防焊層,削除
                Gen.COM($"sel_copy_other,dest=layer_name,target_layer={tombstone},invert=yes," +
                        $"dx=0,dy=0,size={trim_size},x_anchor=0,y_anchor=0,rotation=0,mirror=none");
                Gen.COM($"delete_layer,layer={touch_sm_obj}");


                GenTools.Clear_Layers();
                Gen.COM($"affected_layer,name={tombstone},mode=single,affected=yes");
                Gen.COM(GenTools.CONTOURIZE);

                //Gen.PAUSE("wait");
                GenTools.Clear_Layers();
                //將1:1 pad加大 ts_size(防焊位於導體上的大小) 並複製到墓碑防焊層
                Gen.COM($"affected_layer,name={out_lyr_pad},mode=single,affected=yes");
                Gen.COM($"sel_copy_other,dest=layer_name,target_layer={tombstone}," +
                        $"invert=no,dx=0,dy=0,size={ts_size},x_anchor=0,y_anchor=0,rotation=0,mirror=none");

                //表面化
                GenTools.Clear_Layers();
                Gen.COM($"affected_layer,name={tombstone},mode=single,affected=yes");
                Gen.COM(GenTools.CONTOURIZE);

                //如果導體比pad大,削完也許會有間隙;整體放大,填充間隙
                Gen.COM($"sel_resize,size=2,corner_ctl=no");
                //表面化
                Gen.COM(GenTools.CONTOURIZE);
                //縮小回原大小
                Gen.COM($"sel_resize,size=-2,corner_ctl=no");
                //美化-圓角
                Gen.COM(@"fill_params,type=solid,origin_type=datum,solid_type=fill,
                    std_type=line,min_brush=" + 2 + @",use_arcs=yes,symbol=,dx=0.1,dy=0.1,
                    x_off=0,y_off=0,std_angle=45,std_line_width=10,std_step_dist=50,
                    std_indent=odd,break_partial=yes,cut_prims=no,outline_draw=no,
                    outline_width=0,outline_invert=no");
                Gen.COM("sel_fill");
                Gen.COM(GenTools.CONTOURIZE);


                //刪除細小的銅
                Gen.COM("filter_reset,filter_name=popup");
                Gen.COM(@"filter_set,filter_name=popup,update_popup=no,polarity=positive,
                        feat_types=line\;surface\;arc\;text");
                Gen.COM($"sel_ref_feat,layers={out_lyr_pad},use=filter,mode=disjoint,pads_as=shape," +
                        "f_types=pad,polarity=positive,include_syms=,exclude_syms=,on_multiple=all");
                Gen.COM("sel_delete");

                GenTools.Clear_Layers();

                string tombstone_bak = $"{bak_lyr}_tomb{count}2";
                Gen.INFO($"-t layer -e {job}/{step}/{tombstone_bak} -m script -d EXISTS");
                if (Gen.GetInfo("gEXISTS").First() == "yes")
                {
                    Gen.COM($"delete_layer,layer={tombstone_bak}");
                }

                Gen.COM($"affected_layer,name={bak_lyr},mode=single,affected=yes");
                Gen.COM($"sel_copy_other,dest=layer_name,target_layer={tombstone_bak}," +
                        "invert=no,dx=0,dy=0,size=0,x_anchor=0,y_anchor=0,rotation=0,mirror=none");

                GenTools.Clear_Layers();
                Gen.COM($"affected_layer,name={tombstone_bak},mode=single,affected=yes");
                Gen.COM(GenTools.CONTOURIZE);

                //把沒有需要作的部分刪除
                Gen.COM("filter_reset,filter_name=popup");
                Gen.COM(@"filter_set,filter_name=popup,update_popup=no,polarity=positive,
                        feat_types=line\;pad\;surface\;arc\;text");
                Gen.COM($"sel_ref_feat,layers={tombstone},use=filter,mode=disjoint,pads_as=shape," +
                        "f_types=surface,polarity=positive,include_syms=,exclude_syms=,on_multiple=all");
                Gen.COM("sel_delete");

                Gen.COM("sel_resize,size=2,corner_ctl=no");

                GenTools.Clear_Layers();
                Gen.COM($"affected_layer,name={tombstone},mode=single,affected=yes");
                Gen.COM($"sel_copy_other,dest=layer_name,target_layer={tombstone_bak}," +
                        "invert=yes,dx=0,dy=0,size=0,x_anchor=0,y_anchor=0,rotation=0,mirror=none");

                GenTools.Clear_Layers();
                Gen.COM($"affected_layer,name={tombstone_bak},mode=single,affected=yes");
                Gen.COM(GenTools.CONTOURIZE);
                Gen.COM("sel_resize,size=-2,corner_ctl=no");
                Gen.COM("sel_resize,size=2,corner_ctl=no");
                Gen.COM(@"fill_params,type=solid,origin_type=datum,solid_type=fill,
                        std_type=line,min_brush= 2,use_arcs=yes,symbol=,dx=0.1,dy=0.1,
                        x_off=0,y_off=0,std_angle=45,std_line_width=10,std_step_dist=50,
                        std_indent=odd,break_partial=yes,cut_prims=no,outline_draw=no,
                        outline_width=0,outline_invert=no");
                Gen.COM("sel_fill");
                Gen.COM(GenTools.CONTOURIZE);


                //將tmp層刪除
                Gen.COM($"delete_layer,layer={tombstone}");
                Gen.COM($"delete_layer,layer={out_lyr_pad}");
                Gen.COM($"delete_layer,layer={tomb_lyr}");

                GenTools.Clear_Layers();
                //重置filter
                Gen.COM("filter_reset,filter_name=popup");
            }
        }
    }
}