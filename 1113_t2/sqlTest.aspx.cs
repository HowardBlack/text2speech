﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;
using System.Text;

namespace _1113_t2
{
    public partial class sqlTest : System.Web.UI.Page
    {
        public static SqlConnection connection = null;
        public static SqlCommand command = null;

        public static void SqlLink()
        { //資料庫連線
            string s_data =
            System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Text2Speache"].ConnectionString;
            //從config找到資料庫位置[]內放的是Web.config的connectionStrings的name。
            connection = new SqlConnection(s_data);
            //建立與資料庫建立起連接的通道，以s_data內的連接字串連接所對應的資料庫。
            connection.Open();//開啟通道 
        }

        public static void SqlClose()
        { //關閉資料庫
            connection.Close();
        }

        public static List<List<string>> Reader(string sql)
        { //回傳reader裡的所有欄位資料
            Query(sql);
            SqlDataReader reader = command.ExecuteReader();
            List<List<string>> list = new List<List<string>>();

            DataTable schemaTable = reader.GetSchemaTable();

            while (reader.Read())
            {
                List<string> temp = new List<string>();

                foreach (DataRow row in schemaTable.Rows)
                {
                    string columnName = (string)row["ColumnName"];
                    string columnValue = reader[columnName].ToString();
                    temp.Add(columnValue);
                }

                list.Add(temp);
            }

            reader.Close();
            return list;
        }

        public static void Query(string sql)
        { //執行輸入的sql指令
            command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        public static string Select(string select, string from, string where)
        { //回傳搜尋的sql
            string sql = "Select " + select + from + where;
            return sql;
        }

        public static string From(string from)
        { //在哪裡搜尋
            string sql = "";
            if (from != "") sql = " From " + from;
            return sql;
        }

        public static string Where(string where)
        { //搜尋條件
            string sql = "";
            if (where != "") sql = " Where " + where;
            return sql;
        }

        [WebMethod]
        public static List<string> Get_Unicode(string pinyin)
        { //找到對應注音的所有文字的Unicode碼
            SqlLink();
            List<string> list = new List<string>(); //所查到的全部的字

            List<List<string>> Pinyin = Reader(
                Select("id",
                From("Pinyin"),
                Where("pinyinText = N'" + pinyin + "'"))); //找到PinyinId

            foreach (var i in Pinyin) //i = Pinyin裡的欄位資料
            {
                List<List<string>> Cns = Reader(
                                            Select("id",
                                            From("Cns"),
                                            Where("pinyinId = '" + i[0] + "'")));//找到CnsId

                foreach (var j in Cns) //j = Cns裡的欄位資料
                {
                    List<List<string>> Unicode = Reader(
                                                    Select("distinct code",
                                                    From("Unicode"),
                                                    Where("cnsId = '" + j[0] + "'"))); //找到Unicode

                    foreach (var k in Unicode)//k = Unicode裡的欄位資料
                    {
                        list.Add(k[0]);
                    }
                }
            }

            SqlClose();

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
            SqlLink();

            SqlDataReader reader = null;

            string file1 = null;
            string[] f_array;

            file1 = System.IO.File.ReadAllText(
                    @"D:\\text2speech\\1113_t2\\data\\CNS_phonetic.txt",
                    Encoding.GetEncoding("utf-8")).Trim();
            f_array = file1.Split('\n');

            foreach (var a in f_array)
            {
                string[] data = a.Split('\t');
                Pinyin(data);
            }

            file1 = System.IO.File.ReadAllText(
                    @"D:\\text2speech\\1113_t2\\data\\CNS2UNICODE_Unicode BMP.txt",
                    Encoding.GetEncoding("utf-8")).Trim();
            f_array = file1.Split('\n');

            foreach (var a in f_array)
            {
                string[] data = a.Split('\t');
                Words(data);
            }

            void _Insert(string sql)
            {
                if(reader != null) reader.Close();
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
                _Insert("insert into [Pinyins] values(N'" + data[1].Trim() + "', '" + data[0].Trim() + "')");
            }

            void Words(string[] data)
            {
                _Select($"select id from Pinyins where Cns = '{data[0].Trim()}'");
                //_Select($"select id from Pinyins where Cns = '1-4A3C'");
               
                var list = new List<string>();

                while (reader.Read())
                {
                    list.Add(reader["id"].ToString());
                }

                foreach (var a in list)
                {
                    _Insert($"insert into [Words] values({a}, '{data[1].Trim()}', 0)");
                }
                
            }

            SqlClose();
        }
    }
}