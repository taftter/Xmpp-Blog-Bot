using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BOT.Events
{
    public class PostEventsCs
    {
        BOT.DB.DAL dataaccesslayer = new BOT.DB.DAL();

        public int LikedPostOwnerUid(int id)
        {
            try
            {
                int Res = -1;
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "select uID from tblPosts where id=@id";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                SqlDataReader dr = dataaccesslayer.executereader(sql);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Res = Convert.ToInt32(dr.GetValue(0));
                    }
                }
                dataaccesslayer.disconnect();
                return Res;
            }
            catch { return -1; }
        }

        public string LikedPostOwnerXmppJid(int id)
        {
            try
            {
                string Res = "error";
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
    }
}
