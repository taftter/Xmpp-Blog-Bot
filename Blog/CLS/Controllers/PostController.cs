using BOT.Models;
using BOT.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOT.Controllers
{
    public class PostController
    {
        public string NewPost(PostCs pst)
        {
            try
            {
                if (pst.UID == -1)
                {
                    return "You Are Not Logged in ! Please Login First !";
                }
                else
                {
                    string Result = pst.Insert();
                    pst.ID = pst.GetNewPostID();
                    return "Done ! \n , Your New Post ID : " + pst.ID + "\n" + "Your New Post : \n\n" + "Subject : " + pst.Subject + "\n\n" + "Body : " + pst.Body;
                }
            }
            catch { return "Some Error Happens !"; }
        }

        public string EditPost(PostCs pst)
        {
            try
            {
                if (pst.UID == -1)
                {
                    return "You Are Not Logged in ! Please Login First !";
                }
                else
                {
                    if (pst.isPostExist() == false)
                    {
                        return "Sorry , There is not Any Post with This ID !";
                    }
                    else
                    {
                        if (pst.UID == pst.GetPostUID())
                        {
                            string Result = pst.Update();
                            if (Result == "ok")
                            {
                                return "Done ! \n" + "\n" + "Your Edited Post : \n\n" + "Subject : " + pst.Subject + "\n\n" + "Body : " + pst.Body;
                            }
                            else
                            {
                                return "Some Error Happens !";
                            }
                        }
                        else
                        {
                            return "Sorry , This is Not Your Post !";
                        }
                    }
                }
            }
            catch { return "Some Error Happens !"; }
        }

        public string DeletePost(PostCs pst)
        {
            try
            {
                if (pst.UID == -1)
                {
                    return "You Are Not Logged in ! Please Login First !";
                }
                else
                {
                    if (pst.isPostExist() == false)
                    {
                        return "Sorry , There is not Any Post with This ID !";
                    }
                    else
                    {
                        if (pst.UID == pst.GetPostUID())
                        {
                            string Result = pst.Delete();
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
                            return "Sorry , This is Not Your Post !";
                        }
                    }
                }
            }
            catch { return "Some Error Happens !"; }
        }

        public string LikePost(int uID, int TargetPost)
        {
            try
            {
                PostCs Pc = new PostCs();
                Pc.ID = TargetPost;
                if (BOT.Statics.MainStatics.isLogged(uID) == true)
                {
                    if (Pc.isPostExist() == true)
                    {
                        PostLikeCs PL = new PostLikeCs();
                        PL.uID = uID;
                        PL.pID = TargetPost;
                        if (PL.isPostLiked() == "no")
                        {
                            if (PL.AddPostLike() == "ok" && PL.IncreaseLikes() == "ok")
                            {
                                return "Done.";
                            }
                            else
                            {
                                return "Some Error Happens !";
                            }
                        }
                        else if (PL.isPostLiked() == "yes")
                        {
                            return "You Liked this Post Before !";
                        }
                        else
                        {
                            return "Some Error Happens !";
                        }
                    }
                    else
                    {
                        return "Sorry , There is not Any Post with this ID !";
                    }
                }
                else
                {
                    return "You Are Not Logged in ! Please Login First !";
                }
            }
            catch { return ""; }
        }

        public string UnLikePost(int uID, int TargetPost)
        {
            try
            {
                PostCs Pc = new PostCs();
                Pc.ID = TargetPost;
                if (BOT.Statics.MainStatics.isLogged(uID) == true)
                {
                    if (Pc.isPostExist() == true)
                    {
                        PostLikeCs PL = new PostLikeCs();
                        PL.uID = uID;
                        PL.pID = TargetPost;
                        if (PL.isPostLiked() == "no")
                        {
                            return "You Never Liked this Post !";
                        }
                        else if (PL.isPostLiked() == "yes")
                        {
                            if (PL.DeletePostLike() == "ok" && PL.DecreaseLikes() == "ok")
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
                        return "Sorry , There is not Any Post with this ID !";
                    }
                }
                else
                {
                    return "You Are Not Logged in ! Please Login First !";
                }
            }
            catch { return ""; }
        }

        public string ViewPosts(int id, int uID)
        {
            try
            {
                if (BOT.Statics.MainStatics.isLogged(id) == true)
                {
                    LPost opr = new LPost();
                    List<LPost> Result = opr.GetPosts(uID);
                    if (Result == null)
                    {
                        return "Some Error Happens !";
                    }
                    else
                    {
                        string strResult = "List of Subject of User Posts : \n";
                        int Num = 1;
                        foreach (LPost lp in Result)
                        {
                            if (lp.ID == -1)
                            {
                                return "This User Have Not Any Post Yet !";
                            }
                            else
                            {
                                strResult += Num + ".Post ID : " + lp.ID + " , Subject : " + lp.Subject + " , Liked " + lp.Likes + " Times." + " Date : " + lp.Date + "\n";
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

        public string ShowPost(int id, int pID)
        {
            try
            {
                if (BOT.Statics.MainStatics.isLogged(id) == true)
                {
                    PostCs temp = new PostCs(pID, 0, "", "", 0);
                    PostCs Result = temp.Get();
                    if (Result.ID == -2)
                    {
                        return "Some Error Happens !";
                    }
                    else if (Result.ID == -1)
                    {
                        return "There is Not Any Post With this ID !";
                    }
                    else
                    {
                        return "Post Details : \n" + "Post ID : " + pID + "\n\n" + "Subject : " + Result.Subject + "\n\n" + "Body : " + Result.Body + "\n\n" + "Likes : " + Result.Likes + "\n\n" + "Post Owner : " + Result.OwnerXmppJid + " ( User ID : " + Result.UID + " )";
                    }
                }
                else
                {
                    return "You Are Not Logged in ! Please Login First !";
                }
            }
            catch { return "Some Error Happens !"; }
        }

        public string PostLikers(int id, int pID)
        {
            try
            {
                if (BOT.Statics.MainStatics.isLogged(id) == true)
                {
                    LPostLike opr = new LPostLike();
                    List<LPostLike> Result = opr.GetLikers(pID);
                    if (Result == null)
                    {
                        return "Some Error Happens !";
                    }
                    else
                    {
                        string strResult = "List of Users Who Liked Post With ID : " + pID + "\n";
                        int Num = 1;
                        foreach (LPostLike lp in Result)
                        {
                            if (lp.uID == -1)
                            {
                                strResult = "Sorry , Nobody Liked This Post !";
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
