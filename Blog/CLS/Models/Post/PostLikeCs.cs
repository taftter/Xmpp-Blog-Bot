using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BOT.Models.Post
{
    public class PostLikeCs
    {
        BOT.DB.DAL dataaccesslayer = new DB.DAL();

        private int _id;
        private int _uID;
        private int _pID;
        private int _lID;
        private string _likerXmppJid;

        public int ID { get { return _id; } set { _id = value; } }
        public int uID { get { return _uID; } set { _uID = value; } }
        public int pID { get { return _pID; } set { _pID = value; } }
        public int LID { get { return _lID; } set { _lID = value; } }
        public string LikerXmppJid { get { return _likerXmppJid; } set { _likerXmppJid = value; } }

        public string AddPostLike()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "insert into tblPostLikes(uID,pID)values(@uid,@pid)";
                dataaccesslayer.cmd.Parameters.Add("@uid", SqlDbType.BigInt).Value = this.uID;
                dataaccesslayer.cmd.Parameters.Add("@pid", SqlDbType.BigInt).Value = this.pID;
                dataaccesslayer.executenonquery(sql);
                return "ok";
            }
            catch { return "error"; }
        }

        public string DeletePostLike()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "delete from tblPostLikes where uID=@uid and pID=@pid";
                dataaccesslayer.cmd.Parameters.Add("@uid", SqlDbType.BigInt).Value = this.uID;
                dataaccesslayer.cmd.Parameters.Add("@pid", SqlDbType.BigInt).Value = this.pID;
                dataaccesslayer.executenonquery(sql);
                return "ok";
            }
            catch { return "error"; }
        }

        public string IncreaseLikes()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "update tblPosts set likes = ((select likes from tblPosts where id=@id)+1 ) where id=@uid";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = this.pID;
                dataaccesslayer.cmd.Parameters.Add("@uid", SqlDbType.BigInt).Value = this.pID;
                dataaccesslayer.executenonquery(sql);
                return "ok";
            }
            catch { return "error"; }
        }

        public string DecreaseLikes()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "update tblPosts set likes = ((select likes from tblPosts where id=@id)-1 ) where id=@uid";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = this.pID;
                dataaccesslayer.cmd.Parameters.Add("@uid", SqlDbType.BigInt).Value = this.pID;
                dataaccesslayer.executenonquery(sql);
                return "ok";
            }
            catch { return "error"; }
        }

        public string isPostLiked()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "select count(id) from tblPostLikes where uID=@uid and pID=@pID";
                dataaccesslayer.cmd.Parameters.Add("@uid", SqlDbType.BigInt).Value = this.uID;
                dataaccesslayer.cmd.Parameters.Add("@pID", SqlDbType.BigInt).Value = this.pID;
                string Result = dataaccesslayer.executescaler(sql).ToString();
                if (Result == "0" | Result == null)
                {
                    return "no";
                }
                else
                {
                    return "yes";
                }
            }
            catch { return "error"; }
        }
    }
}
