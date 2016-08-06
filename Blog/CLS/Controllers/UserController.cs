using BOT.Models;
using BOT.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOT.Controllers
{
    public class UserController
    {
        public string Register(UserCs usr)
        {
            try
            {
                if (usr.IsIDUserExist() == false)
                {
                    if (usr.IsXmppJidUserExist() == false)
                    {
                        if (usr.Insert() == "ok")
                        {
                            return "Thank you for your registration , This is Your Login info : \n\n   " + "ID : " + usr.ID + "\n   Password : " + usr.Password + "\n\n" + "Please Remember Your Login INFO , We Cant Help if You Forget it ! \n Use this Command For Login : \n .login/ID/Password";
                        }
                        else if (usr.Insert() == "error")
                        {
                            return "Some Error Happens !";
                        }
                        else
                        {
                            return "Some Error Happens !";
                        }
                    }
                    else
                    {
                        return "Sorry, Your Username is Already Registered.";
                    }
                }
                else
                {
                    return "Sorry, This ID is Already Taken.";
                }
            }
            catch (Exception x)
            {
                return x.Message;
            }
        }

        public string Login(int id, string username, string password)
        {
            try
            {
                UserCs Cs = new UserCs();
                UserCs Result = new UserCs();
                Result = Cs.Login(id, username, password);
                if (Result.ID == -2)
                {
                    return "Some Error Happens !";
                }
                else if (Result.ID == -1)
                {
                    return "Invalid ID or Password ! Or Maybe This XmppJid , Is Not Your XmppJid That You Registered With it !";
                }
                else
                {
                    BOT.Statics.MainStatics.LoggedUsers.Add(new LoggedUser(Result.ID, Result.XmppJid, Result.Password, Result.IsAdmin, Result.FlwrNum, Result.FlwrNum));
                    return "You Successfully logged in.";
                }
            }
            catch (Exception x)
            {
                return x.Message;
            }
        }

        public string Follow(int uID,int targetID)
        {
            UserCs Cs = new UserCs();
            Cs.ID = targetID;
            if (BOT.Statics.MainStatics.isLogged(uID) == true)
            {
                if (Cs.IsIDUserExist() == true)
                {
                    FollowCs flw = new FollowCs(0, uID, targetID);
                    if (flw.isFollowed() == "no")
                    {
                        if (flw.AddFollow() == "ok" && flw.IncreaseFlwngs() == "ok" && flw.IncreaseFlwrs() == "ok")
                        {
                            return "Done.";
                        }
                        else
                        {
                            return "Some Error Happens !";
                        }
                    }
                    else if (flw.isFollowed() == "yes")
                    {
                        return "You Followed this User Before !";
                    }
                    else
                    {
                        return "Some Error Happens !";
                    }
                }
                else
                {
                    return "Sorry , There is not Any User with this ID !";
                }
            }
            else
            {
                return "You Are Not Logged in ! Please Login First !";
            }
        }

        public string UnFollow(int uID, int targetID)
        {
            UserCs Cs = new UserCs();
            Cs.ID = targetID;
            if (BOT.Statics.MainStatics.isLogged(uID) == true)
            {
                if (Cs.IsIDUserExist() == true)
                {
                    FollowCs flw = new FollowCs(0, uID, targetID);
                    if (flw.isFollowed() == "no")
                    {
                        return "You Never Followed this User !";
                    }
                    else if (flw.isFollowed() == "yes")
                    {
                        if (flw.RemoveFollow() == "ok" && flw.DecreaseFlwngs() == "ok" && flw.DecreaseFlwrs() == "ok")
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
                    return "Sorry , There is not Any User with this ID !";
                }
            }
            else
            {
                return "You Are Not Logged in ! Please Login First !";
            }
        }

        public string Find(string XmppJid,int id)
        {
            try
            {
                if (BOT.Statics.MainStatics.isLogged(id) == true)
                {
                    UserCs Cs = new UserCs();
                    string Result = Cs.ReturnIDByXmppJid(XmppJid + "@chatagent.ir").ToLower();
                    if (Result == "error")
                    {
                        return "Some Error Happens !";
                    }
                    else if (Result == "no")
                    {
                        return "There is Not Any User with This Username !";
                    }
                    else
                    {
                        return "One User ID Found With This XmppJid : \n" + XmppJid + " , ID : " + Result;
                    }
                }
                else
                {
                    return "You Are Not Logged in ! Please Login First !";
                }
            }
            catch { return "Some Error Happens !"; }
        }

        public string User(int id, int Uid)
        {
            try
            {
                if (BOT.Statics.MainStatics.isLogged(id) == true)
                {
                    UserCs temp = new UserCs(Uid, "", "", 0, 0, 0);
                    UserCs Result = temp.Get();
                    if (Result.ID == -2)
                    {
                        return "Some Error Happens !";
                    }
                    else if (Result.ID == -1)
                    {
                        return "There is Not Any User With this ID !";
                    }
                    else
                    {
                        return "User Details : \n" + "User ID : " + Uid + "\n" + "Username : " + Result.XmppJid + "\n" + "Following : " + Result.FlwngNum + "\n" + "Followers : " + Result.FlwrNum + "\n\n" + "User this Command to See User Posts : .view/UserID";
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
