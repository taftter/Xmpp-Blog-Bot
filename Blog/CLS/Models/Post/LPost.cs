using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BOT.Models.Post
{
    public class LPost
    {
        BOT.DB.DAL dataaccesslayer = new BOT.DB.DAL();

        private int _id;
        private string _subject;
        private int _likes;
        private string _date;

        public int ID { get { return _id; } set { _id = value; } }
        public string Subject { get { return _subject; } set { _subject = value; } }
        public int Likes { get { return _likes; } set { _likes = value; } }
        public string Date { get { return _date; } set { _date = value; } }

        public LPost()
        {
        }

        public LPost(int id, string subject,int likes,string dt)
        {
            this.ID = id;
            this.Subject = subject;
            this.Likes = likes;
            this.Date = dt;
        }

        public List<LPost> GetPosts(int uID)
        {
            try
            {
                List<LPost> ResLst = new List<LPost>();
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "SELECT id,subject,likes,date from tblPosts where uID=@id";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = uID;
                SqlDataReader dr = dataaccesslayer.executereader(sql);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ResLst.Add(new LPost(Convert.ToInt32(dr.GetValue(0)), dr.GetValue(1).ToString(), Convert.ToInt32(dr.GetValue(2)), dr.GetValue(3).ToString()));
                    }
                    dataaccesslayer.disconnect();
                    return ResLst;
                }
                else
                {
                    ResLst.Add(new LPost(-1, "", 0,""));
                    dataaccesslayer.disconnect();
                    return ResLst;
                }

            }
            catch { return null; }
        }
    }
}
