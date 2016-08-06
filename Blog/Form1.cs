using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using agsXMPP;
using agsXMPP.Xml.Dom;
using System.Threading.Tasks;
using System.IO;

namespace Blog
{
    public partial class frmMain : Form
    {

        XmppClientConnection BotClient;
        BOT.Controllers.UserController Uc;
        BOT.Controllers.PostController Pc;
        BOT.Controllers.CommentController Cc;
        BOT.Controllers.EventsController Ec;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text != "" & txtPw.Text != "" & txtServer.Text != "")
                {
                    BotClient = new XmppClientConnection(txtServer.Text, Convert.ToInt32(txtPort.Text));
                    if (chkAutoResolve.Checked == true)
                    {
                        BotClient.AutoResolveConnectServer = true;
                    }
                    else
                    {
                        BotClient.AutoResolveConnectServer = false;
                    }
                    BotClient.ConnectServer = txtHost.Text;
                    BotClient.Status = "Send Help in Private To Get Started !";
                    BotClient.Open(txtID.Text, txtPw.Text, txtRes.Text);
                    BotClient.KeepAliveInterval = 120000;
                    BotClient.KeepAlive = true;
                    BotClient.OnRosterItem += new XmppClientConnection.RosterHandler(OnRoster);
                    BotClient.OnPresence += new agsXMPP.protocol.client.PresenceHandler(OnPres);
                    BotClient.OnMessage += new agsXMPP.protocol.client.MessageHandler(OnMsg);
                    BotClient.OnLogin += new ObjectHandler(OnLogin);
                    BotClient.OnAuthError += new XmppElementHandler(OnAuthError);
                    BotClient.OnClose += new ObjectHandler(dc);
                }
                else
                {
                    MessageBox.Show("Please Enter Username and Password");
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                BotClient.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void OnLogin(object sender)
        {
            if (base.InvokeRequired)
            {
                base.BeginInvoke(new ObjectHandler(OnLogin), new object[] { sender });
            }
            else
            {
                lblStatus.Text = "Connected";
                lblStatus.ForeColor = Color.DarkGreen;
            }
        }

        private void OnAuthError(object sender, Element e)
        {
            if (base.InvokeRequired)
            {
                base.BeginInvoke(new XmppElementHandler(OnAuthError), new object[] { sender, e });
            }
            else
            {
                lblStatus.Text = "Wrong ID or Pw";
                lblStatus.ForeColor = Color.DarkRed;
            }
        }

        private void dc(object sender)
        {
            if (base.InvokeRequired)
            {
                base.BeginInvoke(new ObjectHandler(dc), new object[] { sender });
            }
            else
            {
                lblStatus.Text = "Disconnected";
                lblStatus.ForeColor = Color.Yellow;

                if (chkAutoLogin.Checked == true)
                {
                    try
                    {
                        if (txtID.Text != "" & txtPw.Text != "" & txtServer.Text != "")
                        {
                            BotClient = new XmppClientConnection(txtServer.Text, Convert.ToInt32(txtPort.Text));
                            if (chkAutoResolve.Checked == true)
                            {
                                BotClient.AutoResolveConnectServer = true;
                            }
                            else
                            {
                                BotClient.AutoResolveConnectServer = false;
                            }
                            BotClient.ConnectServer = txtHost.Text;
                            BotClient.Status = "Send Help in Private To Get Started !";
                            BotClient.Open(txtID.Text, txtPw.Text, txtRes.Text);
                            BotClient.KeepAliveInterval = 120000;
                            BotClient.KeepAlive = true;
                            BotClient.OnRosterItem += new XmppClientConnection.RosterHandler(OnRoster);
                            BotClient.OnPresence += new agsXMPP.protocol.client.PresenceHandler(OnPres);
                            BotClient.OnMessage += new agsXMPP.protocol.client.MessageHandler(OnMsg);
                            BotClient.OnLogin += new ObjectHandler(OnLogin);
                            BotClient.OnAuthError += new XmppElementHandler(OnAuthError);
                            BotClient.OnClose += new ObjectHandler(dc);
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Username and Password");
                        }
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show(x.Message);
                    }
                }
            }
        }

        private void OnPres(object sender, agsXMPP.protocol.client.Presence pres)
        {
            if (base.InvokeRequired == true)
            {
                base.BeginInvoke(new agsXMPP.protocol.client.PresenceHandler(OnPres), new object[] { this, pres });
            }
            else
            {
                if (pres.From.User == BotClient.Username)
                {
                }
                else
                {
                    if (pres.Type == agsXMPP.protocol.client.PresenceType.available)
                    {
                        if (lstOnlines.Items.Contains(pres.From.Bare.ToString()))
                        {
                        }
                        else
                        {
                            lstOnlines.Items.Add(pres.From.Bare.ToString());
                        }
                    }
                    else if (pres.Type == agsXMPP.protocol.client.PresenceType.unavailable)
                    {
                        if (lstOnlines.Items.Contains(pres.From.Bare.ToString()))
                        {
                            lstOnlines.Items.Remove(pres.From.Bare.ToString());
                        }
                        else
                        {
                        }
                    }
                    else if (pres.Type == agsXMPP.protocol.client.PresenceType.unsubscribe | pres.Type == agsXMPP.protocol.client.PresenceType.unsubscribed)
                    {
                        if (lstAddlist.Items.Contains(pres.From.Bare.ToString()))
                        {
                            lstAddlist.Items.Remove(pres.From.Bare.ToString());
                            BOT.Statics.MainStatics.Logout(pres.From.Bare);
                        }
                        else
                        {
                        }
                    }
                    else if (pres.Type == agsXMPP.protocol.client.PresenceType.subscribe)
                    {
                        if (chkAutoAddAcc.Checked==true)
                        {
                            BotClient.Send("<presence to=\"" + pres.From + "\" type=\"subscribed\" />" + "<presence to=\"" + pres.From + "\" type=\"subscribe\" />");
                        }
                    }
                }
            }
        }

        private void OnRoster(object sender, agsXMPP.protocol.iq.roster.RosterItem item)
        {
            if (base.InvokeRequired == true)
            {
                base.BeginInvoke(new XmppClientConnection.RosterHandler(OnRoster), new object[] { this, item });
            }
            else
            {
                try
                {
                    if (item.Jid.ToString().Contains(BotClient.Username))
                    {
                    }
                    else
                    {
                        if (item.Subscription == agsXMPP.protocol.iq.roster.SubscriptionType.both)
                        {
                            if (lstAddlist.Items.Contains(item.Jid.ToString()))
                            {
                            }
                            else
                            {
                                lstAddlist.Items.Add(item.Jid.ToString());
                            }
                        }

                    }
                }
                catch { }
            }
        }

        private void OnMsg(object sender, agsXMPP.protocol.client.Message msg)
        {
            try
            {
                   Task.Factory.StartNew(() =>
                   {
                       if (msg.Body != null)
                       {
                           if (msg.From.User != BotClient.Username)
                           {
                               if (msg.Body == "123ImTyping123")
                               {

                               }
                               else if (msg.Body == "123ImNotTyping123")
                               {

                               }
                               else
                               {


                                   if (msg.Body.ToLower() == ".help")
                                   {
                                       //SendMsg(msg.From.Bare, "Wellcome to Blog Bot !\nIf u Wanna USE Blog BOT , Follow This Guidance By Sending This Commands :\n\n1.How to Register and Login : help/1\n2.How to Send Posts : help/2\n3.How to Send Comments : help/3\n4.How to Like Post and Comments and Follow Users : help/4\n5.How to Explore Users,Posts,Comments and Likers : help/5\n6.When Events Happens : help/6");
                                   }
                                   else
                                   {
                                       String[] str = msg.Body.Split('\\');
                                       if (str[0].ToLower() == ".reg")
                                       {
                                           if (str.Length == 3)
                                           {
                                               BOT.Models.User.UserCs usrCs = new BOT.Models.User.UserCs(Convert.ToInt32(str[1]), msg.From.Bare.ToString(), str[2], 0, 0, 0);
                                               Uc = new BOT.Controllers.UserController();
                                               SendMsg(msg.From.Bare, Uc.Register(usrCs).Replace("@chatagent.ir", ""));
                                               rchMonitor.AppendText(msg.From.User+" Registered in BOT\n");
                                           }
                                           else
                                           {
                                               SendMsg(msg.From.Bare, "Invalid Reg Command !");
                                           }
                                       }
                                       else if (str[0].ToLower() == ".login")
                                       {
                                           if (str.Length == 3)
                                           {
                                               if (BOT.Statics.MainStatics.isLogged(Convert.ToInt32(str[1])) == true)
                                               {
                                                   SendMsg(msg.From.Bare, "You've previously Logged in !");
                                               }
                                               else
                                               {
                                                   Uc = new BOT.Controllers.UserController();
                                                   SendMsg(msg.From.Bare, Uc.Login(Convert.ToInt32(str[1]), msg.From.Bare, str[2]).Replace("@chatagent.ir", ""));
                                                   rchMonitor.AppendText(msg.From.User + " Logged in\n");
                                               }
                                           }
                                           else
                                           {
                                               SendMsg(msg.From.Bare, "Invalid Login Command !");
                                           }
                                       }
                                       else if (str[0].ToLower() == ".logout")
                                       {
                                           SendMsg(msg.From.Bare, BOT.Statics.MainStatics.Logout(msg.From.Bare).Replace("@chatagent.ir", ""));
                                           rchMonitor.AppendText(msg.From.User + " Sent Request For Log out\n");
                                       }
                                       else if (str[0].ToLower() == ".post")
                                       {
                                           if (str.Length == 3)
                                           {
                                               Pc = new BOT.Controllers.PostController();
                                               string Result = Pc.NewPost(new BOT.Models.Post.PostCs(0, BOT.Statics.MainStatics.ReturnUserID(msg.From.Bare), str[1], str[2], 0));
                                               SendMsg(msg.From.Bare, Result.Replace("@chatagent.ir", ""));
                                               if (Result.Contains("Done ! \n , Your New Post ID : "))
                                               {
                                                   Ec = new BOT.Controllers.EventsController(this.BotClient);
                                                   Ec.PostSent(BOT.Statics.MainStatics.ReturnUserID(msg.From.Bare), msg.From.Bare, str[1],str[2]);
                                                   rchMonitor.AppendText(msg.From.User + " Sent New Post\n");
                                               }
                                           }
                                           else
                                           {
                                               SendMsg(msg.From.Bare, "Invalid Post Command !");
                                           }
                                       }
                                       else if (str[0].ToLower() == ".ep")
                                       {
                                           if (str.Length == 4)
                                           {
                                               Pc = new BOT.Controllers.PostController();
                                               SendMsg(msg.From.Bare, Pc.EditPost(new BOT.Models.Post.PostCs(Convert.ToInt32(str[1]), BOT.Statics.MainStatics.ReturnUserID(msg.From.Bare), str[2], str[3], 0)).Replace("@chatagent.ir", ""));
                                               rchMonitor.AppendText(msg.From.User + " Edited a Post\n");
                                           }
                                           else
                                           {
                                               SendMsg(msg.From.Bare, "Invalid Edit Post Command !");
                                           }
                                       }
                                       else if (str[0].ToLower() == ".dp")
                                       {
                                           if (str.Length == 2)
                                           {
                                               Pc = new BOT.Controllers.PostController();
                                               SendMsg(msg.From.Bare, Pc.DeletePost(new BOT.Models.Post.PostCs(Convert.ToInt32(str[1]), BOT.Statics.MainStatics.ReturnUserID(msg.From.Bare), "", "", 0)).Replace("@chatagent.ir", ""));
                                               rchMonitor.AppendText(msg.From.User + " Deleted a post Post\n");
                                           }
                                           else
                                           {
                                               SendMsg(msg.From.Bare, "Invalid Delete Post Command !");
                                           }
                                       }
                                       else if (str[0].ToLower() == ".follow")
                                       {
                                           if (str.Length == 2)
                                           {
                                               Uc = new BOT.Controllers.UserController();
                                               string Result = Uc.Follow(BOT.Statics.MainStatics.ReturnUserID(msg.From.Bare), Convert.ToInt32(str[1]));
                                               SendMsg(msg.From.Bare, Result.Replace("@chatagent.ir", ""));
                                               if (Result == "Done.")
                                               {
                                                   Ec = new BOT.Controllers.EventsController();
                                                   BOT.Models.User.UserCs u = new BOT.Models.User.UserCs();
                                                   SendMsg(Ec.UserFollowed(Convert.ToInt32(str[1])), "event#follow#" + msg.From.Bare.Replace("@chatagent.ir", "") + " Followed You ( User ID : " + u.ReturnIDByXmppJid(msg.From.Bare) + " ) .");
                                                   rchMonitor.AppendText(msg.From.User + " Followed Some one\n");
                                               }
                                           }
                                           else
                                           {
                                               SendMsg(msg.From.Bare, "Invalid Follow Command !");
                                           }

                                       }
                                       else if (str[0].ToLower() == ".unfollow")
                                       {
                                           if (str.Length == 2)
                                           {
                                               Uc = new BOT.Controllers.UserController();
                                               SendMsg(msg.From.Bare, Uc.UnFollow(BOT.Statics.MainStatics.ReturnUserID(msg.From.Bare), Convert.ToInt32(str[1])).Replace("@chatagent.ir", ""));
                                               rchMonitor.AppendText(msg.From.User + " UnFollowed Some one\n");
                                           }
                                           else
                                           {
                                               SendMsg(msg.From.Bare, "Invalid UnFollow Command !");
                                           }
                                       }
                                       else if (str[0].ToLower() == ".comment")
                                       {
                                           if (str.Length == 3)
                                           {
                                               Cc = new BOT.Controllers.CommentController();
                                               string Result = Cc.NewComment(new BOT.Models.Comment.CommentCs(0, BOT.Statics.MainStatics.ReturnUserID(msg.From.Bare), Convert.ToInt32(str[1]), str[2], 0, ""));
                                               SendMsg(msg.From.Bare, Result.Replace("@chatagent.ir", ""));
                                               if (Result.Contains("Done  ! \n , Your New Comment ID : "))
                                               {
                                                   Ec = new BOT.Controllers.EventsController();
                                                   string TargetXmpp = Ec.CommentSent(Convert.ToInt32(str[1]));
                                                   if (TargetXmpp != "error")
                                                   {
                                                       BOT.Models.Comment.CommentCs cmcs = new BOT.Models.Comment.CommentCs();
                                                       int newID = cmcs.GetNewCommentID();
                                                       SendMsg(TargetXmpp, "event#comment#" + msg.From.Bare.Replace("@chatagent.ir", "") + " ( User ID : " + BOT.Statics.MainStatics.ReturnUserID(msg.From.Bare) + " ) Sent a New Comment (Comment ID : " + newID + " ) Under Your Post ( Post ID : " + str[1] + " ) \n\n Body : " + str[2]);
                                                       rchMonitor.AppendText(msg.From.User + " Sent a new Comment\n");
                                                   }
                                               }
                                           }
                                           else
                                           {
                                               SendMsg(msg.From.Bare, "Invalid Comment Command !");
                                           }
                                       }
                                       else if (str[0].ToLower() == ".ec")
                                       {
                                           if (str.Length == 3)
                                           {
                                               Cc = new BOT.Controllers.CommentController();
                                               SendMsg(msg.From.Bare, Cc.EditComment(new BOT.Models.Comment.CommentCs(Convert.ToInt32(str[1]), BOT.Statics.MainStatics.ReturnUserID(msg.From.Bare), 0, str[2], 0, "")).Replace("@chatagent.ir", ""));
                                               rchMonitor.AppendText(msg.From.User + " Edited a Comment\n");
                                           }
                                           else
                                           {
                                               SendMsg(msg.From.Bare, "Invalid Edit Comment Command !");
                                           }
                                       }
                                       else if (str[0].ToLower() == ".dc")
                                       {
                                           if (str.Length == 2)
                                           {
                                               Cc = new BOT.Controllers.CommentController();
                                               SendMsg(msg.From.Bare, Cc.DeleteComment(new BOT.Models.Comment.CommentCs(Convert.ToInt32(str[1]), BOT.Statics.MainStatics.ReturnUserID(msg.From.Bare), 0, "", 0, "")).Replace("@chatagent.ir", ""));
                                               rchMonitor.AppendText(msg.From.User + " Deleted a Comment\n");
                                           }
                                           else
                                           {
                                               SendMsg(msg.From.Bare, "Invalid Delete Comment Command !");
                                           }
                                       }
                                       else if (str[0].ToLower() == ".lp")
                                       {
                                           if (str.Length == 2)
                                           {
                                               Pc = new BOT.Controllers.PostController();
                                               string Result = Pc.LikePost(BOT.Statics.MainStatics.ReturnUserID(msg.From.Bare), Convert.ToInt32(str[1]));
                                               SendMsg(msg.From.Bare, Result.Replace("@chatagent.ir", ""));
                                               if (Result == "Done.")
                                               {
                                                   Ec = new BOT.Controllers.EventsController();
                                                   string Res = Ec.PostLiked(Convert.ToInt32(str[1]));
                                                   if (Res != "error")
                                                   {
                                                       BOT.Models.User.UserCs u = new BOT.Models.User.UserCs();
                                                       SendMsg(Res, "event#likepost#" + msg.From.Bare.Replace("@chatagent.ir", "") + " ( User ID : " + u.ReturnIDByXmppJid(msg.From.Bare) + " ) Liked Your Post ( Your Post ID : " + str[1] + " ) .");
                                                       rchMonitor.AppendText(msg.From.User + " Liked a Post\n");
                                                   }
                                               }
                                           }
                                           else
                                           {
                                               SendMsg(msg.From.Bare, "Invalid Like Post Command !");
                                           }
                                       }
                                       else if (str[0].ToLower() == ".ulp")
                                       {
                                           if (str.Length == 2)
                                           {
                                               Pc = new BOT.Controllers.PostController();
                                               SendMsg(msg.From.Bare, Pc.UnLikePost(BOT.Statics.MainStatics.ReturnUserID(msg.From.Bare), Convert.ToInt32(str[1])).Replace("@chatagent.ir", ""));
                                               rchMonitor.AppendText(msg.From.User + " UnLiked a Post\n");
                                           }
                                           else
                                           {
                                               SendMsg(msg.From.Bare, "Invalid UnLike Post Command !");
                                           }
                                       }
                                       else if (str[0].ToLower() == ".lc")
                                       {
                                           if (str.Length == 2)
                                           {
                                               Cc = new BOT.Controllers.CommentController();
                                               string Result = Cc.LikeComment(BOT.Statics.MainStatics.ReturnUserID(msg.From.Bare), Convert.ToInt32(str[1]));
                                               SendMsg(msg.From.Bare, Result.Replace("@chatagent.ir", ""));
                                               if (Result == "Done.")
                                               {
                                                   Ec = new BOT.Controllers.EventsController();
                                                   string Res = Ec.CommentLiked(Convert.ToInt32(str[1]));
                                                   if (Res != "error")
                                                   {
                                                       BOT.Models.User.UserCs u = new BOT.Models.User.UserCs();
                                                       BOT.Events.CommentEventsCs tempCs = new BOT.Events.CommentEventsCs();
                                                       SendMsg(Res, "event#likecomment#" + msg.From.Bare.Replace("@chatagent.ir", "") + " ( User ID : " + u.ReturnIDByXmppJid(msg.From.Bare) + ") Liked Your Comment ( Your Comment ID : " + str[1] + " ) Under Post ID : " + tempCs.LikedCommentOwnerPostID(Convert.ToInt32(str[1])) + " .");
                                                       rchMonitor.AppendText(msg.From.User + " Liked a Comment\n");
                                                   }
                                               }
                                           }
                                           else
                                           {
                                               SendMsg(msg.From.Bare, "Invalid Like Comment Command !");
                                           }
                                       }
                                       else if (str[0].ToLower() == ".ulc")
                                       {
                                           if (str.Length == 2)
                                           {
                                               Cc = new BOT.Controllers.CommentController();
                                               SendMsg(msg.From.Bare, Cc.UnLikeComment(BOT.Statics.MainStatics.ReturnUserID(msg.From.Bare), Convert.ToInt32(str[1])).Replace("@chatagent.ir", ""));
                                               rchMonitor.AppendText(msg.From.User + " UnLiked a Comment\n");
                                           }
                                           else
                                           {
                                               SendMsg(msg.From.Bare, "Invalid UnLike Comment Command !");
                                           }
                                       }
                                       else if (str[0].ToLower() == ".find")
                                       {
                                           if (str.Length == 2)
                                           {
                                               Uc = new BOT.Controllers.UserController();
                                               SendMsg(msg.From.Bare, Uc.Find(str[1], BOT.Statics.MainStatics.ReturnUserID(msg.From.Bare)));
                                               rchMonitor.AppendText(msg.From.User + " Sent a Find Command\n");
                                           }
                                           else
                                           {
                                               SendMsg(msg.From.Bare, "Invalid Find Command !");
                                           }
                                       }
                                       else if (str[0].ToLower() == ".user")
                                       {
                                           if (str.Length == 2)
                                           {
                                               Uc = new BOT.Controllers.UserController();
                                               SendMsg(msg.From.Bare, Uc.User(BOT.Statics.MainStatics.ReturnUserID(msg.From.Bare), Convert.ToInt32(str[1])).Replace("@chatagent.ir", ""));
                                               rchMonitor.AppendText(msg.From.User + " Sent a User Command\n");
                                           }
                                           else
                                           {
                                               SendMsg(msg.From.Bare, "Invalid User Command !");
                                           }
                                       }
                                       else if (str[0].ToLower() == ".view")
                                       {
                                           if (str.Length == 2)
                                           {
                                               Pc = new BOT.Controllers.PostController();
                                               SendMsg(msg.From.Bare, Pc.ViewPosts(BOT.Statics.MainStatics.ReturnUserID(msg.From.Bare), Convert.ToInt32(str[1])).Replace("@chatagent.ir", ""));
                                               rchMonitor.AppendText(msg.From.User + " Sent a View Command\n");
                                           }
                                           else
                                           {
                                               SendMsg(msg.From.Bare, "Invalid View Command !");
                                           }
                                       }
                                       else if (str[0].ToLower() == ".sp")
                                       {
                                           if (str.Length == 2)
                                           {
                                               Pc = new BOT.Controllers.PostController();
                                               SendMsg(msg.From.Bare, Pc.ShowPost(BOT.Statics.MainStatics.ReturnUserID(msg.From.Bare), Convert.ToInt32(str[1])).Replace("@chatagent.ir", ""));
                                               rchMonitor.AppendText(msg.From.User + " Sent a Show Post Command\n");
                                           }
                                           else
                                           {
                                               SendMsg(msg.From.Bare, "Invalid Show Post Command !");
                                           }
                                       }
                                       else if (str[0].ToLower() == ".sc")
                                       {
                                           if (str.Length == 2)
                                           {
                                               Cc = new BOT.Controllers.CommentController();
                                               SendMsg(msg.From.Bare, Cc.ShowComments(BOT.Statics.MainStatics.ReturnUserID(msg.From.Bare), Convert.ToInt32(str[1])).Replace("@chatagent.ir", ""));
                                               rchMonitor.AppendText(msg.From.User + " Sent a Show Comment Command\n");
                                           }
                                           else
                                           {
                                               SendMsg(msg.From.Bare, "Invalid Show Comments Command !");
                                           }
                                       }
                                       else if (str[0].ToLower() == ".spl")
                                       {
                                           if (str.Length == 2)
                                           {
                                               Pc = new BOT.Controllers.PostController();
                                               SendMsg(msg.From.Bare, Pc.PostLikers(BOT.Statics.MainStatics.ReturnUserID(msg.From.Bare), Convert.ToInt32(str[1])).Replace("@chatagent.ir", ""));
                                               rchMonitor.AppendText(msg.From.User + " Sent a Show Post Likers Command\n");
                                           }
                                           else
                                           {
                                               SendMsg(msg.From.Bare, "Invalid Show Post Likers Command !");
                                           }
                                       }
                                       else if (str[0].ToLower() == ".scl")
                                       {
                                           if (str.Length == 2)
                                           {
                                               Cc = new BOT.Controllers.CommentController();
                                               SendMsg(msg.From.Bare, Cc.CommentLikers(BOT.Statics.MainStatics.ReturnUserID(msg.From.Bare), Convert.ToInt32(str[1])).Replace("@chatagent.ir", ""));
                                               rchMonitor.AppendText(msg.From.User + " Sent a Show Comment Likers Command\n");
                                           }
                                           else
                                           {
                                               SendMsg(msg.From.Bare, "Invalid Show Comment Likers Command !");
                                           }
                                       }
                                   }
                               }
                           }
                       }
                   });
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void SendMsg(string id, string body)
        {
            try
            {
                BotClient.Send(new agsXMPP.protocol.client.Message { To = new Jid(id), Type = agsXMPP.protocol.client.MessageType.chat, Body = body });
            }
            catch { }
        }

        private void btnSetSts_Click(object sender, EventArgs e)
        {
            try
            {
                BotClient.Status = txtSts.Text.Trim();
                BotClient.SendMyPresence();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\logged.txt"))
            {
                StreamReader sr1 = new StreamReader(Application.StartupPath + "\\logged.txt");
                string StrText1 = sr1.ReadToEnd().ToString();
                sr1.Close();

                string[] resul = StrText1.Split('#');
                for (int i = 0; i < resul.Length; i++)
                {
                    string[] resu = resul[i].Split('/');
                    BOT.Statics.MainStatics.LoggedUsers.Add(new BOT.Models.User.LoggedUser(Convert.ToInt32(resu[0]), resu[1].ToLower()+"@chatagent.ir", "", 0, 0, 0));
                }
            }
            else
            {
                MessageBox.Show("logged.txt Not Found !");
            }
        }

    }
}
