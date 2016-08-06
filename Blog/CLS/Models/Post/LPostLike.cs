using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BOT.Models.Post
{
    public class LPostLike
    {
        BOT.DB.DAL dataaccesslayer = new DB.DAL();

        private int _uID;
        private string _likerXmppJid;

        public int uID { get { return _uID; } set { _uID = value; } }
        public string LikerXmppJid { get { return _likerXmppJid; } set { _likerXmppJid = value; } }

        public LPostLike()
        {
        }

        public LPostLike(int usID, string xmpp)
        {
            this.uID = usID;
            this.LikerXmppJid = xmpp;
        }

        public List<LPostLike> GetLikers(int pstID)
        {
            try
            {
                List<LPostLike> ResLst = new List<LPostLike>();
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "SELECT dbo.tblUsers.xmppJid, dbo.tblPostLikes.uID FROM dbo.tblPostLikes INNER JOIN dbo.tblPosts ON dbo.tblPostLikes.pID = dbo.tblPosts.id INNER JOIN dbo.tblUsers ON dbo.tblPostLikes.uID = dbo.tblUsers.id where dbo.tblPostLikes.pID=@id";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = pstID;
                SqlDataReader dr = dataaccesslayer.executereader(sql);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ResLst.Add(new LPostLike(Convert.ToInt32(dr.GetValue(1)), dr.GetValue(0).ToString()));
                    }
                    dataaccesslayer.disconnect();
                    return ResLst;
                }
                else
                {
                    dataaccesslayer.disconnect();
                    ResLst.Add(new LPostLike(-1, ""));
                    return ResLst;
                }

            }
            catch { return null; }
        }
    }
}
