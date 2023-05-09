using _1113_t2.Models;
using Antlr.Runtime.Misc;
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

        public void Update(string fun) 
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), fun, fun, true);
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {            
            //判斷是否是在看按鈕
            if (Text2Speach.ButtonIsSeen()) 
            {
                if (Text2Speach.CheckClick()) 
                {
                    Text2Speach.Click();
                    /*
                        Pinyin, 3 parameter 應是變化項目
                            -> userInput0 注音 -> Text2Speech.GetPinyinText().split()
                            -> choiceText0 文字 -> Text2Speech.GetWordText().split()
                            -> Word 文字變換 -> Text2Speech.GetBlock(1).GetButtonValue()
                            -> Pinyin 注音變換 -> Text2Speech.GetBlock(2).GetButtonValue()
                     */

                    //Update(Text2Speach.GetUpdate("UpdatePageArea", "Pinyin", Text2Speach.GetBlock(2).GetButtonsValue()));
                    //判斷類型是否等於 string[]，可解決需要帶入string[]參數類型錯誤問題
                    //callback method 無法正常使用
                    Update(Text2Speach.GetUpdateFunName());
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