using System;
using System.Data;
using System.Collections.Generic;
using BILBasic.DBA;
using BILBasic.Common;
using BILBasic.User;
using Oracle.ManagedDataAccess.Client;

namespace BILWeb.Login.User
{
    public class User_DB : BILBasic.Basing.Base_DB<UserInfo>
    {

        protected override OracleParameter[] GetSaveModelOracleParameter(UserInfo model)
        {
            OracleParameter[] param = new OracleParameter[]{
               new OracleParameter("@bResult",OracleDbType.Int32),
               new OracleParameter("@ErrorMsg",OracleDbType.NVarchar2,1000),
               
               new OracleParameter("@v_ID", model.ID.ToOracleValue()),
               new OracleParameter("@v_UserNo", model.UserNo.ToOracleValue()),
               new OracleParameter("@v_UserName", model.UserName.ToOracleValue()),
               new OracleParameter("@v_Password", Secretkey.JiaMi(model.PassWord)),
               new OracleParameter("@v_UserType", model.UserType.ToOracleValue()),
               new OracleParameter("@v_PinYin", model.PinYin.ToOracleValue()),
               new OracleParameter("@v_Duty", model.Duty.ToOracleValue()),
               new OracleParameter("@v_Tel", model.Tel.ToOracleValue()),
               new OracleParameter("@v_Mobile", model.Mobile.ToOracleValue()),
               new OracleParameter("@v_Email", model.Email.ToOracleValue()),
               new OracleParameter("@v_Sex", model.Sex.ToOracleValue()),
               new OracleParameter("@v_IsPick", model.IsPick.ToOracleValue()),
               new OracleParameter("@v_IsReceive", model.IsReceive.ToOracleValue()),
               new OracleParameter("@v_IsQuality", model.IsQuality.ToOracleValue()),
               new OracleParameter("@v_UserStatus", model.UserStatus.ToOracleValue()),
               new OracleParameter("@v_Address", model.Address.ToOracleValue()),
               new OracleParameter("@v_GroupCode", model.GroupCode.ToOracleValue()),
               new OracleParameter("@v_WarehouseCode", model.WarehouseCode.ToOracleValue()),
               new OracleParameter("@v_Description", model.Description.ToOracleValue()),
               new OracleParameter("@v_LoginIP", model.LoginIP.ToOracleValue()),
               new OracleParameter("@v_LoginTime", model.LoginTime.ToOracleValue()),
               new OracleParameter("@v_IsDel", model.IsDel.ToOracleValue()),
               new OracleParameter("@v_Creater", model.Creater.ToOracleValue()),
               new OracleParameter("@v_CreateTime", model.CreateTime.ToOracleValue()),
               new OracleParameter("@v_Modifyer", model.Modifyer.ToOracleValue()),
               new OracleParameter("@v_ModifyTime", model.ModifyTime.ToOracleValue()),
               new OracleParameter("@v_IsPickLeader", model.PickLeader==false ? 1 : 2 ),
               new OracleParameter("@v_CYAccount", model.CYAccount.ToOracleValue()),
               new OracleParameter("@v_CXAccount", model.CXAccount.ToOracleValue()),
               new OracleParameter("@v_FCAccount", model.FCAccount.ToOracleValue()),
              };

            param[0].Direction = System.Data.ParameterDirection.Output;
            param[1].Direction = System.Data.ParameterDirection.Output;
            param[2].Direction = System.Data.ParameterDirection.InputOutput;

            return param;

        }

        protected override List<string> GetSaveSql(UserModel user, ref UserInfo model)
        {
            throw new NotImplementedException();
        }

        protected override UserInfo ToModel(OracleDataReader reader)
        {
            UserInfo t_user = new UserInfo();

            t_user.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();
            t_user.UserNo = (string)OracleDBHelper.ToModelValue(reader, "USERNO");
            t_user.UserName = (string)OracleDBHelper.ToModelValue(reader, "USERNAME");
            t_user.PassWord = Secretkey.JieMi((string)OracleDBHelper.ToModelValue(reader, "PASSWORD"));
            t_user.UserType = OracleDBHelper.ToModelValue(reader, "USERTYPE").ToInt32();
            t_user.PinYin = (string)OracleDBHelper.ToModelValue(reader, "PINYIN");
            t_user.Duty = (string)OracleDBHelper.ToModelValue(reader, "DUTY");
            t_user.Tel = (string)OracleDBHelper.ToModelValue(reader, "TEL");
            t_user.Mobile = (string)OracleDBHelper.ToModelValue(reader, "MOBILE");
            t_user.Email = (string)OracleDBHelper.ToModelValue(reader, "EMAIL");
            t_user.Sex = OracleDBHelper.ToModelValue(reader, "SEX").ToInt32();
            t_user.IsPick = OracleDBHelper.ToModelValue(reader, "ISPICK").ToInt32();
            t_user.IsReceive = OracleDBHelper.ToModelValue(reader, "ISRECEIVE").ToInt32();
            t_user.IsQuality = OracleDBHelper.ToModelValue(reader, "ISQUALITY").ToInt32();
            t_user.UserStatus = OracleDBHelper.ToModelValue(reader, "USERSTATUS").ToInt32();
            t_user.Address = (string)OracleDBHelper.ToModelValue(reader, "ADDRESS");
            t_user.GroupCode = (string)OracleDBHelper.ToModelValue(reader, "GROUPCODE");
            t_user.WarehouseCode = (string)OracleDBHelper.ToModelValue(reader, "WAREHOUSECODE");
            t_user.Description = (string)OracleDBHelper.ToModelValue(reader, "DESCRIPTION");
            t_user.LoginIP = (string)OracleDBHelper.ToModelValue(reader, "LOGINIP");
            t_user.LoginTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "LOGINTIME");
            t_user.IsDel = (decimal?)OracleDBHelper.ToModelValue(reader, "ISDEL");
            t_user.Creater = (string)OracleDBHelper.ToModelValue(reader, "CREATER");
            t_user.CreateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CREATETIME");
            t_user.Modifyer = (string)OracleDBHelper.ToModelValue(reader, "MODIFYER");
            t_user.ModifyTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "MODIFYTIME");
            t_user.LoginDevice = (string)OracleDBHelper.ToModelValue(reader, "LOGINDEVICE");
            t_user.Deviceversion = (string)OracleDBHelper.ToModelValue(reader, "DEVICEVERSION");

            if (Common_Func.readerExists(reader, "IsAdmin")) t_user.BIsAdmin = reader["IsAdmin"].ToBoolean();
            if (Common_Func.readerExists(reader, "StrUserType")) t_user.StrUserType = reader["StrUserType"].ToDBString();
            if (Common_Func.readerExists(reader, "StrUserStatus")) t_user.StrUserStatus = reader["StrUserStatus"].ToDBString();
            if (Common_Func.readerExists(reader, "StrSex")) t_user.StrSex = reader["StrSex"].ToDBString();
            if (Common_Func.readerExists(reader, "GroupName")) t_user.GroupName = reader["GroupName"].ToDBString();
            if (Common_Func.readerExists(reader, "WarehouseName")) t_user.WarehouseName = reader["WarehouseName"].ToDBString();

            t_user.RePassword = t_user.PassWord;
            t_user.StrIsAdmin = t_user.BIsAdmin ? "管理员" : "标准用户";            
           
            t_user.StrIsPick = t_user.IsPick==1 ? "拣货" : "不拣货";
            t_user.StrIsReceive = t_user.IsReceive==1 ? "收货" : "不收货";
            
            t_user.BIsOnline = !string.IsNullOrEmpty(t_user.LoginIP);
            t_user.IsOnline = t_user.BIsOnline.ToInt32();

            t_user.StrCreateTime = t_user.CreateTime.ToShowTime();
            t_user.StrModifyTime = t_user.ModifyTime.ToShowTime();

            t_user.WarehouseID = OracleDBHelper.ToModelValue(reader, "WAREHOUSECODE").ToInt32();

            t_user.DisplayID = t_user.UserNo;
            t_user.DisplayName = t_user.UserName;

            t_user.IsPickLeader = OracleDBHelper.ToModelValue(reader, "IsPickLeader").ToInt32();

            t_user.StrIsPickLeader = t_user.IsPickLeader == 2 ? "是" : "否";
            t_user.PickLeader = t_user.IsPickLeader == 2 ? true : false;
            t_user.CYAccount = OracleDBHelper.ToModelValue(reader, "CYAccount").ToDBString();
            t_user.CXAccount = OracleDBHelper.ToModelValue(reader, "CXAccount").ToDBString();
            t_user.FCAccount = OracleDBHelper.ToModelValue(reader, "FCAccount").ToDBString();            
            
            //t_user.PostAccount = GetPostAccount(t_user);


            return t_user;
        }


        protected override string GetFilterSql(UserModel user, UserInfo model)
        {
            string strSql = base.GetFilterSql(user, model);
            string strAnd = " and ";


            if (!Common_Func.IsNullOrEmpty(model.UserNo))
            {
                strSql += strAnd;
                strSql += " (USERNO like '%" + model.UserNo + "%')  ";
            }

            if (!Common_Func.IsNullOrEmpty(model.UserName))
            {
                strSql += strAnd;
                strSql += " (UserName like '%" + model.UserName + "%')  ";
            }

            if (model.IsOnline >= 1)
            {
                strSql += strAnd;
                strSql += " LoginIP is " + (model.IsOnline.ToBoolean() ? "not" : "") + " null ";                
            }

            if (!string.IsNullOrEmpty(model.Creater))
            {
                strSql += strAnd;
                strSql += " Creater Like '%" + model.Creater + "%' ";
                
            }

            if (model.DateFrom != null)
            {
                strSql += strAnd;
                strSql += " CreateTime " + this.GetDateFromFilter(model);
                
            }

            if (model.DateTo != null)
            {
                strSql += strAnd;
                strSql += " CreateTime  " + this.GetDateToFilter(model);
                
            }

            if (model.IsPick > 0 )
            {
                strSql += strAnd;
                strSql += " IsPick ='"+model.IsPick+"' ";
            }

            if ( model.LoginTime !=null)
            {
                strSql += strAnd;
                strSql += " nvl(LoginTime,'') <> '' ";
            }


            return strSql;
        }

        protected override string GetViewName()
        {
            return "V_USER";
        }

        protected override string GetTableName()
        {
            return "T_USER";
        }

        protected override string GetSaveProcedureName()
        {
            return "P_SAVE_T_USER";
        }
       

        protected override string GetOrderNoFieldName()
        {
            return base.GetOrderNoFieldName();
        }

        protected override string GetUpdateStatusProcedureName()
        {
 	         return base.GetUpdateStatusProcedureName();
        }
        
        protected override string GetDeleteProcedureName()
        {
            return "P_DELETE_T_USER";
        }

        //public UserInfo GetModelBySql(UserInfo user) 
        //{            
        //    string strSql = string.Format("SELECT sysdate CurrentTime,V_User.* FROM V_User WHERE UserNo = '{0}' AND Password = '{1}' ", user.UserNo, user.PassWord);
        //    return GetModelBySql(strSql);
        //}

        protected override string GetModelSql(UserInfo model)
        {           
            return string.Format("SELECT sysdate CurrentTime,V_User.* FROM V_User WHERE UserNo = '{0}' AND Password = '{1}' ", model.UserNo, model.PassWord);
            
        }

        public int GetScalarBySql(UserInfo user)
        {
            string strSql = string.Format("SELECT COUNT(1) FROM V_User WHERE UserNo = '{0}' ", user.UserNo);
            return GetScalarBySql(strSql).ToInt32();
        }

        public UserInfo GetModelByFilterByUserNo(string UserNo) 
        {
            string strFilter = "UserNo='" + UserNo + "'";
            return base.GetModelByFilter(strFilter);
        }


        /// <summary>
        /// 根据拣货提交的用户获取用户所在拣货组成员
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<UserModel> GetUserGroupByUser(UserModel user)
        {
            List<UserModel> modelList = new List<UserModel>();
            //string strSql = "select a.Groupcode,a.Userno,(a.userno || ';' || a.Username) as username from t_user a where f_useringroup(a.Groupcode,'" + user.GroupCode + "') > 0";
            //update by cym 2018-9-19 增加过滤用户编码为“L”和“PQ”开头的临时工
            string strSql = "select a.Groupcode,a.Userno,(a.userno || ';' || a.Username) as username from t_user a where a.userno not like 'L%' and a.userno not like 'PQ%' and f_useringroup(a.Groupcode,'" + user.GroupCode + "') > 0";
            
            using (OracleDataReader reader = OracleDBHelper.ExecuteReader(strSql))
            {
                while (reader.Read())
                {
                    UserModel model = new UserModel();
                    model.GroupCode = reader["Groupcode"].ToDBString();
                    model.UserNo = reader["UserNo"].ToDBString();
                    model.UserName = reader["UserName"].ToDBString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        private string GetPostAccount(UserModel user)
        {
            string strAccount = string.Empty;
            if (user.StrongHoldCode == "CY1")
            {
                strAccount = user.CYAccount;
            }
            else if (user.StrongHoldCode == "CX1")
            {
                strAccount = user.CXAccount;
            }
            else if (user.StrongHoldCode == "FC1")
            {
                strAccount = user.FCAccount;
            }
            return strAccount;
        }

        public string GetPostAccountByUserNo(string strUserNoSub, string StrongHoldCodeOrder)
        {
            //string strSql = "select userno from t_user a where userno like  '" + strUserNoSub + "%' and a.Strongholdcode = '" + StrongHoldCodeOrder + "' AND regexp_like(userno,'.([a-z]+|[A-Z])') ";//and rownum = 1
            string strSql = "select userno from t_user a where userno =  '" + strUserNoSub + "' and a.Strongholdcode = '" + StrongHoldCodeOrder + "'";//and rownum = 1
            return base.GetScalarBySql(strSql).ToDBString();
        }

        public List<T_QuanUser_Model> GetQuanUser(string strUserID)
        {
            List<T_QuanUser_Model> modelList = new List<T_QuanUser_Model>();
            string strSql = "select id,username from v_user where id in (" + strUserID + ")";

            using (OracleDataReader reader = OracleDBHelper.ExecuteReader(strSql))
            {
                while (reader.Read())
                {
                    T_QuanUser_Model model = new T_QuanUser_Model();
                    model.QuanUserNo = reader["id"].ToDBString();
                    model.QuanUserName = reader["username"].ToDBString();                   
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public bool ChangeUserPassword(UserInfo user, ref string strError)
        {
            string strSql;
            strSql = string.Format("UPDATE T_User SET Password = '{0}', Modifyer = '{1}', ModifyTime = sysdate WHERE ID = {2} ", user.RePassword, user.UserNo, user.ID);
            int i = OracleDBHelper.ExecuteNonQuery2(CommandType.Text, strSql);
            return i >= 1;
        }

    }
}
