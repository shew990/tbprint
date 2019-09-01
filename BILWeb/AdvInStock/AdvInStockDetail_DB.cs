//************************************************************
//******************************作者：方颖*********************
//******************************时间：2019/7/17 16:01:41*******

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILBasic.Basing;
using BILBasic.DBA;
using BILBasic.Common;
using Oracle.ManagedDataAccess.Client;
using BILBasic.User;

namespace BILWeb.AdvInStock
{
    public partial class T_AdvInStockDetail_DB : BILBasic.Basing.Base_DB<T_AdvInStockDetailInfo>
    {

        /// <summary>
        /// 添加t_advinstockdetail
        /// </summary>
        protected override OracleParameter[] GetSaveModelOracleParameter(T_AdvInStockDetailInfo t_advinstockdetail)
        {
            //注意!head表ID要填basemodel的headerID new SqlParameter("@CustomerID", DbHelperSQL.ToDBValue(model.HeaderID)),
            throw new NotImplementedException();


        }

        protected override List<string> GetSaveSql(BILBasic.User.UserModel user, ref T_AdvInStockDetailInfo t_advinstockdetail)
        {
            throw new NotImplementedException();
        }




        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        protected override T_AdvInStockDetailInfo ToModel(OracleDataReader reader)
        {
            T_AdvInStockDetailInfo t_advinstockdetail = new T_AdvInStockDetailInfo();

            t_advinstockdetail.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();
            t_advinstockdetail.HeaderID = OracleDBHelper.ToModelValue(reader, "HEADERID").ToInt32();
            t_advinstockdetail.MaterialNo = (string)OracleDBHelper.ToModelValue(reader, "MATERIALNO");
            t_advinstockdetail.MaterialDesc = (string)OracleDBHelper.ToModelValue(reader, "MATERIALDESC");
            t_advinstockdetail.MaterialNoID = OracleDBHelper.ToModelValue(reader, "MaterialNoID").ToInt32();
            t_advinstockdetail.AdvQty = OracleDBHelper.ToModelValue(reader, "ADVQTY").ToDecimalNull();
            t_advinstockdetail.Unit = (string)OracleDBHelper.ToModelValue(reader, "UNIT");
            t_advinstockdetail.LineStatus = OracleDBHelper.ToModelValue(reader, "LINESTATUS").ToInt32();
            t_advinstockdetail.Creater = (string)OracleDBHelper.ToModelValue(reader, "CREATER");
            t_advinstockdetail.CreateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CREATETIME");
            t_advinstockdetail.Modifyer = (string)OracleDBHelper.ToModelValue(reader, "MODIFYER");
            t_advinstockdetail.ModifyTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "MODIFYTIME");
            t_advinstockdetail.IsDel =OracleDBHelper.ToModelValue(reader, "ISDEL").ToInt32(); 
            t_advinstockdetail.EAN = (string)OracleDBHelper.ToModelValue(reader, "EAN");
            t_advinstockdetail.EDate = (DateTime)OracleDBHelper.ToModelValue(reader, "EDATE");
            t_advinstockdetail.SupBatch = (string)OracleDBHelper.ToModelValue(reader, "SUPBATCH");
            t_advinstockdetail.QualityType = OracleDBHelper.ToModelValue(reader, "QualityType").ToInt32(); ;
            t_advinstockdetail.ErpVoucherNo = (string)OracleDBHelper.ToModelValue(reader, "ErpVoucherNo");
            t_advinstockdetail.VOUCHERNO = (string)OracleDBHelper.ToModelValue(reader, "VOUCHERNO");
            t_advinstockdetail.StrongHoldCode = (string)OracleDBHelper.ToModelValue(reader, "StrongHoldCode");
            t_advinstockdetail.RowNO = (string)OracleDBHelper.ToModelValue(reader, "RowNO");
            t_advinstockdetail.RowNODel = (string)OracleDBHelper.ToModelValue(reader, "RowNODel");
            t_advinstockdetail.strqualitytype = (string)OracleDBHelper.ToModelValue(reader, "strqualitytype");
            t_advinstockdetail.CompanyCode = (string)OracleDBHelper.ToModelValue(reader, "CompanyCode");
            t_advinstockdetail.Createname = (string)OracleDBHelper.ToModelValue(reader, "createname");
            

            return t_advinstockdetail;
        }

        protected override string GetViewName()
        {
            return "V_AdvInStockDetail";
        }

        protected override string GetTableName()
        {
            return "T_ADVINSTOCKDETAIL";
        }

        protected override string GetSaveProcedureName()
        {
            return "";
        }

        protected override string GetFilterSql(UserModel user, T_AdvInStockDetailInfo model)
        {
            string strSql = " where nvl(isDel,0) != 2  ";
            string strAnd = " and ";

            if (!Common_Func.IsNullOrEmpty(model.ErpVoucherNo))
            {
                strSql += strAnd;
                strSql += " ErpVoucherNo = '" + model.ErpVoucherNo + "' ";
            }
            return strSql;
        }
    }
}
