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

namespace _1113_t2
{
    public partial class select : System.Web.UI.Page
    {
        Thread tt;
        static double x = 0.0, y = 0.0,time = 0.0;                     //品宏的變數
        protected static bool cantStopDontStop = true;                  //品宏的變數
        static int count = 0;                                           //世宇的變數 凝視時間變數,進度變數

        protected void xy(string hover, string click)                   //世宇-觸發函數
        {
            count++;
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), hover, hover, true);   //觸發 JS hover函數

            if (count > 10)                                                                     //超過時間則
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), click, click, true);   //觸發 JS click函數
                count = 0;
            }
        }


        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (x > 250 && y > 600 && x < 710 && y < 770)  //如果在該範圍
            {
                xy("hover(0)", "click(0)");                   //呼叫觸發函數
            }
            else if (x > 1210 && y > 600 && x < 1670 && y < 770)
            {
                xy("hover(1)", "click(1)");                   //呼叫觸發函數
            }
            else                                            //否則
            {
                    count = 0;                              //累加時間歸零
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "close()", "close()", true);   //觸發 JS close函數
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