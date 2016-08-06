using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BOT.Models.Comment
{
    public class CommentLikeCs
    {
        BOT.DB.DAL dataaccesslayer = new DB.DAL();

        private int _id;
        private int _uID;
        private int _cID;
        private int _lID;

        public int ID { get { return _id; } set { _id = value; } }
        public int uID { get { return _uID; } set { _uID = value; } }
        public int cID { get { return _cID; } set { _cID = value; } }
        public int LID { get { return _lID; } set { _lID = value; } }

        public string AddCommentLike()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "insert into tblCommentLikes(uID,cID)values(@uid,@cid)";
                dataaccesslayer.cmd.Parameters.Add("@uid", SqlDbType.BigInt).Value = this.uID;
                dataaccesslayer.cmd.Parameters.Add("@cid", SqlDbType.BigInt).Value = this.cID;
                dataaccesslayer.executenonquery(sql);
                return "ok";
            }
            catch { return "error"; }
        }

        public string DeleteCommentLike()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "delete from tblCommentLikes where uID=@uid and cID=@cid)";
                dataaccesslayer.cmd.Parameters.Add("@uid", SqlDbType.BigInt).Value = this.uID;
                dataaccesslayer.cmd.Parameters.Add("@cid", SqlDbType.BigInt).Value = this.cID;
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
                string sql = "update tblComments set likes = ((select likes from tblComments where id=@id)+1 ) where id=@uid";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = this.cID;
                dataaccesslayer.cmd.Parameters.Add("@uid", SqlDbType.BigInt).Value = this.cID;
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
                string sql = "update tblComments set likes = ((select likes from tblComments where id=@id)-1 ) where id=@uid";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = this.cID;
                dataaccesslayer.cmd.Parameters.Add("@uid", SqlDbType.BigInt).Value = this.cID;
                dataaccesslayer.executenonquery(sql);
                return "ok";
            }
            catch { return "error"; }
        }

        public string isCommentLiked()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "select count(id) from tblCommentLikes where uID=@uid and cID=@cID";
                dataaccesslayer.cmd.Parameters.Add("@uid", SqlDbType.BigInt).Value = this.uID;
                dataaccesslayer.cmd.Parameters.Add("@cID", SqlDbType.BigInt).Value = this.cID;
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
