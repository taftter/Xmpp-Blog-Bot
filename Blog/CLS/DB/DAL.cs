using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace BOT.DB
{
    public class DAL
    {
        //SERVER=.;DATABASE=smhp;Integrated Security=True
        //string Connection = @"server=.\SQLEXPRESS;AttachDBFilename=|DataDirectory|Blog.mdf;User Instance=true;integrated security=true";
        string Connection = @"SERVER=WIN-1BYLDTJ6IIG\SQLEXPRESS;DATABASE=Blog;Integrated Security=True";
        //string Connection = @"SERVER=.;DATABASE=Blog;Integrated Security=True";
        SqlConnection con;
        public SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public DAL()
        {
            con = new SqlConnection();
            con.ConnectionString = Connection;
            cmd = new SqlCommand();
            cmd.Connection = con;
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            dt = new DataTable();
        }
        void connect()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void disconnect()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public string executescaler(string sql)
        {
            string result = "";
            cmd.CommandText = sql;
            connect();
            try
            {
                result = cmd.ExecuteScalar().ToString();
            }
            catch
            {
                result = null;
            }
            disconnect();
            return result;
        }
        ////////////////method baraye insert,delete,update
        public string executenonquery(string sql)
        {
            string result = "";
            cmd.CommandText = sql;
            connect();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                result = "خطا در بانک";
            }
            disconnect();
            return result;
        }
        ///////////////method baraye select//////////
        public DataTable select(string sql)
        {
            connect();
            da.SelectCommand.Connection = con;
            da.SelectCommand.CommandText = sql;
            try
            {
                da.SelectCommand.ExecuteReader();
            }
            catch
            {
                da = null;
            }
            disconnect();
            da.Fill(dt);
            return dt;
        }
        public DataTable ExecuteReader_datatable(string Query)
        {
            connect();
            da.SelectCommand.Connection = con;
            da.SelectCommand.CommandText = Query;
            try
            {
                da.SelectCommand.ExecuteReader();
            }
            catch
            {
                da = null;
            }
            disconnect();
            da.Fill(dt);
            return dt;
        }

        public SqlDataReader executereader(string sql)
        {
            SqlDataReader DATAREADER = null;
            cmd.CommandText = sql;
            connect();
            try
            {
                DATAREADER = cmd.ExecuteReader();
            }
            catch
            {

            }
            return DATAREADER;
        }

    }

}