
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILBasic.User;
using BILBasic.DBA;
using BILBasic.Common;
using Oracle.ManagedDataAccess.Client;
using BILWeb.Area;
using System.Data;

namespace BILWeb.InStock
{
    public partial class T_InStockDetail_DB : BILBasic.Basing.Base_DB<T_InStockDetailInfo>
    {

        /// <summary>
        /// 添加t_instockdetail
        /// </summary>
        protected override OracleParameter[] GetSaveModelOracleParameter(T_InStockDetailInfo t_instockdetail)
        {
            //注意!head表ID要填basemodel的headerID new SqlParameter("@CustomerID", DbHelperSQL.ToDBValue(model.HeaderID)),
            throw new NotImplementedException();


        }

        protected override List<string> GetSaveSql(UserModel user, ref  T_InStockDetailInfo model)
        {
            string strSql = string.Empty;
            List<string> lstSql = new List<string>();

            if (model.ID <= 0)
            {
                int detailID = base.GetTableID("Seq_Instockdetail_Id");
                model.ID = detailID;
                strSql = string.Format("insert into t_Instockdetail (Id, Headerid, Rowno, Materialno, Materialdesc, Instockqty, Unit, Unitname, Linestatus, Creater, Createtime,  Voucherno, Erpvoucherno, Isdel,Arrivaldate,partno,remainqty)" +
                    " values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','1','{8}',Sysdate,'{9}','{10}','1',to_date('{11}','YYYY-MM-DD hh24:mi:ss'),'{12}','{13}')",
                    detailID, model.HeaderID, model.RowNo, model.MaterialNo, model.MaterialDesc, model.InStockQty, model.Unit, model.UnitName, user.UserNo, model.VoucherNo, model.ErpVoucherNo, model.ArrivalDate, model.PartNo, model.InStockQty);

                lstSql.Add(strSql);
            }
            else
            {
                strSql = "update t_Instockdetail a set a.Materialno = '" + model.MaterialNo + "',a.Partno = '" + model.PartNo + "',a.Instockqty = '" + model.InStockQty + "',a.Materialdesc='" + model.MaterialDesc + "',a.Arrivaldate = to_date('" + model.ArrivalDate + "','YYYY-MM-DD hh24:mi:ss'),a.remainqty = '" + model.InStockQty + "'" +
                        "where a.Id = '" + model.ID + "'";
                lstSql.Add(strSql);
            }
            return lstSql;
        }

        protected override List<string> GetSaveModelListSql(UserModel user, List<T_InStockDetailInfo> modelList)
        {
            string strSql1 = string.Empty;
            string strSql2 = string.Empty;
            string strSql3 = string.Empty;
            string strSql4 = string.Empty;
            string strSql5 = string.Empty;
            string strSql6 = string.Empty;
            string strSql7 = string.Empty;
            string strSql8 = string.Empty;
            string strSql9 = string.Empty;
            string strSql10 = string.Empty;
            string TaskNo = string.Empty;

            if (modelList == null || modelList.Count == 0)
            {
                return null;
            }

            if (modelList[0].VoucherType == 35)
            {
                return null;
            }

            int taskid = GetTableID("seq_task_id");

            List<string> lstSql = new List<string>();

            if (modelList.Count() > 0)
            {
                string TaskNoID = base.GetTableID("seq_task_no").ToString();

                TaskNo = "T" + System.DateTime.Now.ToString("yyyyMMdd") + TaskNoID.PadLeft(4, '0');

                modelList.ForEach(t => t.TaskNo = TaskNo);
            }
            else
            {
                modelList.ForEach(t => t.TaskNo = "");
            }

            foreach (var item in modelList)
            {
                strSql1 = "update t_Instockdetail a set a.remainqty = (case when (nvl(a.remainqty,0) - '" + item.ScanQty + "') <= 0 then 0 else nvl(a.remainqty,0) - '" + item.ScanQty + "' end), a.Receiveqty = (nvl(a.Receiveqty,0) + '" + item.ScanQty + "') ," +
                        "a.OPERATORUSERNO = '" + user.UserNo + "',a.Operatordatetime = Sysdate  ,a.materialnoid = '" + item.MaterialNoID + "'  where id  ='" + item.ID + "'";
                lstSql.Add(strSql1);

                strSql2 = "update t_Instockdetail a set a.Linestatus =  (case when nvl(a.Receiveqty,0)< nvl(a.Instockqty,0) and nvl(a.remainqty,0)<>0 then 2" +
                          "when nvl(a.Receiveqty,0) >= nvl(a.Instockqty,0)  then 3 end ) where id = '" + item.ID + "'";
                lstSql.Add(strSql2);

                foreach (var itemBarCode in item.lstBarCode)
                {
                    item.IsQuality = 3;//库存状态改为合格
                    strSql8 = "insert into t_stock(id,serialno,Materialno,materialdesc,qty,status,isdel,Creater,Createtime,batchno,unit,unitname,Palletno," +
                             "islimitstock,materialnoid,warehouseid,houseid,areaid,Receivestatus,barcode,STRONGHOLDCODE,STRONGHOLDNAME,COMPANYCODE,EDATE,SUPCODE,SUPNAME," +
                            "PRODUCTDATE,SUPPRDBATCH,SUPPRDDATE,Isquality,Stocktype,ean)" +
                            "values (seq_stock_id.Nextval,'" + itemBarCode.SerialNo + "','" + item.MaterialNo + "','" + item.MaterialDesc + "','" + itemBarCode.Qty + "','" + item.IsQuality + "','1'" +
                            ",'" + user.UserNo + "',Sysdate,'" + itemBarCode.BatchNo + "','" + item.Unit + "','" + item.UnitName + "'" +
                            ",(select palletno from t_Palletdetail where serialno = '" + itemBarCode.SerialNo + "'),'1','" + item.MaterialNoID + "'" +
                            ", '" + user.WarehouseID + "','" + user.ReceiveHouseID + "','" + user.ReceiveAreaID + "','1','" + itemBarCode.BarCode + "','" + item.StrongHoldCode + "', " +
                            "  '" + itemBarCode.StrongHoldName + "','" + itemBarCode.CompanyCode + "',to_date('" + itemBarCode.EDate + "','YYYY-MM-DD hh24:mi:ss'),'" + item.SupplierNo + "','" + item.SupplierName + "'," +
                            "to_date('" + itemBarCode.ProductDate + "','YYYY-MM-DD hh24:mi:ss') ,'" + itemBarCode.SupPrdBatch + "',to_date('" + itemBarCode.SupPrdDate + "','YYYY-MM-DD hh24:mi:ss'),'3' ,'1','" + itemBarCode.EAN + "' )";

                    lstSql.Add(strSql8);

                    strSql10 = "insert into t_tasktrans(Id, Serialno,towarehouseid,Tohouseid, Toareaid, Materialno, Materialdesc, Supcuscode, " +
                                "Supcusname, Qty, Tasktype, Vouchertype, Creater, Createtime,TaskdetailsId, Unit, Unitname,materialnoid," +
                                "erpvoucherno,voucherno,barcode,STRONGHOLDCODE,STRONGHOLDNAME,COMPANYCODE,PRODUCTDATE,SUPPRDBATCH,SUPPRDDATE,EDATE,TASKNO,batchno)" +
                            " values (seq_tasktrans_id.Nextval,'" + itemBarCode.SerialNo + "','" + user.WarehouseID + "','" + user.ReceiveHouseID + "'," +
                            "'" + user.ReceiveAreaID + "','" + item.MaterialNo + "','" + item.MaterialDesc + "','" + item.SupplierNo + "','" + item.SupplierName + "'," +
                            " '" + itemBarCode.Qty + "','4',(select vouchertype from t_Instock where voucherno = '" + item.VoucherNo + "') ,'" + user.UserName + "',Sysdate,'" + item.ID + "'," +
                            "'" + item.Unit + "','" + item.UnitName + "','" + item.MaterialNoID + "','" + item.ErpVoucherNo + "','" + item.VoucherNo + "','" + itemBarCode.BarCode + "'," +
                            "'" + item.StrongHoldCode + "','" + item.StrongHoldName + "','" + item.CompanyCode + "',to_date('" + itemBarCode.ProductDate + "','YYYY-MM-DD hh24:mi:ss'),'" + itemBarCode.SupPrdBatch + "'" +
                            " ,to_date('" + itemBarCode.SupPrdDate + "','YYYY-MM-DD hh24:mi:ss'),to_date('" + itemBarCode.EDate + "','YYYY-MM-DD hh24:mi:ss'),'" + TaskNo + "','" + itemBarCode.BatchNo + "')";
                    lstSql.Add(strSql10);

                }

            }

            strSql3 = "update t_Instock a set a.Status = 2 where id = '" + modelList[0].HeaderID + "'";
            lstSql.Add(strSql3);

            strSql4 = " update t_Instock a set a.Status = 3 where " +
                      "a.id in(select b.Headerid from t_Instockdetail b  group by b.Headerid having(max(nvl(linestatus,1)) = 3 and min(nvl(linestatus,1))=3) and b.Headerid = '" + modelList[0].HeaderID + "')" +
                      "and id = '" + modelList[0].HeaderID + "'";
            lstSql.Add(strSql4);


            List<T_InStockDetailInfo> NewModelList = GroupInstockDetailList(modelList);

            //汇总生成上架任务不汇总收货数据
            foreach (var item in NewModelList)
            {
                strSql6 = "insert into t_Taskdetails (id,headerid,Materialno,materialdesc,Taskqty,Remainqty,LineStatus,Creater,Createtime,Unit,Unitname,erpvoucherno,materialnoid,toareano,voucherno," +
                "STRONGHOLDCODE,STRONGHOLDNAME,COMPANYCODE,batchno,Productbatch,Productdate,Supprdbatch,Supprddate,Frombatchno,Fromerpareano,Fromerpwarehouse)" +
                   "values(seq_taskdetail_id.Nextval ,'" + taskid + "','" + item.MaterialNo + "','" + item.MaterialDesc + "','" + item.ScanQty + "','" + item.ScanQty + "'," +
                   "'1','" + user.UserNo + "',Sysdate,'" + item.Unit + "','" + item.UnitName + "','" + item.ErpVoucherNo + "','" + item.MaterialNoID + "','" + user.ReceiveAreaID + "','" + item.VoucherNo + "'," +
                   "'" + item.StrongHoldCode + "','" + item.StrongHoldName + "','" + item.CompanyCode + "','" + item.BatchNo + "'," +
                "'" + item.ProductBatch + "',to_date('" + item.ProductDate + "','YYYY-MM-DD hh24:mi:ss'),'" + item.SupPrdBatch + "'," +
                "to_date('" + item.SupPrdDate + "','YYYY-MM-DD hh24:mi:ss'),'" + item.BatchNo + "','" + user.ReceiveAreaNo + "','" + user.ReceiveWareHouseNo + "')";

                lstSql.Add(strSql6);
            }

            if (NewModelList != null && NewModelList.Count() > 0)
            {
                strSql5 = "insert into t_task (id,Vouchertype,tasktype,Taskno,Supcusname,status,Taskissued,Receiveuserno,Createtime,supcuscode,Creater,InStockID," +
                          "erpvoucherno,plant,plantname,movetype,Taskissueduser,voucherno,STRONGHOLDCODE,STRONGHOLDNAME,COMPANYCODE,ERPCREATER,VOUDATE,VOUUSER,ERPSTATUS,ERPNOTE,erpinvoucherno,WAREHOUSEID,erpvouchertype)" +
                          "select  '" + taskid + "',a.Vouchertype,'1','" + TaskNo + "',a.Suppliername , '1',Sysdate,'" + user.UserNo + "',Sysdate,a.Supplierno,'" + user.UserNo + "',a.Id," +
                          "a.Erpvoucherno,a.Plant,a.Plantname,a.Movetype,'" + user.UserNo + "',voucherno,STRONGHOLDCODE,STRONGHOLDNAME,COMPANYCODE,ERPCREATER,VOUDATE,VOUUSER,ERPSTATUS,ERPNOTE,'" + NewModelList[0].MaterialDoc + "'" +
                          "  ,'" + user.WarehouseID + "','" + modelList[0].ERPVoucherType + "' from t_Instock a where id = '" + modelList[0].HeaderID + "'";
                lstSql.Add(strSql5);
            }


            return lstSql;
        }


        /// <summary>
        /// 汇总收货数据
        /// </summary>
        /// <param name="modelList"></param>
        private List<T_InStockDetailInfo> GroupInstockDetailList(List<T_InStockDetailInfo> modelList)
        {
            var newModelList = from t in modelList
                               group t by new { t1 = t.MaterialNo, t2 = t.BatchNo } into m
                               select new T_InStockDetailInfo
                               {
                                   MaterialNo = m.Key.t1,
                                   ScanQty = m.Sum(item => item.ScanQty),
                                   MaterialDesc = m.FirstOrDefault().MaterialDesc,
                                   Unit = m.FirstOrDefault().Unit,
                                   UnitName = m.FirstOrDefault().UnitName,
                                   ErpVoucherNo = m.FirstOrDefault().ErpVoucherNo,
                                   MaterialNoID = m.FirstOrDefault().MaterialNoID,
                                   VoucherNo = m.FirstOrDefault().VoucherNo,
                                   StrongHoldCode = m.FirstOrDefault().StrongHoldCode,
                                   StrongHoldName = m.FirstOrDefault().StrongHoldName,
                                   CompanyCode = m.FirstOrDefault().CompanyCode,
                                   BatchNo = m.FirstOrDefault().BatchNo,
                                   ProductBatch = m.FirstOrDefault().ProductBatch,
                                   ProductDate = m.FirstOrDefault().ProductDate,
                                   SupPrdBatch = m.FirstOrDefault().SupPrdBatch,
                                   SupPrdDate = m.FirstOrDefault().SupPrdDate,
                                   MaterialDoc = m.FirstOrDefault().MaterialDoc

                               };

            return newModelList.ToList();
        }

        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        protected override T_InStockDetailInfo ToModel(OracleDataReader reader)
        {
            T_InStockDetailInfo t_instockdetail = new T_InStockDetailInfo();

            t_instockdetail.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();
            t_instockdetail.HeaderID = OracleDBHelper.ToModelValue(reader, "HeaderID").ToInt32();
            t_instockdetail.RowNo = OracleDBHelper.ToModelValue(reader, "ROWNO").ToDBString();
            t_instockdetail.MaterialNo = (string)OracleDBHelper.ToModelValue(reader, "MATERIALNO");
            t_instockdetail.MaterialDesc = (string)OracleDBHelper.ToModelValue(reader, "MATERIALDESC");
            t_instockdetail.InStockQty = OracleDBHelper.ToModelValue(reader, "INSTOCKQTY").ToDecimal();
            t_instockdetail.ReceiveQty = OracleDBHelper.ToModelValue(reader, "RECEIVEQTY").ToDecimal();
            t_instockdetail.Unit = (string)OracleDBHelper.ToModelValue(reader, "UNIT");
            t_instockdetail.StorageLoc = (string)OracleDBHelper.ToModelValue(reader, "STORAGELOC");
            t_instockdetail.Plant = (string)OracleDBHelper.ToModelValue(reader, "PLANT");
            t_instockdetail.PlantName = (string)OracleDBHelper.ToModelValue(reader, "PLANTNAME");
            t_instockdetail.QualityQty = OracleDBHelper.ToModelValue(reader, "QUALITYQTY").ToDecimal();
            t_instockdetail.UnQualityQty = OracleDBHelper.ToModelValue(reader, "UNQUALITYQTY").ToDecimal();
            t_instockdetail.QualityType = (string)OracleDBHelper.ToModelValue(reader, "QUALITYTYPE");
            t_instockdetail.QualityUserNo = (string)OracleDBHelper.ToModelValue(reader, "QUALITYUSERNO");
            t_instockdetail.QualityDate = (DateTime?)OracleDBHelper.ToModelValue(reader, "QUALITYDATE");
            t_instockdetail.UnitName = (string)OracleDBHelper.ToModelValue(reader, "UNITNAME");
            t_instockdetail.LineStatus = OracleDBHelper.ToModelValue(reader, "LINESTATUS").ToInt32();
            t_instockdetail.Creater = (string)OracleDBHelper.ToModelValue(reader, "CREATER");
            t_instockdetail.CreateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CREATETIME");
            t_instockdetail.Modifyer = (string)OracleDBHelper.ToModelValue(reader, "MODIFYER");
            t_instockdetail.ModifyTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "MODIFYTIME");
            t_instockdetail.TimeStamp = (DateTime?)OracleDBHelper.ToModelValue(reader, "TIMESTAMP");
            t_instockdetail.RemainQty = OracleDBHelper.ToModelValue(reader, "RemainQty").ToDecimal();
            t_instockdetail.ArrivalDate = (DateTime?)OracleDBHelper.ToModelValue(reader, "ArrivalDate");
            t_instockdetail.VoucherType = OracleDBHelper.ToModelValue(reader, "VoucherType").ToInt32();
            t_instockdetail.SupplierNo = OracleDBHelper.ToModelValue(reader, "SupplierNo").ToDBString();
            t_instockdetail.SupplierName = OracleDBHelper.ToModelValue(reader, "SupplierName").ToDBString();
            t_instockdetail.SaleCode = OracleDBHelper.ToModelValue(reader, "SaleCode").ToDBString();
            t_instockdetail.SaleName = OracleDBHelper.ToModelValue(reader, "SaleName").ToDBString();
            t_instockdetail.ErpVoucherNo = OracleDBHelper.ToModelValue(reader, "ErpVoucherNo").ToDBString();

            t_instockdetail.MaterialNoID = OracleDBHelper.ToModelValue(reader, "MateiralNoID").ToInt32();
            t_instockdetail.PartNo = OracleDBHelper.ToModelValue(reader, "PartNo").ToDBString();

            t_instockdetail.VoucherNo = OracleDBHelper.ToModelValue(reader, "VoucherNo").ToDBString();
            t_instockdetail.IsSerial = OracleDBHelper.ToModelValue(reader, "IsSerial").ToInt32();


            t_instockdetail.StrongHoldCode = OracleDBHelper.ToModelValue(reader, "StrongHoldCode").ToDBString();
            t_instockdetail.StrongHoldName = OracleDBHelper.ToModelValue(reader, "StrongHoldName").ToDBString();
            t_instockdetail.CompanyCode = OracleDBHelper.ToModelValue(reader, "CompanyCode").ToDBString();
            t_instockdetail.RowNoDel = OracleDBHelper.ToModelValue(reader, "RowNoDel").ToDBString();
            t_instockdetail.DeliverySup = OracleDBHelper.ToModelValue(reader, "DeliverySup").ToDBString();
            t_instockdetail.ShipmentDate = OracleDBHelper.ToModelValue(reader, "ShipmentDate").ToDateTime();
            t_instockdetail.ArrStockDate = OracleDBHelper.ToModelValue(reader, "ArrStockDate").ToDateTime();
            t_instockdetail.ErpLineStatus = OracleDBHelper.ToModelValue(reader, "ErpLineStatus").ToInt32();
            t_instockdetail.ERPNote = OracleDBHelper.ToModelValue(reader, "ERPNote").ToDBString();

            t_instockdetail.FromBatchNo = OracleDBHelper.ToModelValue(reader, "FromBatchNo").ToDBString();
            t_instockdetail.FromErpAreaNo = OracleDBHelper.ToModelValue(reader, "FromErpAreaNo").ToDBString();
            t_instockdetail.FromErpWarehouse = OracleDBHelper.ToModelValue(reader, "FromErpWarehouse").ToDBString();
            t_instockdetail.ToBatchno = OracleDBHelper.ToModelValue(reader, "ToBatchNo").ToDBString();
            t_instockdetail.ToErpAreaNo = OracleDBHelper.ToModelValue(reader, "ToErpAreaNo").ToDBString();
            t_instockdetail.ToErpWarehouse = OracleDBHelper.ToModelValue(reader, "ToErpWarehouse").ToDBString();
            t_instockdetail.IsSpcBatch = OracleDBHelper.ToModelValue(reader, "IsSpcBatch").ToDBString();
            t_instockdetail.ADVRECEIVEQTY = OracleDBHelper.ToModelValue(reader, "ADVRECEIVEQTY").ToInt32();

            t_instockdetail.QcCode = OracleDBHelper.ToModelValue(reader, "QcCode").ToDBString();
            t_instockdetail.QcDesc = OracleDBHelper.ToModelValue(reader, "QcDesc").ToDBString();
            t_instockdetail.ERPVoucherType = OracleDBHelper.ToModelValue(reader, "ErpVoucherType").ToDBString();
            t_instockdetail.EDate = OracleDBHelper.ToModelValue(reader, "EDate").ToDateTime();


            return t_instockdetail;
        }

        protected override string GetViewName()
        {
            return "V_INSTOCKDETAIL";
        }

        protected override string GetTableName()
        {
            return "T_INSTOCKDETAIL";
        }

        protected override string GetSaveProcedureName()
        {
            return "";
        }

        protected override List<string> GetDeleteSql(UserModel user, T_InStockDetailInfo model)
        {
            List<string> lstSql = new List<string>();
            string strSql = string.Empty;

            strSql = "delete t_Instockdetail where id = '" + model.ID + "'";

            lstSql.Add(strSql);

            return lstSql;
        }


        public bool CheckSerialNo(List<T_InStockDetailInfo> modelList, ref string strError)
        {
            try
            {
                bool bSucc = false;
                T_SerialNo_DB db = new T_SerialNo_DB();

                foreach (var item in modelList)
                {
                    //序列号管理
                    if (item.IsSerial == 2)
                    {
                        foreach (var itemSerialNo in item.lstSerialNo)
                        {
                            if (db.CheckSerialNoInStockCommit(itemSerialNo.SerialNo, ref strError) == false)
                            {
                                bSucc = false;
                                break;
                            }
                            else { bSucc = true; }
                        }
                    }
                    else
                    {
                        bSucc = true;
                    }

                }

                return bSucc;

            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 导入序列号验证是否存在
        /// </summary>
        /// <param name="SerialXml"></param>
        /// <param name="strErrMsg"></param>
        /// <returns></returns>
        public bool CheckSerialListIsExist(string SerialXml, ref string strErrMsg)
        {
            try
            {
                int iResult = 0;

                OracleParameter[] cmdParms = new OracleParameter[] 
            {
                new OracleParameter("strSerialXml", OracleDbType.NClob),                
                new OracleParameter("bResult", OracleDbType.Int32,ParameterDirection.Output),
                new OracleParameter("strErrMsg", OracleDbType.NVarchar2,200,strErrMsg,ParameterDirection.Output)
            };

                cmdParms[0].Value = SerialXml;

                OracleDBHelper.ExecuteNonQuery3(OracleDBHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "P_CHECKSERIAL", cmdParms);
                iResult = Convert.ToInt32(cmdParms[1].Value.ToString());
                strErrMsg = cmdParms[2].Value.ToString();

                return iResult == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 导入EXCEL，获取单据明细
        /// </summary>
        /// <param name="VoucherNo"></param>
        /// <returns></returns>
        public List<T_InStockDetailInfo> GetDetailByVoucherNo(string VoucherNo, int VoucherType)
        {
            string strSql = "select * from v_Instockdetail a where a.Erpvoucherno = '" + VoucherNo + "' and vouchertype='" + VoucherType + "'";

            return base.GetModelListBySql(strSql);
        }

        protected override string GetFilterSql(UserModel user, T_InStockDetailInfo model)
        {
            string strSql = base.GetFilterSql(user, model);
            string strAnd = " and ";
            if (!string.IsNullOrEmpty(model.ErpVoucherNo))
            {
                strSql += strAnd;
                strSql += " erpvoucherno = '"+model.ErpVoucherNo+ "' ";
            }
            return strSql + " order by id desc";
        }


        }
}
