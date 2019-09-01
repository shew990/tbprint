//************************************************************
//******************************作者：方颖*********************
//******************************时间：2017/9/7 13:44:29*******

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

namespace BILWeb.EdateChange
{
    public partial class T_EDateChange_DB : BILBasic.Basing.Base_DB<T_EDateChangeInfo>
    {

        /// <summary>
        /// 添加t_edatechange
        /// </summary>
        protected override OracleParameter[] GetSaveModelOracleParameter(T_EDateChangeInfo t_edatechange)
        {
            //注意!head表ID要填basemodel的headerID new SqlParameter("@CustomerID", DbHelperSQL.ToDBValue(model.HeaderID)),
            throw new NotImplementedException();


        }

        protected override List<string> GetSaveSql(UserModel user ,ref T_EDateChangeInfo model)
        {
            string strSql = string.Empty;
            List<string> lstSql = new List<string>();

            //更新
            if (model.ID > 0)
            {
                strSql = string.Format("update t_Edatechange a set a.Modifyer = '{0}' ,a.Modifytime = sysdate,a.Note  = '{1}' where id = '{2}'",
                    user.UserNo,model.Note,model.ID);
                lstSql.Add(strSql);
            }
            else //插入
            {
                int voucherID = base.GetTableID("SEQ_EDATECHANGE_ID");

                model.ID = voucherID.ToInt32();

                string VoucherNoID = base.GetTableID("SEQ_EDATECHANGE_NO").ToString();

                string VoucherNo = "E" + System.DateTime.Now.ToString("yyyyMMdd") + VoucherNoID.PadLeft(4, '0');

                strSql = string.Format("insert into t_Edatechange(Id,  Voucherno,  Createtime, Creater,  Status, Isdel, Note,  Vouchertype) values ('{0}','{1}',Sysdate,'{2}','{3}','{4}','{5}','{6}')",
                    voucherID, VoucherNo,user.UserNo,model.Status,model.IsDel,model.Note,model.VoucherType);

                lstSql.Add(strSql);
            }

            return lstSql;
        }




        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        protected override T_EDateChangeInfo ToModel(OracleDataReader reader)
        {
            T_EDateChangeInfo t_edatechange = new T_EDateChangeInfo();

            t_edatechange.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();
            t_edatechange.ErpVoucherNo = (string)OracleDBHelper.ToModelValue(reader, "ERPVOUCHERNO");
            t_edatechange.VoucherNo = (string)OracleDBHelper.ToModelValue(reader, "VOUCHERNO");
            t_edatechange.ResoneCode = (string)OracleDBHelper.ToModelValue(reader, "RESONECODE");
            t_edatechange.CreateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CREATETIME");
            t_edatechange.Creater = (string)OracleDBHelper.ToModelValue(reader, "CREATER");
            t_edatechange.Modifyer = (string)OracleDBHelper.ToModelValue(reader, "MODIFYER");
            t_edatechange.ModifyTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "MODIFYTIME");
            t_edatechange.Status = OracleDBHelper.ToModelValue(reader, "STATUS").ToInt32();
            t_edatechange.IsDel = (decimal?)OracleDBHelper.ToModelValue(reader, "ISDEL");
            t_edatechange.Note = (string)OracleDBHelper.ToModelValue(reader, "NOTE");
            t_edatechange.ErpStatus = (string)OracleDBHelper.ToModelValue(reader, "ERPSTATUS");
            t_edatechange.VoucherType = OracleDBHelper.ToModelValue(reader, "VoucherType").ToInt32();
            t_edatechange.StrVoucherType = (string)OracleDBHelper.ToModelValue(reader, "StrVoucherType");
            t_edatechange.StrStatus = (string)OracleDBHelper.ToModelValue(reader, "StrStatus");
            t_edatechange.StrCreater = (string)OracleDBHelper.ToModelValue(reader, "StrCreater");
            

            return t_edatechange;
        }

        protected override string GetViewName()
        {
            return "V_EDATECHANGE";
        }

        protected override string GetTableName()
        {
            return "T_EDATECHANGE";
        }

        protected override string GetSaveProcedureName()
        {
            return "";
        }

        protected override string GetFilterSql(UserModel user, T_EDateChangeInfo model)
        {
            string strSql = base.GetFilterSql(user, model);
            string strAnd = " and ";

            if (model.Status > 0)
            {
                strSql += " Status = " + model.Status+ " ";
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

        protected override List<string> GetDeleteSql(UserModel user, T_EDateChangeInfo model)
        {
            List<string> lstSql = new List<string>();
            string strSql = string.Empty;

            strSql = "delete t_Edatechange where id = '" + model.ID + "'";

            lstSql.Add(strSql);

            return lstSql;
        }

    }
}
