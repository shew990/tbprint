
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILBasic.User;
using BILBasic.DBA;
using BILBasic.Common;
using Oracle.ManagedDataAccess.Client;
using BILWeb.OutStockTask;

namespace BILWeb.OutStock
{
    public partial class T_OutStock_DB : BILBasic.Basing.Base_DB<T_OutStockInfo>
    {

        /// <summary>
        /// 添加t_outstock
        /// </summary>
        protected override OracleParameter[] GetSaveModelOracleParameter(T_OutStockInfo t_outstock)
        {
            //注意!head表ID要填basemodel的headerID new SqlParameter("@CustomerID", DbHelperSQL.ToDBValue(model.HeaderID)),
            throw new NotImplementedException();


        }

        protected override List<string> GetSaveSql(UserModel user,ref T_OutStockInfo model)
        {
            string strSql = string.Empty;
            List<string> lstSql = new List<string>();

            //更新
            if (model.ID > 0)
            {
                strSql = string.Format("update t_Outstock a set a.Customercode = '{0}',a.Plant='{1}',a.Plantname='{2}',a.Modifyer = '{3}',a.Modifytime = Sysdate,a.note = '{4}',a.customername = '{5}',a.Address = '{6}',a.Address1 = '{7}',a.Contact = '{8}',a.Phone = '{9}',a.ShipNFlg = '{10}',a.ShipWFlg = '{11}',a.TRAD_NAME = '{12}' where a.Id = '{13}'", 
                    model.CustomerCode, model.Plant, model.PlantName,  user.UserNo,model.Note,model.CustomerName, model.Address, model.Address1, model.Contact, model.Phone, model.ShipNFlg, model.ShipWFlg, model.TradingConditionsName, model.ID);
                lstSql.Add(strSql);
            }
            else //插入
            {
                int voucherID = base.GetTableID("seq_outstock_id");

                model.ID = voucherID.ToInt32();

                string VoucherNoID = base.GetTableID("seq_outstock_no").ToString();

                string VoucherNo ="F"+ System.DateTime.Now.ToString("yyyyMMdd") + VoucherNoID.PadLeft(4, '0');

                strSql = string.Format("insert into t_Outstock (Id,  Vouchertype, Customercode, Plant, Plantname,  Creater, Createtime, Isdel,voucherno,status,note,CustomerName)" +
                    " values('{0}','{1}','{2}','{3}','{4}','{5}',Sysdate,1,'{6}','1','{7}','{8}')", voucherID, model.VoucherType, model.CustomerCode, model.Plant, model.PlantName, user.UserNo,VoucherNo,model.Note,model.CustomerName);

                lstSql.Add(strSql);
            }

            return lstSql;
        }

        protected override List<string> GetUpdateSql(UserModel user, T_OutStockInfo model)
        {
            List<string> lstSql = new List<string>();

            string strSql = "update t_Outstock a set a.Status = '" + model.Status + "' where id = '" + model.ID + "'";

            lstSql.Add(strSql);

            return lstSql;
        }


        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        protected override T_OutStockInfo ToModel(OracleDataReader reader)
        {
            T_OutStockInfo t_outstock = new T_OutStockInfo();

            t_outstock.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();
            t_outstock.ErpVoucherNo = (string)OracleDBHelper.ToModelValue(reader, "ERPVOUCHERNO");
            t_outstock.VoucherType = OracleDBHelper.ToModelValue(reader, "VOUCHERTYPE").ToInt32();
            t_outstock.CustomerCode = (string)OracleDBHelper.ToModelValue(reader, "CUSTOMERCODE");
            t_outstock.CustomerName = (string)OracleDBHelper.ToModelValue(reader, "CUSTOMERNAME");
            t_outstock.IsOutStockPost = (decimal?)OracleDBHelper.ToModelValue(reader, "ISOUTSTOCKPOST");
            t_outstock.IsUnderShelvePost = (decimal?)OracleDBHelper.ToModelValue(reader, "ISUNDERSHELVEPOST");
            t_outstock.Plant = (string)OracleDBHelper.ToModelValue(reader, "PLANT");
            t_outstock.PlantName = (string)OracleDBHelper.ToModelValue(reader, "PLANTNAME");
            t_outstock.MoveType = (string)OracleDBHelper.ToModelValue(reader, "MOVETYPE");
            t_outstock.SupCode = (string)OracleDBHelper.ToModelValue(reader, "SUPPLIERNO");
            t_outstock.SupName = (string)OracleDBHelper.ToModelValue(reader, "SUPPLIERNAME");
            t_outstock.DepartmentCode = (string)OracleDBHelper.ToModelValue(reader, "DEPARTMENTCODE");
            t_outstock.DepartmentName = (string)OracleDBHelper.ToModelValue(reader, "DEPARTMENTNAME");
            t_outstock.MoveReasonCode = (string)OracleDBHelper.ToModelValue(reader, "MOVEREASONCODE");
            t_outstock.MoveReasonDesc = (string)OracleDBHelper.ToModelValue(reader, "MOVEREASONDESC");
            t_outstock.ReviewStatus = (decimal?)OracleDBHelper.ToModelValue(reader, "REVIEWSTATUS");
            t_outstock.OutStockDate = (DateTime?)OracleDBHelper.ToModelValue(reader, "OUTSTOCKDATE");
            t_outstock.Creater = (string)OracleDBHelper.ToModelValue(reader, "CREATER");
            t_outstock.CreateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CREATETIME");
            t_outstock.Modifyer = (string)OracleDBHelper.ToModelValue(reader, "Modifyer");
            t_outstock.ModifyTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "ModifyTime");
            t_outstock.VoucherNo = (string)OracleDBHelper.ToModelValue(reader, "VoucherNo");
            t_outstock.StrVoucherType = (string)OracleDBHelper.ToModelValue(reader, "StrVoucherType");
            t_outstock.StrStatus = (string)OracleDBHelper.ToModelValue(reader, "StrStatus");
            t_outstock.StrCreater = (string)OracleDBHelper.ToModelValue(reader, "StrCreater");
            t_outstock.Note = (string)OracleDBHelper.ToModelValue(reader, "Note");
            t_outstock.Status = OracleDBHelper.ToModelValue(reader, "Status").ToInt32();
            t_outstock.ERPStatus = OracleDBHelper.ToModelValue(reader, "ERPStatus").ToDBString();

            t_outstock.FromShipmentDate = (DateTime?)OracleDBHelper.ToModelValue(reader, "SHIPMENTDATE");
            t_outstock.StrongHoldCode = OracleDBHelper.ToModelValue(reader, "StrongHoldCode").ToDBString();
            t_outstock.StrongHoldName = OracleDBHelper.ToModelValue(reader, "StrongHoldName").ToDBString();
            t_outstock.CompanyCode = OracleDBHelper.ToModelValue(reader, "CompanyCode").ToDBString();
            t_outstock.DepartmentCode = (string)OracleDBHelper.ToModelValue(reader, "DepartmentCode");
            t_outstock.DepartmentName = (string)OracleDBHelper.ToModelValue(reader, "DepartmentName");
            t_outstock.StockQty = (decimal?)OracleDBHelper.ToModelValue(reader, "StockQty");
            t_outstock.OutStockQty = (decimal?)OracleDBHelper.ToModelValue(reader, "OutStockQty");
            t_outstock.CompanyCode = (string)OracleDBHelper.ToModelValue(reader, "CompanyCode");
            t_outstock.StrongHoldCode = (string)OracleDBHelper.ToModelValue(reader, "StrongHoldCode");
            t_outstock.StrongHoldName = (string)OracleDBHelper.ToModelValue(reader, "StrongHoldName");

            t_outstock.Address = OracleDBHelper.ToModelValue(reader, "Address").ToDBString();
            t_outstock.Province = OracleDBHelper.ToModelValue(reader, "Province").ToDBString();
            t_outstock.City = OracleDBHelper.ToModelValue(reader, "City").ToDBString();
            t_outstock.Area = OracleDBHelper.ToModelValue(reader, "Area").ToDBString();
            t_outstock.Phone = OracleDBHelper.ToModelValue(reader, "Phone").ToDBString();
            t_outstock.Contact = OracleDBHelper.ToModelValue(reader, "Contact").ToDBString();
            t_outstock.Address1 = OracleDBHelper.ToModelValue(reader, "Address1").ToDBString();
            t_outstock.ShipNFlg = OracleDBHelper.ToModelValue(reader, "ShipNFlg").ToDBString();
            t_outstock.ShipDFlg = OracleDBHelper.ToModelValue(reader, "ShipDFlg").ToDBString();
            t_outstock.ShipWFlg = OracleDBHelper.ToModelValue(reader, "ShipWFlg").ToDBString();
            t_outstock.ShipPFlg = OracleDBHelper.ToModelValue(reader, "ShipPFlg").ToDBString();
            //t_outstock.ShipPFlg = OracleDBHelper.ToModelValue(reader, "ShipPFlg").ToDBString();
            t_outstock.TradingConditions = OracleDBHelper.ToModelValue(reader, "TradingConditions").ToDBString();
            t_outstock.TradingConditionsName = OracleDBHelper.ToModelValue(reader, "trad_name").ToDBString();
            t_outstock.strReviewUserNo = OracleDBHelper.ToModelValue(reader, "strReviewUserNo").ToDBString();
            t_outstock.fydocno = OracleDBHelper.ToModelValue(reader, "fydocno").ToDBString();
            t_outstock.hmdocno = OracleDBHelper.ToModelValue(reader, "hmdocno").ToDBString();

            return t_outstock;
        }

        protected override string GetViewName()
        {
            return "V_OUTSTOCK";
        }

        protected override string GetTableName()
        {
            return "T_OUTSTOCK";
        }

        protected override string GetSaveProcedureName()
        {
            return "";
        }


        protected override string GetFilterSql(UserModel user, T_OutStockInfo model)
        {
            string strSql = base.GetFilterSql(user, model);
            string strAnd = " and ";


            if (model.Status > 0)
            {
                //strSql += strAnd;
                //strSql += " nvl(status,1)= '" + model.Status + "' ";
                //strSql += strAnd;
                //strSql += "status= '" + model.Status + "'";
                if (model.Status == 3 || model.Status == 4 || model.Status == 2)
                {
                    strSql += strAnd;
                    strSql += " (nvl(status,1)=2 or nvl(status,1)=3 or nvl(status,1)=4) ";
                }
                else
                {
                    strSql += strAnd;
                    strSql += "nvl(status,1)= '" + model.Status + "'";
                }
            }

            if (model.FromShipmentDate != null)
            {
                strSql += strAnd;
                strSql += " ShipmentDate >= " + model.FromShipmentDate.ToDateTime().Date.ToOracleTimeString() + " ";
            }

            if (model.ToShipmentDate != null)
            {
                strSql += strAnd;
                strSql += " ShipmentDate <= " + model.ToShipmentDate.ToDateTime().Date.AddDays(1).ToOracleTimeString() + " ";
            }

            if (!string.IsNullOrEmpty(model.CustomerCode))
            {
                strSql += strAnd;
                strSql += " (CustomerCode Like '" + model.CustomerCode + "%'  or CustomerName Like '" + model.CustomerCode + "%' )";
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
                strSql += " erpvoucherno = '" + model.ErpVoucherNo + "'  ";
            }

            if (model.VoucherType > 0)
            {
                strSql += strAnd;
                strSql += " vouchertype ='" + model.VoucherType + "'  ";
            }

            if (model.StrongHoldType == 1)
            {
                strSql += strAnd;
                strSql += " StrongHoldCode ='CY1'";
            }

            if (model.StrongHoldType == 2)
            {
                strSql += strAnd;
                strSql += " StrongHoldCode ='CX1'";
            }

            if (model.MStockStatus == 1)
            {
                strSql += strAnd;
                strSql += " stockqty = 0 ";
            }

            if (model.MStockStatus == 2)
            {
                strSql += strAnd;
                strSql += " stockqty  > 0 and stockqty < OutStockQty ";
            }

            if (model.MStockStatus == 3)
            {
                strSql += strAnd;
                strSql += " stockqty  > 0 and stockqty >= OutStockQty ";
            }

            return strSql + " order by id desc ";
        }

        #region 获取一张销售出库单和明细列表----------PC端----------------导出装箱单用！！！
        public bool GetOutStockAndDetailsModelByNo(string erpNo, ref BILWeb.OutStockTask.T_OutStockTaskInfo head, ref List<BILWeb.OutStockTask.T_OutStockTaskDetailsInfo> lstDetail, ref string ErrMsg)
        {
            try
            {
                string strSql = "";

                head = new BILWeb.OutStockTask.T_OutStockTaskInfo();

                strSql = "select m.erpbarcode,t.materialno,t.materialdesc,t.edate,t.batchno,t.erpvoucherno,sum(t.qty) as sumQty,count(t.serialno) as countQty from t_tasktrans t " +
                    " inner join t_material m on m.id = t.materialnoid " +
                    " where t.tasktype=12 and t.vouchertype=24 and t.erpvoucherno in (" + erpNo + ") " +
                    " group by t.erpvoucherno,m.erpbarcode,t.materialno,t.materialdesc,t.edate,t.batchno " +
                    " order by t.erpvoucherno,t.materialno,t.batchno ";

                lstDetail = new List<BILWeb.OutStockTask.T_OutStockTaskDetailsInfo>();

                using (OracleDataReader dr = OracleDBHelper.ExecuteReader(strSql))
                {
                    while (dr.Read())
                    {
                        lstDetail.Add(new BILWeb.OutStockTask.T_OutStockTaskDetailsInfo()
                        {
                            MaterialNo = dr["materialno"].ToDBString(),
                            MaterialDesc = dr["materialdesc"].ToDBString(),
                            TaskQty = dr["sumQty"].ToDecimal(),//合计数量
                            QualityQty = dr["countQty"].ToDecimal(),//合计件数
                            ErpDocNo = dr["erpvoucherno"].ToDBString(),//销货单号
                            BatchNo = dr["batchno"].ToDBString(),//批号
                            Remark = dr["erpbarcode"].ToDBString(),//条码
                            CompleteDateTime = dr["edate"].ToDateTime()//产品限用日期
                        });
                    }
                }

                if (lstDetail.Count <= 0)
                {
                    ErrMsg = "没有拣货单明细数据！";
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                return false;
            }
        }
        #endregion

        public bool GetModelListByCar(string strCarNo, ref T_OutStockInfo model ,ref string strError) 
        {
            string strFilter = "   erpvoucherno = ( select erpvoucherno from t_task where taskno = (select taskno from t_Pickcar where carno = '"+strCarNo+"') )";

            string strFilter1 = "erpvoucherno = '" + strCarNo + "'";

            //扫描批次标签
            if (strCarNo.Contains("@"))
            {
                string strSerialNo = OutBarCode.OutBarCode_DeCode.GetEndSerialNo(strCarNo);
                string strFilter2 = "   erpvoucherno = (select erpvoucherno from t_Taskdetails where id  = (select a.Taskdetailesid from t_stock a where a.Serialno = '" + strSerialNo + "'))";
                model = base.GetModelByFilter(strFilter2);
            }
            else 
            {
                //先查小车
                model = base.GetModelByFilter(strFilter);

                if (model == null)
                {
                    //再查ERP单号
                    model = base.GetModelByFilter(strFilter1);
                }
            }

            if (model == null) 
            {
                strError = "该单据编号不存在或者小车编码未关联拣货单！" ;
                return false;
            }

            model.lstDetail = new List<T_OutStockDetailInfo>();

            T_OutTaskDetails_DB tdb = new T_OutTaskDetails_DB();
            List<T_OutStockTaskDetailsInfo> modelListTaskDetail = new List<T_OutStockTaskDetailsInfo>();

            if (tdb.GetOutTaskDetailByErpVoucherNo(model.ErpVoucherNo, ref modelListTaskDetail, ref strError) == false) 
            {
                return false;
            }

            T_OutStockDetail_DB odb = new T_OutStockDetail_DB();
            model.lstDetail = odb.CreateOutStockDetailByTaskDetail(modelListTaskDetail);

            //T_OutStockDetail_DB _db = new T_OutStockDetail_DB();
            ////model.lstDetail = _db.GetModelListByHeaderIDForCar(model.ID);
            //T_OutStockDetail_Func tfunc = new T_OutStockDetail_Func();
            //model.lstDetail = tfunc.OutStockSameMaterialNoSumQty(_db.GetModelListByHeaderIDForCar(model.ID));

            return true;
        }

        public T_OutStockInfo  GetOutStockDetailForPrint(string strErpVoucherNo)
        {
            string strFilter1 = "erpvoucherno = '" + strErpVoucherNo + "'";
            return base.GetModelByFilter(strFilter1);
        }

        public int GetOutStockNoIsExists(string strErpVoucherNo) 
        {
            string strSql = "select count(1) from t_Outstock where erpvoucherno = '" + strErpVoucherNo + "'";
            return base.GetScalarBySql(strSql).ToInt32();
        }
    }
}
