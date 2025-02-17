using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Gen
{
    public class Genesis : IDisposable
    {
        public string prefix, lmc, msg;
        public string READANS, COMANS, PAUSANS, MOUSEANS;
        public int STATUS = 0;
        public System.IO.StreamReader conv;
        public System.IO.StreamReader @in;

        public Genesis()
        {
            //exe程序发送指令需要以这个字符串开头，genesis才会识别
            this.prefix = "@%#%@";
            this.blank();
            return;
        }


        public virtual void blank()
        {
            this.STATUS = 0;
            this.READANS = "";
            this.COMANS = "";
            this.PAUSANS = "";
            this.MOUSEANS = "";
            return;
        }

        /// <summary>
        /// 执行指令
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="arg"></param>
        /// <returns></returns>
        public virtual int sendCmd(string cmd, string arg)
        {
            this.blank();


            this.lmc = this.prefix + cmd + " " + arg + "\n";
            Console.Write(this.lmc);


            return 0;
        }

        /// <summary>
        /// 执行genesis2000 line mode command动作
        /// </summary>
        /// <param name="arg">指令</param>
        /// <returns></returns>
        public virtual int COM(string arg)
        {
            this.sendCmd("COM", arg);


            try
            {
                int.TryParse(Console.ReadLine(), out STATUS);
                this.COMANS = Console.ReadLine();
                this.READANS = this.COMANS;
            }
            catch (IOException e)
            {
                Console.WriteLine("IO Error: " + e.Message);
            }

            return this.STATUS;
        }

        /// <summary>
        ///      用于暂停当前运行程序，等待用户做其它动作后继续执行程序或无条件退出程序。
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public virtual int PAUSE(string msg)
        {
            this.sendCmd("PAUSE", msg);


            try
            {
                int.TryParse(Console.ReadLine(), out this.STATUS);
                this.READANS = Console.ReadLine();
                this.PAUSANS = Console.ReadLine();
            }
            catch (IOException e)
            {
                Console.WriteLine("IO Error: " + e.Message);
            }

            return this.STATUS;
        }

        /// <summary>
        /// 设置活动工作界面
        /// </summary>
        /// <param name="arg">指令</param>
        /// <returns></returns>
        public virtual int AUX(string arg)
        {
            this.sendCmd("AUX", msg);


            try
            {
                //this.STATUS  = this.in.readLine();
                this.STATUS = int.Parse(Console.ReadLine());
                this.COMANS = Console.ReadLine();
            }
            catch (IOException e)
            {
                Console.WriteLine("IO Error: " + e.Message);
            }

            return this.STATUS;
        }

        /// <summary>
        /// 用于获取鼠标点击位置坐标。
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public virtual int MOUSE(string msg, string mode)
        {
            this.sendCmd("MOUSE " + mode, msg);


            try
            {
                int.TryParse(Console.ReadLine(), out STATUS);
                this.READANS = Console.ReadLine();
                this.MOUSEANS = Console.ReadLine();
            }

            catch (IOException e)
            {
                Console.WriteLine("IO Error: " + e.Message);
            }

            return this.STATUS;
        }


        /// <summary>
        /// 指令的主要目的是当我们有些程序需要用超级用户才能执行的时候，我们用SU_ON打开超级用户，然后执行程序。
        /// </summary>
        /// <returns></returns>
        public virtual int SU_ON()
        {
            this.sendCmd("SU_ON", "");
            return 0;
        }

        /// <summary>
        /// 为退出由SU_ON打开的超级用户模式
        /// </summary>
        /// <returns></returns>
        public virtual int SU_OFF()
        {
            this.sendCmd("SU_OFF", "");
            return 0;
        }

        /// <summary>
        ///     VON主要用于取得VOF的结果，然后执行其它的一些指令
        /// </summary>
        /// <returns></returns>
        public virtual int VON()
        {
            this.sendCmd("VON", "");
            return 0;
        }

        /// <summary>
        /// 该指令主要用于设置执行有可能出现错误的动作，并利用status得到结果，并经常结合VON使用
        /// </summary>
        /// <returns></returns>
        public virtual int VOF()
        {
            this.sendCmd("VOF", "");
            return 0;
        }

        public void Dispose()
        {
            conv.Dispose();
            @in.Dispose();
        }
    }
}