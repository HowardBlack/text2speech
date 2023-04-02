using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1113_t2.Models
{
    public class Button //按鈕模型
    {
        //沒有要帶參數的話就給""空值
        //帶進來就不會再改變的參數 
        public string Text { get; set; } //按鈕要成現的文字

        public string Event { get; set; } //這個按鈕被點擊到時要執行的事件

        public string Value { get; set; } //執行事件時要帶的參數 

        double[] Range { get; set; } //這個按鈕在頁面會被執行到的X軸範圍 一定要有

        public Button(string Text, string Event, string Value, double[] Range) //初始化設定
        { 
            this.Text = Text;
            this.Event = Event;
            this.Value = Value;
            this.Range = Range;
        }

        //可變的參數


        //function
        public string GetText() { return Text; }

        public string GetEvent() { return Event; }

        public string GetValue() { return Value; }

        public double[] GetRange() { return Range; }


        public bool CheckRange(double X) //判斷現在有沒有被看到
        {
            //輸入眼動儀的X軸坐標判斷這個按鈕有沒有在範圍裡 有就true 沒有就false

            return true;
        }


        public string GetExecutEvent() //取得代參數的function名稱
        {
            //把 Value 塞到 Event 裡面
            // 例 Event(Value)

            return "";
        }
    }
}