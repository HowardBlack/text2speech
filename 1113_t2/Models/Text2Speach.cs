using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace _1113_t2.Models
{
    public class Text2Speach : Page //注音鍵盤頁面的模型
    {
        DB DB { get; set; }

        string[,] Pinyins { get; set; } //注音資料

        public int PinyinPage { get; set; } //現在要顯示的注音類型

        List<string[]> Words { get; set; } //文字資料

        public int WordPage { get; set; } //現在要顯示的文字頁數

        List<Block> Blocks { get; set; } //頁面裡的區塊 用Y軸來分區塊

        public Text2Speach(System.Web.UI.Page UIpage) : base(UIpage)
        {
            DB = new DB("Text2Speache");

            Pinyins = new string[,]{
            { "ㄅ", "ㄆ", "ㄇ", "ㄈ", "ㄉ", "ㄊ", "ㄋ" },
            { "ㄌ", "ㄍ", "ㄎ", "ㄏ", "ㄐ", "ㄑ", "ㄒ" },
            { "ㄓ", "ㄔ", "ㄕ", "ㄖ", "ㄗ", "ㄘ", "ㄙ" },
            { "ㄧ", "ㄨ", "ㄩ", "", "", "", "" },
            { "ㄚ", "ㄛ", "ㄜ", "ㄝ", "ㄞ", "ㄟ", "ㄠ" },
            { "ㄡ", "ㄢ", "ㄣ", "ㄤ", "ㄥ", "ㄦ", "" },
            { "ˊ", "ˇ", "ˋ", "˙", "", "", "" }};

            PinyinPage = 0;

            Words = new List<string[]>() { 
                new string[] { "-1" ,"", "", "", "", "", "", "1"}  //第一個跟最後一個要塞-1, 1
            };

            WordPage = 0;

            //Block要帶的參數int ButtonCount, double[] Range, string[,] ButtonData
            //string[,] ButtonData { get; set; } = { {"Text", "Event", "Value", "Range 給字串用逗號區隔"} }; 舉例 ButtonData要帶的參數形式有幾個按鈕就要有多少筆資料
            //第一區塊 文字顯示倒退鑑區塊
            Blocks.Add(new Block(1, new double[] { 32, 232 }, new string[,] {
                {"", "", "", "1424,1624" } // backspace 按鈕
            }));

            //第二區塊 文字選取區塊 Value給Words[0]裡的參數就可以了換頁時在更新裡面的按鈕
            Blocks.Add(new Block(8, new double[] { 242, 442 }, new string[,] {
                {"⇦", "", "-1", "117,317" }, //上一頁按鈕
                {"⇨", "", "1", "1587,1787" } //下一頁按鈕
            }));

            //第三區塊 注音區塊 Value給Pinyins[0]裡的參數就可以了換頁時在更新裡面的按鈕
            Blocks.Add(new Block(8, new double[] { 517, 717 }, new string[,] {
                {"ㄅ", "", "ㄅ", "82,282" }, //第一個按鈕
                {"ㄆ", "", "ㄆ", "302,502" }, //第二個按鈕
                {"ㄇ", "", "ㄇ", "522,722" }, //第三個按鈕
                {"ㄈ", "", "ㄈ", "742,942" }, //第四個按鈕
                {"ㄉ", "", "ㄉ", "962,1162" }, //第五個按鈕
                {"ㄊ", "", "ㄊ", "1182,1382" }, //第六個按鈕
                {"ㄋ", "", "ㄋ", "1402,1602" }, //第七個按鈕
                {"PLAY", "", "", "1622,1822" } // PLAY 按鈕
            }));

            //第四區塊 注音切換區塊
            Blocks.Add(new Block(8, new double[] { 737, 937 }, new string[,] {
                {"ㄅ~ㄋ聲母", "", "1", "82,282" },    //第一個按鈕
                {"ㄌ~ㄒ聲母", "", "2", "302,502" },   //第二個按鈕
                {"ㄓ~ㄙ聲母", "", "3", "522,722" },   //第三個按鈕
                {"ㄧ~ㄩ介音", "", "4", "742,942" },   //第四個按鈕
                {"ㄚ~ㄠ韻母", "", "5", "962,1162" },  //第五個按鈕
                {"ㄡ~ㄦ韻母", "", "6", "1182,1382" }, //第六個按鈕
                {"聲調", "", "7", "1402,1602" },      //第七個按鈕
                {"CANCEL", "", "", "1622,1822" }      // CANCEL 按鈕
            })); 


        }

        public string CheckClick(double X, double Y) //判斷看到哪個區塊了
        {
            //用for迴圈來呼叫Blocks裡的CheckRange(Y) 
            //True
            //要先知道在哪個區塊裡面
            //如果再 文字選取區塊 或 注音切換區塊 要call WordChangePage 或 PinyinChangePage 
            //回傳 GetButtonEvent(X)得到是被按到按鈕的事件 字串

            for (var i = 0; i < Blocks.Count; i++) // for 迴圈走訪 Blocks
            {
                Block block = Blocks[i];
                if (block.CheckRange(Y)) // 在範圍裡
                {
                    if (i == 1) // 在 文字選取區塊
                        WordChangePage(WordPage);
                    else if (i == 3) // 在 注音切換區塊
                        PinyinChangePage(PinyinPage);
                    return block.GetButtonEvent(X); // 無論在哪，取得這個按鈕執行什麼方法
                }
            }

            //False
            //回傳空字串
            return "";
        }

        void PinyinChangePage(int page) //先不要管這個
        {
            PinyinPage = page;
            Blocks[2].SetButtons(new string[,]{ }); //更新按鈕的資料
        }

        void WordChangePage(int page) //先不要管這個
        {
            WordPage = page;
            Blocks[1].SetButtons(new string[,] { }); //更新按鈕的資料
        }

        public void SearchWords(string str) //先不要管這個
        {
            List<Dictionary<string, string>> getWords()
            {
                //Select* from Words where pinyinId IN(Select id from Pinyins where Text = N'ㄨㄛˇ')
                List<Dictionary<string, string>> temps =
                    DB.Reader(
                        DB.Select("*", "Words", $"pinyinId IN ({DB.Select("id", "Pinyins", $"Text = N'{str}'")}) Order by Usecount DESC"));

                return temps;
            }

            List<Dictionary<string, string>> Words = getWords();
        }
    }
}