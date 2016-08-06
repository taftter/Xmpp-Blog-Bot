using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BOT.Models.Comment
{
    public class CommentCs
    {
        BOT.DB.DAL dataaccesslayer = new BOT.DB.DAL(); 

        private int _id;
        private int _Uid;
        private int _pID;
        private string _body;
        private int _likes;
        private string _commentOwnerXmppjid;

        public int ID { get { return _id; } set { _id = value; } }
        public int UID { get { return _Uid; } set { _Uid = value; } }
        public int PID { get { return _pID; } set { _pID = value; } }
        public string Body { get { return _body; } set { _body = value; } }
        public int Likes { get { return _likes; } set { _likes = value; } }
        public string CommentOwnerXmppJid { get { return _commentOwnerXmppjid; } set { _commentOwnerXmppjid = value; } }

        /////////////////////////////////////

        public CommentCs()
        {
        }

        public CommentCs(int id,int uid,int pid,string body,int likes,string xmpp)
        {
            this.ID = id;
            this.UID = uid;
            this.PID = pid;
            this.Body = body;
            this.Likes = likes;
            this.CommentOwnerXmppJid = xmpp;
        }

        ////////////////////////////////// Methods //////////////////////

        public List<CommentCs> GetComments(int pstID)
        {
            try
            {
                List<CommentCs> ResLst = new List<CommentCs>();
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "SELECT dbo.tblComments.id, dbo.tblComments.uID, dbo.tblUsers.xmppJid,dbo.tblComments.body,dbo.tblComments.likes FROM dbo.tblComments INNER JOIN dbo.tblPosts ON dbo.tblComments.pID = dbo.tblPosts.id INNER JOIN dbo.tblUsers ON dbo.tblComments.uID = dbo.tblUsers.id where dbo.tblComments.pID = @id";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = pstID;
                SqlDataReader dr = dataaccesslayer.executereader(sql);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ResLst.Add(new CommentCs(Convert.ToInt32(dr.GetValue(0)), Convert.ToInt32(dr.GetValue(1)), 0, dr.GetValue(3).ToString(), Convert.ToInt32(dr.GetValue(4)), dr.GetValue(2).ToString()));
                    }
                    dataaccesslayer.disconnect();
                    return ResLst;
                }
                else
                {
                    dataaccesslayer.disconnect();
                    ResLst.Add(new CommentCs(-1, -1, -1, "", -1, ""));
                    return ResLst;
                }
            }
            catch { return null; }
        }

        public int GetCommentUID()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "select uID from tblComments where id=@id";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = this.ID;
                return Convert.ToInt32(dataaccesslayer.executescaler(sql));
            }
            catch { return -1; }
        }

        public int GetNewCommentID()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "select max(id) from tblComments";
                return Convert.ToInt32(dataaccesslayer.executescaler(sql));
            }
            catch { return -1; }
        }

        public bool isCommentExist()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "select count(id) from tblComments where id=@id";
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
                string sql = "insert into tblComments(uID,pID,body,likes)values(@uID,@pid,@body,@likes)";
                dataaccesslayer.cmd.Parameters.Add("@uID", SqlDbType.BigInt).Value = this.UID;
                dataaccesslayer.cmd.Parameters.Add("@pid", SqlDbType.BigInt).Value = this.PID;
                dataaccesslayer.cmd.Parameters.Add("@body", SqlDbType.NVarChar).Value = this.Body;
                dataaccesslayer.cmd.Parameters.Add("@likes", SqlDbType.BigInt).Value = this.Likes;
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
                string sql = "update tblComments set body=@body where id=@id";
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
                string sql = "delete from tblComments where id=@id";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = this.ID;
                dataaccesslayer.executenonquery(sql);
                return "ok";
            }
            catch { return "error"; }
        }
    }
}
