using _1113_t2.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Windows.Forms;

namespace _1113_t2.Controllers
{
    public class Text2SpeacheController : ApiController
    {
        public static DB DB = new DB("Text2Speache");

        public string Get(string pinyin)
        {
            List<Dictionary<string, string>> Words = GetWords(pinyin);
            return JsonConvert.SerializeObject(Words);
        }

        public bool Update()
        {
            return true;
        }

        List<Dictionary<string, string>> GetWords(string pinyin)
        {
            //Select* from Words where pinyinId IN(Select id from Pinyins where Text = N'ㄨㄛˇ')
            List<Dictionary<string, string>> Words =
                DB.Reader(
                    DB.Select("*", "Words", $"pinyinId IN ({DB.Select("id", "Pinyins", $"Text = N'{pinyin}'")}) Order by Usecount DESC"));

            return Words;
        }

        void AddUsecount(int id)
        {
            DB.Query(
                DB.Update("Words", "Usecount += 1", $"id = {id}"));
        }
    }
}
