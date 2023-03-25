using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

namespace _1113_t2.Controllers
{
    public class PinyinController : ApiController
    {
        SqlConnection connection = new SqlConnection(
            System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Text2Speache"].ConnectionString;);
        public static SqlCommand command = null;

        public string Get() {
            connection.Open();

            connection.Close();
            return "123";
        }
    }
}
