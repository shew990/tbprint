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
    public partial class T_Material_Batch_DB : BILBasic.Basing.Base_DB<T_Material_BatchInfo>
    {

        /// <summary>
        /// 添加t_material_batch
        /// </summary>
        protected override OracleParameter[] GetSaveModelOracleParameter(T_Material_BatchInfo t_material_batch)
        {
            //注意!head表ID要填basemodel的headerID new SqlParameter("@CustomerID", DbHelperSQL.ToDBValue(model.HeaderID)),
            throw new NotImplementedException();


        }

        protected override List<string> GetSaveSql(UserModel user,ref  T_Material_BatchInfo model)
        {
            List<string> lstSql = new List<string>();
            string strSql = string.Empty;

            if (model.ID <= 0)
            {
                int voucherID = base.GetTableID("seq_matarial_batch");

                model.ID = voucherID.ToInt32();

                strSql = "insert into T_MATERIAL_BATCH (id, headerid, brand, batch, departmentcode, departmentname, pquantily, dquantily, rquantily, edate, wbs, projectno, customerno, customername, iescrow, factorycode, factoryname, version, rohs, customernote, exceptionnote,  creater, createtime)" +
                        "values ('" + voucherID + "', '" + model.HeaderID + "','" + model.Brand + "','" + model.BatchNo + "','" + model.DepartmentCode + "','" + model.DepartmentName + "','" + model.PQuantily + "','" + model.DQuantily + "'," +
                        "'" + model.RQuantily + "','" + model.Edate + "','" + model.WBS + "','" + model.ProjectNo + "','" + model.CustomerNo + "','" + model.CustomerName + "','" + model.IEscrow + "','" + model.FactoryCode + "','" + model.FactoryName + "',"+
                        "'" + model.Version + "','" + model.ROHS + "','" + model.CustomerNote + "','" + model.ExceptionNote + "','" + user.UserNo + "',sysdate)";

                lstSql.Add(strSql);
            }
            else
            {
                strSql = "update t_Material_Batch a set a.Batch='" + model.BatchNo + "',a.Brand='" + model.Brand + "',a.Customername='" + model.CustomerName + "',a.Customerno='" + model.CustomerNo + "',a.Customernote='" + model.CustomerNote + "',a.Departmentcode='" + model.DepartmentCode + "'," +
                        "a.Departmentname='"+model.DepartmentName+"',a.Dquantily='"+model.DQuantily+"',a.Edate='"+model.Edate+"',a.Exceptionnote='"+model.ExceptionNote+"',a.Factorycode='"+model.FactoryCode+"',a.Factoryname='"+model.FactoryName+"',a.Iescrow='"+model.IEscrow+"',"+
                        "a.Modifyer='" + user.Modifyer + "',a.Modifytime=Sysdate,a.Pquantily='" + model.PQuantily + "',a.Projectno='" + model.ProjectNo + "',a.Rohs='" + model.ROHS + "',a.Rquantily='" + model.RQuantily + "',a.Version='" + model.Version + "',a.Wbs='" + model.WBS + "' where a.Id = '"+model.ID+"'";
                lstSql.Add(strSql);
            }

            return lstSql;
        }

        protected override List<string> GetDeleteSql(UserModel user, T_Material_BatchInfo model)
        {
            List<string> lstSql = new List<string>();
            string strSql = string.Empty;

            strSql = "delete t_Material_Batch where id = '"+model.ID+"'";

            lstSql.Add(strSql);

            return lstSql;
        }


        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        protected override T_Material_BatchInfo ToModel(OracleDataReader reader)
        {
            T_Material_BatchInfo t_material_batch = new T_Material_BatchInfo();
            //读取的是库存的数据
            t_material_batch.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();
            t_material_batch.BatchNo = OracleDBHelper.ToModelValue(reader, "BatchNo").ToDBString();
            t_material_batch.Edate = OracleDBHelper.ToModelValue(reader, "Edate").ToDateTime();
            t_material_batch.StockQty = OracleDBHelper.ToModelValue(reader, "Qty").ToDecimal();
            t_material_batch.CreateTime = OracleDBHelper.ToModelValue(reader, "CreateTime").ToDateTime();
            t_material_batch.WareHouseNo = OracleDBHelper.ToModelValue(reader, "WareHouseNo").ToDBString();
            t_material_batch.HouseNo = OracleDBHelper.ToModelValue(reader, "HouseNo").ToDBString();
            t_material_batch.AreaNo = OracleDBHelper.ToModelValue(reader, "AreaNo").ToDBString();
            t_material_batch.SupCode = OracleDBHelper.ToModelValue(reader, "SupCode").ToDBString();
            t_material_batch.SupName = OracleDBHelper.ToModelValue(reader, "SupName").ToDBString();
            t_material_batch.Status = OracleDBHelper.ToModelValue(reader, "Status").ToInt32();
            t_material_batch.SupPrdDate = OracleDBHelper.ToModelValue(reader, "SupPrdDate").ToDateTime();
            t_material_batch.SupPrdBatch = OracleDBHelper.ToModelValue(reader, "SupPrdBatch").ToDBString();
            t_material_batch.ProductDate = OracleDBHelper.ToModelValue(reader, "ProductDate").ToDateTime();
            t_material_batch.ProductBatch = OracleDBHelper.ToModelValue(reader, "ProductBatch").ToDBString();

            return t_material_batch;
            //t_material_batch.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();
            //t_material_batch.HeaderID = OracleDBHelper.ToModelValue(reader, "HeaderID").ToInt32();
            //t_material_batch.Brand = (string)OracleDBHelper.ToModelValue(reader, "BRAND");
            //t_material_batch.Batch = (string)OracleDBHelper.ToModelValue(reader, "BATCH");
            //t_material_batch.DepartmentCode = (string)OracleDBHelper.ToModelValue(reader, "DEPARTMENTCODE");
            //t_material_batch.DepartmentName = (string)OracleDBHelper.ToModelValue(reader, "DEPARTMENTNAME");
            //t_material_batch.PQuantily = (decimal?)OracleDBHelper.ToModelValue(reader, "PQUANTILY");
            //t_material_batch.DQuantily = (decimal?)OracleDBHelper.ToModelValue(reader, "DQUANTILY");
            //t_material_batch.RQuantily = (decimal?)OracleDBHelper.ToModelValue(reader, "RQUANTILY");
            //t_material_batch.Edate = (DateTime?)OracleDBHelper.ToModelValue(reader, "EDATE");
            //t_material_batch.WBS = (string)OracleDBHelper.ToModelValue(reader, "WBS");
            //t_material_batch.ProjectNo = (string)OracleDBHelper.ToModelValue(reader, "PROJECTNO");
            //t_material_batch.CustomerNo = (string)OracleDBHelper.ToModelValue(reader, "CUSTOMERNO");
            //t_material_batch.CustomerName = (string)OracleDBHelper.ToModelValue(reader, "CUSTOMERNAME");
            //t_material_batch.IEscrow = (decimal?)OracleDBHelper.ToModelValue(reader, "IESCROW");
            //t_material_batch.FactoryCode = (string)OracleDBHelper.ToModelValue(reader, "FACTORYCODE");
            //t_material_batch.FactoryName = (string)OracleDBHelper.ToModelValue(reader, "FACTORYNAME");
            //t_material_batch.Version = (string)OracleDBHelper.ToModelValue(reader, "VERSION");
            //t_material_batch.ROHS = (string)OracleDBHelper.ToModelValue(reader, "ROHS");
            //t_material_batch.CustomerNote = (string)OracleDBHelper.ToModelValue(reader, "CUSTOMERNOTE");
            //t_material_batch.ExceptionNote = (string)OracleDBHelper.ToModelValue(reader, "EXCEPTIONNOTE");
            
            //t_material_batch.Creater = (string)OracleDBHelper.ToModelValue(reader, "CREATER");
            //t_material_batch.CreateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CREATETIME");
            //t_material_batch.Modifyer = (string)OracleDBHelper.ToModelValue(reader, "MODIFYER");
            //t_material_batch.ModifyTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "MODIFYTIME");


        }

        protected override string GetViewName()
        {
            return "V_MATERIAL_BATCH";
        }

        protected override string GetTableName()
        {
            return "T_MATERIAL_BATCH";
        }

        protected override string  GetHeaderIDFieldName()        
        {
            return "MaterialNoID";
        }

        protected override string GetSaveProcedureName()
        {
            return "";
        }
      
        public int CheckMaterialExist(T_Material_BatchInfo model)
        {
            string strSql = string.Format("SELECT COUNT(1) FROM T_MATERIAL_BATCH WHERE BATCH = '{0}' and id <> '{1}'", model.BatchNo, model.ID);
            return GetScalarBySql(strSql).ToInt32();
        }


        public override List<T_Material_BatchInfo> GetModelListByHeaderID(int headerID)
        {
            List<T_Material_BatchInfo> list = base.GetModelListByHeaderID(headerID);
            List<T_Material_BatchInfo> groupList = null;
            if (list.Count > 0)
            {
                    groupList = list
                    .GroupBy(x => new { x.BatchNo, x.AreaNo})
                    .Select(group => new T_Material_BatchInfo
                    {
                        BatchNo = group.Key.BatchNo,
                        StockQty = group.Sum(p => p.StockQty),
                        Edate = group.FirstOrDefault().Edate,
                        CreateTime = group.FirstOrDefault().CreateTime,
                        WareHouseNo = group.FirstOrDefault().WareHouseNo,
                        HouseNo = group.FirstOrDefault().HouseNo,
                        AreaNo = group.FirstOrDefault().AreaNo,
                        SupCode = group.FirstOrDefault().SupCode,
                        SupName = group.FirstOrDefault().SupName,
                        SupPrdBatch = group.FirstOrDefault().SupPrdBatch,
                        SupPrdDate = group.FirstOrDefault().SupPrdDate,
                        ProductBatch = group.FirstOrDefault().ProductBatch,
                        ProductDate = group.FirstOrDefault().ProductDate
                    }).ToList();
            }

            return groupList;
        }


    }
}
