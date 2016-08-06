using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BOT.Models.User
{
    public class FollowCs
    {
        BOT.DB.DAL dataaccesslayer = new DB.DAL(); 

        private int _id;
        private int _uID;
        private int _targetID;

        public int ID { get { return _id; } set { _id = value; } }
        public int uID { get { return _uID; } set { _uID = value; } }
        public int TargetID { get { return _targetID; } set { _targetID = value; } }


        //////////////////////////


        public FollowCs()
        {
        }

        public FollowCs(int id, int uid, int targetid)
        {
            this.ID = id;
            this.uID = uid;
            this.TargetID = targetid;
        }


        //////////////////////////// Methods //////////////////


        //public string AddFollower()
        //{
        //    try
        //    {
        //        dataaccesslayer.cmd.Parameters.Clear();
        //        string sql = "insert into tblFollowers(uID,flwrID)values(@uid,@flwrID)";
        //        dataaccesslayer.cmd.Parameters.Add("@uid", SqlDbType.BigInt).Value = this.uID;
        //        dataaccesslayer.cmd.Parameters.Add("@flwrID", SqlDbType.BigInt).Value = this.TargetID;
        //        dataaccesslayer.executenonquery(sql);
        //        return "ok";
        //    }
        //    catch { return "error"; }
        //}

        //public string AddFollowing()
        //{
        //    try
        //    {
        //        dataaccesslayer.cmd.Parameters.Clear();
        //        string sql = "insert into tblFollowing(uID,flwngID)values(@uid,@flwngID)";
        //        dataaccesslayer.cmd.Parameters.Add("@uid", SqlDbType.BigInt).Value = this.uID;
        //        dataaccesslayer.cmd.Parameters.Add("@flwngID", SqlDbType.BigInt).Value = this.TargetID;
        //        dataaccesslayer.executenonquery(sql);
        //        return "ok";
        //    }
        //    catch { return "error"; }
        //}

        //public string RemoveFollower()
        //{
        //    try
        //    {
        //        dataaccesslayer.cmd.Parameters.Clear();
        //        string sql = "delete from tblFollowers where uID=@uid and flwrID=@flwrID";
        //        dataaccesslayer.cmd.Parameters.Add("@uid", SqlDbType.BigInt).Value = this.uID;
        //        dataaccesslayer.cmd.Parameters.Add("@flwrID", SqlDbType.BigInt).Value = this.TargetID;
        //        dataaccesslayer.executenonquery(sql);
        //        return "ok";
        //    }
        //    catch { return "error"; }
        //}

        //public string RemoveFollowing()
        //{
        //    try
        //    {
        //        dataaccesslayer.cmd.Parameters.Clear();
        //        string sql = "delete from tblFollowing where uID=@uid and flwngID=@flwngID";
        //        dataaccesslayer.cmd.Parameters.Add("@uid", SqlDbType.BigInt).Value = this.uID;
        //        dataaccesslayer.cmd.Parameters.Add("@flwngID", SqlDbType.BigInt).Value = this.TargetID;
        //        dataaccesslayer.executenonquery(sql);
        //        return "ok";
        //    }
        //    catch { return "error"; }
        //}

        public string AddFollow()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "insert into tblFollow(uID,flwID)values(@uid,@flwID)";
                dataaccesslayer.cmd.Parameters.Add("@uid", SqlDbType.BigInt).Value = this.uID;
                dataaccesslayer.cmd.Parameters.Add("@flwID", SqlDbType.BigInt).Value = this.TargetID;
                dataaccesslayer.executenonquery(sql);
                return "ok";
            }
            catch { return "error"; }
        }

        public string RemoveFollow()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "delete from tblFollow where uID=@uid and flwID=@flwid";
                dataaccesslayer.cmd.Parameters.Add("@uid", SqlDbType.BigInt).Value = this.uID;
                dataaccesslayer.cmd.Parameters.Add("@flwid", SqlDbType.BigInt).Value = this.TargetID;
                dataaccesslayer.executenonquery(sql);
                return "ok";
            }
            catch { return "error"; }
        }

        public string IncreaseFlwrs()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "update tblUsers set flwrNum = ((select flwrNum from tblUsers where id=@id)+1 ) where id=@uid";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = this.TargetID;
                dataaccesslayer.cmd.Parameters.Add("@uid", SqlDbType.BigInt).Value = this.TargetID;
                dataaccesslayer.executenonquery(sql);
                return "ok";
            }
            catch { return "error"; }
        }

        public string IncreaseFlwngs()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "update tblUsers set flwngNum = ((select flwngNum from tblUsers where id=@id)+1 ) where id=@uid";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = this.uID;
                dataaccesslayer.cmd.Parameters.Add("@uid", SqlDbType.BigInt).Value = this.uID;
                dataaccesslayer.executenonquery(sql);
                return "ok";
            }
            catch { return "error"; }
        }

        public string DecreaseFlwrs()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "update tblUsers set flwrNum = ((select flwrNum from tblUsers where id=@id)-1 ) where id=@uid";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = this.TargetID;
                dataaccesslayer.cmd.Parameters.Add("@uid", SqlDbType.BigInt).Value = this.TargetID;
                dataaccesslayer.executenonquery(sql);
                return "ok";
            }
            catch { return "error"; }
        }

        public string DecreaseFlwngs()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "update tblUsers set flwngNum = ((select flwngNum from tblUsers where id=@id)-1 ) where id=@uid";
                dataaccesslayer.cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = this.uID;
                dataaccesslayer.cmd.Parameters.Add("@uid", SqlDbType.BigInt).Value = this.uID;
                dataaccesslayer.executenonquery(sql);
                return "ok";
            }
            catch { return "error"; }
        }

        public string isFollowed()
        {
            try
            {
                dataaccesslayer.cmd.Parameters.Clear();
                string sql = "select count(id) from tblFollow where uID=@uid and flwID=@targetID";
                dataaccesslayer.cmd.Parameters.Add("@uid", SqlDbType.BigInt).Value = this.uID;
                dataaccesslayer.cmd.Parameters.Add("@targetID", SqlDbType.BigInt).Value = this.TargetID;
                string Result = dataaccesslayer.executescaler(sql).ToString();
                if (Result == "0" | Result == null)
                {
                    return "no";
                }
                else
                {
                    return "yes";
                }
            }
            catch { return "error"; }
        }

    }
}
