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
    public partial class sf : System.Web.UI.Page
    {
        Thread tt;
        static double x = 0.0, y = 0.0, time = 0.0;                     //品宏的變數
        protected static bool cantStopDontStop = true;                  //品宏的變數
        SerialPort arduino;
        static int count = 0;                                           //世宇的變數 凝視時間變數,進度變數
        static string dis = "", st = "";
        string [,] xxyy = new string [,] { 
            {"110","150","370","410","hover(0)","click(0)","頭部"},
            {"590","150","850","410","hover(1)","click(1)","肩頸"},
            {"1070","150","1330","410","hover(2)","click(2)","胸部"},
            {"1550","150","1810","410","hover(3)","click(3)","手部"},
            {"110","600","370","770","hover(4)","click(4)","腹部"},
            {"590","600","850","770","hover(5)","click(5)","腰部"},
            {"1070","600","1330","770","hover(6)","click(6)","臀部"},
            {"1550","600","1810","770","hover(7)","click(7)","腳部"},
            {"740","900","1190","1260","hover(8)","click(8)","返回"},
        };
        protected void xy(string hover, string click,string ax)                   //世宇-觸發函數
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
            int i;
            bool yes = false;
            for(i = 0;i <= xxyy.GetUpperBound(0); i++)
            {
                if (x > Convert.ToInt32(xxyy[i, 0]) && y > Convert.ToInt32(xxyy[i, 1]) && x < Convert.ToInt32(xxyy[i, 2]) && y < Convert.ToInt32(xxyy[i, 3]))
                {
                    xy(xxyy[i, 4], xxyy[i, 5], xxyy[i, 6]);
                    yes = true;
                    break;
                }
            }
            if (yes == false){
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