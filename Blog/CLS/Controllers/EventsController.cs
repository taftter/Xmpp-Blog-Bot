using agsXMPP;
using BOT.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOT.Controllers
{
    public class EventsController
    {
        agsXMPP.XmppClientConnection Client;

        public EventsController()
        {
        }

        public EventsController(agsXMPP.XmppClientConnection clie)
        {
            Client = clie;
        }

        public string UserFollowed(int id)
        {
            BOT.Models.User.UserCs cs = new Models.User.UserCs();
            string Result = cs.ReturnXmppJidByID(id);
            if ( Result == "error")
            {
                return "error";
            }
            else
            {
                return Result;
            }
        }

        public string PostLiked(int id)
        {
            try
            {
                BOT.Events.PostEventsCs PeC = new BOT.Events.PostEventsCs();
                int Res = PeC.LikedPostOwnerUid(id);
                if (Res == -1)
                {
                    return "error";
                }
                else
                {
                    string Result = PeC.LikedPostOwnerXmppJid(Res);
                    return Result;
                }
            }
            catch { return "error"; }
        }

        public string CommentLiked(int id)
        {
            try
            {
                BOT.Events.CommentEventsCs CeC = new Events.CommentEventsCs();
                int Res = CeC.LikedCommentOwnerUid(id);
                if (Res == -1)
                {
                    return "error";
                }
                else
                {
                    string Result = CeC.LikedCommentOwnerXmppJid(Res);
                    return Result;
                }
            }
            catch { return "error"; }
        }

        public string CommentSent(int PstID)
        {
            BOT.Events.CommentEventsCs Cec = new Events.CommentEventsCs();
            int Res = Cec.SentCommentOwnerUID(PstID);
            if (Res != -1)
            {
                string Result = Cec.LikedCommentOwnerXmppJid(Res);
                if (Result != "error")
                {
                    return Result;
                }
                else
                {
                    return "error";
                }
            }
            else
            {
                return "error";
            }
        }

        public void PostSent(int Uid,string user,string subject,string body)
        {
            FollowEvents Fes = new FollowEvents();
            List<FollowEvents> ResLst = Fes.lst(Uid);
            if (ResLst != null)
            {
                BOT.Models.Post.PostCs pst = new Models.Post.PostCs();
                int id = pst.GetNewPostID();
                foreach (FollowEvents cs in ResLst)
                {
                    SendMsg(cs.XmppJid, "event#newpost#" + user.Replace("@chatagent.ir", "") + " ( User ID : " + Uid + " ) Sent a New Post ! \n ( Post ID : " + id + " ) : \n\nPost Subject : " + subject + "\n\n" + "Body : " + body);
                }
            }
        }

        private void SendMsg(string id, string body)
        {
            try
            {
                Client.Send(new agsXMPP.protocol.client.Message { To = new Jid(id), Type = agsXMPP.protocol.client.MessageType.chat, Body = body });
            }
            catch { }
        }
    }
}
