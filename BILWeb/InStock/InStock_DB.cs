
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILBasic.User;
using BILBasic.Common;
using BILBasic.DBA;
using Oracle.ManagedDataAccess.Client;

namespace BILWeb.InStock
{
    public partial class T_InStock_DB : BILBasic.Basing.Base_DB<T_InStockInfo>
    {

        /// <summary>
        /// 添加t_instock
        /// </summary>
        protected override OracleParameter[] GetSaveModelOracleParameter(T_InStockInfo t_instock)
        {
            //注意!head表ID要填basemodel的headerID new SqlParameter("@CustomerID", DbHelperSQL.ToDBValue(model.HeaderID)),
            throw new NotImplementedException();


        }

        protected override List<string> GetSaveSql(UserModel user, ref T_InStockInfo model)
        {
            string strSql = string.Empty;
            List<string> lstSql = new List<string>();

            //更新
            if (model.ID > 0)
            {
                strSql = string.Format("update t_Instock a set a.Supplierno = '{0}',a.Suppliername = '{1}',a.Plant = '{2}',a.Plantname='{3}',a.Modifyer = '{4}',a.Modifytime = Sysdate，note = '{6}'" +
                        " where a.Id = '{5}'", model.SupplierNo, model.SupplierName, model.Plant, model.PlantName, user.UserNo, model.ID,model.Note);
                lstSql.Add(strSql);
            }
            else //插入
            {
                int voucherID = base.GetTableID("SEQ_INSTOCK_ID");

                model.ID = voucherID.ToInt32();

                string VoucherNoID = base.GetTableID("SEQ_INSTOCK_NO").ToString();

                string VoucherNo = "S" + System.DateTime.Now.ToString("yyyyMMdd") + VoucherNoID.PadLeft(4, '0');

                strSql = string.Format("insert into t_Instock (Id, Voucherno, Supplierno, Suppliername,  Vouchertype, Plant, Plantname, Createtime, Creater,  Status,  Isdel,note)" +
                        "values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',Sysdate,'{7}','{8}','1','{9}')",voucherID, VoucherNo, model.SupplierNo, model.SupplierName, model.VoucherType, model.Plant, model.PlantName, user.UserNo, model.Status,model.Note);
                
                lstSql.Add(strSql);
            }

            return lstSql;

        }


        protected override List<string> GetUpdateSql(UserModel user, T_InStockInfo model)
        {
            List<string> lstSql = new List<string>();

            string strSql = "update t_Instock a set a.Status = '" + model.Status + "' where id = '" + model.ID + "'";

            lstSql.Add(strSql);

            return lstSql;
        }

        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        protected override T_InStockInfo ToModel(OracleDataReader reader)
        {
            T_InStockInfo t_instock = new T_InStockInfo();

            t_instock.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();
            t_instock.VoucherNo = (string)OracleDBHelper.ToModelValue(reader, "VOUCHERNO");
            t_instock.ErpVoucherNo = (string)OracleDBHelper.ToModelValue(reader, "ERPVOUCHERNO");
            t_instock.SupplierNo = (string)OracleDBHelper.ToModelValue(reader, "SUPPLIERNO");
            t_instock.SupplierName = (string)OracleDBHelper.ToModelValue(reader, "SUPPLIERNAME");
            t_instock.IsQuality = (decimal?)OracleDBHelper.ToModelValue(reader, "ISQUALITY");
            t_instock.IsReceivePost = (decimal?)OracleDBHelper.ToModelValue(reader, "ISRECEIVEPOST");
            t_instock.IsShelvePost = (decimal?)OracleDBHelper.ToModelValue(reader, "ISSHELVEPOST");
            t_instock.VoucherType = OracleDBHelper.ToModelValue(reader, "VOUCHERTYPE").ToInt32();
            t_instock.Plant = (string)OracleDBHelper.ToModelValue(reader, "PLANT");
            t_instock.PlantName = (string)OracleDBHelper.ToModelValue(reader, "PLANTNAME");
            t_instock.MoveType = (string)OracleDBHelper.ToModelValue(reader, "MOVETYPE");
            t_instock.CreateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CREATETIME");
            t_instock.Creater = (string)OracleDBHelper.ToModelValue(reader, "CREATER");
            t_instock.Modifyer = (string)OracleDBHelper.ToModelValue(reader, "MODIFYER");
            t_instock.ModifyTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "MODIFYTIME");
            t_instock.Status = OracleDBHelper.ToModelValue(reader, "STATUS").ToInt32();
            t_instock.StrVoucherType = (string)OracleDBHelper.ToModelValue(reader, "StrVoucherType");
            t_instock.StrStatus = (string)OracleDBHelper.ToModelValue(reader, "StrStatus");
            t_instock.StrCreater = (string)OracleDBHelper.ToModelValue(reader, "StrCreater");

            t_instock.StrongHoldCode = OracleDBHelper.ToModelValue(reader, "StrongHoldCode").ToDBString();
            t_instock.StrongHoldName = OracleDBHelper.ToModelValue(reader, "StrongHoldName").ToDBString();
            t_instock.CompanyCode = OracleDBHelper.ToModelValue(reader, "CompanyCode").ToDBString();
            t_instock.ERPCreater = OracleDBHelper.ToModelValue(reader, "ERPCreater").ToDBString();
            t_instock.VouDate = OracleDBHelper.ToModelValue(reader, "VouDate").ToDateTime();
            t_instock.VouUser = OracleDBHelper.ToModelValue(reader, "VouUser").ToDBString();
            t_instock.DepartmentCode = OracleDBHelper.ToModelValue(reader, "DepartmentCode").ToDBString();
            t_instock.DepartmentName = OracleDBHelper.ToModelValue(reader, "DepartmentName").ToDBString();
            t_instock.ERPStatus = OracleDBHelper.ToModelValue(reader, "ERPStatus").ToDBString();
            t_instock.ERPNote = OracleDBHelper.ToModelValue(reader, "ERPNote").ToDBString();
            t_instock.QcCode = OracleDBHelper.ToModelValue(reader, "QcCode").ToDBString();
            t_instock.QcDesc = OracleDBHelper.ToModelValue(reader, "QcDesc").ToDBString();
            t_instock.AdvInStatus = OracleDBHelper.ToModelValue(reader, "AdvInStatus").ToInt32(); // 预到货状态

            t_instock.Note = (string)OracleDBHelper.ToModelValue(reader, "Note");
            
            return t_instock;
        }

        protected override string GetViewName()
        {
            return "V_INSTOCK";
        }

        protected override string GetTableName()
        {
            return "T_INSTOCK";
        }

        protected override string GetSaveProcedureName()
        {
            return "";
        }

        protected override string GetFilterSql(UserModel user,T_InStockInfo model)
        {
            string strSql = base.GetFilterSql(user, model);
            string strAnd = " and ";

            if (model.Status > 0)
            {
                //strSql += strAnd;
                //strSql += "nvl(status,1)= '" + model.Status + "'";

                if (model.Status == 1 || model.Status == 2)
                {
                    strSql += strAnd;
                    strSql += "(nvl(status,1)=1 or nvl(status,1)=2)";

                }
                else
                {
                    strSql += strAnd;
                    strSql += "nvl(status,1)= '" + model.Status + "'";
                }
            }
            if(!string.IsNullOrEmpty(model.StrVoucherType)&&model.StrVoucherType.Equals("预到货"))
            {
                strSql += strAnd;
                strSql += "(nvl(AdvInStatus,1)=1 or nvl(AdvInStatus,1)=2)";
            }

            if (!string.IsNullOrEmpty(model.SupplierNo)) 
            {
                strSql += strAnd;
                strSql += " (SupplierNo Like '" + model.SupplierNo + "%'  or SupplierName Like '" + model.SupplierNo + "%' )";
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
                strSql += " erpvoucherno like  '%" + model.ErpVoucherNo + "%'  ";
            }

            if (model.VoucherType > 0) 
            {
                strSql += strAnd;
                strSql += " vouchertype ='"+model.VoucherType+"'  ";
            }


            return strSql + "order by id desc";
        }

        /// <summary>
        /// 导入序列号，验证订单是否存在
        /// </summary>
        /// <param name="VoucherNo"></param>
        /// <returns></returns>
        public int CheckVoucherNo(string VoucherNo,int VoucherType) 
        {
            string strSql = "select count(1) from t_Instock   where Erpvoucherno ='" + VoucherNo + "' and vouchertype = '"+VoucherType+"' ";

           return base.GetScalarBySql(strSql).ToInt32();
        }

        /// <summary>
        /// 上架扫描物料条码，获取该物料的质检状态
        /// 用来判断能不能上架
        /// </summary>
        /// <param name="strTaskNo"></param>
        /// <param name="MaterialNoID"></param>
        /// <param name="BatchNo"></param>
        /// <returns></returns>
        public string GetInStockStatusByTaskNo(string strTaskNo)
        {
            string strSql = "select Qccode from t_Instock where id = (select instockid from t_task where taskno = '" + strTaskNo + "' )";
            return base.GetScalarBySql(strSql).ToDBString();
        }

        public int GetInStockVoucherType(string strTaskNo) 
        {
            string strSql = "select vouchertype from t_task where taskno = '"+strTaskNo+"'";
            return base.GetScalarBySql(strSql).ToInt32();
        }

        public override List<T_InStockInfo> GetModelListADF(UserModel user, T_InStockInfo model)
        {
            List < T_InStockInfo > modelList= base.GetModelListADF(user, model);
            if (modelList != null && modelList.Count > 0) 
            {
                modelList = modelList.Take(20).ToList();
            }

            return modelList;

        }

    }
}
