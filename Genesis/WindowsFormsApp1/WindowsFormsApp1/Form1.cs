using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Genesis gen = new Genesis();
            string dbname = "genesis";
            string jobname = textBox1.Text;



            Console.WriteLine("Instantiated the Genesis Object...");



            string msg = "Welcome to the Java test Script...apparently its working...";
            Console.WriteLine(msg);

            gen.PAUSE(msg);

            gen.COM("create_entity,job=,is_fw=no,type=job,name=" + jobname + ",db=" + dbname + ",fw_type=form");
            gen.COM("clipb_open_job,job=" + jobname + ",update_clipboard=view_job");
            gen.COM("open_job,job=" + jobname);
            gen.COM("open_entity,job=" + jobname + ",type=matrix,name=matrix,iconic=no");
            gen.COM("matrix_add_step,job=" + jobname + ",matrix=matrix,step=test,col=1");
            gen.COM("matrix_add_layer,job=" + jobname + ",matrix=matrix,layer=lay1,row=1,context=board,type=signal,polarity=positive");
            gen.COM("matrix_add_layer,job=" + jobname + ",matrix=matrix,layer=lay2,row=2,context=board,type=signal,polarity=positive");

            string msg2 = "Now we'll open the newly created step...";
            Console.WriteLine(msg2);

            gen.PAUSE(msg2);

            gen.COM("open_entity,job=" + jobname + ",type=step,name=test,iconic=no");
            string group = gen.COMANS;
            gen.PAUSE("Group number is " + group);



            gen.COM("units,type=inch");
            gen.COM("display_layer,name=lay1,display=yes,number=1");
            gen.COM("work_layer,name=lay1");
            gen.COM("display_layer,name=lay2,display=yes,number=2");
            gen.COM("profile_rect,x1=0,y1=0,x2=5,y2=5");
            gen.COM("zoom_home");
            gen.COM("add_line,attributes=no,xs=0.6239601378,ys=0.5049917323,xe=4.6505824803,ye=4.5865225394,symbol=r40,polarity=positive");
            gen.COM("work_layer,name=lay2");
            gen.COM("add_line,attributes=no,xs=0.5049917323,ys=4.4675541339,xe=4.4584027559,ye=0.4409318898,symbol=r40,polarity=positive");

            gen.MOUSE("Click a point", "p");
            Console.WriteLine("Mouseans : " + gen.MOUSEANS);

            Console.WriteLine("Checking return of Genesis object...");
            Console.WriteLine("genStatus : " + Convert.ToString(gen.STATUS));
            Console.WriteLine("genComans : " + gen.COMANS);

            string msg3 = "Now we'll clean up...";
            Console.WriteLine(msg3);

            gen.PAUSE(msg3);


            gen.COM("check_inout,mode=in,type=job,job=" + jobname);
            gen.COM("close_job,job=" + jobname);
            gen.COM("close_form,job=" + jobname);
            gen.COM("close_flow,job=" + jobname);
            gen.COM("delete_entity,job=,type=job,name=" + jobname);


            Console.WriteLine("genStatus : " + Convert.ToString(gen.STATUS));
            Console.WriteLine("genComans : " + gen.COMANS);

            string msg4 = "Thats it...";
            Console.WriteLine(msg4);

            gen.PAUSE(msg4);

            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
