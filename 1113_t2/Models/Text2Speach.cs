using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml.Linq;

namespace _1113_t2.Models
{
    public class Text2Speach : Page //注音鍵盤頁面的模型
    {
        string Text { get; set; } //要顯示的文字
        string PinyinText { get; set; } //要顯示的注音文字

        DB DB { get; set; } //資料庫

        string[,] Pinyins { get; set; } //注音資料

        string[] Pinyins_x { get; set; }

        int PinyinPage { get; set; } //現在要顯示的注音類型

        List<string[]> Words { get; set; } //文字資料

        int WordPage { get; set; } //現在要顯示的文字頁數

        public Text2Speach():base(10)
        {
            Text = "";
            PinyinText = "";

            DB = new DB("Text2Speache");  //帶的是資料庫名稱

            Pinyins = new string[,] {
            { "ㄅ", "ㄆ", "ㄇ", "ㄈ", "ㄉ", "ㄊ", "ㄋ" },
            { "ㄌ", "ㄍ", "ㄎ", "ㄏ", "ㄐ", "ㄑ", "ㄒ" },
            { "ㄓ", "ㄔ", "ㄕ", "ㄖ", "ㄗ", "ㄘ", "ㄙ" },
            { "ㄧ", "ㄨ", "ㄩ", "", "", "", "" },
            { "ㄚ", "ㄛ", "ㄜ", "ㄝ", "ㄞ", "ㄟ", "ㄠ" },
            { "ㄡ", "ㄢ", "ㄣ", "ㄤ", "ㄥ", "ㄦ", "" },
            { "ˊ", "ˇ", "ˋ", "˙", "", "", "" }};

            Pinyins_x = new string[] { "82,282", "302,502", "522,722", "742,942", "962,1162", "1182,1382", "1402,1602", "1622,1822" };

            PinyinPage = 0;

            Words = new List<string[]>() {
                new string[] { "-1" ,"", "", "", "", "", "", "1"}  //第一個跟最後一個要塞-1, 1
            };

            WordPage = 0;


            //Block要帶的參數int ButtonCount, double[] Range, string[,] ButtonData

            //事件參數裡塞Text2Speach裡寫好的要call的function名稱就行 例: {"ㄅ", "InsertPinyin", "ㄅ", "82,282" }

            //第一區塊 文字顯示倒退鑑區塊
            AddBlock(new Block(1, new double[] { 32, 232 }, new string[,] {
                {"", "Backspace", "", "1424,1624" } // backspace 按鈕
            }));

            //第二區塊 文字選取區塊 Value給Words[0]裡的參數就可以了換頁時在更新裡面的按鈕
            AddBlock(new Block(8, new double[] { 242, 442 }, new string[,] {
                {"⇦", "WordChangePage", "-1", "117,317" }, //上一頁按鈕
                {"", "InsertWord", "", "" },
                {"", "InsertWord", "", "" },
                {"", "InsertWord", "", "" },
                {"", "InsertWord", "", "" },
                {"", "InsertWord", "", "" },
                {"", "InsertWord", "", "" },
                {"⇨", "WordChangePage", "1", "1587,1787" } //下一頁按鈕
            }));

            //第三區塊 注音區塊 Value給Pinyins[0]裡的參數就可以了換頁時在更新裡面的按鈕
            AddBlock(new Block(8, new double[] { 517, 717 }, new string[,] {
                {"ㄅ", "InsertPinyin", "ㄅ", "82,282" }, //第一個按鈕
                {"ㄆ", "InsertPinyin", "ㄆ", "302,502" }, //第二個按鈕
                {"ㄇ", "InsertPinyin", "ㄇ", "522,722" }, //第三個按鈕
                {"ㄈ", "InsertPinyin", "ㄈ", "742,942" }, //第四個按鈕
                {"ㄉ", "InsertPinyin", "ㄉ", "962,1162" }, //第五個按鈕
                {"ㄊ", "InsertPinyin", "ㄊ", "1182,1382" }, //第六個按鈕
                {"ㄋ", "InsertPinyin", "ㄋ", "1402,1602" }, //第七個按鈕
                {"PLAY", "", "", "1622,1822" } // PLAY 按鈕
            }));

            //第四區塊 注音切換區塊
            AddBlock(new Block(8, new double[] { 737, 937 }, new string[,] {
                {"ㄅ~ㄋ聲母", "PinyinChangePage", "0", "82,282" },    //第一個按鈕
                {"ㄌ~ㄒ聲母", "PinyinChangePage", "1", "302,502" },   //第二個按鈕
                {"ㄓ~ㄙ聲母", "PinyinChangePage", "2", "522,722" },   //第三個按鈕
                {"ㄧ~ㄩ介音", "PinyinChangePage", "3", "742,942" },   //第四個按鈕
                {"ㄚ~ㄠ韻母", "PinyinChangePage", "4", "962,1162" },  //第五個按鈕
                {"ㄡ~ㄦ韻母", "PinyinChangePage", "5", "1182,1382" }, //第六個按鈕
                {"聲調", "PinyinChangePage", "6", "1402,1602" },      //第七個按鈕
                {"CANCEL", "", "", "1622,1822" }      // CANCEL 按鈕
            }));
            
       }

        public string GetText() { return Text; }

        public void SetText(string text) {  Text = text; }

        public string GetPinyinText() { return PinyinText; }

        public void SetPinyinText(string text) { PinyinText = text; }

        public int GetPinyinPage() { return PinyinPage; }

        public void SetPinyinPage(int page) { PinyinPage = page; }

        public int GetWordPage() { return WordPage; }

        public void SetWordPage(int page) { WordPage = page; }


        //按鈕的事件 只能帶字串類型的參數 自己轉型態
        public void Backspace() //到退鍵的事件
        {
            /*
                1. 判斷是注音區塊還是選字區塊? 如果注音區塊有文字先刪除，否則刪選字區塊
                2. 刪除該區塊最後一個字
                3. 重新設定文字至該區塊
            */
            if (string.IsNullOrEmpty(GetPinyinText())) // 判斷注音區塊是否空白
            {
                string NewPinyinText = GetPinyinText().Remove(GetPinyinText().Length - 1, 1); // 刪除注音區塊最後一個字
                SetPinyinText(NewPinyinText); // 重新設定注音區塊文字
            }
            else
            {
                string NewText = GetText().Remove(GetText().Length - 1, 1); // 刪除選取文字區塊最後一個字
                SetText(NewText); // 重新設定選取文字區塊文字
            }
        }

        public void InsertWord(string str) //文字事件
        {
            //GetTet() 取得文字框內的文字，再加上 str 新增的文字，最後 SetText() 重新設定在文字框內
            SetText(GetText() + str);
            //暫時未清除注音及文字選字區塊

            //AddUseCount();
        }

        public void WordChangePage(string page) //文字切換事件
        {
            //跟注音切換的原理一樣
            SetWordPage(int.Parse(page));
            GetBlock(1).SetButtons(new string[,] { }); //更新按鈕的資料
        }

        public void InsertPinyin(string str) //注音事件
        {
            //把被點到的按鈕的text塞進要顯示的text裡
            SetPinyinText(GetPinyinText() + str);
            //多注音切割後分批call SearchWords()
            SearchWords(GetPinyinText()); //帶入全部注音

            //SearchWords(str);
        }

        public void PinyinChangePage(string page) //輸入注音切換事件
        {
            SetPinyinPage(int.Parse(page));

            string[,] newPinyinButtons = new string[,] { };
            
            for (int i = 0; i < 7; i++)
            {
                newPinyinButtons[i, 0] = Pinyins[PinyinPage, i];
                newPinyinButtons[i, 1] = "InsertPinyin";
                newPinyinButtons[i, 2] = Pinyins[PinyinPage, i]; ;
                newPinyinButtons[i, 3] = Pinyins_x[i];
            }

            newPinyinButtons[7, 1] = "PLAY";
            newPinyinButtons[7, 2] = "";
            newPinyinButtons[7, 3] = "";
            newPinyinButtons[7, 4] = Pinyins_x[7];

            GetBlock(2).SetButtons(newPinyinButtons); //更新按鈕的資料

            //SetButtons() 裡的資料就像這個 1, 3的參數換成對應頁數的注音
            //想不到怎樣寫比較好
            /*AddBlock(new Block(8, new double[] { 517, 717 }, new string[,] {
                {"ㄅ", "InsertPinyin", "ㄅ", "82,282" }, //第一個按鈕
                {"ㄆ", "InsertPinyin", "ㄆ", "302,502" }, //第二個按鈕
                {"ㄇ", "InsertPinyin", "ㄇ", "522,722" }, //第三個按鈕
                {"ㄈ", "InsertPinyin", "ㄈ", "742,942" }, //第四個按鈕
                {"ㄉ", "InsertPinyin", "ㄉ", "962,1162" }, //第五個按鈕
                {"ㄊ", "InsertPinyin", "ㄊ", "1182,1382" }, //第六個按鈕
                {"ㄋ", "InsertPinyin", "ㄋ", "1402,1602" }, //第七個按鈕
                {"PLAY", "", "", "1622,1822" } // PLAY 按鈕
            }));*/
        }
        //

        //帶注音
        void SearchWords(string str) //從資料庫找對應的字 先不要管這個
        {
            /*List<Dictionary<string, string>> getWords()
            {
                //Select* from Words where pinyinId IN(Select id from Pinyins where Text = N'ㄨㄛˇ')
                List<Dictionary<string, string>> temps =
                    DB.Reader(
                        DB.Select("*", "Words", $"pinyinId IN ({DB.Select("id", "Pinyins", $"Text = N'{str}'")}) Order by Usecount DESC"));

                return temps;
            }

            List<Dictionary<string, string>> Words = getWords();*/
        }

        //帶文字的ID或是unicode碼 
        void AddUsecount(int id)//增加文字使用次數 先不要管這個
        {
            DB.Query(
                DB.Update("Words", "Usecount += 1", $"id = {id}"));
        }
    }
}