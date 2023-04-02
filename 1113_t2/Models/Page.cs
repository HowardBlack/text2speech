using EyeXFramework;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Tobii.EyeX.Framework;

namespace _1113_t2.Models
{
    public class Page
    {
        System.Web.UI.Page UIpage { get; set; }

        double X { get; set; }
        double Y { get; set; }

        int WatchingTime {  get; set; } //注視時間

        public Page(System.Web.UI.Page uIpage)
        {
            X = 0;
            Y = 0;
            WatchingTime = 0;
            UIpage = uIpage;
        }

        public void CheckExecute(string hover, string click) //確認是否執行點擊事件
        {
            WatchingTime++; //累加時間
            
            Execute(hover); //觸發 JS hover函數

            if (WatchingTime > 10) //超過時間則
            {
                Execute(click);//觸發 JS click函數
                WatchingTime = 0;
            }

        }

        public void Execute(string functionName) //執行事件
        {
            ScriptManager.RegisterClientScriptBlock(UIpage, GetType(), functionName, functionName, true);
        }

        public void MyEye() 
        {
            using (var eyeXHost = new EyeXHost())
            {
                // Create a data stream: lightly filtered gaze point data.
                // Other choices of data streams include EyePositionDataStream and FixationDataStream.
                using (var lightlyFilteredGazeDataStream = eyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered))
                {
                    // Start the EyeX host.
                    //eyeXHost.Start();
                    // Write the data to the console.
                    lightlyFilteredGazeDataStream.Next += (s, e) =>
                    {
                        X = e.X;
                        Y = e.Y;
                    };
                    Console.In.Read();
                }
            }
        }

        public void ResetCount() { WatchingTime = 0; }

    }
}