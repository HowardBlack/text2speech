﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace _1113_t2.Models
{
    public class Text2Speach : Main //注音鍵盤頁面的模型
    {
        
        string WordText { get; set; } //要顯示的文字
        string PinyinText { get; set; } //要顯示的注音文字        

        List<string> UpdateFunName { get; set; }
        
        DB DB { get; set; } //資料庫

        List<string[]> Pinyins { get; set; } //注音資料

        int PinyinPage { get; set; } //現在要顯示的注音類型

        List<List<Dictionary<string, string>>> Words { get; set; } //文字資料
        //private List<List<Dictionary<string, string>>> Words = new List<List<Dictionary<string, string>>>(); //文字資料        

        int WordPage { get; set; } //現在要顯示的文字頁數

        public Text2Speach() : base(8)
        {
            WordText = ""; //文字
            
            PinyinText = ""; //注音

            DB = new DB("Text2Speache");  //帶的是資料庫名稱

            UpdateFunName = new List<string>();

            Pinyins = new List<string[]>()
            {
                new string[]{ "ㄅ", "ㄆ", "ㄇ", "ㄈ", "ㄉ", "ㄊ", "ㄋ" },
                new string[]{ "ㄌ", "ㄍ", "ㄎ", "ㄏ", "ㄐ", "ㄑ", "ㄒ" },
                new string[]{ "ㄓ", "ㄔ", "ㄕ", "ㄖ", "ㄗ", "ㄘ", "ㄙ" },
                new string[]{ "ㄧ", "ㄨ", "ㄩ", "", "", "", "" },
                new string[]{ "ㄚ", "ㄛ", "ㄜ", "ㄝ", "ㄞ", "ㄟ", "ㄠ"},
                new string[]{ "ㄡ", "ㄢ", "ㄣ", "ㄤ", "ㄥ", "ㄦ", "" },
                new string[]{ "ˊ", "ˇ", "ˋ", "˙", "", "", "" },
            };

            PinyinPage = 0;

            Words = new List<List<Dictionary<string, string>>>();

            WordPage = 0;

            //第一區塊 文字顯示倒退鍵區塊
            AddBlock(new Block(1, new double[] { 37, 237 }, new string[,] {
                {"⇦backspace", "Backspace", "", "1424,1624" } // backspace 按鈕
            }));

            //第二區塊 文字選取區塊
            AddBlock(new Block(8, new double[] { 257, 457 }, new string[,] {
                {"⇦", "WordChangePage", "-1", "82,282" }, //上一頁按鈕
                {"", "InsertWord", "", "302,502" },
                {"", "InsertWord", "", "522,722" },
                {"", "InsertWord", "", "742,942" },
                {"", "InsertWord", "", "962,1162" },
                {"", "InsertWord", "", "1182,1382" },
                {"", "InsertWord", "", "1402,1602" },
                {"⇨", "WordChangePage", "1", "1622,1822" } //下一頁按鈕
            }));

            //第三區塊 注音區塊 Value給Pinyins[0]裡的參數就可以了換頁時在更新裡面的按鈕
            AddBlock(new Block(8, new double[] { 537, 737 }, new string[,] {
                {"ㄅ", "InsertPinyin", "ㄅ", "82,282" }, //第一個按鈕
                {"ㄆ", "InsertPinyin", "ㄆ", "302,502" }, //第二個按鈕
                {"ㄇ", "InsertPinyin", "ㄇ", "522,722" }, //第三個按鈕
                {"ㄈ", "InsertPinyin", "ㄈ", "742,942" }, //第四個按鈕
                {"ㄉ", "InsertPinyin", "ㄉ", "962,1162" }, //第五個按鈕
                {"ㄊ", "InsertPinyin", "ㄊ", "1182,1382" }, //第六個按鈕
                {"ㄋ", "InsertPinyin", "ㄋ", "1402,1602" }, //第七個按鈕
                {"PLAY", "PlayVoice", "", "1622,1822" } // PLAY 按鈕
            }));

            //第四區塊 注音切換區塊
            AddBlock(new Block(8, new double[] { 757, 957 }, new string[,] {
                {"ㄅ~ㄋ聲母", "PinyinChangePage", "0", "82,282" },    //第一個按鈕
                {"ㄌ~ㄒ聲母", "PinyinChangePage", "1", "302,502" },   //第二個按鈕
                {"ㄓ~ㄙ聲母", "PinyinChangePage", "2", "522,722" },   //第三個按鈕
                {"ㄧ~ㄩ介音", "PinyinChangePage", "3", "742,942" },   //第四個按鈕
                {"ㄚ~ㄠ韻母", "PinyinChangePage", "4", "962,1162" },  //第五個按鈕
                {"ㄡ~ㄦ韻母", "PinyinChangePage", "5", "1182,1382" }, //第六個按鈕
                {"聲調", "PinyinChangePage", "6", "1402,1602" },      //第七個按鈕
                {"CANCEL", "CloseVoice", "", "1622,1822" }      // CANCEL 按鈕
            }));

        }

        public string GetWordText() { return WordText; }

        public void SetWordText(string text) { WordText = text; }

        public string GetPinyinText() { return PinyinText; }

        public void SetPinyinText(string text) { PinyinText = text; }

        public List<string[]> GetPinyins() { return Pinyins; }

        public string[] GetPinyins(int index) { return Pinyins[index]; }

        public int GetPinyinPage() { return PinyinPage; }

        public void SetPinyinPage(int page) { PinyinPage = page; }

        public int GetWordPage() { return WordPage; }

        public void SetWordPage(int page) { WordPage = page; }

        public List<string> GetUpdateFunName() { return UpdateFunName; }        

        public void ClearUpdateFunName() { UpdateFunName.Clear(); }        

        //按鈕事件
        public void Backspace() //到退鍵的事件
        {
            if (!string.IsNullOrEmpty(GetPinyinText())) // 先判斷注音區塊為非空白
            {
                string NewPinyinText = GetPinyinText().Remove(GetPinyinText().Length - 1, 1); // 刪除選取文字區塊最後一個字
                SetPinyinText(NewPinyinText); // 重新設定選取文字區塊文字
                UpdateFunName.Add(GetUpdate("UpdatePageArea", "PinyinInput", GetPinyinText().Split()));
            }
            else if (!string.IsNullOrEmpty(GetWordText())) //注音空白再判斷文字區為非空白
            {
                string NewText = GetWordText().Remove(GetWordText().Length - 1, 1); // 刪除選取文字區塊最後一個字
                SetWordText(NewText); // 重新設定選取文字區塊文字
                UpdateFunName.Add(GetUpdate("UpdatePageArea", "WordText", GetWordText().Split()));
            }
        }

        public void InsertWord(string str) //文字事件
        {
            if (!String.IsNullOrEmpty(str))
            {
                AddUsecount(str); //增加使用次數
                str = Regex.Unescape($"\\u{str}"); //轉碼
                SetWordText(GetWordText() + str); //設定文字
                SetPinyinText(""); //清除注音
                SetWordPage(0);      //清除文字選字頁數
                Words.Clear(); ; //清除所有文字選字

                //清除文字選字區塊為空
                List<Button> previusButtons = GetBlock(1).GetButtons(); //取得選字區塊所有 buttonts 資料
                for (int i = 1; i < previusButtons.Count - 1; i++)
                {
                    previusButtons[i].SetText(""); //設定該button的文字為空
                    previusButtons[i].SetValue(""); //設定該button的值為空
                }
                UpdateFunName.Add(GetUpdate("UpdatePageArea", "PinyinInput", GetPinyinText().Split()));
                UpdateFunName.Add(GetUpdate("UpdatePageArea", "WordText", GetWordText().Split()));
                UpdateFunName.Add(GetUpdate("UpdatePageArea", "Word", GetBlock(1).GetButtonsValue()));
            }
        }

        public void WordChangePage(string page) //文字切換事件
        {
            SetWordPage(GetWordPage() + int.Parse(page));
            if (GetWordPage() >= 0 && GetWordPage() <= Words.Count) //判斷 WordPage 是否在範圍內
            {
                List<Button> previousButtons = GetBlock(1).GetButtons(); //取得所有選取文字的 buttons 資料                
                List<Dictionary<string, string>> currentWords = Words[GetWordPage()]; //取得目前頁面的所有文字
                for (int i = 0; i < previousButtons.Count - 2; i++)
                {
                    try
                    {
                        string word = currentWords[i]["unicode"]; //取得該文字unicode資料
                        previousButtons[i + 1].SetText(word); //設定該button的文字
                        previousButtons[i + 1].SetValue(word); //設定該button的值
                    }
                    catch
                    {
                        previousButtons[i + 1].SetText(""); //設定該button的文字
                        previousButtons[i + 1].SetValue(""); //設定該button的值
                    }
                }
            }
            UpdateFunName.Add(GetUpdate("UpdatePageArea", "Word", GetBlock(1).GetButtonsValue()));
        }

        public void InsertPinyin(string str) //注音事件
        {
            SetWordPage(0); //重新設定選取文字頁面為 0
            Words.Clear();   //清除所有文字

            //把被點到的按鈕的text塞進要顯示的text裡
            SetPinyinText(GetPinyinText() + str);

            //多注音切割後分批call SearchWords()
            SearchWords(GetPinyinText()); //帶入全部注音
            
            //重新設定選取文字的 buttons text & value
            List<Button> previousButtons = GetBlock(1).GetButtons(); //取得所有選取文字的 buttons 資料
            if (Words.Count > 0) //Words有資料
            {
                List<Dictionary<string, string>> currentWords = Words[GetWordPage()]; //取得目前頁面的所有文字
                for (int i = 0; i < currentWords.Count; i++)
                {
                    string word = currentWords[i]["unicode"]; //取得該文字unicode資料
                    previousButtons[i + 1].SetText(word); //設定該button的文字
                    previousButtons[i + 1].SetValue(word); //設定該button的值
                }
            }
            else //Words沒有資料
            {
                for (int i = 1; i < previousButtons.Count - 1; i++)
                {
                    previousButtons[i].SetText(""); //設定該button的文字為空
                    previousButtons[i].SetValue(""); //設定該button的值為空
                }
            }
            UpdateFunName.Add(GetUpdate("UpdatePageArea", "Word", GetBlock(1).GetButtonsValue()));
            UpdateFunName.Add(GetUpdate("UpdatePageArea", "PinyinInput", GetPinyinText().Split()));
        }

        public void PinyinChangePage(string page) //輸入注音切換事件
        {
            SetPinyinPage(int.Parse(page));

            List<Button> previusButtons = GetBlock(2).GetButtons(); //取得所有注音的 buttons 資料
            for (int i = 0; i < previusButtons.Count - 1; i++)
            {
                string textValue = Pinyins[GetPinyinPage()][i]; //取得相對應頁數的注音
                previusButtons[i].SetText(textValue); //設定該button的文字
                previusButtons[i].SetValue(textValue); //設定該button的值
            }
            UpdateFunName.Add(GetUpdate("UpdatePageArea", "Pinyin", GetBlock(2).GetButtonsValue()));
        }

        public void PlayVoice()  //播放聲音
        {
            UpdateFunName.Add($"Speak('{GetWordText()}')");
        }

        public void CloseVoice() //關閉聲音
        {
            UpdateFunName.Add("Cancel()");
        } 

        //帶注音
        void SearchWords(string str) //從資料庫找對應的字
        {
            List<Dictionary<string, string>> getWords()
            {
                return DB.Reader(
                        DB.Select("*", "Words", $"pinyinId IN ({DB.Select("id", "Pinyins", $"Text = N'{str}'")}) Order by Usecount DESC"));
            }

            List<Dictionary<string, string>> temps = new List<Dictionary<string, string>>();            

            foreach (Dictionary<string, string> item in getWords())
            {
                temps.Add(item);

                if (temps.Count == 6)
                {                    
                    List<Dictionary<string, string>> copyTemps = new List<Dictionary<string, string>>(temps); // 解決記憶體位置相同，導致 temps 清除時，Words 新增的資料也跟著清除
                    Words.Add(copyTemps);
                    temps.Clear();
                }
            }
            if (temps.Count > 0) Words.Add(temps);
            
        }

        //帶文字的ID或是unicode碼 
        void AddUsecount(string str)//增加文字使用次數
        {
            string pinyinId = DB.Select("pinyinId", "Words", $"pinyinId IN ({DB.Select("id", "Pinyins", $"Text = N'{GetPinyinText()}'")}) and unicode = '{str}'");
            if (!string.IsNullOrEmpty(str))
                DB.Query(
                    DB.Update("Words", "Usecount += 1", $"unicode = '{str}' and pinyinId = ({pinyinId})"));
        }


    }
}