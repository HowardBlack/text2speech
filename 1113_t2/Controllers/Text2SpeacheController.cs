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
        public static Text2Speache db = new Text2Speache();
        public string Get(string data)
        {
            string searchStr = "N" + "'ㄅㄨˇ'";

            var result = (from u in db.Unicodes
                          join c in db.Cns on u.cnsId equals c.Id
                          join p in db.Pinyins on c.pinyinId equals p.Id
                          where p.pinyinText.StartsWith(searchStr)
                          select u).ToList();

            return "123";
            /*SELECT Unicode.*
FROM Unicode
JOIN CNS ON Unicode.cnsId = CNS.id
JOIN Pinyin ON CNS.pinyinId = Pinyin.id
WHERE Pinyin.id = 515*/

            //var db = new Text2Speache();
            //var model = db.Pinyins.Where(m => m.Id == data).ToList();
            /*var temp = '"' + data + '"';
            List<Unicode> results = (from u in db.Unicodes
                                     join c in db.Cns on u.cnsId equals c.Id
                                     join p in db.Pinyins on c.pinyinId equals p.Id
                                     where p.pinyinText == "\"ㄨㄛˇ\""
                                     select u).ToList();


            string temp2 = "ㄨㄛˇ";
            var query = (from p in db.Pinyins
                         where p.pinyinText.StartsWith("N" + temp2)
                         select p).ToList();

            string jsonResult = JsonConvert.SerializeObject(results);

            return jsonResult;*/
        }

        public bool Update()
        {
            return true;
        }
    }
}
