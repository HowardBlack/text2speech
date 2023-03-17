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
    public partial class so : System.Web.UI.Page
    {
        Thread tt;
        static double x = 0.0, y = 0.0, time = 0.0;                     //品宏的變數
        protected static bool cantStopDontStop = true;                  //品宏的變數
        static int count = 0;                                           //世宇的變數 凝視時間變數,進度變數

        protected void xy(string hover, string click)                   //世宇-觸發函數
        {
            count++;
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), hover, hover, true);   //觸發 JS hover函數

            if (count > 15)                                                                     //超過時間則
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), click, click, true);   //觸發 JS click函數
                count = 0;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
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
            if (x > 110 && y > 150 && x < 370 && y < 410)  //如果在該範圍
            {
                xy("hover(0)", "click(0)");                   //呼叫觸發函數
            }
            else if (x > 590 && y > 150 && x < 850 && y < 410)
            {
                xy("hover(1)", "");                   //呼叫觸發函數
            }
            else if (x > 1070 && y > 150 && x < 1330 && y < 410)
            {
                xy("hover(2)", "");                   //呼叫觸發函數
            }
            else if (x > 1550 && y > 150 && x < 1810 && y < 410)
            {
                xy("hover(3)", "");                   //呼叫觸發函數
            }
            else if (x > 730 && y > 690 && x < 1190 && y < 790)
            {
                xy("hover(4)", "click_out()");          //呼叫觸發函數
            }
            else                                            //否則
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