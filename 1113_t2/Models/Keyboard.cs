using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1113_t2.Models
{
    public class Keyboard
    {
        //要再改 先用最簡單的方式來判斷

        public Keyboard() 
        {
            //輸入最多的button是多少個
            //y Zone {{ min, max}, }
            //x Zone  {{ min, max}, }
        }
        int ButtonCount { get; set; } = 8;

        int BlockType { get; set; } = -1; //文字顯示倒退鑑區塊 1文字選取區塊 2注音區塊 3注音切換區塊

        int ButtonType { get; set; } = -1; //用來當作判斷現在被按的按鈕是哪個的索引

        public int GetButtonCount() { return ButtonCount; }

        public int GetBlockType() { return BlockType; }

        public void CheckBlockType(double Y) //用 Y軸座標 來判斷現在在哪個區塊
        {
            //改成用for來判斷
            switch (Y)
            {
                case double t when (t >= 0 && t < 10): //文字顯示倒退鑑區塊 y軸的範圍
                    SetBlockTyep(0);
                    break;

                case double t when (t >= 0 && t < 10): //文字選取區塊 y軸的範圍
                    SetBlockTyep(1);
                    break;

                case double t when (t >= 0 && t < 10): //注音區塊 y軸的範圍
                    SetBlockTyep(2);
                    break;

                case double t when (t >= 0 && t < 10): //注音切換區塊 y軸的範圍
                    SetBlockTyep(3);
                    break;

                default:
                    SetBlockTyep(-1);
                    break;
            }
        }

        void SetBlockTyep(int type) { BlockType = type; }

        public int GetButtonType() { return ButtonType; }

        public void CheckButtonType(double X, int deviation) // 用 X軸座標 - 誤差值 來判斷現在在哪個按鈕
        {
            void checkBlockType(int ButtonType) {
                switch (BlockType)
                {
                    case 0: //文字顯示倒退鑑區塊 只有一個按鈕所以都是零
                        SetButtonType(0);
                        break;
                    case 1: //文字選取區塊 注音區塊 注音切換區塊 按鈕數量一致可以一起判斷
                    case 2: 
                    case 3:
                        SetButtonType(ButtonType);
                        break;
                }
            }

            //改成用for來判斷
            switch (X)
            {
                case double t when (t - deviation >= 0 && t - deviation < 10): //第一個要判斷的按鈕 x軸的範圍
                    checkBlockType(0);
                    break;
                case double t when (t - deviation >= 0 && t - deviation < 10): 
                    checkBlockType(1);
                    break;

                case double t when (t - deviation >= 0 && t - deviation < 10):
                    checkBlockType(2);
                    break;

                case double t when (t - deviation >= 0 && t - deviation < 10):
                    checkBlockType(3);
                    break;

                case double t when (t - deviation >= 0 && t - deviation < 10):
                    checkBlockType(4);
                    break;

                case double t when (t - deviation >= 0 && t - deviation < 10):
                    checkBlockType(5);
                    break;

                case double t when (t - deviation >= 0 && t - deviation < 10):
                    checkBlockType(6);
                    break;

                case double t when (t - deviation >= 0 && t - deviation < 10):
                    checkBlockType(7);
                    break;

                default:
                    SetButtonType(-1);
                    break;
            }
        }
        
        void SetButtonType(int type) { ButtonType = type; }
    }
}