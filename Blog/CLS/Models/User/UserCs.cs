using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BOT.Models.User
{
    public class UserCs
    {
        BOT.DB.DAL dataaccesslayer = new DB.DAL(); 

        private int _id;
        private string _xmppJid;
        private string _password;
        private int _isAdmin;
        private int _flwrNum;
        private int _flwngNum;

        public int ID { get { return _id; } set { _id = value; } }
        public string XmppJid { get { return _xmppJid; } set { _xmppJid = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public int IsAdmin { get { return _isAdmin; } set { _isAdmin = value; } }
        public int FlwrNum { get { return _flwrNum; } set { _flwrNum = value; } }
        public int FlwngNum { get { return _flwngNum; } set { _flwngNum = value; } }

        /////////////

        public UserCs()
        {
        }

        public UserCs(int id,string xmppjid,string password,int isadmin,int flwrnum,int flwngnum)
        {
            this.ID = id;
            this.XmppJid = xmppjid;
            this.Password = password;
            this.IsAdmin = isadmin;
            this.FlwrNum = flwrnum;
            this.FlwngNum = flwngnum;
        }

        ///////////// Methods ////////////

        public UserCs Get()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "select * from tblUsers where id=@id";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = this.ID;
                SqlDataReader dr = dataaccesslayer.executereader(sql);
                if (dr.HasRows)
                {
                    UserCs Result = new UserCs();
                    while (dr.Read())
                    {
                        Result.ID = Convert.ToInt32(dr.GetValue(0));
                        Result.XmppJid = dr.GetValue(1).ToString();
                        Result.Password = dr.GetValue(2).ToString();
                        Result.IsAdmin = Convert.ToInt32(dr.GetValue(3));
                        Result.FlwrNum = Convert.ToInt32(dr.GetValue(4));
                        Result.FlwngNum = Convert.ToInt32(dr.GetValue(5));
                    }
                    dataaccesslayer.disconnect();
                    return Result;
                }
                else
                {
                    UserCs Result = new UserCs();
                    Result.ID = -1;
                    dataaccesslayer.disconnect();
                    return Result;
                }
            }
            catch(Exception x)
            {
                UserCs Result = new UserCs();
                Result.ID = -2;
                dataaccesslayer.disconnect();
                return Result;
            }
        }

        public string ReturnXmppJidByID(int id)
        {
            try
            {
                string Res = "";
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "select xmppJid from tblUsers where id=@id";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                SqlDataReader dr = dataaccesslayer.executereader(sql);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Res = dr.GetValue(0).ToString();
                    }
                }
                dataaccesslayer.disconnect();
                return Res;
            }
            catch { return "error"; }
        }

        public string ReturnIDByXmppJid(string xmpp)
        {
            try
            {
                string Res = "";
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "select id from tblUsers where xmppJid=@xmpp";
                dataaccesslayer.cmd.Parameters.Add("@xmpp", SqlDbType.NVarChar).Value = xmpp;
                SqlDataReader dr = dataaccesslayer.executereader(sql);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Res = dr.GetValue(0).ToString();
                    }
                }
                else
                {
                    Res = "no";
                }
                dataaccesslayer.disconnect();
                return Res;
            }
            catch { return "error"; }
        }

        public List<UserCs> GetList()
        {
            return new List<UserCs>();
        }

        public bool IsIDUserExist()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "select count(id) from tblUsers where id=@id";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = this.ID;
                string Result = dataaccesslayer.executescaler(sql).ToString();
                if (Result == "0" | Result == null)
                {
                    return false;
                }
                else
                { return true; }
            }
            catch { return true; }
        }

        public bool IsXmppJidUserExist()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "select count(xmppJid) from tblUsers where xmppJid=@jid";
                dataaccesslayer.cmd.Parameters.Add("@jid", SqlDbType.NVarChar).Value = this.XmppJid;
                string Result = dataaccesslayer.executescaler(sql).ToString();
                if (Result == "0" | Result == null)
                {
                    return false;
                }
                else
                { return true; }
            }
            catch { return false; }
        }

        public UserCs Login(int id,string username,string password)
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "select * from tblUsers where id=@id and xmppJid=@username and Password=@password";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                dataaccesslayer.cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                dataaccesslayer.cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;
                SqlDataReader dr = dataaccesslayer.executereader(sql);
                if (dr.HasRows)
                {
                    UserCs Result = new UserCs();
                    while (dr.Read())
                    {
                        Result.ID = Convert.ToInt32(dr.GetValue(0));
                        Result.XmppJid = dr.GetValue(1).ToString();
                        Result.Password = dr.GetValue(2).ToString();
                        Result.IsAdmin = Convert.ToInt32(dr.GetValue(3));
                        Result.FlwrNum = Convert.ToInt32(dr.GetValue(4));
                        Result.FlwngNum = Convert.ToInt32(dr.GetValue(5));
                    }
                    dataaccesslayer.disconnect();
                    return Result;
                }
                else
                {
                    UserCs Result = new UserCs();
                    Result.ID = -1;
                    dataaccesslayer.disconnect();
                    return Result;
                }
            }
            catch
            {
                UserCs Result = new UserCs();
                Result.ID = -2;
                dataaccesslayer.disconnect();
                return Result;
            }
        }

        public string Insert()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "insert into tblUsers(id,xmppJid,Password,isAdmin,flwrNum,flwngNum)values(@id,@xmppJid,@Password,@isAdmin,@flwrNum,@flwngNum)";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = this.ID;
                dataaccesslayer.cmd.Parameters.Add("@xmppJid", SqlDbType.NVarChar).Value = this.XmppJid;
                dataaccesslayer.cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = this.Password;
                dataaccesslayer.cmd.Parameters.Add("@isAdmin", SqlDbType.Int).Value = this.IsAdmin;
                dataaccesslayer.cmd.Parameters.Add("@flwrNum", SqlDbType.BigInt).Value = this.FlwrNum;
                dataaccesslayer.cmd.Parameters.Add("@flwngNum", SqlDbType.BigInt).Value = this.FlwngNum;
                dataaccesslayer.executenonquery(sql);
                return "ok";
            }
            catch { return "error"; }
        }

        public string Delete()
        {
            return "ok";
        }
    }
}
