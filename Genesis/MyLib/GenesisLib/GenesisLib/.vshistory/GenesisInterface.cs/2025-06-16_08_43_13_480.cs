using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
//using System.Windows.Forms;/*提示用的写完可删*/
/*
 * By:Crazy
 * QQ:766519668
 * Date:2018-11-09
 * 暂无调试功能
*/

namespace GenesisLib 
{

    public class Gen
    {

        public static string JOB = Environment.GetEnvironmentVariable("JOB");
        public static string STEP = Environment.GetEnvironmentVariable("STEP");

        static bool ISVOF = false;
        static string Header = "@%#%@";
        public static string STATUS = "";
        public static string COMANS = "";
        public static string[] MOUSEANS = new string[0];
        static Dictionary<string, object[]> InfoVal = new Dictionary<string, object[]>();

        public static void COM(string Param) 
        {
            Console.WriteLine(Header + "COM " + Param);
            STATUS = Console.ReadLine();
            COMANS = Console.ReadLine();
            if (Gen.STATUS != "0" && ISVOF == false)
            {
                System.Environment.Exit(0);
            }
        }
        
        public static void INFO(string Param) 
        {
            InfoVal.Clear();
            Random rdNum = new Random();
            string RandomVal = rdNum.Next(9999).ToString();
            string InfoPath = Environment.GetEnvironmentVariable("GENESIS_TMP") + "/LRT_" + RandomVal;
            COM("info,out_file=" + InfoPath + ",write_mode=replace,args=" + Param);

            FileStream InfoData = new FileStream(InfoPath.Trim(), FileMode.Open);
            long size = InfoData.Length;
            byte[] Infobyte = new byte[size];
            InfoData.Read(Infobyte,0,Infobyte.Length);
            InfoData.Close();
            File.Delete(InfoPath);

            /*byte[] s = {0x0A};
            byte[] t = {0x0D,0x0A};
            Replace(ref Infobyte,s,t);*/
            string InfoString = Encoding.ASCII.GetString(Infobyte);
            
            Regex InfoRegex = new Regex("^set\\s*(\\S+)\\s*=\\s*(.*?)$", RegexOptions.Multiline);
            Regex ValRegex = new Regex(".*?'(.*?)'.*?", RegexOptions.Multiline);
            MatchCollection RegexResult = InfoRegex.Matches(InfoString, 0);
            for(int i = 0; i< RegexResult.Count;i++)
            {
                string[] ValArray = new string[0];
                List<string> ValList = new List<string>(); 
                string SetNameStr = RegexResult[i].Groups[1].ToString();
                string ValStr = RegexResult[i].Groups[2].ToString();
                if (ValRegex.IsMatch(ValStr))
                {
                    MatchCollection RegexValResult = ValRegex.Matches(ValStr, 0);
                    for (int k = 0; k < RegexValResult.Count;k++)
                    {
                        ValList.Add(RegexValResult[k].Groups[1].ToString());
                    }
                }else{
                   ValStr = ValStr.Replace("(","");
                   ValStr = ValStr.Replace(")", "");
                   ValList.Add(ValStr);
                }
                ValArray = ValList.ToArray();
                                 InfoVal[SetNameStr] = ValArray;
               
            }
        }
        /// <summary>
        /// 直接返回INFO取得的原文件内容
        /// </summary>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static string INFO_TXT(string Param)
        {
            InfoVal.Clear();
            Random rdNum = new Random();
            string RandomVal = rdNum.Next(9999).ToString();
            string InfoPath = Environment.GetEnvironmentVariable("GENESIS_TMP") + "/LRT_" + RandomVal;
            COM("info,out_file=" + InfoPath + ",write_mode=replace,args=" + Param);

            FileStream InfoData = new FileStream(InfoPath.Trim(), FileMode.Open);
            long size = InfoData.Length;
            byte[] Infobyte = new byte[size];
            InfoData.Read(Infobyte, 0, Infobyte.Length);
            InfoData.Close();
            File.Delete(InfoPath);

            /*byte[] s = { 0x0A };
            byte[] t = { 0x0D, 0x0A };
            Replace(ref Infobyte, s, t);*/
            string InfoString = Encoding.ASCII.GetString(Infobyte);
            return InfoString;
        }
        /// <summary>
        /// 通过提供Genesis变量文件的路径,读取变量值；
        /// </summary>
        /// <param name="Path"></param>
        public static void INFO_P(string Path)
        {
            InfoVal.Clear();
            Random rdNum = new Random();
            string RandomVal = rdNum.Next(9999).ToString();
            string InfoPath = Path;

            FileStream InfoData = new FileStream(InfoPath.Trim(), FileMode.Open);
            long size = InfoData.Length;
            byte[] Infobyte = new byte[size];
            InfoData.Read(Infobyte, 0, Infobyte.Length);
            InfoData.Close();
            File.Delete(InfoPath);

            /*byte[] s = { 0x0A };
            byte[] t = { 0x0D, 0x0A };
            Replace(ref Infobyte, s, t);*/
            string InfoString = Encoding.ASCII.GetString(Infobyte);

            Regex InfoRegex = new Regex("^set\\s*(\\S+)\\s*=\\s*(.*?)$", RegexOptions.Multiline);
            Regex ValRegex = new Regex(".*?'(.*?)'.*?", RegexOptions.Multiline);
            MatchCollection RegexResult = InfoRegex.Matches(InfoString, 0);
            for (int i = 0; i < RegexResult.Count; i++)
            {
                string[] ValArray = new string[0];
                List<string> ValList = new List<string>();
                string SetNameStr = RegexResult[i].Groups[1].ToString();
                string ValStr = RegexResult[i].Groups[2].ToString();
                if (ValRegex.IsMatch(ValStr))
                {
                    MatchCollection RegexValResult = ValRegex.Matches(ValStr, 0);
                    for (int k = 0; k < RegexValResult.Count; k++)
                    {
                        ValList.Add(RegexValResult[k].Groups[1].ToString());
                    }
                }
                else
                {
                    ValStr = ValStr.Replace("(", "");
                    ValStr = ValStr.Replace(")", "");
                    ValList.Add(ValStr);
                }
                ValArray = ValList.ToArray();
                if (InfoVal.ContainsKey(SetNameStr))
                {
                    InfoVal.Add(SetNameStr, ValArray);
                }
                else
                {
                    InfoVal[SetNameStr] = ValArray;
                }
            }
        }
        /// <summary>
        /// 取INFO或INFO_P的变量值
        /// </summary>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static string[] GetInfo(string Param)
        {
            string[] Val = new string[InfoVal[Param].Count<object>()];
            InfoVal[Param].ToArray().CopyTo(Val, 0);
            return Val;
        }
        /// <summary>
        /// Param参数直接OPEN STEP时的COMANS值即可
        /// </summary>
        /// <param name="Param"></param>
        public static void AUX(string Param) 
        {
            Console.WriteLine(Header + "AUX set_group,group=" + Param);
            STATUS = Console.ReadLine();
            COMANS = Console.ReadLine();
        }

        public static void PAUSE(string Param) 
        {
            Console.WriteLine(Header + "PAUSE " + Param);
            STATUS = Console.ReadLine();
            COMANS = Console.ReadLine();
            string PAUSANS = Console.ReadLine();
            if (PAUSANS != "OK") /*跟genesis一样不等于OK就退出*/
            {
                System.Environment.Exit(0);
            }
           
        }
        /// <summary>
        /// 取到的值存放在数组MOUSEANS中
        /// </summary>
        /// <param name="Param"></param>
        public static void MOUSE(string Param) 
        {
            Console.WriteLine(Header + "MOUSE " + Param);
            STATUS = Console.ReadLine();
            COMANS = Console.ReadLine();
            MOUSEANS = Console.ReadLine().Split();
        }

        public static void VOF()  
        {
            Console.WriteLine(Header + "VOF ");
            ISVOF = true;
        }

        public static void VON()  
        {
            Console.WriteLine(Header + "VON ");
            ISVOF = false;
        }

        public static void SU_ON() 
        {
            Console.WriteLine(Header + "SU_ON ");
        }

        public static void SU_OFF() 
        {
            Console.WriteLine(Header + "SU_OFF ");
        }

    }
}