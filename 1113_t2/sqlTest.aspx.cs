using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Collections;

namespace _1113_t2
{
    public partial class sqlTest : System.Web.UI.Page
    {
        public static SqlConnection connection = null;
        public static SqlCommand command = null;

        public static void sqlLink() { //資料庫連線
            string s_data =
            System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Text2Speache"].ConnectionString;
            //從config找到資料庫位置[]內放的是Web.config的connectionStrings的name。
            connection = new SqlConnection(s_data);
            //建立與資料庫建立起連接的通道，以s_data內的連接字串連接所對應的資料庫。
            connection.Open();//開啟通道 
        }

        public static void sqlClose() { //關閉資料庫
            connection.Close();
        }

        public static List<List<string>> Reader() { //回傳reader裡的所有欄位資料
            SqlDataReader reader = command.ExecuteReader();
            List<List<string>> list = new List<List<string>>();

            while (reader.Read()) {
                List<string> temp = new List<string>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    temp.Add(reader[i].ToString());
                }

                list.Add(temp);
                reader.NextResult();
            }        
            
            reader.Close();

            return list;
        }

        public static void Query(string sql) { //執行輸入的sql指令
            command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        public static string Select(string select, string from, string where) { //回傳搜尋的sql
            string sql = "Select " + select + from + where;            
            return sql;
        }

        public static string From(string from) { //在哪裡搜尋
            string sql = "";
            if (from != "") sql = " From " + from;
            return sql;
        }

        public static string Where(string where) { //搜尋條件
            string sql = "";
            if (where != "") sql = " Where " + where;
            return sql;
        }

        public static List<List<string>> Get_Reader(string select, string from, string where) { //得到搜尋結果的陣列
            Query(
                Select(select, 
                From(from), 
                Where(where)
               )
            );

            return Reader();
        }

        [WebMethod]
        public static List<string> Get_Unicode(string pinyin) { //找到對應注音的所有文字的Unicode碼
            List<string> list = new List<string>(); //所查到的全部的字

            List<List<string>> Pinyin = Get_Reader("id", "Pinyin", "pinyinText = N'" + pinyin + "'"); //找到PinyinId
            foreach (var i in Pinyin) //i = Pinyin裡的欄位資料
            {
                List<List<string>> Cns = Get_Reader("id", "Cns", "pinyinId = '" + i[0] + "'"); //找到CnsId

                foreach (var j in Cns) //j = Cns裡的欄位資料
                {
                    List<List<string>> Unicode = Get_Reader("code", "Unicode", "cnsId = '" + j[0] + "'"); //找到CnsId

                    foreach (var k in Unicode)//k = Unicode裡的欄位資料
                    {
                        list.Add(k[0]);
                    }
                }
            }

            return list;
        }

        /* 使用說明
            sqlLink(); //資料庫要先連線
            List<string> list = Get_Unicode(""); //空格裡輸入注音 找到所有對應文字的unicode陣列
            sqlClose(); //資料庫用完要關閉
         */

        protected void Page_Load(object sender, EventArgs e)
        {
            //讓資料庫寫入資料 
            /*sqlLink();

            SqlDataReader reader = null;
            foreach (var a in getData())
            {
                string[] data = a.Split('\t');
                //按順序解開註解寫完一個再重新註解一次後在執行下一個
                Pinyin(data); //第一個
                //Cns(data); //第二個
                //Unicode(data); //第三個
            }
          
            string[] getData() {
                string file1 = System.IO.File.ReadAllText(
                    //@"D:\\project\\eye0312\\eye\\1113_t2\\data\\CNS_phonetic.txt",
                    @"D:\\project\\eye0312\\eye\\1113_t2\\data\\CNS2UNICODE_Unicode BMP.txt",
                    Encoding.GetEncoding("utf-8")).Trim();

                string[] f_array = file1.Split('\n');
                return f_array;
            }

            void _Insert(string sql)
            {
                if (reader != null) reader.Close();
                SqlCommand insert = new SqlCommand(sql, connection);
                insert.ExecuteNonQuery();
            }

            void _Select(string sql)
            {
                if (reader != null) reader.Close();
                SqlCommand select = new SqlCommand(sql, connection);
                select.ExecuteNonQuery();
                reader = select.ExecuteReader();
            }

            void Pinyin(string[] data)
            {
                _Select("select pinyinText from [Pinyin] where pinyinText = N'" + data[1].Trim() + "'");
                if (reader.Read() == false)
                {
                    _Insert("insert into [Pinyin] values(N'" + data[1].Trim() + "')");
                }
            }

            void Cns(string[] data)
            {
                _Insert(
                    "insert into [Cns] values(" +
                    "(select id from Pinyin where pinyinText = N'" + data[1].Trim() + "')," +
                    "'" + data[0].Trim() + "'" +
                    ")");
            }

            void Unicode(string[] data)
            {
                _Select("select id from Cns where code = '" + data[0].Trim() + "'");
                
                if (reader.Read() == true)
                {
                    _Insert(
                    "insert into [Unicode] values("
                    + reader["id"].ToString() + "," +
                    "'" + data[1].Trim() + "'" +
                    ")");
                } 
            }

            sqlClose();*/
        }
    }
}