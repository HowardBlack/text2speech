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
    public class Text2Speach : DB
    {
        public Text2Speach(string DB_Name) : base(DB_Name)
        {
        }

        public List<Dictionary<string, string>> GetWord(string pinyin)
        {
            //Select* from Words where pinyinId IN(Select id from Pinyins where Text = N'ㄨㄛˇ')
            List<Dictionary<string, string>> Words =
                Reader(Select("*", "Words", $"pinyinId IN ({Select("id", "Pinyins", $"Text = N'{pinyin}'")}) Order by Usecount DESC"));

            return Words;
        }

        public void AddUsecount(int id)
        {
            Query(
                Update("Words", "Usecount += 1", $"id = {id}"));
        }
    }
}