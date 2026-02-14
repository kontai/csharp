using System.Collections.Generic;
using System.Windows.Documents;

namespace Panel_Script
{
    /// <summary>
    /// <para>
    /// pnl_ccd_out_fid: 外層CCD 光學點
    /// </para>
    /// <para>
    /// pnl_ccd_sm_fid: 防焊CCD 光學點PAD
    /// </para>
    /// <para>
    ///  pnl_out_pin_pad: 外層PIN PAD
    /// </para>
    /// <para>
    ///  pnl_inn_pin_pad_n: 內層PIN PAD
    /// </para>
    /// <para>
    /// pnl_pin_ccd_pad_n: 負片CCDPAD
    /// </para>
    ///
    /// <para>
    /// pnl_ccd_frame_n: 負片CCD框
    /// </para>
    /// <para>
    ///    pnl_ccd_frame_p: 正片CCD框
    /// </para>
    /// <para>
    ///   pnl_ccd_inner_frame_1: 正片CCD內框1
    /// </para>
    /// <para>
    ///   pnl_ccd_inner_frame_2: 正片CCD內框2
    /// </para>
    /// <para>
    /// pnl_ten_pad: 外層十字PAD
    /// </para>
    /// <para>
    /// pan_l_mark: L Mark
    /// </para>
    /// <para>
    /// pan_l_mark_n: L Mark Negative
    /// </para>
    /// <para>
    /// pan_mic_n: 外層切片孔
    /// </para>
    /// <para>
    /// pan_mic_inn: 內層切片孔
    /// </para>
    /// <para>
    /// pnl_layer_text_frame: 層別顯示框架
    /// </para>
    /// <para>
    /// pnl_tenting_process: tenting 負片流程
    /// </para>
    /// <para>
    /// <para>
    /// pnl_inn_mnt: 內層鉚釘孔clearance</para>
    /// inn-pin: 內層靶孔</para>
    /// <para>
    /// pnl_inn_mnt_dr: 外層祭氣孔clearance</para>
    /// inn-pin: 內層靶孔
    /// </para>
    /// <para>
    /// pnl_tag: 靶孔PAD
    /// </para>
    /// <para>
    /// pnl_inn_pad: inn pad
    /// </para>
    /// <para>
    /// pnl_min_dam: 最小下墨間距
    /// </para>
    /// <para>
    /// C/S面負片擋點片
    /// </para>
    /// <para>
    /// pnl_tent: c/s面正片塞孔
    /// </para>
    /// <para>
    /// pbl_both_tenting: 兩面擋點共用
    /// </para>
    /// <para>
    /// <para>
    /// pnl_sm_ccd_outline: 防焊CCD框</para>
    /// pnl_dc_yyww:Date code</para>
    /// </summary>
    public struct MySymbols
    {
        public string Pnl_Ccd_Out_Fid => "pnl_ccd_out_fid";
        public string Pnl_Ccd_Sm_Fid => "pnl_ccd_sm_fid";
        public string Pnl_Out_Pin_Pad => "pnl_out_pin_pad";
        public string Pnl_Inn_Pin_Pad_N => "pnl_inn_pin_pad_n";
        public string Pnl_Inn_Pin_Pad_P => "pnl_inn_pin_pad_p";
        public string Pnl_Pin_Ccd_Pad_N => "pnl_pin_ccd_pad_n";
        public string Pnl_Pin_Ccd_Pad_P => "pnl_pin_ccd_pad_p";
        public string Pnl_Ccd_Frame_N => "pnl_ccd_frame_n";
        public string Pnl_Ccd_Frame_P => "pnl_ccd_frame_p";
        public string Pnl_Ccd_Inner_Frame_1 => "pnl_ccd_inner_frame_1";
        public string Pnl_Ccd_Inner_Frame_2 => "pnl_ccd_inner_frame_2";
        public string Pnl_Ten_Pad => "pnl_ten_pad";
        public string Pnl_Ten_Pad_Sm => "pnl_ten_pad_sm";
        public string Pnl_Ten_Pad_Ss => "pnl_ten_pad_ss";
        public string Pnl_L_Mark => "pnl_l_mark";
        public string Pnl_L_Mark_N => "pnl_l_mark_n";
        public string Pnl_Mic_N => "pnl_mic_n";
        public string Pnl_Mic_Inn => "pnl_mic_inn";
        public string Pnl_Tenting_Process => "pnl_tenting_process";
        public string Pnl_Layer_Text_Frame => "pnl_layer_text_frame";
        public string Pnl_Inn_Mnt => "pnl_inn_mnt";
        public string Pnl_Inn_Mnt_Dr => "pnl_inn_mnt_dr";
        public string Pnl_Inn_Mnt_Dr2 => "pnl_inn_mnt_dr2";
        public string Pnl_Inn_Mnt_Dr_N => "pnl_inn_mnt_dr_n";
        public string Pnl_Inn_Mnt_Dr2_N => "pnl_inn_mnt_dr2_n";
        public string Pnl_Tag => "pnl_tag";
        public string Pnl_Inn_Pad => "pnl_inn_pad";
        public string Pnl_Min_Dam => "pnl_min_dam";
        public string Pnl_Via => "pnl_via";
        public string Pnl_Tent => "pnl_tent";
        public string Pnl_Both_Tenting => "pnl_both_tenting";
        public string Pnl_Dc_Yyww => "pnl_dc_yyww";
        public string Pnl_Dc_Wwyy => "pnl_dc_wwyy";
        public string Pnl_Sm_Ccd_Outline => "pnl_sm_ccd_outline";

        public static string[] Pnl_Layer_Name_List =
        {
            "pnl_layer_name-t",
            "pnl_layer_name-1",
            "pnl_layer_name-2",
            "pnl_layer_name-3",
            "pnl_layer_name-4",
            "pnl_layer_name-5",
            "pnl_layer_name-6",
            "pnl_layer_name-7",
            "pnl_layer_name-8",
            "pnl_layer_name-9",
            "pnl_layer_name-10",
            "pnl_layer_name-11",
            "pnl_layer_name-12",
            "pnl_layer_name-13",
            "pnl_layer_name-b",
        };
    }
}