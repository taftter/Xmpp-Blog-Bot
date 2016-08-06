using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOT.Models;
using BOT.Models.Comment;
using BOT.Models.Post;

namespace BOT.Controllers
{
    public class CommentController
    {
        public string NewComment(CommentCs cmnt)
        {
            try
            {
                if (cmnt.UID == -1)
                {
                    return "You Are Not Logged in ! Please Login First !";
                }
                else
                {
                    PostCs Pc = new PostCs(cmnt.PID,cmnt.UID,"","",0);
                    if (Pc.isPostExist())
                    {
                        string Result = cmnt.Insert();
                        cmnt.ID = cmnt.GetNewCommentID();
                        return "Done  ! \n , Your New Comment ID : " + cmnt.ID + "\n" + "On Post with ID : " + cmnt.PID + "\n\n" + "Body : " + cmnt.Body;
                    }
                    else
                    {
                        return "Sorry , There is not Any Post with This ID !";
                    }
                }
            }
            catch { return "Some Error Happens !"; }
        }

        public string EditComment(CommentCs cmnt)
        {
            try
            {
                if (cmnt.UID == -1)
                {
                    return "You Are Not Logged in ! Please Login First !";
                }
                else
                {
                    if (cmnt.isCommentExist())
                    {
                        if (cmnt.UID == cmnt.GetCommentUID())
                        {
                            string Result = cmnt.Update();
                            if (Result == "ok")
                            {
                                return "Done !" + "\n" + "Your Edited Comment ID : " + cmnt.ID + "\n\n" + "Body : " + cmnt.Body;
                            }
                            else
                            {
                                return "Some Error Happens !";
                            }
                        }
                        else
                        {
                            return "Sorry , This is Not Your Comment !";
                        }
                    }
                    else
                    {
                        return "Sorry , There is not Any Comment with This ID !";
                    }
                }
            }
            catch { return "Some Error Happens !"; }
        }

        public string DeleteComment(CommentCs cmnt)
        {
            try
            {
                if (cmnt.UID == -1)
                {
                    return "You Are Not Logged in ! Please Login First !";
                }
                else
                {
                    if (cmnt.isCommentExist())
                    {
                        if (cmnt.UID == cmnt.GetCommentUID())
                        {
                            string Result = cmnt.Delete();
                            if (Result == "ok")
                            {
                                return "Done !";
                            }
                            else
                            {
                                return "Some Error Happens !";
                            }
                        }
                        else
                        {
                            return "Sorry , This is Not Your Comment !";
                        }
                    }
                    else
                    {
                        return "Sorry , There is not Any Comment with This ID !";
                    }
                }
            }
            catch { return "Some Error Happens !"; }
        }

        public string LikeComment(int uID,int TargetComment)
        {
            try
            {
                CommentCs Cc = new CommentCs();
                Cc.ID = TargetComment;
                if (BOT.Statics.MainStatics.isLogged(uID) == true)
                {
                    if (Cc.isCommentExist() == true)
                    {
                        CommentLikeCs CL = new CommentLikeCs();
                        CL.uID = uID;
                        CL.cID = TargetComment;
                        if (CL.isCommentLiked() == "no")
                        {
                            if (CL.AddCommentLike() == "ok" && CL.IncreaseLikes() == "ok")
                            {
                                return "Done.";
                            }
                            else
                            {
                                return "Some Error Happens !";
                            }
                        }
                        else if (CL.isCommentLiked() == "yes")
                        {
                            return "You Liked this Comment Before !";
                        }
                        else
                        {
                            return "Some Error Happens !";
                        }
                    }
                    else
                    {
                        return "Sorry , There is not Any Comment with this ID !";
                    }
                }
                else
                {
                    return "You Are Not Logged in ! Please Login First !";
                }
            }
            catch { return ""; }
        }

        public string UnLikeComment(int uID,int TargetComment)
        {
            try
            {
                CommentCs Cc = new CommentCs();
                Cc.ID = TargetComment;
                if (BOT.Statics.MainStatics.isLogged(uID) == true)
                {
                    if (Cc.isCommentExist() == true)
                    {
                        CommentLikeCs CL = new CommentLikeCs();
                        CL.uID = uID;
                        CL.cID = TargetComment;
                        if (CL.isCommentLiked() == "no")
                        {
                            return "You Never Liked this Comment !";
                        }
                        else if (CL.isCommentLiked() == "yes")
                        {
                            if (CL.DeleteCommentLike() == "ok" && CL.DecreaseLikes() == "ok")
                            {
                                return "Done.";
                            }
                            else
                            {
                                return "Some Error Happens !";
                            }
                        }
                        else
                        {
                            return "Some Error Happens !";
                        }
                    }
                    else
                    {
                        return "Sorry , There is not Any Comment with this ID !";
                    }
                }
                else
                {
                    return "You Are Not Logged in ! Please Login First !";
                }
            }
            catch { return ""; }
        }

        public string ShowComments(int id,int pID)
        {
            try
            {
                if (BOT.Statics.MainStatics.isLogged(id) == true)
                {
                    CommentCs opr = new CommentCs();
                    List<CommentCs> Result = opr.GetComments(pID);
                    if (Result == null)
                    {
                        return "Some Error Happens !";
                    }
                    else
                    {
                        string strResult = "List of Comments of Post With ID : " + pID + "\n";
                        int Num = 1;
                        foreach (CommentCs lp in Result)
                        {
                            if (lp.ID == -1)
                            {
                                strResult = "Sorry , There is not Any Comment For this Post !";
                            }
                            else
                            {
                                strResult += Num + ". Comment ID : " + lp.ID + " , Sent By : " + lp.CommentOwnerXmppJid + " ( User ID : " + lp.UID + " ) , Liked " + lp.Likes + " Times." + "\n" + "Body : " + lp.Body + "\n\n";
                                Num++;
                            }
                        }
                        return strResult;
                    }
                }
                else
                {
                    return "You Are Not Logged in ! Please Login First !";
                }
            }
            catch { return "Some Error Happens !"; }
        }

        public string CommentLikers(int id, int cmntID)
        {
            try
            {
                if (BOT.Statics.MainStatics.isLogged(id) == true)
                {
                    LCommentLike opr = new LCommentLike();
                    List<LCommentLike> Result = opr.GetLikers(cmntID);
                    if (Result == null)
                    {
                        return "Some Error Happens !";
                    }
                    else
                    {
                        string strResult = "List of Users Who Liked Comment With ID : " + cmntID + "\n";
                        int Num = 1;
                        foreach (LCommentLike lp in Result)
                        {
                            if (lp.uID == -1)
                            {
                                strResult = "Sorry , Nobody Liked This Comment !";
                            }
                            else
                            {
                                strResult += Num + ". Username : " + lp.LikerXmppJid + " , User ID : " + lp.uID + "\n";
                                Num++;
                            }
                        }
                        return strResult;
                    }
                }
                else
                {
                    return "You Are Not Logged in ! Please Login First !";
                }
            }
            catch { return "Some Error Happens !"; }
        }
    }
}
