using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1113_t2.Models
{
    public class Pinyin : Keyboard
    {
        //把API新增一個在這直接在這call


        //初始化
        public Pinyin(int[] dev)
        {
            Deviation = dev;
            //
            ButtonFunName.Add(new string[] { "PinyinDelete()" }); //文字顯示倒退鑑區塊
            ButtonFunName.Add(new string[] { "FontChange()", "InsertText()" }); //文字選取區塊
            ButtonFunName.Add(new string[] { "PinyinClick()" }); //注音區塊
            ButtonFunName.Add(new string[] { "PinyinChange()" }); //注音切換區塊

            SetButtonData();
            SetWords(new List<string[]>());
        }
        //每個區塊的button間的X軸誤差
        int[] Deviation { get; set; }

        //紀錄現在的注音是在哪一頁
        int PinyinPage { get; set; } = 0;
        //注音按鈕的參數
        List<string[]> Pinyins { get; set; } = new List<string[]>() 
        {
            new string[] { "ㄅ", "ㄆ", "ㄇ", "ㄈ", "ㄉ", "ㄊ", "ㄋ" },
            new string[] { "ㄌ", "ㄍ", "ㄎ", "ㄏ", "ㄐ", "ㄑ", "ㄒ" },
            new string[] { "ㄓ", "ㄔ", "ㄕ", "ㄖ", "ㄗ", "ㄘ", "ㄙ" },
            new string[] { "ㄧ", "ㄨ", "ㄩ" },
            new string[] { "ㄚ", "ㄛ", "ㄜ", "ㄝ", "ㄞ", "ㄟ", "ㄠ" },
            new string[] { "ㄡ", "ㄢ", "ㄣ", "ㄤ", "ㄥ", "ㄦ" },
            new string[] { "ˊ", "ˇ", "ˋ", "˙"}
        };

        //紀錄現在的文字是在哪一頁
        int WordPage { get; set; } = 0;
        //文字按鈕的參數
        List<string[]> Words { get; set; } = new List<string[]>();

        //按鈕的fun名稱
        List<string[]> ButtonFunName { get; set; } = new List<string[]>();
        //按鈕的fun參數
        List<List<string[]>> ButtonFunData { get; set; } = new List<List<string[]>>();

        public string Click()
        {
            int fun_name_X = 0;

            int fun_data_X = 0;
            int fun_data_Y = 0;

            int BlockType = GetBlockType();
            int ButtonType = GetButtonType();

            switch (BlockType)
            {
                case 0:  //文字顯示倒退鑑區塊
                    break;
                case 1: //文字選取區塊
                    if (ButtonType > 0 && ButtonType < GetButtonCount() - 1) //因為換頁在第一個跟最後一個所以要判斷他是不是在範圍裡
                    {
                        //文字範圍裡
                        fun_name_X = 1;
                        fun_data_X = WordPage;
                        fun_data_Y = ButtonType;
                    }
                    else
                    {
                        if (ButtonType != 0) //上一頁
                        {
                            if (WordPage > 0) WordPage--;
                            fun_data_X = 0;
                        }
                        else //下一頁
                        {
                            if(WordPage < Words.Count) WordPage++;
                            fun_data_X = Words.Count - 1;
                        }
                    }
                    
                    break;
                case 2://注音區塊
                    fun_data_X = PinyinPage; //用現在的PinyinPage來找是哪一列的資料
                    fun_data_Y = ButtonType; //用ButtonType來找是哪一個字被選到
                    break;
                case 3: //注音切換區塊
                    PinyinPage = ButtonType; //被點選到的話改變現在的PinyinPage只會有0~7固定的
                    break;
                default: break;
            }

            string fun_name = ButtonFunName[BlockType][fun_name_X]; //要呼叫的fun名稱
            string fun_data = ButtonFunData[BlockType][fun_data_X][fun_data_Y];//fun要給的參數 
            string fun = fun_name.Insert(fun_name.Length - 1, fun_data); //結合

            return fun;
        }

        //判斷點擊到的區塊裡有沒有按鈕
        public bool checkClick(double X, double Y)
        {
            void setType()
            {
                CheckBlockType(Y);
                CheckButtonType(X, Deviation[GetBlockType()]);
            }

            setType();

            return GetBlockType() > 0 && GetButtonType() > 0;
        }

        //設定按鈕的fun參數
        void SetButtonData()
        {
            ButtonFunData.Clear();
            ButtonFunData = new List<List<string[]>>() {
                                new List<string[]>() { new string[] { "" } }, //文字顯示倒退鑑 沒有要帶參數所以給空值
                                Words,                                        //文字選取
                                Pinyins,                                      //注音
                                new List<string[]>() { new string[] { "" } }, //注音切換
            };
        }

        //在搜尋的文在換掉時要設定現在的文字
        public void SetWords(List<string[]> temp) 
        {
            Words.Clear();
            Words.Add(new string[] { "-1" });

            foreach (string[] word in temp)
            {
                Words.Add(word);
            }

            Words.Add(new string[] { "1" });

            SetButtonData();
        }
    }
}