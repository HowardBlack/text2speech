﻿using EyeXFramework;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using Tobii.EyeX.Framework;

namespace _1113_t2.Models
{
    public class Page
    {
        double X { get; set; }
        double Y { get; set; }

        int WatchingTime {  get; set; } //視線在按鈕上的時間
        int OverWatchingTime { get; set; } //視線在按鈕上過多久要做點擊事件的時間


        List<Block> Blocks { get; set; } //頁面裡的區塊 用Y軸來分區塊
        Button ButtonSeen { get; set; } //被看到的按鈕

        public Page(int overWatchingTime)
        {
            X = 0;
            Y = 0;
            WatchingTime = 0;
            OverWatchingTime = overWatchingTime;
        }

        public void AddBlock(Block block) { Blocks.Add(block); }

        public Block GetBlock(int index) { return Blocks[index]; }



        public bool ButtonIsSeen() //判斷視線是否在按鈕上 
        {
            //先判斷視線是否有在該區塊上
            //後判斷視線是否在該區塊裡的按鈕上
            //後得到該按鈕
            ButtonSeen = Blocks.Where(block => block.CheckRange(Y))
                            .SelectMany(block => block.GetButtons().Where(button => button.CheckRange(X)))
                            .FirstOrDefault();

            //如果視線不再按鈕上注視時間歸零
            if (ButtonSeen == null) ResetWatchingTime();

            //判斷是否有的到按鈕
            return ButtonSeen != null;
        }

        public void Click() //執行被看的按鈕的點擊事件
        {
            MethodInfo methodInfo = 
                GetType().GetMethod(ButtonSeen.GetEvent(), BindingFlags.Instance | BindingFlags.Public); //獲得按鈕裡的function

            if (methodInfo != null)
            {
                ParameterInfo[] parameters = methodInfo.GetParameters();
                //判斷呼叫的function要不要代參數
                if (parameters.Length == 0)
                {
                    //沒有要代參數要給null
                    methodInfo.Invoke(this, null); 
                }
                else
                {
                    //目前只能給字串類型的參數 給的參數型態跟要代的參數型代不對會報錯
                    methodInfo.Invoke(this, new object[] { ButtonSeen.GetValue() });
                }
            }
        }

        public void Hover() { } //滑過的事件

        public bool CheckClick() //確認是否執行點擊事件
        {
            WatchingTime++; //累加時間

            if (WatchingTime > OverWatchingTime) //超過時間則
            {
                ResetWatchingTime(); //重置注視時間
                return true;
            }

            return false;
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

        public void ResetWatchingTime() { WatchingTime = 0; }

    }
}