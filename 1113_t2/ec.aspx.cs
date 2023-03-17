using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tobii.Interaction;
using Tobii.EyeX.Framework;
using Tobii.EyeX.Client;
using EyeXFramework;
using System.Diagnostics;
using System.Threading;
using System.IO.Ports;

namespace _1113_t2
{
    public partial class ec : System.Web.UI.Page
    {
        Thread tt;
        SerialPort arduino;
        static double x = 0.0, y = 0.0, time = 0.0;                     //品宏的變數
        protected static bool cantStopDontStop = true;                  //品宏的變數
        static int count = 0;                                           //世宇的變數 凝視時間變數,進度變數
        static string dis = "", st = "";
        protected void xy(string hover, string click, string ax)        //世宇-觸發函數
        {
            count++;                                                    //累加時間
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), hover, hover, true);       //觸發 JS hover函數
            if (count > 15)                                                                     //超過時間則
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), click, click, true);   //觸發 JS click函數
                count = 0;
               
                if (st != ax)
                {
                    if (!arduino.IsOpen)
                    {
                        arduino.Open();
                    }
                    arduino.Write(ax);
                    arduino.Close();
                    st = ax;
                    Label1.Text = ax;
                }
               
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            arduino = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);

            if (!Page.IsPostBack)
            {
                tt = new Thread(new ThreadStart(myeye));
                tt.Start();
                Timer1.Interval = 100;//設定每秒執行一次
                Timer1.Enabled = true;//先關閉計時

            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            
           
            if (x > 930 && y > 90 && x < 1180 && y < 220)  //如果在該範圍
            {
                xy("hover(0)", "click(0)", "4");                   //呼叫觸發函數
            }
            else if (x > 1470 && y > 90 && x < 1720 && y < 220)  //如果在該範圍
            {
                xy("hover(1)", "click(1)", "5");                   //呼叫觸發函數
            }
            else if (x > 930 && y > 350 && x < 1200 && y < 480)  //如果在該範圍
            {
                xy("hover(2)", "click(2)", "6");                   //呼叫觸發函數
            }
            else if (x > 1470 && y > 350 && x < 1720 && y < 480)  //如果在該範圍
            {
                xy("hover(3)", "click(3)", "7");                   //呼叫觸發函數
            }
            else if (x > 930 && y > 610 && x < 1200 && y < 740)  //如果在該範圍
            {
                xy("hover(4)", "click(4)", "8");                   //呼叫觸發函數
            }
            else if (x > 1470 && y > 610 && x < 1720 && y < 740)  //如果在該範圍
            {
                xy("hover(5)", "click(5)", "9");                   //呼叫觸發函數
            }
            else if (x > 840 && y > 850 && x < 1070 && y < 1030)  //如果在該範圍
            {
                xy("hover_out()", "click_out()", "");                   //呼叫觸發函數
            }
            else//否則
            {
                count = 0;                              //累加時間歸零
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "close()", "close()", true);   //觸發 JS close函數
            }
        }

        public static void myeye()  //品宏的程式
        {

            using (var eyeXHost = new EyeXHost())
            {
                // Create a data stream: lightly filtered gaze point data.
                // Other choices of data streams include EyePositionDataStream and FixationDataStream.
                using (var lightlyFilteredGazeDataStream = eyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered))
                {
                    // Start the EyeX host.
                    eyeXHost.Start();
                    // Write the data to the console.
                    lightlyFilteredGazeDataStream.Next += (s, e) =>
                    {
                        x = e.X;
                        y = e.Y;
                        time = e.Timestamp;
                    };
                    Console.In.Read();
                }
            }

        }
    }
}