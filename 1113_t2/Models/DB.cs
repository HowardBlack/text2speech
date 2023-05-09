using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace _1113_t2.Models
{
    public class DB
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }

        public DB(string DB_Name) { 
            Connection = new SqlConnection(
                System.Web.Configuration.WebConfigurationManager.ConnectionStrings[DB_Name].ConnectionString);
        }

        public void Query(string sql) //執行
        {
            Connection.Open();
            Command = new SqlCommand(sql, Connection);
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public List<Dictionary<string, string>> Reader(string sql) //取得資料
        {
            Connection.Open();
            Command = new SqlCommand(sql, Connection);
            Command.ExecuteNonQuery();

            SqlDataReader reader = Command.ExecuteReader();
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();

            DataTable schemaTable = reader.GetSchemaTable();

            while (reader.Read())
            {
                Dictionary<string, string> temp = new Dictionary<string, string>();

                foreach (DataRow row in schemaTable.Rows)
                {
                    string columnName = (string)row["ColumnName"];
                    string columnValue = reader[columnName].ToString();
                    temp.Add(columnName, columnValue);
                }

                list.Add(temp);
            }

            reader.Close();
            Connection.Close();

            return list;
        }

        public string Insert() //新增資料
        {
            return "";
        }

        public string Select(string select, string from, string where) //搜尋資料
        {
            string sql = "Select " + select + From(from) + Where(where);
            return sql;
        }

        public string Update(string from, string set, string where) //更新資料
        {
            string sql = "UPDATE " + from + " SET " + set + Where(where);
            return sql;
        }

        public string Delete() //刪除資料
        {
            return "";
        }

        string From(string from) //哪裡
        {
            string sql = "";
            if (from != "") sql = " From " + from;
            return sql;
        }

        string Where(string where) //條件
        {
            string sql = "";
            if (where != "") sql = " Where " + where;
            return sql;
        }
    }
}