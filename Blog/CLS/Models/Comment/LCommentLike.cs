using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BOT.Models.Comment
{
    public class LCommentLike
    {
        BOT.DB.DAL dataaccesslayer = new BOT.DB.DAL();

        private int _uID;
        private string _likerXmppJid;

        public int uID { get { return _uID; } set { _uID = value; } }
        public string LikerXmppJid { get { return _likerXmppJid; } set { _likerXmppJid = value; } }

        public LCommentLike()
        {
        }

        public LCommentLike(int usID, string xmpp)
        {
            this.uID = usID;
            this.LikerXmppJid = xmpp;
        }

        public List<LCommentLike> GetLikers(int cmntID)
        {
            try
            {
                List<LCommentLike> ResLst = new List<LCommentLike>();
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "SELECT dbo.tblUsers.xmppJid, dbo.tblCommentLikes.uID FROM dbo.tblCommentLikes INNER JOIN dbo.tblComments ON dbo.tblCommentLikes.cID = dbo.tblComments.id INNER JOIN dbo.tblPosts ON dbo.tblComments.pID = dbo.tblPosts.id INNER JOIN dbo.tblUsers ON dbo.tblCommentLikes.uID = dbo.tblUsers.id where dbo.tblCommentLikes.cID=@id";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = cmntID;
                SqlDataReader dr = dataaccesslayer.executereader(sql);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ResLst.Add(new LCommentLike(Convert.ToInt32(dr.GetValue(1)), dr.GetValue(0).ToString()));
                    }
                    dataaccesslayer.disconnect();
                    return ResLst;
                }
                else
                {
                    dataaccesslayer.disconnect();
                    ResLst.Add(new LCommentLike(-1, ""));
                    return ResLst;
                }

            }
            catch { return null; }
        }
    }
}
