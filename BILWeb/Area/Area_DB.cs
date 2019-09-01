//************************************************************
//******************************作者：方颖*********************
//******************************时间：2016/11/4 15:46:48*******

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILBasic.Basing;
using BILBasic.DBA;
using BILBasic.Common;
using BILBasic.User;
using Oracle.ManagedDataAccess.Client;

namespace BILWeb.Area
{
    public partial class T_Area_DB : BILBasic.Basing.Base_DB<T_AreaInfo>
    {

        /// <summary>
        /// 添加T_AREA
        /// </summary>
        protected override OracleParameter[] GetSaveModelOracleParameter(T_AreaInfo model)
        {
            OracleParameter[] param = new OracleParameter[]{
               new OracleParameter("@bResult",OracleDbType.Int32),
               new OracleParameter("@ErrorMsg",OracleDbType.NVarchar2,1000),
               
               new OracleParameter("@v_ID", model.ID.ToOracleValue()),
               new OracleParameter("@v_AreaNo", model.AreaNo.ToOracleValue()),
               new OracleParameter("@v_AreaName", model.AreaName.ToOracleValue()),
               new OracleParameter("@v_AreaType", model.AreaType.ToOracleValue()),
               new OracleParameter("@v_ContactUser", model.ContactUser.ToOracleValue()),
               new OracleParameter("@v_ContactPhone", model.ContactPhone.ToOracleValue()),
               new OracleParameter("@v_Address", model.Address.ToOracleValue()),
               new OracleParameter("@v_LocationDesc", model.LocationDesc.ToOracleValue()),
               new OracleParameter("@v_AreaStatus", model.AreaStatus.ToOracleValue()),
               new OracleParameter("@v_HouseID", model.HouseID.ToOracleValue()),
               new OracleParameter("@v_IsDel", model.IsDel.ToOracleValue()),
               new OracleParameter("@v_Creater", model.Creater.ToOracleValue()),
               new OracleParameter("@v_CreateTime", model.CreateTime.ToOracleValue()),
               new OracleParameter("@v_Modifyer", model.Modifyer.ToOracleValue()),
               new OracleParameter("@v_ModifyTime", model.ModifyTime.ToOracleValue()),

               new OracleParameter("@v_Length", model.Length.ToOracleValue()),
               new OracleParameter("@v_Wide", model.Wide.ToOracleValue()),
               new OracleParameter("@v_Hight", model.Hight.ToOracleValue()),
               new OracleParameter("@v_WeightLimit", model.WeightLimit.ToOracleValue()),
               new OracleParameter("@v_VolumeLimit", model.VolumeLimit.ToOracleValue()),
               new OracleParameter("@v_QuantityLimit", model.QuantityLimit.ToOracleValue()),
               new OracleParameter("@v_PalletLimit", model.PalletLimit.ToOracleValue()),
               new OracleParameter("@v_TemperaturePry", model.TemperaturePry.ToOracleValue()),
               new OracleParameter("@v_CustomerNo", model.CustomerNo.ToOracleValue()),
               new OracleParameter("@v_CustomerName", model.CustomerName.ToOracleValue()),
               new OracleParameter("@v_ProjectNo", model.ProjectNo.ToOracleValue()),
               new OracleParameter("@v_IEscrow", model.IsDel.ToOracleValue()),
               new OracleParameter("@v_HeightArea", model.HeightArea.ToOracleValue()),
               new OracleParameter("@v_SortArea", model.SortArea.ToOracleValue()),
              };

            param[0].Direction = System.Data.ParameterDirection.Output;
            param[1].Direction = System.Data.ParameterDirection.Output;
            param[2].Direction = System.Data.ParameterDirection.InputOutput;


            return param;
        }

        protected override List<string> GetSaveSql(UserModel user,ref T_AreaInfo t_area)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        protected override T_AreaInfo ToModel(OracleDataReader reader)
        {
            T_AreaInfo t_area = new T_AreaInfo();

            t_area.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();
            t_area.AreaNo = (string)OracleDBHelper.ToModelValue(reader, "AREANO");
            t_area.AreaName = (string)OracleDBHelper.ToModelValue(reader, "AREANAME");
            t_area.AreaType = OracleDBHelper.ToModelValue(reader, "AREATYPE").ToInt32();
            t_area.ContactUser = (string)OracleDBHelper.ToModelValue(reader, "CONTACTUSER");
            t_area.ContactPhone = (string)OracleDBHelper.ToModelValue(reader, "CONTACTPHONE");
            t_area.Address = (string)OracleDBHelper.ToModelValue(reader, "ADDRESS");
            t_area.LocationDesc = (string)OracleDBHelper.ToModelValue(reader, "LOCATIONDESC");
            t_area.AreaStatus = OracleDBHelper.ToModelValue(reader, "AREASTATUS").ToInt32();
            t_area.HouseID = OracleDBHelper.ToModelValue(reader, "HOUSEID").ToInt32();
            t_area.IsDel = OracleDBHelper.ToModelValue(reader, "ISDEL").ToInt32();
            t_area.Creater = (string)OracleDBHelper.ToModelValue(reader, "CREATER");
            t_area.CreateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CREATETIME");
            t_area.Modifyer = (string)OracleDBHelper.ToModelValue(reader, "MODIFYER");
            t_area.ModifyTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "MODIFYTIME");
            t_area.CheckID = OracleDBHelper.ToModelValue(reader, "CHECKID").ToInt32();

            t_area.Length = OracleDBHelper.ToModelValue(reader, "Length").ToDecimal();
            t_area.Wide = OracleDBHelper.ToModelValue(reader, "Wide").ToDecimal();
            t_area.Hight = OracleDBHelper.ToModelValue(reader, "Hight").ToDecimal();
            t_area.WeightLimit = OracleDBHelper.ToModelValue(reader, "WeightLimit").ToDecimal();
            t_area.VolumeLimit = OracleDBHelper.ToModelValue(reader, "VolumeLimit").ToDecimal();
            t_area.QuantityLimit = OracleDBHelper.ToModelValue(reader, "QuantityLimit").ToDecimal();
            t_area.PalletLimit = OracleDBHelper.ToModelValue(reader, "PalletLimit").ToDecimal();
            t_area.TemperaturePry = OracleDBHelper.ToModelValue(reader, "TemperaturePry").ToDBString();
            t_area.CustomerNo = OracleDBHelper.ToModelValue(reader, "CustomerNo").ToDBString();
            t_area.CustomerName = OracleDBHelper.ToModelValue(reader, "CustomerName").ToDBString();
            t_area.ProjectNo = OracleDBHelper.ToModelValue(reader, "ProjectNo").ToDBString();
            t_area.IEscrow = OracleDBHelper.ToModelValue(reader, "IEscrow").ToInt32();

            if (Common_Func.readerExists(reader, "HouseNo")) t_area.HouseNo = reader["HouseNo"].ToDBString();
            if (Common_Func.readerExists(reader, "HouseName")) t_area.HouseName = reader["HouseName"].ToDBString();
            if (Common_Func.readerExists(reader, "WarehouseNo")) t_area.WarehouseNo = reader["WarehouseNo"].ToDBString();
            if (Common_Func.readerExists(reader, "WarehouseName")) t_area.WarehouseName = reader["WarehouseName"].ToDBString();
            if (Common_Func.readerExists(reader, "StrAreaStatus")) t_area.StrAreaStatus = reader["StrAreaStatus"].ToDBString();
            if (Common_Func.readerExists(reader, "StrAreaType")) t_area.StrAreaStatus = reader["StrAreaType"].ToDBString();
            
            if (Common_Func.readerExists(reader, "CheckID")) t_area.CheckID = reader["CheckID"].ToInt32();

            t_area.StrCreateTime = t_area.CreateTime.ToShowTime();
            t_area.StrModifyTime = t_area.ModifyTime.ToShowTime();

            t_area.WarehouseID = OracleDBHelper.ToModelValue(reader, "WarehouseID").ToInt32();
            t_area.HeightArea = OracleDBHelper.ToModelValue(reader, "HeightArea").ToInt32();
            t_area.StrHeightArea = OracleDBHelper.ToModelValue(reader, "StrHeightArea").ToDBString();
            t_area.QuanUserNo = OracleDBHelper.ToModelValue(reader, "Samplercode").ToDBString();
            t_area.QuanUserName = OracleDBHelper.ToModelValue(reader, "Samplername").ToDBString();
            t_area.SortArea = OracleDBHelper.ToModelValue(reader, "SortArea").ToDBString();
            t_area.StrAreaStatus = OracleDBHelper.ToModelValue(reader, "StrAreaStatus").ToDBString();
            t_area.StrAreaType = OracleDBHelper.ToModelValue(reader, "StrAreaType").ToDBString();
            t_area.HouseProp = OracleDBHelper.ToModelValue(reader, "HouseProp").ToDBString();

            return t_area;

        }

        protected override string GetViewName()
        {
            return "V_AREA";
        }

        protected override string GetTableName()
        {
            return "T_AREA";
        }

        protected override string GetSaveProcedureName()
        {
            return "P_SAVE_T_AREA";
        }

        protected override string GetDeleteProcedureName()
        {
            return "P_DELETE_T_AREA";
        }

        protected override string GetFilterSql(UserModel user, T_AreaInfo model)
        {
            string strSql = " where nvl(isDel,0) != 2";

            string strAnd = " and ";

            if (model.HouseID > 0)
            {
                strSql += strAnd;
                strSql += " HouseID = '" + model.HouseID + "'  ";
            }

            if (!string.IsNullOrEmpty(model.AreaNo))
            {
                strSql += strAnd;
                strSql += " areano like '" + model.AreaNo + "%'  ";
            }

            if (!Common_Func.IsNullOrEmpty(model.WarehouseNo))
            {
                strSql += strAnd;
                strSql += "  (WarehouseNo LIKE '%" + model.WarehouseNo + "%' OR WarehouseName Like '%" + model.WarehouseNo + "%')  ";
            }

            if (!Common_Func.IsNullOrEmpty(model.HouseNo))
            {
                strSql += strAnd;
                strSql += "  (HouseNo LIKE '%" + model.HouseNo + "%' OR HouseName Like '%" + model.HouseNo + "%') ";
            }

            //if (!Common_Func.IsNullOrEmpty(model.Creater))
            //{
            //    strSql += strAnd;
            //    strSql += " Creater Like '%" + model.Creater + "%' ";
            //}

            //if (model.DateFrom != null)
            //{
            //    strSql += strAnd;
            //    strSql += " CreateTime >= " + model.DateFrom.ToDateTime().Date.ToOracleTimeString() + "  ";
            //}

            //if (model.DateTo != null)
            //{
            //    strSql += strAnd;
            //    strSql += " CreateTime <= " + model.DateTo.ToDateTime().AddDays(1).Date.ToOracleTimeString() + " ";
            //}

            return strSql;
        }
      

        protected override string GetModelSql(T_AreaInfo model)
        {
            if (model.WarehouseID == null || model.WarehouseID ==0)
            {
                return string.Format("select * from v_area where areano = '{0}' and isdel = 1 ", model.AreaNo);
            }
            else
            {
                return string.Format("select * from v_area where areano = '{0}' and isdel = 1 and WAREHOUSEID = '{1}'", model.AreaNo, model.WarehouseID);
            }
          
        }



        /// <summary>
        /// 根据仓库ID获取收货库位和拣货清点货位
        /// </summary>
        /// <param name="WareHouseID"></param>
        /// <returns></returns>
        public List<T_AreaInfo> GetAreaModelList(int WareHouseID)
        {
            try
            {
                string strSql = "select * from v_Area a where a.warehouseid = '" + WareHouseID + "' and  ( areatype = 2 or areatype = 3 or areatype = 4 )";
                List<T_AreaInfo> modelList = base.GetModelListBySql(strSql);
                if (modelList == null || modelList.Count == 0)
                {
                    return null;
                }
                else
                {
                    return modelList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public int CheckAreaType(T_AreaInfo model)
        {
            string strSql = string.Format("select * from v_area where areatype = '{0}' and nvl(isdel,1) = 1 and warehouseid = (select warehouseid from t_house where id='{1}') and v_area.ID <> '{2}' ", model.AreaType, model.HouseID, model.ID);
            return GetScalarBySql(strSql).ToInt32();
        }

        public int GetHouseTypeByAreaNo(T_AreaInfo mdoel) 
        {
            string strSql = string.Format("select housetype from t_house where id = '{0}' ", mdoel.HouseID);
            return GetScalarBySql(strSql).ToInt32();
        }

    }
}
