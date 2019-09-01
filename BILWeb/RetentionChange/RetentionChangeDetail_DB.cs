//************************************************************
//******************************作者：方颖*********************
//******************************时间：2017/10/19 15:50:52*******

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess;
using BILBasic.Basing;
using BILBasic.DBA;
using Oracle.ManagedDataAccess.Client;
using BILBasic.Common;
using BILBasic.User;

namespace BILWeb.RetentionChange
{
    public partial class T_RetentionDetailChange_DB : BILBasic.Basing.Base_DB<T_RetentionDetailChangeInfo>
    {

        /// <summary>
        /// 添加t_retentiondetailchange
        /// </summary>
        protected override OracleParameter[] GetSaveModelOracleParameter(T_RetentionDetailChangeInfo t_retentiondetailchange)
        {
            //注意!head表ID要填basemodel的headerID new SqlParameter("@CustomerID", DbHelperSQL.ToDBValue(model.HeaderID)),
            throw new NotImplementedException();


        }

        protected override List<string> GetSaveSql(UserModel user, ref  T_RetentionDetailChangeInfo model)
        {
            string strSql = string.Empty;
            List<string> lstSql = new List<string>();

            if (model.ID <= 0)
            {
                int detailID = base.GetTableID("Seq_Retentionchanged_Id");
                model.ID = detailID;
                strSql = string.Format("insert into t_Retentiondetailchange(Id, Headerid,  Materialno, Materialnoid, Materialdesc, Batchno, Qresonecode, " +
                                        " Note, Linestatus, Creater, Createtime, Isdel, Voucherno, Strongholdcode, Strongholdname, Companycode, Warehouseno, Areano,warehouseid,areaid)" +
                                        "values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',Sysdate,'{10}','{11}','{12}','{13}','{14}' " +
                                        ",'{15}','{16}','{17}','{18}')", model.ID, model.HeaderID, model.MaterialNo, model.MaterialNoID, model.MaterialDesc, model.BatchNo, model.QresoneCode,
                                        model.Note, '1', user.UserNo, '1', model.VoucherNo, model.StrongHoldCode, model.StrongHoldName, 10, model.WareHouseNo, model.AreaNo, model.WareHouseID, model.AreaID);

                lstSql.Add(strSql);
            }
            else
            {
                strSql = "update t_Retentiondetailchange a  set a.Materialno = '" + model.MaterialNo + "',a.Materialdesc = '" + model.MaterialDesc + "',a.Materialnoid = '" + model.MaterialNoID + "',a.Batchno='" + model.BatchNo + "'," +
                        "a.Qresonecode='" + model.QresoneCode + "',a.Note = '" + model.Note + "',a.Strongholdcode='" + model.StrongHoldCode + "',a.Strongholdname='" + model.StrongHoldName + "',a.Companycode='10',a.Warehouseno='" + model.WareHouseNo + "'," +
                        "a.Areano='" + model.AreaNo + "',a.Modifyer='" + user.UserNo + "',a.Modifytime=Sysdate,a.warehouseid = '" + model.WareHouseID + "',a.areaid = '" + model.AreaID + "' where id = '" + model.ID + "'";
                lstSql.Add(strSql);
            }
            return lstSql;
        }




        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        protected override T_RetentionDetailChangeInfo ToModel(OracleDataReader reader)
        {
            T_RetentionDetailChangeInfo t_retentiondetailchange = new T_RetentionDetailChangeInfo();

            t_retentiondetailchange.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32() ;
            t_retentiondetailchange.HeaderID = OracleDBHelper.ToModelValue(reader, "HEADERID").ToInt32();
            t_retentiondetailchange.Rowno = (string)OracleDBHelper.ToModelValue(reader, "ROWNO");
            t_retentiondetailchange.MaterialNo = (string)OracleDBHelper.ToModelValue(reader, "MATERIALNO");
            t_retentiondetailchange.MaterialNoID = OracleDBHelper.ToModelValue(reader, "MATERIALNOID").ToInt32();
            t_retentiondetailchange.MaterialDesc = (string)OracleDBHelper.ToModelValue(reader, "MATERIALDESC");
            t_retentiondetailchange.BatchNo = (string)OracleDBHelper.ToModelValue(reader, "BATCHNO");
            t_retentiondetailchange.QresoneCode = (string)OracleDBHelper.ToModelValue(reader, "QRESONECODE");
            t_retentiondetailchange.QresoneName = (string)OracleDBHelper.ToModelValue(reader, "QRESONENAME");
            t_retentiondetailchange.Note = (string)OracleDBHelper.ToModelValue(reader, "NOTE");
            t_retentiondetailchange.LineStatus = OracleDBHelper.ToModelValue(reader, "LINESTATUS").ToInt32();
            t_retentiondetailchange.Creater = (string)OracleDBHelper.ToModelValue(reader, "CREATER");
            t_retentiondetailchange.CreateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CREATETIME");
            t_retentiondetailchange.Modifyer = (string)OracleDBHelper.ToModelValue(reader, "MODIFYER");
            t_retentiondetailchange.ModifyTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "MODIFYTIME");
            t_retentiondetailchange.ErpVoucherNo = (string)OracleDBHelper.ToModelValue(reader, "ERPVOUCHERNO");
            t_retentiondetailchange.IsDel = (decimal?)OracleDBHelper.ToModelValue(reader, "ISDEL");
            t_retentiondetailchange.VoucherNo = (string)OracleDBHelper.ToModelValue(reader, "VOUCHERNO");
            t_retentiondetailchange.StrongHoldCode = (string)OracleDBHelper.ToModelValue(reader, "STRONGHOLDCODE");
            t_retentiondetailchange.StrongHoldName = (string)OracleDBHelper.ToModelValue(reader, "STRONGHOLDNAME");
            t_retentiondetailchange.CompanyCode = (string)OracleDBHelper.ToModelValue(reader, "COMPANYCODE");
            t_retentiondetailchange.WareHouseNo = (string)OracleDBHelper.ToModelValue(reader, "WAREHOUSENO");
            t_retentiondetailchange.AreaNo = (string)OracleDBHelper.ToModelValue(reader, "AREANO");
            t_retentiondetailchange.WareHouseID = (decimal?)OracleDBHelper.ToModelValue(reader, "WAREHOUSEID");
            t_retentiondetailchange.AreaID = (decimal?)OracleDBHelper.ToModelValue(reader, "AREAID");

            return t_retentiondetailchange;
        }

        protected override string GetViewName()
        {
            return "V_RETENTIONDETAILCHANGE";
        }

        protected override string GetTableName()
        {
            return "T_RETENTIONDETAILCHANGE";
        }

        protected override string GetSaveProcedureName()
        {
            return "";
        }

        protected override List<string> GetDeleteSql(UserModel user, T_RetentionDetailChangeInfo model)
        {
            List<string> lstSql = new List<string>();
            string strSql = string.Empty;

            strSql = "delete T_RETENTIONDETAILCHANGE where id = '" + model.ID + "'";

            lstSql.Add(strSql);

            return lstSql;
        }

        public int CheckRetenMaterialNoIsExists(T_RetentionDetailChangeInfo model)
        {
            string strSql = "select count(1) from T_RETENTIONDETAILCHANGE a where a.Materialnoid = '" + model.MaterialNoID + "' and a.Batchno = '" + model.BatchNo + "' and a.Warehouseid = '" + model.WareHouseID + "' and a.Areaid = '" + model.AreaID + "' and a.Headerid = '" + model.HeaderID + "'";

            return base.GetScalarBySql(strSql).ToInt32();
        }

        public bool UpdateStockRetention(List<T_RetentionDetailChangeInfo> modelList, ref string strError)
        {
            List<string> lstSql = new List<string>();
            string strSql = string.Empty;


            foreach (var item in modelList)
            {
                strSql = "update t_stock a set a.ISRETENTION = '"+item.RetainType+"' " +
                        " where a.Materialnoid = '" + item.MaterialNoID + "' and a.Warehouseid = '" + item.WareHouseID + "' and a.Areaid = '" + item.AreaID + "' and a.Batchno = '" + item.BatchNo + "' ";

                lstSql.Add(strSql);

                strSql = "update T_RETENTIONDETAILCHANGE a set a.Erpvoucherno = '" + item.ErpVoucherNo + "' where id = '" + item.ID + "'";
                lstSql.Add(strSql);
            }

            strSql = "update T_RETENTIONCHANGE a set a.Erpvoucherno = '" + modelList[0].ErpVoucherNo + "' ,a.Status = 2,Retaintype = '" + modelList[0].RetainType+ "' where id = '" + modelList[0].HeaderID + "'";
            lstSql.Add(strSql);

            return base.UpdateModelListStatusBySql(lstSql, ref strError);

        }

    }
}
