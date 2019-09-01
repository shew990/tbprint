//************************************************************
//******************************作者：方颖*********************
//******************************时间：2017/9/20 16:13:23*******

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess;
using BILBasic.Basing;
using BILBasic.DBA;
using Oracle.ManagedDataAccess.Client;
using BILBasic.User;
using BILBasic.Common;

namespace BILWeb.QualityChange
{
    public partial class T_QualityChangeDetail_DB : BILBasic.Basing.Base_DB<T_QualityChangeDetailInfo>
    {

        /// <summary>
        /// 添加t_qualitychangedetail
        /// </summary>
        protected override OracleParameter[] GetSaveModelOracleParameter(T_QualityChangeDetailInfo t_qualitychangedetail)
        {
            //注意!head表ID要填basemodel的headerID new SqlParameter("@CustomerID", DbHelperSQL.ToDBValue(model.HeaderID)),
            throw new NotImplementedException();


        }

        protected override List<string> GetSaveSql(UserModel user,ref  T_QualityChangeDetailInfo model)
        {
            string strSql = string.Empty;
            List<string> lstSql = new List<string>();

            if (model.ID <= 0)
            {
                int detailID = base.GetTableID("Seq_Qualitychanged_Id");
                model.ID = detailID;
                strSql = string.Format("insert into t_Qualitychangedetail(Id, Headerid,  Materialno, Materialnoid, Materialdesc, Batchno, Qresonecode, "+
                                        " Note, Linestatus, Creater, Createtime, Isdel, Voucherno, Strongholdcode, Strongholdname, Companycode, Warehouseno, Areano, Stockqty,warehouseid,areaid)"+
                                        "values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',Sysdate,'{10}','{11}','{12}','{13}','{14}' "+
                                        ",'{15}','{16}','{17}','{18}','{19}')", model.ID, model.HeaderID, model.MaterialNo, model.MaterialNoID, model.MaterialDesc, model.BatchNo, model.QResoneCode,
                                        model.Note,'1',user.UserNo,'1',model.VoucherNo,model.StrongHoldCode,model.StrongHoldName,10,model.WareHouseNo,model.AreaNo,model.StockQty,model.WareHouseID,model.AreaID);

                lstSql.Add(strSql);
            }
            else
            {
                strSql = "update t_Qualitychangedetail a  set a.Materialno = '" + model.MaterialNo + "',a.Materialdesc = '" + model.MaterialDesc + "',a.Materialnoid = '" + model.MaterialNoID + "',a.Batchno='" + model.BatchNo + "'," +
                        "a.Qresonecode='" + model.QResoneCode + "',a.Note = '" + model.Note + "',a.Strongholdcode='" + model.StrongHoldCode + "',a.Strongholdname='" + model.StrongHoldName + "',a.Companycode='10',a.Warehouseno='" + model.WareHouseNo + "'," +
                        "a.Areano='" + model.AreaNo + "',a.Stockqty='" + model.StockQty + "',a.Modifyer='" + user.UserNo + "',a.Modifytime=Sysdate,a.warehouseid = '"+model.WareHouseID+"',a.areaid = '"+model.AreaID+"' where id = '" + model.ID + "'";
                lstSql.Add(strSql);
            }
            return lstSql;
        }




        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        protected override T_QualityChangeDetailInfo ToModel(OracleDataReader reader)
        {
            T_QualityChangeDetailInfo t_qualitychangedetail = new T_QualityChangeDetailInfo();

            t_qualitychangedetail.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32() ;
            t_qualitychangedetail.HeaderID = OracleDBHelper.ToModelValue(reader, "HEADERID").ToInt32();
            t_qualitychangedetail.RowNo = (string)OracleDBHelper.ToModelValue(reader, "ROWNO");
            t_qualitychangedetail.MaterialNo = (string)OracleDBHelper.ToModelValue(reader, "MATERIALNO");
            t_qualitychangedetail.MaterialNoID = OracleDBHelper.ToModelValue(reader, "MATERIALNOID").ToInt32();
            t_qualitychangedetail.MaterialDesc = (string)OracleDBHelper.ToModelValue(reader, "MATERIALDESC");
            t_qualitychangedetail.BatchNo = (string)OracleDBHelper.ToModelValue(reader, "BATCHNO");
            t_qualitychangedetail.QResoneCode = OracleDBHelper.ToModelValue(reader, "QRESONECODE").ToInt32();
            t_qualitychangedetail.QResoneName = (string)OracleDBHelper.ToModelValue(reader, "QRESONENAME");
            t_qualitychangedetail.Note = (string)OracleDBHelper.ToModelValue(reader, "NOTE");
            t_qualitychangedetail.LineStatus = OracleDBHelper.ToModelValue(reader, "LINESTATUS").ToInt32();
            t_qualitychangedetail.Creater = (string)OracleDBHelper.ToModelValue(reader, "CREATER");
            t_qualitychangedetail.CreateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CREATETIME");
            t_qualitychangedetail.Modifyer = (string)OracleDBHelper.ToModelValue(reader, "MODIFYER");
            t_qualitychangedetail.ModifyTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "MODIFYTIME");
            t_qualitychangedetail.ErpVoucherNo = (string)OracleDBHelper.ToModelValue(reader, "ERPVOUCHERNO");
            t_qualitychangedetail.IsDel = (decimal?)OracleDBHelper.ToModelValue(reader, "ISDEL");
            t_qualitychangedetail.VoucherNo = (string)OracleDBHelper.ToModelValue(reader, "VOUCHERNO");
            t_qualitychangedetail.StrongHoldCode = (string)OracleDBHelper.ToModelValue(reader, "STRONGHOLDCODE");
            t_qualitychangedetail.StrongHoldName = (string)OracleDBHelper.ToModelValue(reader, "STRONGHOLDNAME");
            t_qualitychangedetail.CompanyCode = (string)OracleDBHelper.ToModelValue(reader, "COMPANYCODE");
            t_qualitychangedetail.WareHouseNo = (string)OracleDBHelper.ToModelValue(reader, "WAREHOUSENO");
            t_qualitychangedetail.AreaNo = (string)OracleDBHelper.ToModelValue(reader, "AREANO");
            t_qualitychangedetail.StockQty = (decimal?)OracleDBHelper.ToModelValue(reader, "STOCKQTY");
            t_qualitychangedetail.WareHouseID = OracleDBHelper.ToModelValue(reader, "WareHouseID").ToInt32();
            t_qualitychangedetail.AreaID = OracleDBHelper.ToModelValue(reader, "AreaID").ToInt32();

            return t_qualitychangedetail;
        }

        protected override string GetViewName()
        {
            return "v_qualitychangedetail";
        }

        protected override string GetTableName()
        {
            return "T_QUALITYCHANGEDETAIL";
        }

        protected override string GetSaveProcedureName()
        {
            return "";
        }

        protected override List<string> GetDeleteSql(UserModel user, T_QualityChangeDetailInfo model)
        {
            List<string> lstSql = new List<string>();
            string strSql = string.Empty;

            strSql = "delete t_Qualitychangedetail where id = '" + model.ID + "'";

            lstSql.Add(strSql);

            return lstSql;
        }

        public bool UpdateStockQuality(List<T_QualityChangeDetailInfo> modelList, ref string strError)
        {
            List<string> lstSql = new List<string>();
            string strSql = string.Empty;


            foreach (var item in modelList)
            {
                strSql = "update t_stock a set a.Status = (case "+item.QResoneCode+" when 0 then 1 when 1 then 3 when 2 then 4 end) "+
                        " where a.Materialnoid = '"+item.MaterialNoID+"' and a.Warehouseid = '"+item.WareHouseID+"' and a.Areaid = '"+item.AreaID+"' and a.Batchno = '"+item.BatchNo+"' ";

                lstSql.Add(strSql);

                strSql = "update t_Qualitychangedetail a set a.Erpvoucherno = '" + item.ErpVoucherNo + "' where id = '" + item.ID + "'";
                lstSql.Add(strSql);
            }

            strSql = "update t_Qualitychange a set a.Erpvoucherno = '" + modelList[0].ErpVoucherNo + "' ,a.Status = 2 where id = '" + modelList[0].HeaderID + "'";
            lstSql.Add(strSql);

            return base.UpdateModelListStatusBySql(lstSql, ref strError);

        }


        public int CheckQualityMaterialNoIsExists(T_QualityChangeDetailInfo model)
        {
            string strSql = "select count(1) from t_Qualitychangedetail a where a.Materialnoid = '" + model.MaterialNoID + "' and a.Batchno = '" + model.BatchNo + "' and a.Warehouseid = '" + model.WareHouseID + "' and a.Areaid = '" + model.AreaID + "' and a.Headerid = '" + model.HeaderID + "'";

            return base.GetScalarBySql(strSql).ToInt32();
        }


    }
}
