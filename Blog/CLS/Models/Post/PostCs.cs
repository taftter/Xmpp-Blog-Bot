using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BOT.Models.Post
{
    public class PostCs
    {
        BOT.DB.DAL dataaccesslayer = new DB.DAL(); 

        private int _id;
        private int _Uid;
        private string _subject;
        private string _body;
        private int _likes;
        private string _ownerXmppJid;

        public int ID { get { return _id; } set { _id = value; } }
        public int UID { get { return _Uid; } set { _Uid = value; } }
        public string Subject { get { return _subject; } set { _subject = value; } }
        public string Body { get { return _body; } set { _body = value; } }
        public int Likes { get { return _likes; } set { _likes = value; } }
        public string OwnerXmppJid { get { return _ownerXmppJid; } set { _ownerXmppJid = value; } }

        ////////////////////////

        public PostCs()
        {
        }

        public PostCs(int id,int uid,string subject,string body,int likes)
        {
            this.ID = id;
            this.UID = uid;
            this.Subject = subject;
            this.Body = body;
            this.Likes = likes;
        }

        ///////////////////////// methods ///////////////////////

        public PostCs Get()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "SELECT dbo.tblPosts.id, dbo.tblPosts.subject, dbo.tblPosts.body, dbo.tblPosts.likes, dbo.tblUsers.id AS userID, dbo.tblUsers.xmppJid FROM dbo.tblPosts INNER JOIN dbo.tblUsers ON dbo.tblPosts.uID = dbo.tblUsers.id where dbo.tblPosts.id = @id";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = this.ID;
                SqlDataReader dr = dataaccesslayer.executereader(sql);
                if (dr.HasRows)
                {
                    PostCs Result = new PostCs();
                    while (dr.Read())
                    {
                        Result.ID = Convert.ToInt32(dr.GetValue(0));
                        Result.Subject = dr.GetValue(1).ToString();
                        Result.Body = dr.GetValue(2).ToString();
                        Result.Likes = Convert.ToInt32(dr.GetValue(3));
                        Result.UID = Convert.ToInt32(dr.GetValue(4));
                        Result.OwnerXmppJid = dr.GetValue(5).ToString();
                    }
                    dataaccesslayer.disconnect();
                    return Result;
                }
                else
                {
                    PostCs Result = new PostCs();
                    Result.ID = -1;
                    dataaccesslayer.disconnect();
                    return Result;
                }
            }
            catch
            {
                PostCs Result = new PostCs();
                Result.ID = -2;
                dataaccesslayer.disconnect();
                return Result;
            }
        }

        public int GetPostUID()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "select uID from tblPosts where id=@id";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = this.ID;
                return Convert.ToInt32(dataaccesslayer.executescaler(sql));
            }
            catch { return -1; }
        }

        public int GetNewPostID()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "select max(id) from tblPosts";
                return Convert.ToInt32(dataaccesslayer.executescaler(sql));
            }
            catch { return -1; }
        }

        public bool isPostExist()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "select count(id) from tblPosts where id=@id";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = this.ID;
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

        public string Insert()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "insert into tblPosts(uID,subject,body,likes,date)values(@uID,@subject,@body,@likes,@date)";
                dataaccesslayer.cmd.Parameters.Add("@uID", SqlDbType.BigInt).Value = this.UID;
                dataaccesslayer.cmd.Parameters.Add("@subject", SqlDbType.NVarChar).Value = this.Subject;
                dataaccesslayer.cmd.Parameters.Add("@body", SqlDbType.NVarChar).Value = this.Body;
                dataaccesslayer.cmd.Parameters.Add("@likes", SqlDbType.BigInt).Value = this.Likes;
                dataaccesslayer.cmd.Parameters.Add("@date", SqlDbType.NVarChar).Value = DateTime.Now.ToString();
                dataaccesslayer.executenonquery(sql);
                return "ok";
            }
            catch { return "error"; }
        }

        public string Update()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "update tblPosts set subject=@subject , body=@body where id=@id";
                dataaccesslayer.cmd.Parameters.Add("@subject", SqlDbType.NVarChar).Value = this.Subject;
                dataaccesslayer.cmd.Parameters.Add("@body", SqlDbType.NVarChar).Value = this.Body;
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = this.ID;
                dataaccesslayer.executenonquery(sql);
                return "ok";
            }
            catch { return "error"; }
        }

        public string Delete()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "delete from tblPosts where id=@id";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = this.ID;
                dataaccesslayer.executenonquery(sql);
                return "ok";
            }
            catch { return "error"; }
        }
    }
}
