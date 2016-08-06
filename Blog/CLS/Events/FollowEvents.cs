using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BOT.Events
{
    public class FollowEvents
    {
        BOT.DB.DAL dataaccesslayer = new BOT.DB.DAL();

        private string _xmppJid;
        public string XmppJid { get { return _xmppJid; } set { _xmppJid = value; } }

        public FollowEvents()
        {
        }

        public FollowEvents(string Xmpp)
        {
            this.XmppJid = Xmpp;
        }

        public List<FollowEvents> lst(int id)
        {
            try
            {
                List<FollowEvents> ResLst = new List<FollowEvents>();
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "SELECT dbo.tblUsers.xmppJid FROM dbo.tblFollow INNER JOIN dbo.tblUsers ON dbo.tblFollow.uID = dbo.tblUsers.id where dbo.tblFollow.FlwID=@id";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
                SqlDataReader dr = dataaccesslayer.executereader(sql);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ResLst.Add(new FollowEvents(dr.GetValue(0).ToString()));
                    }
                    dataaccesslayer.disconnect();
                    return ResLst;
                }
                else
                {
                    dataaccesslayer.disconnect();
                    return null;
                }

            }
            catch { return null; }
        }
    }
}
