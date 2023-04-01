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
        public static Text2Speach db = new Text2Speach("Text2Speache");

        public string Get(string pinyin)
        {
            List<Dictionary<string, string>> Words = db.GetWord(pinyin);
            return JsonConvert.SerializeObject(Words);
        }

        public bool Update()
        {
            return true;
        }
    }
}
