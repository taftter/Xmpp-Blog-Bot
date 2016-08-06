using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOT.Statics
{
    public static class MainStatics
    {
        public static List<BOT.Models.User.LoggedUser> LoggedUsers = new List<BOT.Models.User.LoggedUser>();

        public static string Logout(string XmppJid)
        {
            var Result = (from i in LoggedUsers where i.XmppJid == XmppJid select i).FirstOrDefault();
            if (Result == null)
            {
                return "You Are Not Logged in !";
            }
            else
            {
                LoggedUsers.Remove(Result);
                return "You Successfully Logged Out.";
            }
        }

        public static bool isLogged(int id)
        {
            var Result = (from i in LoggedUsers where i.ID == id select i).FirstOrDefault();
            if (Result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static int ReturnUserID(string XmppJid)
        {
            var Result = (from i in LoggedUsers where i.XmppJid == XmppJid select i).FirstOrDefault();
            if (Result == null)
            {
                return -1;
            }
            else
            {
                return Result.ID;
            }
        }

    }
}
