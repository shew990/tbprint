//************************************************************
//******************************作者：方颖*********************
//******************************时间：2016/10/24 11:15:45*******

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILBasic.Basing;
using BILBasic.DBA;
using BILBasic.Common;
using BILWeb.Login.User;
using BILBasic.User;
using Oracle.ManagedDataAccess.Client;

namespace BILWeb.UserGroup
{
    public partial class T_UserGroup_DB : BILBasic.Basing.Base_DB<T_UserGroupInfo>
    {

        /// <summary>
        /// 添加T_USERGROUP
        /// </summary>
        protected override OracleParameter[] GetSaveModelOracleParameter(T_UserGroupInfo t_usergroup)
        {
            //注意!head表ID要填basemodel的headerID new SqlParameter("@CustomerID", DbHelperSQL.ToDBValue(model.HeaderID)),
            OracleParameter[] param = new OracleParameter[]{
                new OracleParameter("@bResult",OracleDbType.Int32),
                new OracleParameter("@ErrorMsg",OracleDbType.NVarchar2,1000),
               
               
               new OracleParameter("@v_ID", OracleDBHelper.ToDBValue(Convert.ToDecimal(t_usergroup.ID))),
               new OracleParameter("@v_UserGroupNo", OracleDBHelper.ToDBValue(t_usergroup.UserGroupNo)),
               new OracleParameter("@v_UserGroupName", OracleDBHelper.ToDBValue(t_usergroup.UserGroupName)),
               new OracleParameter("@v_UserGroupAbbName", OracleDBHelper.ToDBValue(t_usergroup.UserGroupAbbname)),
               new OracleParameter("@v_UserGroupType", OracleDBHelper.ToDBValue(Convert.ToDecimal(t_usergroup.UserGroupType))),
               new OracleParameter("@v_UserGroupStatus", OracleDBHelper.ToDBValue(Convert.ToDecimal(t_usergroup.UserGroupStatus))),
               new OracleParameter("@v_Description",OracleDBHelper.ToDBValue( t_usergroup.Description)),
               new OracleParameter("@v_IsDel", OracleDBHelper.ToDBValue(t_usergroup.IsDel)),
               new OracleParameter("@v_Creater",OracleDBHelper.ToDBValue( t_usergroup.Creater)),
               new OracleParameter("@v_CreateTime",OracleDBHelper.ToDBValue( t_usergroup.CreateTime)),
               new OracleParameter("@v_Modifyer", OracleDBHelper.ToDBValue(t_usergroup.Modifyer)),
               new OracleParameter("@v_ModifyTime", OracleDBHelper.ToDBValue(t_usergroup.ModifyTime)),
               new OracleParameter("@v_MainTypeCode", OracleDBHelper.ToDBValue(t_usergroup.MainTypeCode)),
               new OracleParameter("@v_PickLeaderUserNo", OracleDBHelper.ToDBValue(t_usergroup.PickLeaderUserNo)),
              };

            param[0].Direction = System.Data.ParameterDirection.Output;
            param[1].Direction = System.Data.ParameterDirection.Output;
            param[2].Direction = System.Data.ParameterDirection.InputOutput;
            param[11].Direction = System.Data.ParameterDirection.InputOutput;
            param[13].Direction = System.Data.ParameterDirection.InputOutput;
            return param;
        }

        protected override List<string> GetSaveSql(UserModel user,ref  T_UserGroupInfo t_usergroup)
        {
            throw new NotImplementedException();
        }




        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        protected override T_UserGroupInfo ToModel(OracleDataReader reader)
        {
            T_UserGroupInfo t_usergroup = new T_UserGroupInfo();

            t_usergroup.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();
            t_usergroup.UserGroupNo = (string)OracleDBHelper.ToModelValue(reader, "USERGROUPNO");
            t_usergroup.UserGroupName = (string)OracleDBHelper.ToModelValue(reader, "USERGROUPNAME");
            t_usergroup.UserGroupAbbname = (string)OracleDBHelper.ToModelValue(reader, "USERGROUPABBNAME");
            t_usergroup.UserGroupType = OracleDBHelper.ToModelValue(reader, "USERGROUPTYPE").ToInt32();
            t_usergroup.UserGroupStatus = OracleDBHelper.ToModelValue(reader, "USERGROUPSTATUS").ToInt32();
            t_usergroup.Description = (string)OracleDBHelper.ToModelValue(reader, "DESCRIPTION");
            t_usergroup.IsDel = (decimal?)OracleDBHelper.ToModelValue(reader, "ISDEL");
            t_usergroup.Creater = (string)OracleDBHelper.ToModelValue(reader, "CREATER");
            t_usergroup.CreateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CREATETIME");
            t_usergroup.Modifyer = (string)OracleDBHelper.ToModelValue(reader, "MODIFYER");
            t_usergroup.ModifyTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "MODIFYTIME");

            if (Common_Func.readerExists(reader, "IsChecked")) t_usergroup.BIsChecked = reader["IsChecked"].ToBoolean();
            if (Common_Func.readerExists(reader, "StrUserGroupType")) t_usergroup.StrUserGroupType = reader["StrUserGroupType"].ToDBString();
            if (Common_Func.readerExists(reader, "StrUserGroupStatus")) t_usergroup.StrUserGroupStatus = reader["StrUserGroupStatus"].ToDBString();

            t_usergroup.StrCreateTime = t_usergroup.CreateTime.ToShowTime();
            t_usergroup.StrModifyTime = t_usergroup.ModifyTime.ToShowTime();

            t_usergroup.DisplayID = t_usergroup.ID.ToString();
            t_usergroup.DisplayName = t_usergroup.UserGroupName;

            t_usergroup.MainTypeCode = (string)OracleDBHelper.ToModelValue(reader, "MainTypeCode");
            t_usergroup.PickLeaderUserNo = (string)OracleDBHelper.ToModelValue(reader, "PickLeaderUserNo");

            return t_usergroup;
        }


        protected override string GetFilterSql(UserModel user, T_UserGroupInfo model)
        {
            string strSql = base.GetFilterSql(user, model);
            string strAnd = " and ";


            if (!Common_Func.IsNullOrEmpty(model.UserGroupNo))
            {
                strSql += strAnd;
                strSql += " (USERGROUPNO like '%" + model.UserGroupNo + "%')  ";
            }

            if (!Common_Func.IsNullOrEmpty(model.UserGroupName))
            {
                strSql += strAnd;
                strSql += " (USERGROUPNAME like '%" + model.UserGroupName + "%')  ";
            }

            if (model.UserGroupType >= 1)
            {
                strSql += strAnd;
                strSql += " USERGROUPTYPE = " + model.UserGroupType + "";
            }

            return strSql;
        }

        public List<T_UserGroupInfo> GetModelListBySql(UserInfo user, bool IncludNoCheck)
        {
            string strSql = string.Empty;
            if (user.ID >= 1)
            {
                strSql = string.Format("SELECT DISTINCT 2 AS IsChecked,T_UserGroup.* FROM T_UserGroup WHERE ISDEL <> 2 AND UserGroupStatus <> 2 AND ID IN (SELECT GroupID FROM T_UserWithGroup WHERE UserID = {0}) ", user.ID);
                if (IncludNoCheck) strSql += string.Format("UNION SELECT DISTINCT 1 AS IsChecked,T_UserGroup.* FROM T_UserGroup WHERE ISDEL <> 2 AND UserGroupStatus <> 2 AND ID NOT IN (SELECT GroupID FROM T_UserWithGroup WHERE UserID = {0}) ", user.ID);
                strSql = string.Format("SELECT * FROM ({0}) T ORDER BY ID ", strSql);
            }
            else
            {
                if (IncludNoCheck) strSql = "SELECT DISTINCT 1 AS IsChecked,T_UserGroup.* FROM T_UserGroup WHERE ISDEL <> 2 AND UserGroupStatus <> 2";
                else strSql = "SELECT DISTINCT 2 AS IsChecked,T_UserGroup.* FROM T_UserGroup WHERE 1 = 2";
            }

            return GetModelListBySql(strSql);

        }

        protected override string GetViewName()
        {
            return "V_USERGROUP";
        }

        protected override string GetTableName()
        {
            return "T_USERGROUP";
        }

        protected override string GetSaveProcedureName()
        {
            return "P_SAVE_T_USERGROUP";
        }

        protected override string GetDeleteProcedureName() 
        {
            return "P_DELETE_T_USERGROUP";
        }

        /// <summary>
        /// 获取物料分类对应主管的用户组编码
        /// </summary>
        /// <returns></returns>
        public List<T_UserGroupInfo> GetPickLaderForMaintypeCode() 
        {
            List<T_UserGroupInfo> modelList = new List<T_UserGroupInfo>();

            string strSql = "select a.Maintypecode,a.Pickleaderuserno,a.Usergroupno,Func_GetWHCodeByWHID(nvl(to_char(b.Warehousecode),0)) as warehouseno from t_Usergroup a left join t_User b on a.Pickleaderuserno = b.Userno";

            using (OracleDataReader reader = OracleDBHelper.ExecuteReader(strSql))
            {
                while (reader.Read())
                {
                    T_UserGroupInfo model = new T_UserGroupInfo();
                    model.MainTypeCode = reader["MainTypeCode"].ToDBString();
                    model.PickLeaderUserNo = reader["PickLeaderUserNo"].ToDBString();
                    model.PickGroupNo = reader["UserGroupNo"].ToDBString();
                    model.WarehouseNo = reader["warehouseno"].ToDBString();
                    modelList.Add(model);
                }
            }

            return modelList;
    
        }

        
    }
}
