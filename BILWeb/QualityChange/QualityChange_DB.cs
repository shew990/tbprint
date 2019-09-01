//************************************************************
//******************************作者：方颖*********************
//******************************时间：2017/9/20 15:27:11*******

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


namespace BILWeb.QualityChange
{
    public partial class T_QualityChange_DB : BILBasic.Basing.Base_DB<T_QualityChangeInfo>
    {

        /// <summary>
        /// 添加t_qualitychange
        /// </summary>
        protected override OracleParameter[] GetSaveModelOracleParameter(T_QualityChangeInfo t_qualitychange)
        {
            //注意!head表ID要填basemodel的headerID new SqlParameter("@CustomerID", DbHelperSQL.ToDBValue(model.HeaderID)),
            throw new NotImplementedException();


        }

        protected override List<string> GetSaveSql(UserModel user,ref  T_QualityChangeInfo model)
        {
            string strSql = string.Empty;
            List<string> lstSql = new List<string>();

            //更新
            if (model.ID > 0)
            {
                strSql = string.Format("update t_Qualitychange a set a.Modifyer = '{0}' ,a.Modifytime = sysdate,a.Note  = '{1}' where id = '{2}'",
                    user.UserNo, model.Note, model.ID);
                lstSql.Add(strSql);
            }
            else //插入
            {
                int voucherID = base.GetTableID("Seq_Qualitychange_Id");

                model.ID = voucherID.ToInt32();

                string VoucherNoID = base.GetTableID("Seq_Qualitychange_NO").ToString();

                string VoucherNo = "Q" + System.DateTime.Now.ToString("yyyyMMdd") + VoucherNoID.PadLeft(4, '0');

                strSql = string.Format("insert into t_Qualitychange(Id,  Voucherno,  Createtime, Creater,  Status, Isdel, Note,  Vouchertype) values ('{0}','{1}',Sysdate,'{2}','{3}','{4}','{5}','{6}')",
                    voucherID, VoucherNo, user.UserNo, model.Status, model.IsDel, model.Note, model.VoucherType);

                lstSql.Add(strSql);
            }

            return lstSql;
        }


        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        protected override T_QualityChangeInfo ToModel(OracleDataReader reader)
        {
            T_QualityChangeInfo t_qualitychange = new T_QualityChangeInfo();

            t_qualitychange.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();
            t_qualitychange.ErpVoucherNo = (string)OracleDBHelper.ToModelValue(reader, "ERPVOUCHERNO");
            t_qualitychange.VoucherNo = (string)OracleDBHelper.ToModelValue(reader, "VOUCHERNO");
            t_qualitychange.QresoneCode = (string)OracleDBHelper.ToModelValue(reader, "QRESONECODE");
            t_qualitychange.CreateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CREATETIME");
            t_qualitychange.Creater = (string)OracleDBHelper.ToModelValue(reader, "CREATER");
            t_qualitychange.Modifyer = (string)OracleDBHelper.ToModelValue(reader, "MODIFYER");
            t_qualitychange.ModifyTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "MODIFYTIME");
            t_qualitychange.Status = OracleDBHelper.ToModelValue(reader, "STATUS").ToInt32();
            t_qualitychange.IsDel = (decimal?)OracleDBHelper.ToModelValue(reader, "ISDEL");
            t_qualitychange.Note = (string)OracleDBHelper.ToModelValue(reader, "NOTE");
            t_qualitychange.ERPStatus = (string)OracleDBHelper.ToModelValue(reader, "ERPSTATUS");
            t_qualitychange.VoucherType = OracleDBHelper.ToModelValue(reader, "VOUCHERTYPE").ToInt32();
            t_qualitychange.StrVoucherType = (string)OracleDBHelper.ToModelValue(reader, "StrVoucherType");
            t_qualitychange.StrStatus = (string)OracleDBHelper.ToModelValue(reader, "StrStatus");
            t_qualitychange.StrCreater = (string)OracleDBHelper.ToModelValue(reader, "StrCreater");
            return t_qualitychange;
        }

        protected override string GetViewName()
        {
            return "v_qualitychange";
        }

        protected override string GetTableName()
        {
            return "T_QUALITYCHANGE";
        }

        protected override string GetSaveProcedureName()
        {
            return "";
        }

        protected override string GetFilterSql(UserModel user, T_QualityChangeInfo model)
        {
            string strSql = base.GetFilterSql(user, model);
            string strAnd = " and ";

            if (model.Status > 0)
            {
                strSql += " Status = " + model.Status + " ";
                strSql += strAnd;
            }

            if (model.DateFrom != null)
            {
                strSql += strAnd;
                strSql += " CreateTime >= " + model.DateFrom.ToDateTime().Date.ToOracleTimeString() + " ";
            }

            if (model.DateTo != null)
            {
                strSql += strAnd;
                strSql += " CreateTime <= " + model.DateTo.ToDateTime().Date.AddDays(1).ToOracleTimeString() + " ";
            }

            if (!string.IsNullOrEmpty(model.ErpVoucherNo))
            {
                strSql += strAnd;
                strSql += " erpvoucherno Like '" + model.ErpVoucherNo + "%'  ";
            }

            return strSql + "order by id desc";
        }

        protected override List<string> GetDeleteSql(UserModel user, T_QualityChangeInfo model)
        {
            List<string> lstSql = new List<string>();
            string strSql = string.Empty;

            strSql = "delete t_Qualitychange where id = '" + model.ID + "'";

            lstSql.Add(strSql);

            return lstSql;
        }
    }
}
