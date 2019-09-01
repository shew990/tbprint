using BILBasic.DBA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILBasic.Common;
using BILBasic.User;
using BILWeb.Warehouse;
using Oracle.ManagedDataAccess.Client;

namespace BILWeb.House
{
    public partial class T_House_DB : BILBasic.Basing.Base_DB<T_HouseInfo>
    {
        /// <summary>
        /// 添加T_HOUSE
        /// </summary>
        protected override OracleParameter[] GetSaveModelOracleParameter(T_HouseInfo model)
        {
            OracleParameter[] param = new OracleParameter[]{
               new OracleParameter("@bResult",OracleDbType.Int32),
               new OracleParameter("@ErrorMsg",OracleDbType.NVarchar2,1000),                        
               
               new OracleParameter("@v_ID", model.ID.ToOracleValue()),
               new OracleParameter("@v_HouseNo", model.HouseNo.ToOracleValue()),
               new OracleParameter("@v_HouseName", model.HouseName.ToOracleValue()),
               new OracleParameter("@v_HouseType", model.HouseType.ToOracleValue()),
               new OracleParameter("@v_ContactUser", model.ContactUser.ToOracleValue()),
               new OracleParameter("@v_ContactPhone", model.ContactPhone.ToOracleValue()),
               new OracleParameter("@v_HouseCount", model.AreaCount.ToOracleValue()),
               new OracleParameter("@v_HouseUsingCount", model.AreaUsingCount.ToOracleValue()),
               new OracleParameter("@v_Address", model.Address.ToOracleValue()),
               new OracleParameter("@v_LocationDesc", model.LocationDesc.ToOracleValue()),
               new OracleParameter("@v_HouseStatus", model.HouseStatus.ToOracleValue()),
               new OracleParameter("@v_WarehouseID", model.WarehouseID.ToOracleValue()),
               new OracleParameter("@v_IsDel", model.IsDel.ToOracleValue()),
               new OracleParameter("@v_Creater", model.Creater.ToOracleValue()),
               new OracleParameter("@v_CreateTime", model.CreateTime.ToOracleValue()),
               new OracleParameter("@v_Modifyer", model.Modifyer.ToOracleValue()),
               new OracleParameter("@v_ModifyTime", model.ModifyTime.ToOracleValue()),
               new OracleParameter("@v_FloorType", model.FloorType.ToOracleValue()),
               new OracleParameter("@v_MaterialClassCode", model.MaterialClassCode.ToOracleValue()),
               new OracleParameter("@v_HousePropType", model.HouseProp.ToOracleValue()),
            };

            param[0].Direction = System.Data.ParameterDirection.Output;
            param[1].Direction = System.Data.ParameterDirection.Output;
            param[2].Direction = System.Data.ParameterDirection.InputOutput;
           

            return param;



        }

        protected override List<string> GetSaveSql(UserModel user,ref T_HouseInfo t_house)
        {
            throw new NotImplementedException();
        }




        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        protected override T_HouseInfo ToModel(OracleDataReader reader)
        {
            T_HouseInfo t_house = new T_HouseInfo();

            t_house.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();
            t_house.HouseNo = (string)OracleDBHelper.ToModelValue(reader, "HOUSENO");
            t_house.HouseName = (string)OracleDBHelper.ToModelValue(reader, "HOUSENAME");
            t_house.HouseType = OracleDBHelper.ToModelValue(reader, "HOUSETYPE").ToInt32();
            t_house.ContactUser = (string)OracleDBHelper.ToModelValue(reader, "CONTACTUSER");
            t_house.ContactPhone = (string)OracleDBHelper.ToModelValue(reader, "CONTACTPHONE");
            t_house.AreaCount = OracleDBHelper.ToModelValue(reader, "AREACOUNT").ToInt32();
            t_house.AreaUsingCount = OracleDBHelper.ToModelValue(reader, "AREAUSINGCOUNT").ToInt32();
            t_house.Address = (string)OracleDBHelper.ToModelValue(reader, "ADDRESS");
            t_house.LocationDesc = (string)OracleDBHelper.ToModelValue(reader, "LOCATIONDESC");
            t_house.HouseStatus = OracleDBHelper.ToModelValue(reader, "HOUSESTATUS").ToInt32();
            t_house.WarehouseID = OracleDBHelper.ToModelValue(reader, "WAREHOUSEID").ToInt32();
            t_house.IsDel = OracleDBHelper.ToModelValue(reader, "ISDEL").ToInt32();
            t_house.Creater = (string)OracleDBHelper.ToModelValue(reader, "CREATER");
            t_house.CreateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CREATETIME");
            t_house.Modifyer = (string)OracleDBHelper.ToModelValue(reader, "MODIFYER");
            t_house.ModifyTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "MODIFYTIME");


            if (Common_Func.readerExists(reader, "WarehouseNo")) t_house.WarehouseNo = reader["WarehouseNo"].ToDBString();
            if (Common_Func.readerExists(reader, "WarehouseName")) t_house.WarehouseName = reader["WarehouseName"].ToDBString();
            if (Common_Func.readerExists(reader, "StrHouseStatus")) t_house.StrHouseStatus = reader["StrHouseStatus"].ToDBString();
            if (Common_Func.readerExists(reader, "StrHouseType")) t_house.StrHouseType = reader["StrHouseType"].ToDBString();
            if (Common_Func.readerExists(reader, "StrFloorType")) t_house.StrFloorType = reader["StrFloorType"].ToDBString();

            t_house.AreaRate = t_house.AreaCount >= 1 ? t_house.AreaUsingCount.ToDecimal() / t_house.AreaCount.ToDecimal() : 0;

            t_house.FloorType = OracleDBHelper.ToModelValue(reader, "FloorType").ToInt32();
            t_house.MaterialClassCode = OracleDBHelper.ToModelValue(reader, "MaterialClassCode").ToDBString();
            t_house.MaterialClassName = OracleDBHelper.ToModelValue(reader, "MaterialClassName").ToDBString();
            t_house.HouseProp = OracleDBHelper.ToModelValue(reader, "HouseProp").ToInt32();
            t_house.StrHouseProp = OracleDBHelper.ToModelValue(reader, "StrHouseProp").ToDBString();

            return t_house;
        }

        protected override string GetViewName()
        {
            return "V_HOUSE";
        }

        protected override string GetTableName()
        {
            return "T_HOUSE";
        }

        protected override string GetSaveProcedureName()
        {
            return "P_SAVE_T_HOUSE";
        }

        protected override string GetDeleteProcedureName()
        {
            return "P_DELETE_T_HOUSE";
        }

        protected override string GetFilterSql(UserModel user, T_HouseInfo model)
        {
            string strSql = " where nvl(isDel,0) != 2";

            string strAnd = " and ";
            if (model.WarehouseID > 0) 
            {
                strSql += strAnd;
                strSql += " warehouseid = '"+model.WarehouseID+"'  ";
            }

            if (!Common_Func.IsNullOrEmpty(model.WarehouseNo))
            {
                strSql += strAnd;
                strSql += " (WarehouseNo LIKE '%" + model.WarehouseNo + "%' OR WarehouseName Like '%" + model.WarehouseNo + "%')  ";
            }

            if (!Common_Func.IsNullOrEmpty(model.HouseNo))
            {
                strSql += strAnd;
                //strSql += " ID In (Select WarehouseID From T_House Where HouseNo LIKE '%" + model.HouseNo + "%' OR HouseName Like '%" + model.HouseNo + "%') ";
                strSql += "(HouseNo LIKE '%" + model.HouseNo + "%' OR HouseName Like '%" + model.HouseNo + "%') ";
            }

            if (!Common_Func.IsNullOrEmpty(model.AreaNo))
            {
                strSql += strAnd;
                strSql += " ID In (Select houseid From t_area Where AreaNo LIKE '" + model.AreaNo + "%' OR AreaName Like '" + model.AreaNo + "%') ";
                
            }

            if (!Common_Func.IsNullOrEmpty(model.Creater))
            {
                strSql += strAnd;
                strSql += " Creater Like '%" + model.Creater + "%' ";
            }

            if (model.DateFrom != null)
            {
                strSql += strAnd;
                strSql += " CreateTime >= " + model.DateFrom.ToDateTime().Date.ToOracleTimeString() + "  ";
            }

            if (model.DateTo != null)
            {
                strSql += strAnd;
                strSql += " CreateTime <= " + model.DateTo.ToDateTime().AddDays(1).Date.ToOracleTimeString() + " ";
            }

            return strSql;
        }


        public int CheckHouseType(T_HouseInfo model)
        {
            string strSql = string.Format("select count(1) from t_House where housetype = '{0}' and nvl(isdel,1) = 1 and warehouseid ='{1}' and id <> '{2}' ", model.HouseType, model.WarehouseID,model.ID);
            return GetScalarBySql(strSql).ToInt32();
        }

        public int CheckHouseTypeArea(T_HouseInfo model)
        {
            string strSql = string.Format("select count(1) from t_area a where a.Houseid <> '{0}' and  nvl(a.Areatype,1) = '"+model.HouseType+"' and nvl(a.Isdel,1) = 1", model.ID);
            return GetScalarBySql(strSql).ToInt32();
        }
       
    }
}
