using BILBasic.DBA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILBasic.Common;
using BILBasic.User;
using Oracle.ManagedDataAccess.Client;

namespace BILWeb.Material
{
    public partial class T_Material_DB : BILBasic.Basing.Base_DB<T_MaterialInfo>
    {

        /// <summary>
        /// 添加t_material
        /// </summary>
        protected override OracleParameter[] GetSaveModelOracleParameter(T_MaterialInfo t_material)
        {
            //注意!head表ID要填basemodel的headerID new SqlParameter("@CustomerID", DbHelperSQL.ToDBValue(model.HeaderID)),
            throw new NotImplementedException();
        }

        protected override List<string> GetSaveSql(UserModel user,ref  T_MaterialInfo model)
        {
            List<string> lstSql = new List<string>();
            string strSql = string.Empty;

            if (model.ID <= 0)
            {
                int voucherID = base.GetTableID("seq_material");

                model.ID = voucherID.ToInt32();

                strSql = "insert into T_MATERIAL (id, materialno, materialdesc, materialdescen, stackwarehouse, stackhouse, stackarea, length, wide, hight, volume, weight, netweight, packrule, stackrule, disrule, supplierno, suppliername, unit, UnitName, keeperno, keepername, isdangerous, isactivate, isbond, isquality, creater, createtime,isserial,partno)" +
                            "values ('" + voucherID + "', '" + model.MaterialNo + "','" + model.MaterialDesc + "','" + model.MaterialDescEN + "','" + model.StackWareHouse + "','" + model.StackHouse + "','" + model.StackArea + "'," +
                            "'" + model.Length + "','" + model.Wide + "','" + model.Hight + "', '" + model.Volume + "','" + model.Weight + "','" + model.NetWeight + "', '" + model.PackRule + "','" + model.StackRule + "','"+model.DisRule+"','" + model.SupplierNo + "'," +
                            "'" + model.SupplierName + "','" + model.Unit + "','" + model.UnitName + "','" + model.KeeperNo + "','" + model.KeeperName + "','" + model.IsDangerous + "','" + model.IsActivate + "','" + model.IsBond + "','" + model.IsQuality + "'," +
                            "'" + user.UserNo + "',sysdate,'"+model.IsSerial+"','"+model.PartNo+"')";
                lstSql.Add(strSql);
            }
            else 
            {
                 strSql = "update t_Material a set a.Materialno = '" + model.MaterialNo + "',a.Materialdesc =  '" + model.MaterialDesc + "',a.Materialdescen= '" + model.MaterialDescEN + "',a.Stackwarehouse= '" + model.StackWareHouse + "',a.Stackhouse= '" + model.StackHouse + "',a.Stackarea= '" + model.StackArea + "',a.Length= '" + model.Length + "',a.Wide= '" + model.Wide + "',a.Hight= '" + model.Hight + "'," +
                                "a.Volume = '" + model.Volume + "' ,a.Weight = '" + model.Weight + "' ,a.Netweight= '" + model.NetWeight + "',a.Packrule= '" + model.PackRule + "',a.Stackrule= '" + model.StackRule + "',a.Disrule= '" + model.DisRule + "',a.Supplierno= '" + model.SupplierNo + "',a.Suppliername= '" + model.SupplierName + "',a.Unit= '" + model.Unit + "',a.Unitname= '" + model.UnitName + "',a.Keeperno= '" + model.KeeperNo + "',a.Keepername= '" + model.KeeperName + "'," +
                                "a.Isdangerous= '" + model.IsDangerous + "',a.Isactivate= '" + model.IsActivate + "',a.Isquality= '" + model.IsQuality + "',a.Modifyer= '" + user.Modifyer + "',a.Modifytime=Sysdate,a.isserial = '"+model.IsSerial+"' ,a.partno = '"+model.PartNo+"' where a.Id = '" + model.ID + "'";
                 lstSql.Add(strSql);
            }
            
            return lstSql;
        }

        protected override List<string> GetDeleteSql(UserModel user, T_MaterialInfo model)
        {
            List<string> lstSql = new List<string>();
            string strSql = string.Empty;

            strSql = "delete t_Material where id = '" + model.ID + "'";
            lstSql.Add(strSql);

            strSql = "delete t_Material_Batch where headerid = '"+model.ID+"'";
            lstSql.Add(strSql);

            return lstSql;
        }




        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        protected override T_MaterialInfo ToModel(OracleDataReader reader)
        {
            T_MaterialInfo t_material = new T_MaterialInfo();

            t_material.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();
            t_material.MaterialNo = (string)OracleDBHelper.ToModelValue(reader, "MATERIALNO");
            t_material.MaterialDesc = (string)OracleDBHelper.ToModelValue(reader, "MATERIALDESC");
            t_material.MaterialDescEN = (string)OracleDBHelper.ToModelValue(reader, "MATERIALDESCEN");
            t_material.StackWareHouse = OracleDBHelper.ToModelValue(reader, "STACKWAREHOUSE").ToInt32();
            t_material.StackHouse = OracleDBHelper.ToModelValue(reader, "STACKHOUSE").ToInt32();
            t_material.StackArea = OracleDBHelper.ToModelValue(reader, "STACKAREA").ToInt32();
            t_material.Length = (decimal?)OracleDBHelper.ToModelValue(reader, "LENGTH");
            t_material.Wide = (decimal?)OracleDBHelper.ToModelValue(reader, "WIDE");
            t_material.Hight = (decimal?)OracleDBHelper.ToModelValue(reader, "HIGHT");
            t_material.Volume = (decimal?)OracleDBHelper.ToModelValue(reader, "VOLUME");
            t_material.Weight = (decimal?)OracleDBHelper.ToModelValue(reader, "WEIGHT");
            t_material.NetWeight = (decimal?)OracleDBHelper.ToModelValue(reader, "NETWEIGHT");
            t_material.PackRule = (decimal?)OracleDBHelper.ToModelValue(reader, "PACKRULE");
            t_material.StackRule = (decimal?)OracleDBHelper.ToModelValue(reader, "STACKRULE");
            t_material.DisRule = (decimal?)OracleDBHelper.ToModelValue(reader, "DISRULE");
            t_material.SupplierNo = (string)OracleDBHelper.ToModelValue(reader, "SUPPLIERNO");
            t_material.SupplierName = (string)OracleDBHelper.ToModelValue(reader, "SUPPLIERNAME");
            t_material.Unit = (string)OracleDBHelper.ToModelValue(reader, "UNIT");
            t_material.UnitName = (string)OracleDBHelper.ToModelValue(reader, "UnitName");
            t_material.KeeperNo = (string)OracleDBHelper.ToModelValue(reader, "KEEPERNO");
            t_material.KeeperName = (string)OracleDBHelper.ToModelValue(reader, "KEEPERNAME");
            t_material.IsDangerous = (decimal?)OracleDBHelper.ToModelValue(reader, "ISDANGEROUS");
            t_material.IsActivate = (decimal?)OracleDBHelper.ToModelValue(reader, "ISACTIVATE");
            t_material.IsBond = (decimal?)OracleDBHelper.ToModelValue(reader, "ISBOND");
            t_material.IsQuality = (decimal?)OracleDBHelper.ToModelValue(reader, "ISQUALITY");
            t_material.Creater = (string)OracleDBHelper.ToModelValue(reader, "CREATER");
            t_material.CreateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CREATETIME");
            t_material.Modifyer = (string)OracleDBHelper.ToModelValue(reader, "MODIFYER");
            t_material.ModifyTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "MODIFYTIME");
            t_material.IsSerial = OracleDBHelper.ToModelValue(reader, "IsSerial").ToInt32();
            t_material.PartNo = OracleDBHelper.ToModelValue(reader, "PartNo").ToDBString();
            t_material.DisplayName = (string)OracleDBHelper.ToModelValue(reader, "MATERIALDESC");
            t_material.StrongHoldCode = (string)OracleDBHelper.ToModelValue(reader, "StrongHoldCode");
            t_material.StrongHoldName = (string)OracleDBHelper.ToModelValue(reader, "Strongholdname");
            t_material.CompanyCode = (string)OracleDBHelper.ToModelValue(reader, "CompanyCode");
            t_material.MainTypeCode = (string)OracleDBHelper.ToModelValue(reader, "MainTypeCode");
            t_material.MainTypeName = (string)OracleDBHelper.ToModelValue(reader, "MainTypeName");
            t_material.PurchaseTypeCode = (string)OracleDBHelper.ToModelValue(reader, "PurchaseTypeCode");
            t_material.PurchaseTypeName = (string)OracleDBHelper.ToModelValue(reader, "PurchaseTypeName");
            t_material.ProductTypeCode = (string)OracleDBHelper.ToModelValue(reader, "ProductTypeCode");
            t_material.ProductTypeName = (string)OracleDBHelper.ToModelValue(reader, "ProductTypeName");
            t_material.QualityDay = OracleDBHelper.ToModelValue(reader, "QualityDay").ToDecimal();
            t_material.QualityMon = OracleDBHelper.ToModelValue(reader, "QualityMon").ToDecimal();
            t_material.Brand = (string)OracleDBHelper.ToModelValue(reader, "Brand");
            t_material.PlaceArea = (string)OracleDBHelper.ToModelValue(reader, "PlaceArea");
            t_material.LifeCycle = (string)OracleDBHelper.ToModelValue(reader, "LifeCycle");
            t_material.PackQty = OracleDBHelper.ToModelValue(reader, "PackQty").ToDecimal();
            t_material.PalletVolume = OracleDBHelper.ToModelValue(reader, "PalletVolume").ToDecimal();
            t_material.PalletPackQty = OracleDBHelper.ToModelValue(reader, "PalletPackQty").ToDecimal();
            t_material.PackVolume = OracleDBHelper.ToModelValue(reader, "PackVolume").ToDecimal();
            t_material.Status = OracleDBHelper.ToModelValue(reader, "Status").ToInt32();

            //t_material.WaterCode = (string)OracleDBHelper.ToModelValue(reader, "WaterCode");//ena码

            //if (Common_Func.readerExists(reader, "Batchno")) t_material.BatchNo = reader["Batchno"].ToDBString();
            //if (Common_Func.readerExists(reader, "EDate")) t_material.EDate = reader["EDate"].ToDateTime();
            //t_material.WareHouseNo = OracleDBHelper.ToModelValue(reader, "WareHouseNo").ToDBString();
            //t_material.AreaNo = OracleDBHelper.ToModelValue(reader, "AreaNo").ToDBString();
            //t_material.StockQty = OracleDBHelper.ToModelValue(reader, "StockQty").ToDecimal();
            //t_material.WareHouseID = OracleDBHelper.ToModelValue(reader, "WareHouseID").ToInt32();
            //t_material.AreaID = OracleDBHelper.ToModelValue(reader, "AreaID").ToInt32();

            return t_material;
        }

        protected override string GetViewName()
        {
            return "V_MATERIAL";
        }

        protected override string GetTableName()
        {
            return "T_MATERIAL";
        }

        protected override string GetSaveProcedureName()
        {
            return "";
        }


        protected override string GetFilterSql(UserModel user, T_MaterialInfo model)
        {
            string strSql = string.Empty;
            string strAnd = " and ";
         
            strSql +=  base.GetFilterSql(user, model);

            if (!Common_Func.IsNullOrEmpty(model.MaterialNo))
            {
                strSql += strAnd;
                strSql += " (MaterialNo LIKE '" + model.MaterialNo + "%' )  ";
            }           

            if (!Common_Func.IsNullOrEmpty(model.MaterialDesc))
            {
                strSql += strAnd;
                strSql += " MaterialDesc Like '" + model.MaterialDesc + "%'";
            }

            if (!Common_Func.IsNullOrEmpty(model.SupplierNo))
            {
                strSql += strAnd;
                strSql += "( SupplierNo Like '" + model.SupplierNo + "%'  or SupplierName Like '" + model.SupplierNo + "%' )";
            }

            if (model.DateFrom != null)
            {
                strSql += strAnd;
                strSql += " CreateTime >= " + model.DateFrom.ToDateTime().Date.AddDays(-1).ToOracleTimeString() + "  ";
            }

            if (model.DateTo != null)
            {
                strSql += strAnd;
                strSql += " CreateTime <= " + model.DateTo.ToDateTime().Date.AddDays(1).ToOracleTimeString() + " ";
            }

            if (!string.IsNullOrEmpty(model.BatchNo))
            {
                strSql += strAnd;
                strSql += " Batchno = '"+model.BatchNo+"' ";
            }

            if (!string.IsNullOrEmpty(model.WareHouseNo))
            {
                strSql += strAnd;
                strSql += " WareHouseNo = '" + model.WareHouseNo + "' ";
            }

            if (!string.IsNullOrEmpty(model.AreaNo))
            {
                strSql += strAnd;
                strSql += " AreaNo = '" + model.AreaNo + "' ";
            }

            return strSql;
        }

        public int CheckMaterialExist(T_MaterialInfo model)
        {
            string strSql = string.Format("SELECT COUNT(1) FROM T_MATERIAL WHERE materialno = '{0}'and nvl(isdel,1) = 1  ", model.MaterialNo);
            return GetScalarBySql(strSql).ToInt32();
        }

        protected override string GetModelSql(T_MaterialInfo model)
        {
            return string.Format("select * from t_Material where MaterialNo  = '{0}' and nvl(isdel,1) = 1", model.MaterialNo);
        }

        public List<T_MaterialInfo> getListMaterial(T_MaterialInfo model)
        {
            string sql = string.Format("select t.*,tp.watercode from t_material t left join t_material_pack tp on  t.id =tp.headerid where tp.watercode ='{0}'", model.WaterCode);
            return GetModelListBySql(sql);
        }
        /// <summary>
        /// 获取物料标准包装量
        /// </summary>
        /// <param name="MaterialNoID"></param>
        /// <param name="Strongholdcode"></param>
        /// <returns></returns>
        public decimal GetMaterialPackQty(string MaterialNo,string Strongholdcode)
        {
            string strSql = string.Format("select a.Unitnum from t_Material_Pack a where a.Mateno='{0}' and unit='箱' and a.Strongholdcode='{1}'  ", MaterialNo,Strongholdcode);
            return GetScalarBySql(strSql).ToDecimal();
        }

        /// <summary>
        /// 根据物料获取EAN
        /// </summary>
        public string getEAN(string materialno)
        {
            string sql = string.Format("select watercode from t_material_pack where mateno='"+ materialno + "' and unit='PCS'");
            return GetScalarBySql(sql).ToString();
        }
    }
}
