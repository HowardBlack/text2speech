﻿using _1113_t2.Models;
using System;
using System.Threading;
using System.Web.UI;

namespace _1113_t2
{
    public partial class index : Page
    {
        Thread tt;
        public static Text2Speach Text2Speach = new Text2Speach();

        protected void Page_Load(object sender, EventArgs e)
        {
            //arduino = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);

            if (!Page.IsPostBack)
            {
                tt = new Thread(new ThreadStart(Text2Speach.MyEye));
                tt.Start();
                Timer1.Interval = 100;//設定每秒執行一次
                Timer1.Enabled = true;//先關閉計時
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //判斷是否是在看按鈕
            if (Text2Speach.ButtonIsSeen()) 
            {
                if (Text2Speach.CheckClick()) 
                {
                    Text2Speach.Click();
                }
                else 
                {
                    Text2Speach.Hover();
                }
            }
            else 
            {
                Text2Speach.ResetWatchingTime();
            }

            //ScriptManager.RegisterClientScriptBlock(Page, GetType(), "close()", "close()", true);   //觸發 JS close函數
        }
    }
}