using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOT.Models.User
{
    public class LoggedUser : UserCs
    {

        private int _watchingPostID;
        private int _watchingPostPage;

        private int _watchingCommentID;
        private int _watchingCommentPage;

        public int WatchingPostID { get { return _watchingPostID; } set { _watchingPostID = value; } }
        public int WatchingPostPage { get { return _watchingPostPage; } set { _watchingPostPage = value; } }
        public int WatchingCommentID { get { return _watchingCommentID; } set { _watchingCommentID = value; } }
        public int WatchingCommentPage { get { return _watchingCommentPage; } set { _watchingCommentPage = value; } }


         ///////////////////////////////////
        

        public LoggedUser()
        {
        }

        public LoggedUser(int id, string xmppjid, string password, int isadmin, int flwrnum, int flwngnum)
        {
            this.ID = id;
            this.XmppJid = xmppjid;
            this.Password = password;
            this.IsAdmin = isadmin;
            this.FlwrNum = flwrnum;
            this.FlwngNum = flwngnum;
        }

        ////////////////////// methods ////////////////////////
    }
}
