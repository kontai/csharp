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

            try
            {
                COM("info,out_file=" + InfoPath + ",write_mode=replace,args=" + Param);

                // 等待文件完全寫入
                int retryCount = 0;
                while (retryCount < 50) // 最多等待 5 秒
                {
                    try
                    {
                        if (File.Exists(InfoPath))
                        {
                            // 嘗試開啟文件，如果成功表示寫入完成
                            using (var testStream = new FileStream(InfoPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                            {
                                if (testStream.Length > 0)
                                    break;
                            }
                        }
                    }
                    catch (IOException)
                    {
                        // 文件還在被寫入，繼續等待
                    }

                    System.Threading.Thread.Sleep(100);
                    retryCount++;
                }

                if (!File.Exists(InfoPath))
                {
                    throw new FileNotFoundException($"Genesis 輸出文件未產生: {InfoPath}");
                }
                // 使用 using 確保文件正確關閉
                using (FileStream InfoData = new FileStream(InfoPath.Trim(), FileMode.Open, FileAccess.Read))
                {
                    long size = InfoData.Length;
                    if (size == 0)
                    {
                        throw new InvalidDataException("Genesis 輸出文件為空");
                    }

                    byte[] Infobyte = new byte[size];
                    int totalBytesRead = 0;

                    // 確保完整讀取文件
                    while (totalBytesRead < size)
                    {
                        int bytesRead = InfoData.Read(Infobyte, totalBytesRead, (int)(size - totalBytesRead));
                        if (bytesRead == 0)
                            break;
                        totalBytesRead += bytesRead;
                    }
                    /*byte[] s = {0x0A};
                    byte[] t = {0x0D,0x0A};
                    Replace(ref Infobyte,s,t);*/
                    string InfoString = Encoding.ASCII.GetString(Infobyte);

                    Regex InfoRegex = new Regex("^set\\s*(\\S+)\\s*=\\s*(.*?)$", RegexOptions.Multiline);
                    Regex ValRegex = new Regex(".*?'(.*?)'.*?", RegexOptions.Multiline);
                    MatchCollection RegexResult = InfoRegex.Matches(InfoString, 0);

                    for (int i = 0; i < RegexResult.Count; i++)
                    {
                        try
                        {
                            List<string> ValList = new List<string>();
                            string SetNameStr = RegexResult[i].Groups[1].ToString();
                            string ValStr = RegexResult[i].Groups[2].ToString();

                            if (string.IsNullOrEmpty(SetNameStr))
                                continue;

                            if (ValRegex.IsMatch(ValStr))
                            {
                                MatchCollection RegexValResult = ValRegex.Matches(ValStr, 0);
                                for (int k = 0; k < RegexValResult.Count; k++)
                                {
                                    string val = RegexValResult[k].Groups[1].ToString();
                                    if (!string.IsNullOrEmpty(val))
                                    {
                                        ValList.Add(val);
                                    }
                                }
                            }
                            else
                            {
                                ValStr = ValStr.Replace("(", "").Replace(")", "").Trim();
                                if (!string.IsNullOrEmpty(ValStr))
                                {
                                    ValList.Add(ValStr);
                                }
                            }

                            if (ValList.Count > 0)
                            {
                                string[] ValArray = ValList.ToArray();

                                // 修正字典操作邏輯
                                if (InfoVal.ContainsKey(SetNameStr))
                                {
                                    InfoVal[SetNameStr] = ValArray; // 直接覆蓋，不要 Add
                                }
                                else
                                {
                                    InfoVal[SetNameStr] = ValArray;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"處理正規表達式結果時發生錯誤: {ex.Message}");
                            // 繼續處理下一個結果，不要中斷整個流程
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gen.INFO 執行錯誤: {ex.Message}");
                throw; // 重新拋出例外讓呼叫者處理
            }
            finally
            {
                // 確保清理臨時文件
                try
                {
                    if (File.Exists(InfoPath))
                    {
                        File.Delete(InfoPath);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"清理臨時文件失敗: {ex.Message}");
                }
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