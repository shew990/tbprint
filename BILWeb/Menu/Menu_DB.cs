//************************************************************
//******************************作者：方颖*********************
//******************************时间：2016/10/20 10:43:54*******

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILBasic.DBA;
using BILBasic.Basing;
using BILWeb.Login.User;
using BILBasic.Common;
using BILWeb.UserGroup;
using BILBasic.User;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace BILWeb.Menu
{
    public partial class T_MENU_DB : Base_DB<T_MenuInfo>
    {

        /// <summary>
        /// 添加T_MENU
        /// </summary>
        protected override OracleParameter[] GetSaveModelOracleParameter(T_MenuInfo t_menu)
        {
            //注意!head表ID要填basemodel的headerID new SqlParameter("@CustomerID", DbHelperSQL.ToDBValue(model.HeaderID)),
            OracleParameter[] param = new OracleParameter[]{
                new OracleParameter("@bResult",OracleDbType.Int32),
               new OracleParameter("@ErrorMsg",OracleDbType.NVarchar2,1000),
               
               new OracleParameter("@v_ID", OracleDBHelper.ToDBValue(t_menu.ID)),
               new OracleParameter("@v_MenuNo", OracleDBHelper.ToDBValue(t_menu.MenuNo)),
               new OracleParameter("@v_MenuName", OracleDBHelper.ToDBValue(t_menu.MenuName)),
               new OracleParameter("@v_MenuAbbName", t_menu.MemuAbbName.ToOracleValue()),
               new OracleParameter("@v_MenuType", t_menu.MenuType.ToOracleValue()),
               new OracleParameter("@v_ProjectName", t_menu.ProjectName.ToOracleValue()),
               new OracleParameter("@v_IcoName", t_menu.IcoName.ToOracleValue()),
               new OracleParameter("@v_SafeLevel", t_menu.SafeLevel.ToOracleValue()),
               new OracleParameter("@v_IsDefault", t_menu.IsDefault.ToOracleValue()),
               new OracleParameter("@v_NodeUrl", t_menu.NodeUrl.ToOracleValue()),
               new OracleParameter("@v_NodeLevel", t_menu.NodeLevel.ToOracleValue()),
               new OracleParameter("@v_NodeSort", t_menu.NodeSort.ToOracleValue()),
               new OracleParameter("@v_ParentID", t_menu.ParentID.ToOracleValue()),
               new OracleParameter("@v_MenuStatus", t_menu.MenuStatus.ToOracleValue()),
               new OracleParameter("@v_Description", t_menu.Description.ToOracleValue()),
               new OracleParameter("@v_IsDel", t_menu.IsDel.ToOracleValue()),
               new OracleParameter("@v_Creater", t_menu.Creater.ToOracleValue()),
               new OracleParameter("@v_CreateTime", t_menu.CreateTime.ToOracleValue()),
               new OracleParameter("@v_Modifyer", t_menu.Modifyer.ToOracleValue()),
               new OracleParameter("@v_ModifyTime", t_menu.ModifyTime.ToOracleValue()),
               new OracleParameter("@v_ModifyTime", t_menu.MenuStyle.ToOracleValue()),
              };

            param[0].Direction = System.Data.ParameterDirection.Output;
            param[1].Direction = System.Data.ParameterDirection.Output;
            param[2].Direction = System.Data.ParameterDirection.InputOutput;
           
            return param;


        }

        protected override List<string> GetSaveSql(UserModel user, ref T_MenuInfo t_menu)
        {
            throw new NotImplementedException();
        }




        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        protected override T_MenuInfo ToModel(OracleDataReader reader)
        {
            T_MenuInfo t_menu = new T_MenuInfo();

            t_menu.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();
            t_menu.MenuNo = (string)OracleDBHelper.ToModelValue(reader, "MENUNO");
            t_menu.MenuName = (string)OracleDBHelper.ToModelValue(reader, "MENUNAME");
            t_menu.MemuAbbName = (string)OracleDBHelper.ToModelValue(reader, "MENUABBNAME");
            t_menu.MenuType = OracleDBHelper.ToModelValue(reader, "MENUTYPE").ToInt32();
            t_menu.ProjectName = (string)OracleDBHelper.ToModelValue(reader, "PROJECTNAME");
            t_menu.IcoName = (string)OracleDBHelper.ToModelValue(reader, "ICONAME");
            t_menu.SafeLevel = (decimal?)OracleDBHelper.ToModelValue(reader, "SAFELEVEL");
            t_menu.IsDefault = (decimal?)OracleDBHelper.ToModelValue(reader, "ISDEFAULT");
            t_menu.Mnemonic = (decimal?)OracleDBHelper.ToModelValue(reader, "MNEMONIC");
            t_menu.Mnemoniccode = (string)OracleDBHelper.ToModelValue(reader, "MNEMONICCODE");
            t_menu.NodeUrl = (string)OracleDBHelper.ToModelValue(reader, "NODEURL");
            t_menu.NodeLevel = OracleDBHelper.ToModelValue(reader, "NODELEVEL").ToInt32();
            t_menu.NodeSort = OracleDBHelper.ToModelValue(reader, "NODESORT").ToInt32();
            t_menu.ParentID = OracleDBHelper.ToModelValue(reader, "PARENTID").ToInt32();
            t_menu.MenuStatus =OracleDBHelper.ToModelValue(reader, "MENUSTATUS").ToInt32();
            t_menu.Description = (string)OracleDBHelper.ToModelValue(reader, "DESCRIPTION");
            t_menu.IsDel = (decimal?)OracleDBHelper.ToModelValue(reader, "ISDEL");
            t_menu.Creater = (string)OracleDBHelper.ToModelValue(reader, "CREATER");
            t_menu.CreateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CREATETIME");
            t_menu.Modifyer = (string)OracleDBHelper.ToModelValue(reader, "MODIFYER");
            t_menu.ModifyTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "MODIFYTIME");
            t_menu.MenuStyle = (decimal?)OracleDBHelper.ToModelValue(reader, "MENUSTYLE");

            if (Common_Func.readerExists(reader, "ParentName")) t_menu.ParentName = reader["ParentName"].ToDBString();
            if (Common_Func.readerExists(reader, "MenuStyle")) t_menu.MenuStyle = reader["MenuStyle"].ToInt32();

            if (Common_Func.readerExists(reader, "IsChecked")) t_menu.IsChecked = reader["IsChecked"].ToBoolean();
            if (Common_Func.readerExists(reader, "StrMenuType")) t_menu.StrMenuType = reader["StrMenuType"].ToDBString();
            if (Common_Func.readerExists(reader, "StrMenuStatus")) t_menu.StrMenuStatus = reader["StrMenuStatus"].ToDBString();
            if (Common_Func.readerExists(reader, "SonQty")) t_menu.SonQty = reader["SonQty"].ToInt32();
            if (Common_Func.readerExists(reader, "StrMenuStyle")) t_menu.StrMenuStyle = reader["StrMenuStyle"].ToDBString();


            t_menu.BIsDefault = t_menu.IsDefault.ToBoolean();
            t_menu.BHaveParameter = t_menu.MenuType == 2 && t_menu.ProjectName.IndexOf(':') >= 0;

            t_menu.StrCreateTime = t_menu.CreateTime.ToShowTime();
            t_menu.StrModifyTime = t_menu.ModifyTime.ToShowTime();

            return t_menu;
        }

        protected override string GetViewName()
        {
            return "V_MENU";
        }

        protected override string GetTableName()
        {
            return "T_MENU";
        }

        protected override string GetSaveProcedureName()
        {
            return "P_SAVE_T_MENU";
        }


        public List<T_MenuInfo> GetModelListBySql(UserInfo user, bool IncludNoCheck) 
        {
            string strSql = string.Empty;
            if (user.ID >= 1)
            {
                strSql = string.Format("SELECT DISTINCT 2 AS IsChecked,T_Menu.* from T_Menu WHERE ISDEL <> 2 AND MenuStatus <> 2 AND ID IN (SELECT MenuID FROM T_GroupWithMenu WHERE GroupID IN (SELECT T_USERGROUP.ID FROM T_UserWithGroup JOIN T_USERGROUP ON T_UserWithGroup.Groupid = T_USERGROUP.ID WHERE T_USERGROUP.ISDEL <> 2 AND T_USERGROUP.USERGROUPSTATUS <> 2 AND T_UserWithGroup.UserID = {0})) ", user.ID);
                if (IncludNoCheck) strSql += string.Format("UNION SELECT DISTINCT 1 AS IsChecked,T_Menu.* from T_Menu WHERE ISDEL <> 2 AND MenuStatus <> 2 AND ID NOT IN (SELECT MenuID FROM T_GroupWithMenu WHERE GroupID IN (SELECT T_USERGROUP.ID FROM T_UserWithGroup JOIN T_USERGROUP ON T_UserWithGroup.Groupid = T_USERGROUP.ID WHERE T_USERGROUP.ISDEL <> 2 AND T_USERGROUP.USERGROUPSTATUS <> 2 AND T_UserWithGroup.UserID = {0})) ", user.ID);
                if (user.UserType == 1) strSql += "UNION SELECT DISTINCT 2 AS IsChecked,T_Menu.* from T_Menu WHERE ISDEL <> 2 AND MenuStatus <> 2 AND SafeLevel <> 0 ";
                strSql = string.Format("SELECT * FROM ({0}) T ORDER BY NodeLevel, NodeSort, ID  ", strSql);
            }
            else
            {
                if (IncludNoCheck) strSql = "SELECT DISTINCT 1 AS IsChecked,T_Menu.* FROM T_Menu WHERE ISDEL <> 2 AND MenuStatus <> 2 ORDER BY NodeLevel, NodeSort, ID ";
                else strSql = "SELECT DISTINCT 2 AS IsChecked,T_Menu.* FROM T_Menu WHERE 1 = 2";
            }

            return GetModelListBySql(strSql);
        }


        internal List<T_MenuInfo> GetMenuListByUserGroupID(int UserGroupID, bool IncludNoCheck)
        {
            string strSql = string.Empty;
            if (UserGroupID >= 1)
            {
                strSql = string.Format("SELECT DISTINCT 2 AS IsChecked,T_Menu.* FROM T_Menu WHERE ISDEL <> 2 AND ID IN (SELECT MenuID FROM T_GroupWithMenu WHERE GroupID = {0}) ", UserGroupID);
                if (IncludNoCheck) strSql += string.Format("UNION SELECT DISTINCT 1 AS IsChecked,T_Menu.* FROM T_Menu WHERE ISDEL <> 2 AND ID NOT IN (SELECT MenuID FROM T_GroupWithMenu WHERE GroupID = {0}) ", UserGroupID);
                strSql = string.Format("SELECT * FROM ({0}) T ORDER BY NodeLevel, NodeSort, ID ", strSql);
            }
            else
            {
                if (IncludNoCheck) strSql = "SELECT DISTINCT 1 AS IsChecked,T_Menu.* FROM T_Menu WHERE ISDEL <> 2 ORDER BY NodeUrl, NodeSort, ID ";
                else strSql = "SELECT DISTINCT 2 AS IsChecked,T_Menu.* FROM T_Menu WHERE 1 = 2";
            }

            return GetModelListBySql(strSql);
        }

        internal bool SaveUserGroupMenuToDB(UserInfo user, T_MenuInfo model, int UserGroupID, ref string strError)
        {
            try
            {
                OracleParameter[] param = new OracleParameter[]{
               new OracleParameter("@ErrorMsg",OracleDbType.NVarchar2,1000),
               
               new OracleParameter("@v_MenuID", model.ID.ToOracleValue()),
               new OracleParameter("@v_UserGroupID", UserGroupID.ToOracleValue()),
               new OracleParameter("@v_IsChecked", model.IsChecked.ToOracleValue()),
            };
                param[0].Direction = ParameterDirection.Output;

                OracleDBHelper.ExecuteNonQuery2(CommandType.StoredProcedure, "P_Save_T_GroupWithMenu", param);

                string ErrorMsg = param[0].Value.ToDBString();
                if (ErrorMsg.StartsWith("执行错误"))
                {
                    throw new Exception(ErrorMsg);
                }
                else
                {
                    return string.IsNullOrEmpty(ErrorMsg);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
