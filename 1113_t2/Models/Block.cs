using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace _1113_t2.Models
{
    public class Block //區塊模型
    {
        int ButtonCount { get; set; } //這個區塊的按鈕總數 要給list塞空值用的

        double[] Range { get; set; } //這個區塊的Y軸範圍

        List<Button> Buttons { get; set; } //這個區塊的按鈕

        //文字可以先只給上下頁的按鈕其他帶空值
        public Block(int ButtonCount, double[] Range, string[,] ButtonData) //初始化設定
        {
            this.ButtonCount = ButtonCount;
            this.Range = Range;
            Buttons = new List<Button>();
            SetButtons(ButtonData);
        }

        //function
        public List<Button> GetButtons() { return Buttons; }

        public void SetButtons(string[,] Data) //在執行換頁類型的功能時刷新現在區塊裡有的按鈕
        {
            ClearButtons();
            for (int row = 0; row < Data.GetLength(0); row++)
            {
                string Text = Data[row, 0].ToString();
                string Event = Data[row, 1].ToString();
                string Value = Data[row, 2].ToString();
                double[] range = Data[row, 3].ToString().Split(',').Select(double.Parse).ToArray();
                Buttons.Add(new Button(Text, Event, Value, range));
            }
        }

        void ClearButtons() { Buttons.Clear(); }

        public bool CheckRange(double Y)//判斷現在有沒有被看到
        {
            //輸入眼動儀的Y軸坐標判斷這個區塊有沒有在範圍裡 有就true 沒有就false
            return (Y >= Range[0] && Y <= Range[1]);
        }

        //不call js就沒用了
        public string GetButtonEvent(double X)
        {
            //for迴圈Buttos呼叫裡面的CheckRange(X)判斷是否被執行
            //被執行到時呼叫GetExecutEvent()回傳帶參數的事件
            //都沒被看到就回傳""空字串

            foreach (Button btn in Buttons)
                if (btn.CheckRange(X)) return btn.GetExecutEvent();

            return "";
        }

        // 文字資料不需要取得全部資料，只需要取得 1 - count-1        
        public string[] GetButtonsValue() //凝視三秒後，取得buttons最新資料
        {
            List<string> buttonValues = new List<string> { };
            List<Button> currentButtons = GetButtons();

            foreach (Button item in currentButtons)
            {
                buttonValues.Add(item.GetText());
            }

            return buttonValues.ToArray();

        }
    }
}