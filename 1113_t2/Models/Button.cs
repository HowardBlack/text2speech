using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1113_t2.Models
{
    public class Button //按鈕模型
    {
        string Text { get; set; } //按鈕要成現的文字

        string Event { get; set; } //這個按鈕被點擊到時要執行的事件

        string Value { get; set; } //執行事件時要帶的參數 

        double[] Range { get; set; } //這個按鈕在頁面會被執行到的X軸範圍 一定要有

        public Button(string Text, string Event, string Value, double[] Range) //初始化設定
        { 
            this.Text = Text;
            this.Event = Event;
            this.Value = Value;
            this.Range = Range;
        }

        //function
        public string GetText() { return Text; }

        public void SetText(string str) { Text = str; }

        public string GetEvent() { return Event; }        

        public string GetValue() { return Value; }

        public void SetValue(string str) { Value = str; }

        public double[] GetRange() { return Range; }


        public bool CheckRange(double X) //判斷現在有沒有被看到
        {
            //輸入眼動儀的X軸坐標判斷這個按鈕有沒有在範圍裡 有就true 沒有就false
            return (X >= Range[0] && X <= Range[1]);
        }

        //沒有要call js的話就用不到了
        public string GetExecutEvent() //取得代參數的function名稱
        {
            //把 Value 塞到 Event 裡面
            // 例 Event(Value)

            //$"{Event}('{Value}')" 改成 $"{Event}({Value}) 不知道會不會有要傳數字參數的情況
            // Value 是字串的時候 在建立時要自己加 ''

            return $"{Event}({Value})";
        }

        public Button GetButton()
        {
            return this;
        }
    }
}