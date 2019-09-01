using BILBasic.DBA;
using BILBasic.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILBasic.Common;
using Oracle.ManagedDataAccess.Client;
using BILBasic.JSONUtil;
using BILWeb.Stock;
using BILBasic.XMLUtil;
using System.Data;

namespace BILWeb.OutStockTask
{
    public partial class T_OutTaskDetails_DB : BILBasic.Basing.Base_DB<T_OutStockTaskDetailsInfo>
    {

        /// <summary>
        /// 添加t_taskdetails
        /// </summary>
        protected override OracleParameter[] GetSaveModelOracleParameter(T_OutStockTaskDetailsInfo t_taskdetails)
        {
            //注意!head表ID要填basemodel的headerID new SqlParameter("@CustomerID", DbHelperSQL.ToDBValue(model.HeaderID)),
            throw new NotImplementedException();
        }

        protected override List<string> GetSaveSql(UserModel user,ref  T_OutStockTaskDetailsInfo model)
        {
            string strSql = string.Empty;
            List<string> lstSql = new List<string>();

            if (model.ID <= 0)
            {
                return null;
            }
            else
            {
                strSql = "update t_Taskdetails a set a.Taskqty = '" + model.TaskQty + "' , a.Remainqty = '" + model.TaskQty + "' - nvl(a.Unshelveqty,0),a.Outstockqty = '"+model.TaskQty+"', " +
                        " a.Modifyer = '"+user.UserNo+"' ,a.Modifytime = Sysdate where id = '"+model.ID+"'";

                lstSql.Add(strSql);
            }
            return lstSql;
        }

        protected override List<string> GetSaveModelListSql(UserModel user, List<T_OutStockTaskDetailsInfo> modelList)
        {
            string strSql1 = string.Empty;
            string strSql2 = string.Empty;
            string strSql3 = string.Empty;
            string strSql4 = string.Empty;
            string strSql5 = string.Empty;

            List<string> lstSql = new List<string>();

            foreach (var item in modelList) 
            {
                strSql1 = string.Format("update t_taskdetails a set a.remainqty = (case when nvl(a.remainqty,0) >= ('{0}') then (nvl(a.remainqty,0) - '{1}')" +
                                "else 0 end ),a.unshelveqty = nvl(a.unshelveqty,0) + '{2}',a.operatoruserno = '{3}',a.operatordatetime = sysdate where id  = '{4}'",
                                item.ScanQty,item.ScanQty,item.ScanQty,user.UserNo,item.ID);
                lstSql.Add(strSql1);

                strSql1 = string.Format("update t_Outstockdetail set pickqty = nvl(pickqty,0) + '{0}' where erpvoucherno = '{1}' and materialnoid = '{2}' and rowno = '{3}'",
                                item.ScanQty, item.ErpVoucherNo, item.MaterialNoID,item.RowNo);
                lstSql.Add(strSql1);

                strSql2 = string.Format("update t_taskdetails a set a.Linestatus =(case when nvl(a.remainqty,0)< nvl(a.taskqty,0) and nvl(a.remainqty,0)<>0 then 2 when nvl(a.remainqty,0)  = 0  then 3 end )" +
                        "where id ={0}",item.ID);
                lstSql.Add(strSql2);

                strSql3 = "update t_task a set a.Status = 2 where id = '" + item.HeaderID + "'";
                lstSql.Add(strSql3);

                strSql4 = string.Format(" update t_task set status = 3 where id in(select HeaderID from t_taskdetails group by HeaderID having(max(nvl(linestatus,1)) = 3 and min(nvl(linestatus,1))=3) and HeaderID = '{0}')" +
                                        "and id = '{1}'", item.HeaderID, item.HeaderID);

                lstSql.Add(strSql4);

                if (item.lstStockInfo != null && item.lstStockInfo.Count > 0) 
                {
                    foreach (var itemStock in item.lstStockInfo)
                    {
                        lstSql.Add(GetStockTransSql(user, itemStock));

                        //如果是补货单，需要转移到仓库对应的补货库位
                        if (item.VoucherType == 3)
                        {
                            strSql1 = "update t_stock a set a.Areaid = (select id from v_area b where b.warehouseno = '"+item.FromErpWarehouse+"' and b.AREATYPE = '5')," +
                                   " a.Houseid = (select b.HOUSEID from v_area c where c.warehouseno = '" + item.FromErpWarehouse + "' and c.AREATYPE = '5'), " +
                                   " set a.Houseid = (select id from t_Warehouse d where d.Warehouseno = '" + item.FromErpWarehouse + "') where a.Serialno = '"+itemStock.SerialNo+"'";
                            lstSql.Add(strSql1);
                        }
                        else 
                        {
                            if (item.HouseProp == 1)
                            {
                                lstSql.Add("update t_stock a set Taskdetailesid = '" + item.ID + "',a.Areaid = '" + user.PickAreaID + "',a.Houseid = '" + user.PickHouseID + "',a.Warehouseid = '" + user.PickWareHouseID + "' where Serialno = '" + itemStock.SerialNo + "'");

                            }
                            else if (item.HouseProp == 2)
                            {
                                lstSql.Add("update t_stock a set Taskdetailesid = '" + item.ID + "',a.Areaid = '" + user.PickAreaID + "',a.Houseid = '" + user.PickHouseID + "',a.Warehouseid = '" + user.PickWareHouseID + "',houseprop='" + item.HouseProp + "' where Serialno = '" + itemStock.SerialNo + "'");

                            }
                        }

                        

                        lstSql.Add(GetTaskTransSql(user, itemStock, item));

                    }
                   
                }                
                
            }

            return lstSql;
        }

        private string GetStockTransSql(UserModel user,T_StockInfo model) 
        {
            string strSql = "INSERT INTO t_Stocktrans (Id, Barcode, Serialno, Materialno, Materialdesc, Warehouseid, Houseid, Areaid, Qty,  Status, Isdel, Creater, Createtime, " +
                             "Batchno, Sn,  Oldstockid, Taskdetailesid, Checkid, Transferdetailsid,  Unit, Unitname, Palletno, Receivestatus,  Islimitstock,  " +
                             "Materialnoid, Strongholdcode, Strongholdname, Companycode, Edate, Supcode, Supname, Productdate, Supprdbatch, Supprddate, Isquality,ean)" +
                            "SELECT Seq_Stocktrans_Id.Nextval,A.Barcode,A.Serialno,A.Materialno,A.Materialdesc,A.Warehouseid,A.Houseid,A.Areaid,A.Qty, " +
                            "A.Status,A.Isdel,'" + user.UserName + "',A.Createtime,A.Batchno,A.Sn,a.Oldstockid,A.Taskdetailesid,A.Checkid,A.Transferdetailsid,A.Unit,A.Unitname,A.Palletno,A.Receivestatus," +
                            "A.Islimitstock,A.Materialnoid,A.Strongholdcode,A.Strongholdname,A.Companycode,A.Edate,A.Supcode,A.Supname,A.Productdate,A.Supprdbatch," +
                            "A.Supprddate,A.Isquality,a.ean FROM T_STOCK A WHERE A.Serialno = '"+model.SerialNo+"'";
            return strSql;
        }

        private string GetTaskTransSql(UserModel user, T_StockInfo model,T_OutStockTaskDetailsInfo detailModel) 
       { 
            string strSql = "insert into t_tasktrans(Id, Serialno,towarehouseID,TohouseID, ToareaID, Materialno, Materialdesc, Supcuscode, "+
            "Supcusname, Qty, Tasktype, Vouchertype, Creater, Createtime,TaskdetailsId, Unit, Unitname,partno,materialnoid,erpvoucherno,voucherno,"+
            "Strongholdcode,Strongholdname,Companycode,Productdate,Supprdbatch,Supprddate,Edate,taskno,batchno,Fromareaid,Fromwarehouseid,Fromhouseid,barcode,status,materialdoc,houseprop,ean)" +
            " values (seq_tasktrans_id.Nextval,'" + model.SerialNo + "',(select id from t_Warehouse a  where a.Warehouseno = '" + model.ToErpWarehouse + "'),(select a.HOUSEID from v_Area a where a.warehouseno = '" + model.ToErpWarehouse + "' and a.AREANO = '" + model.ToErpAreaNo + "'),(select a.ID from v_Area a where a.warehouseno = '" + model.ToErpWarehouse + "' and a.AREANO = '" + model.ToErpAreaNo + "')," +
            " '" + model.MaterialNo + "','" + model.MaterialDesc + "','" + detailModel.SupCusCode + "','" + detailModel.SupCusName + "','" + model.Qty+ "','2'," +
            " (select vouchertype from t_task where id = '" + detailModel.HeaderID + "') ,'" + user.UserName + "',Sysdate,'" + model.ID + "', " +
            "'" + detailModel.Unit + "','" + detailModel.UnitName + "','" + detailModel.PartNo + "','" + detailModel.MaterialNoID + "','" + detailModel.ErpVoucherNo + "'," +
            "  '" + detailModel.VoucherNo + "','" + detailModel.StrongHoldCode + "','" + detailModel.StrongHoldName + "','" + detailModel.CompanyCode + "',"+
            "  to_date('" + model.ProductDate + "','yyyy-mm-dd hh24:mi:ss'),'" + model.SupPrdBatch + "',to_date('" + model.SupPrdDate + "','yyyy-mm-dd hh24:mi:ss'),to_date('" + model.EDate + "','yyyy-mm-dd hh24:mi:ss') ,'" + detailModel.TaskNo + "'," +
            " '"+model.BatchNo+"', '"+model.AreaID+"','"+model.WareHouseID+"','"+model.HouseID+"' ,'"+model.Barcode+"','"+model.Status+"','"+detailModel.MaterialDoc+"','"+detailModel.HouseProp+"','"+model.EAN+"') ";

            return strSql;
        }

        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        protected override T_OutStockTaskDetailsInfo ToModel(OracleDataReader reader)
        {
            T_OutStockTaskDetailsInfo t_taskdetails = new T_OutStockTaskDetailsInfo();

            t_taskdetails.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();
            //t_taskdetails.ToAreaNo = (string)OracleDBHelper.ToModelValue(reader, "TOAREANO");
            t_taskdetails.MaterialNo = (string)OracleDBHelper.ToModelValue(reader, "MATERIALNO");
            t_taskdetails.MaterialDesc = (string)OracleDBHelper.ToModelValue(reader, "MATERIALDESC");
            t_taskdetails.TaskQty = (decimal?)OracleDBHelper.ToModelValue(reader, "TASKQTY");
            t_taskdetails.QualityQty = (decimal?)OracleDBHelper.ToModelValue(reader, "QUALITYQTY");
            t_taskdetails.RemainQty = (decimal?)OracleDBHelper.ToModelValue(reader, "REMAINQTY");
            t_taskdetails.ShelveQty = (decimal?)OracleDBHelper.ToModelValue(reader, "SHELVEQTY");
            t_taskdetails.LineStatus = OracleDBHelper.ToModelValue(reader, "LINESTATUS").ToInt32();
            t_taskdetails.IsQualitycomp = (decimal?)OracleDBHelper.ToModelValue(reader, "ISQUALITYCOMP");
            t_taskdetails.KeeperUserNo = (string)OracleDBHelper.ToModelValue(reader, "KEEPERUSERNO");
            t_taskdetails.OperatorUserNo = (string)OracleDBHelper.ToModelValue(reader, "OPERATORUSERNO");
            t_taskdetails.CompleteDateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "COMPLETEDATETIME");
            t_taskdetails.HeaderID = OracleDBHelper.ToModelValue(reader, "HeaderID").ToInt32();
            t_taskdetails.TMaterialNo = (string)OracleDBHelper.ToModelValue(reader, "TMATERIALNO");
            t_taskdetails.TMaterialDesc = (string)OracleDBHelper.ToModelValue(reader, "TMATERIALDESC");
            t_taskdetails.OperatorDateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "OPERATORDATETIME");
            t_taskdetails.ReviewQty = OracleDBHelper.ToModelValue(reader, "REVIEWQTY").ToDecimal();
            t_taskdetails.PackCount = (decimal?)OracleDBHelper.ToModelValue(reader, "PACKCOUNT");
            t_taskdetails.ShelvePackCount = (decimal?)OracleDBHelper.ToModelValue(reader, "SHELVEPACKCOUNT");
            t_taskdetails.VoucherNo = (string)OracleDBHelper.ToModelValue(reader, "VOUCHERNO");
            t_taskdetails.RowNo = string.IsNullOrEmpty(OracleDBHelper.ToModelValue(reader, "ROWNO").ToDBString())==true ? "0" : OracleDBHelper.ToModelValue(reader, "ROWNO").ToDBString();
            t_taskdetails.CreateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CREATETIME");
            t_taskdetails.TrackNo = (string)OracleDBHelper.ToModelValue(reader, "TRACKNO");
            t_taskdetails.Unit = (string)OracleDBHelper.ToModelValue(reader, "UNIT");
            t_taskdetails.UnQualityQty = (decimal?)OracleDBHelper.ToModelValue(reader, "UNQUALITYQTY");
            t_taskdetails.PostQty = (decimal?)OracleDBHelper.ToModelValue(reader, "POSTQTY");
            t_taskdetails.PostStatus = (decimal?)OracleDBHelper.ToModelValue(reader, "POSTSTATUS");
            t_taskdetails.PostDate = (DateTime?)OracleDBHelper.ToModelValue(reader, "POSTDATE");
            t_taskdetails.ReserveNumber = (string)OracleDBHelper.ToModelValue(reader, "RESERVENUMBER");
            t_taskdetails.ReserveRowNo = (string)OracleDBHelper.ToModelValue(reader, "RESERVEROWNO");
            t_taskdetails.UnShelveQty = (decimal?)OracleDBHelper.ToModelValue(reader, "UNSHELVEQTY");
            t_taskdetails.Requstreason = (string)OracleDBHelper.ToModelValue(reader, "REQUSTREASON");
            t_taskdetails.Remark = (string)OracleDBHelper.ToModelValue(reader, "REMARK");
            t_taskdetails.ReviewUser = (string)OracleDBHelper.ToModelValue(reader, "REVIEWUSER");
            t_taskdetails.ReviewDate = (DateTime?)OracleDBHelper.ToModelValue(reader, "REVIEWDATE");
            t_taskdetails.ReviewStatus = (decimal?)OracleDBHelper.ToModelValue(reader, "REVIEWSTATUS");
            t_taskdetails.PostUser = (string)OracleDBHelper.ToModelValue(reader, "POSTUSER");
            t_taskdetails.Costcenter = (string)OracleDBHelper.ToModelValue(reader, "COSTCENTER");
            t_taskdetails.Wbselem = (string)OracleDBHelper.ToModelValue(reader, "WBSELEM");
            t_taskdetails.ToStorageLoc = (string)OracleDBHelper.ToModelValue(reader, "TOSTORAGELOC");
            t_taskdetails.FromStorageLoc = (string)OracleDBHelper.ToModelValue(reader, "FROMSTORAGELOC");
            t_taskdetails.OutStockQty = (decimal?)OracleDBHelper.ToModelValue(reader, "OUTSTOCKQTY");
            t_taskdetails.LimitStockQtySAP = (decimal?)OracleDBHelper.ToModelValue(reader, "LIMITSTOCKQTYSAP");
            t_taskdetails.RemainsSockQtySAP = (decimal?)OracleDBHelper.ToModelValue(reader, "REMAINSTOCKQTYSAP");
            t_taskdetails.PackFlag = (decimal?)OracleDBHelper.ToModelValue(reader, "PACKFLAG");
            t_taskdetails.CurrentRemainStockQtySAP = (decimal?)OracleDBHelper.ToModelValue(reader, "CURRENTREMAINSTOCKQTYSAP");
            t_taskdetails.MoveReasonCode = (string)OracleDBHelper.ToModelValue(reader, "MOVEREASONCODE");
            t_taskdetails.MoveReasonDesc = (string)OracleDBHelper.ToModelValue(reader, "MOVEREASONDESC");
            t_taskdetails.PoNo = (string)OracleDBHelper.ToModelValue(reader, "PONO");
            t_taskdetails.PoRowNo = (string)OracleDBHelper.ToModelValue(reader, "POROWNO");
            t_taskdetails.IsLock = (decimal?)OracleDBHelper.ToModelValue(reader, "ISLOCK");
            t_taskdetails.IsSmallBatch = (decimal?)OracleDBHelper.ToModelValue(reader, "ISSMALLBATCH");
            t_taskdetails.DepartmentCode = (string)OracleDBHelper.ToModelValue(reader, "DEPARTMENTCODE");
            t_taskdetails.DepartmentName = (string)OracleDBHelper.ToModelValue(reader, "DEPARTMENTNAME");
            t_taskdetails.UnitName = (string)OracleDBHelper.ToModelValue(reader, "UNITNAME");
            t_taskdetails.Creater = (string)OracleDBHelper.ToModelValue(reader, "CREATER");
            t_taskdetails.VoucherType = OracleDBHelper.ToModelValue(reader, "VoucherType").ToInt32();
            t_taskdetails.ErpVoucherNo = OracleDBHelper.ToModelValue(reader, "ERPVoucherNo").ToDBString();
            t_taskdetails.TaskNo = (string)OracleDBHelper.ToModelValue(reader, "TaskNo");
            t_taskdetails.OperatorUserName = OracleDBHelper.ToModelValue(reader, "OperatorUserName").ToDBString();
            t_taskdetails.StrLineStatus = OracleDBHelper.ToModelValue(reader, "StrLineStatus").ToDBString();
            t_taskdetails.IsSerial = OracleDBHelper.ToModelValue(reader, "IsSerial").ToInt32();
            t_taskdetails.MoveType = (string)OracleDBHelper.ToModelValue(reader, "MoveType");
            t_taskdetails.MaterialNoID = OracleDBHelper.ToModelValue(reader, "MaterialNoID").ToInt32();
            t_taskdetails.PartNo = OracleDBHelper.ToModelValue(reader, "PartNo").ToDBString();

            t_taskdetails.IsSpcBatch = OracleDBHelper.ToModelValue(reader, "IsSpcBatch").ToDBString();
            t_taskdetails.FromBatchNo = OracleDBHelper.ToModelValue(reader, "FromBatchno").ToDBString();
            t_taskdetails.FromErpAreaNo = OracleDBHelper.ToModelValue(reader, "FromErpAreaNo").ToDBString();
            t_taskdetails.FromErpWarehouse = OracleDBHelper.ToModelValue(reader, "FromErpWareHouse").ToDBString();
            t_taskdetails.ToBatchNo = OracleDBHelper.ToModelValue(reader, "ToBatchno").ToDBString();
            t_taskdetails.ToErpAreaNo = OracleDBHelper.ToModelValue(reader, "ToErpAreaNo").ToDBString();
            t_taskdetails.ToErpWarehouse = OracleDBHelper.ToModelValue(reader, "ToErpWareHouse").ToDBString();
            t_taskdetails.FloorType = OracleDBHelper.ToModelValue(reader, "FloorType").ToInt32();
            t_taskdetails.HeightArea = OracleDBHelper.ToModelValue(reader, "HeightArea").ToInt32();
            t_taskdetails.StrongHoldCode = OracleDBHelper.ToModelValue(reader, "StrongHoldCode").ToDBString();
            t_taskdetails.StrongHoldName = OracleDBHelper.ToModelValue(reader, "StrongHoldName").ToDBString();
            t_taskdetails.CompanyCode = OracleDBHelper.ToModelValue(reader, "CompanyCode").ToDBString();
            t_taskdetails.RowNoDel = OracleDBHelper.ToModelValue(reader, "RowNoDel").ToDBString();
            t_taskdetails.StrVoucherType = OracleDBHelper.ToModelValue(reader, "StrVoucherType").ToDBString();
            t_taskdetails.OutstockDetailID = OracleDBHelper.ToModelValue(reader, "OutstockDetailID").ToInt32();

            t_taskdetails.StrIsSpcBatch = t_taskdetails.IsSpcBatch == "Y" ? "是" : "否";
            t_taskdetails.ERPVoucherType = OracleDBHelper.ToModelValue(reader, "ErpVoucherType").ToDBString();
            t_taskdetails.StrModifyer = OracleDBHelper.ToModelValue(reader, "StrModifyer").ToDBString();
            t_taskdetails.ModifyTime = OracleDBHelper.ToModelValue(reader, "ModifyTime").ToDateTime();
            t_taskdetails.MainTypeCode = OracleDBHelper.ToModelValue(reader, "MainTypeCode").ToDBString();
            t_taskdetails.HouseProp = OracleDBHelper.ToModelValue(reader, "HouseProp").ToInt32();
            t_taskdetails.StrHouseProp = OracleDBHelper.ToModelValue(reader, "StrHouseProp").ToDBString();
            t_taskdetails.UnReviewQty = t_taskdetails.TaskQty.ToDecimal() - t_taskdetails.ReviewQty.ToDecimal();

            return t_taskdetails;
        }

        protected override string GetViewName()
        {
            return "V_OUTTASKDETAIL";
        }

        protected override string GetTableName()
        {
            return "T_TASKDETAILS";
        }

        protected override string GetSaveProcedureName()
        {
            return "";
        }

        

        //public override List<T_OutStockTaskDetailsInfo> GetModelListByHeaderID(int headerID)
        //{
        //    try
        //    {
        //        string strError = string.Empty;

        //        List<T_StockInfo> lstStock = new List<T_StockInfo>();
        //        List<T_OutStockTaskDetailsInfo> list = base.GetModelListByHeaderID(headerID);

        //        if (list == null || list.Count == 0) 
        //        {
        //            return null;
        //        }

        //        if (GetPickRuleAreaNo(list, ref lstStock, ref strError) == false)
        //        {
        //            throw new Exception(strError);
        //        }

        //        //if (lstStock == null || lstStock.Count == 0) 
        //        //{
        //        //    throw new Exception("获取物料对应拣货库位为空！");
        //        //}

        //       return  CreateNewListByPickRuleAreaNo(list, lstStock);
               
        //    }
        //    catch (Exception ex) 
        //    {
        //        throw new Exception(ex.Message);
        //    }

            
        //}


        public bool GetPickRuleAreaNo(List<T_OutStockTaskDetailsInfo> modelList,ref List<T_StockInfo> stockList, ref string strError) 
        {
            try
            {
                int iResult = 0;                
                DataSet ds;

                string strOutStockTaskXml = XmlUtil.Serializer(typeof(List<T_OutStockTaskDetailsInfo>), modelList);
                LogNet.LogInfo("GetPickRuleAreaNo:" + strOutStockTaskXml);
                OracleParameter[] cmdParms = new OracleParameter[] 
            {
                new OracleParameter("strOutStockTaskXml", OracleDbType.NClob),    
                new OracleParameter("PickAreaCur", OracleDbType.RefCursor,ParameterDirection.Output),
                new OracleParameter("bResult", OracleDbType.Int32,ParameterDirection.Output),
                new OracleParameter("ErrString", OracleDbType.NVarchar2,200,strError,ParameterDirection.Output)
            };

                cmdParms[0].Value = strOutStockTaskXml;

                cmdParms[1].Value = ParameterDirection.Output;
                cmdParms[2].Value = ParameterDirection.Output;
                cmdParms[3].Value = ParameterDirection.Output;

                ds = OracleDBHelper.ExecuteDataSetForCursor(ref iResult, ref strError, OracleDBHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "p_getpickarea", cmdParms);

                if (iResult == 1)
                {
                    stockList = TOOL.DataTableToList.DataSetToList<T_StockInfo>(ds.Tables[0]);
                    strError = string.Empty;
                }

                return iResult == 1 ? true : false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  List<T_OutStockTaskDetailsInfo> CreateNewListByPickRuleAreaNo( List<T_OutStockTaskDetailsInfo> modelList,  List<T_StockInfo> stockList) 
        {
            List<T_OutStockTaskDetailsInfo> NewModelList = new List<T_OutStockTaskDetailsInfo>();

            #region 现有代码暂时注释

            //foreach (var item in stockList)
            //{
            //    List<T_OutStockTaskDetailsInfo> itemModelList = new List<T_OutStockTaskDetailsInfo>();
            //    itemModelList = modelList.FindAll(t => t.ID == item.OutTaskDetID).ToList();
            //    foreach (var itemModel in itemModelList)
            //    {
            //        T_OutStockTaskDetailsInfo model = new T_OutStockTaskDetailsInfo();
            //        model.ID = itemModel.ID;
            //        model.HeaderID = itemModel.HeaderID;
            //        model.CompanyCode = itemModel.CompanyCode;
            //        model.StrongHoldCode = itemModel.StrongHoldCode;
            //        model.StrongHoldName = itemModel.StrongHoldName;
            //        model.MaterialNo = itemModel.MaterialNo;
            //        model.MaterialDesc = itemModel.MaterialDesc;
            //        model.MaterialNoID = itemModel.MaterialNoID;
            //        model.ErpVoucherNo = itemModel.ErpVoucherNo;
            //        model.VoucherNo = itemModel.VoucherNo;
            //        model.TaskNo = itemModel.TaskNo;
            //        model.TaskQty = itemModel.TaskQty;
            //        model.RemainQty = itemModel.RemainQty;
            //        model.RePickQty = itemModel.RePickQty;
            //        model.AreaNo = item.AreaNo;
            //        model.HeightArea = itemModel.HeightArea;
            //        model.FloorType = itemModel.FloorType;
            //        model.IsSpcBatch = itemModel.IsSpcBatch;
            //        model.ScanQty = itemModel.ScanQty;
            //        model.FromBatchNo = itemModel.FromBatchNo;
            //        model.FromErpAreaNo = itemModel.FromErpAreaNo;
            //        model.FromErpWarehouse = itemModel.FromErpWarehouse;
            //        model.ToBatchNo = itemModel.ToBatchNo;
            //        model.ToErpAreaNo = itemModel.ToErpAreaNo;
            //        model.ToErpWarehouse = itemModel.ToErpWarehouse;
            //        model.TaskType = itemModel.TaskType;
            //        model.DepartmentCode = itemModel.DepartmentCode;
            //        model.DepartmentName = itemModel.DepartmentName;
            //        model.EDate = itemModel.EDate;
            //        model.PickGroupNo = itemModel.PickGroupNo;
            //        model.PickLeaderUserNo = itemModel.PickLeaderUserNo;
            //        model.Status = itemModel.Status;
            //        model.StrStatus = itemModel.StrStatus;
            //        model.StrVoucherType = itemModel.StrVoucherType;
            //        model.StockQty = item.Qty;
            //        NewModelList.Add(model);
            //    }               
            //}

            #endregion            

            

            foreach (var item in modelList) 
            {
                List<T_StockInfo> stockModelList = new List<T_StockInfo>();
                //查找物料可分配库存
                stockModelList = stockList.FindAll(t => t.MaterialNo == item.MaterialNo && t.IsSpcBatch == item.IsSpcBatch && t.Qty>0);
                foreach (var stockModel in stockModelList) 
                {
                    if (item.RemainQty < stockModel.Qty)
                    {
                        item.RePickQty = item.RemainQty;
                        stockModel.Qty = stockModel.Qty - item.RemainQty.ToDecimal();
                        NewModelList.Add(CreateNewOutStockModelToADF(stockModel, item));
                        break;
                    }
                    else if (item.RemainQty == stockModel.Qty)
                    {
                        item.RePickQty = stockModel.Qty;
                        stockModel.Qty = 0;
                        NewModelList.Add(CreateNewOutStockModelToADF(stockModel, item));
                        break;
                    }
                    else if (item.RemainQty > stockModel.Qty)
                    {
                        item.RePickQty = stockModel.Qty;
                        item.RemainQty = item.RemainQty - stockModel.Qty;
                        stockModel.Qty = 0;
                        NewModelList.Add(CreateNewOutStockModelToADF(stockModel, item));
                    }
                }
            }
            //for (int i = 0; i < stockList.Count; i++) 
            //{
            //    List<T_OutStockTaskDetailsInfo> itemModelList = new List<T_OutStockTaskDetailsInfo>();
            //    //根据库存查找订单物料
            //    itemModelList = modelList.FindAll(t => t.MaterialNo == stockList[i].MaterialNo && t.IsSpcBatch == stockList[i].IsSpcBatch);
            //    foreach (var itemModel in itemModelList)
            //    {
            //        if (itemModel.RemainQty == 0 || stockList[i].Qty==0) { break; }

            //        if (itemModel.RemainQty < stockList[i].Qty)
            //        {
            //            itemModel.RePickQty = itemModel.RemainQty;
            //            stockList[i].Qty = stockList[i].Qty - itemModel.RemainQty.ToDecimal();
            //            NewModelList.Add(CreateNewOutStockModelToADF(stockList[i], itemModel));
            //        }
            //        else if (itemModel.RemainQty == stockList[i].Qty)
            //        {
            //            itemModel.RePickQty = stockList[i].Qty;
            //            stockList[i].Qty = 0;
            //            NewModelList.Add(CreateNewOutStockModelToADF(stockList[i], itemModel));
            //        }
            //        else if (itemModel.RemainQty > stockList[i].Qty)
            //        {
            //            itemModel.RePickQty = stockList[i].Qty;
            //            itemModel.RemainQty = itemModel.RemainQty - stockList[i].Qty;
            //            stockList[i].Qty = 0;
            //            NewModelList.Add(CreateNewOutStockModelToADF(stockList[i], itemModel));
            //        }
                    
            //    }
            //}

            #region 异常代码
            //foreach (var itemStock in stockList)
            //{
            //    List<T_OutStockTaskDetailsInfo> itemModelList = new List<T_OutStockTaskDetailsInfo>();
            //    //根据库存查找订单物料
            //    itemModelList = modelList.FindAll(t => t.MaterialNo == itemStock.MaterialNo && t.IsSpcBatch == itemStock.IsSpcBatch);
            //    foreach (var itemModel in itemModelList)
            //    {
            //        if (itemModel.RemainQty < itemStock.Qty)
            //        {
            //            itemModel.RePickQty = itemModel.RemainQty;
            //            itemStock.Qty = itemStock.Qty - itemModel.RemainQty.ToDecimal();
            //        }
            //        else if (itemModel.RemainQty == itemStock.Qty)
            //        {
            //            itemModel.RePickQty = itemStock.Qty;
            //            itemStock.Qty = 0;
            //        }
            //        else if (itemModel.RemainQty > itemStock.Qty)
            //        {
            //            itemModel.RePickQty = itemStock.Qty;
            //            itemModel.RemainQty = itemModel.RemainQty - itemStock.Qty;
            //            itemStock.Qty = 0;

            //        }
            //        T_OutStockTaskDetailsInfo model = new T_OutStockTaskDetailsInfo();
            //        model.ID = itemModel.ID;
            //        model.HeaderID = itemModel.HeaderID;
            //        model.CompanyCode = itemModel.CompanyCode;
            //        model.StrongHoldCode = itemModel.StrongHoldCode;
            //        model.StrongHoldName = itemModel.StrongHoldName;
            //        model.MaterialNo = itemModel.MaterialNo;
            //        model.MaterialDesc = itemModel.MaterialDesc;
            //        model.MaterialNoID = itemModel.MaterialNoID;
            //        model.ErpVoucherNo = itemModel.ErpVoucherNo;
            //        model.VoucherNo = itemModel.VoucherNo;
            //        model.TaskNo = itemModel.TaskNo;
            //        model.TaskQty = itemModel.TaskQty;
            //        model.RemainQty = itemModel.RemainQty;
            //        model.RePickQty = itemModel.RePickQty;
            //        model.AreaNo = itemStock.AreaNo;
            //        model.HeightArea = itemModel.HeightArea;
            //        model.FloorType = itemModel.FloorType;
            //        model.IsSpcBatch = itemModel.IsSpcBatch;
            //        model.ScanQty = itemModel.ScanQty;
            //        model.FromBatchNo = itemModel.FromBatchNo;
            //        model.FromErpAreaNo = itemModel.FromErpAreaNo;
            //        model.FromErpWarehouse = itemModel.FromErpWarehouse;
            //        model.ToBatchNo = itemModel.ToBatchNo;
            //        model.ToErpAreaNo = itemModel.ToErpAreaNo;
            //        model.ToErpWarehouse = itemModel.ToErpWarehouse;
            //        model.TaskType = itemModel.TaskType;
            //        model.DepartmentCode = itemModel.DepartmentCode;
            //        model.DepartmentName = itemModel.DepartmentName;
            //        model.EDate = itemModel.EDate;
            //        model.PickGroupNo = itemModel.PickGroupNo;
            //        model.PickLeaderUserNo = itemModel.PickLeaderUserNo;
            //        model.Status = itemModel.Status;
            //        model.StrStatus = itemModel.StrStatus;
            //        model.StrVoucherType = itemModel.StrVoucherType;
            //        model.StockQty = itemStock.Qty;
            //        NewModelList.Add(model);
            //    }
            //}
            #endregion
           
            return NewModelList.OrderBy(t=>t.SortArea).ToList();

        }

        private T_OutStockTaskDetailsInfo CreateNewOutStockModelToADF(T_StockInfo stockModel,  T_OutStockTaskDetailsInfo itemModel)
        {
            T_OutStockTaskDetailsInfo model = new T_OutStockTaskDetailsInfo();
            model.ID = itemModel.ID;
            model.HeaderID = itemModel.HeaderID;
            model.CompanyCode = itemModel.CompanyCode;
            model.StrongHoldCode = itemModel.StrongHoldCode;
            model.StrongHoldName = itemModel.StrongHoldName;
            model.MaterialNo = itemModel.MaterialNo;
            model.MaterialDesc = itemModel.MaterialDesc;
            model.MaterialNoID = itemModel.MaterialNoID;
            model.ErpVoucherNo = itemModel.ErpVoucherNo;
            model.VoucherNo = itemModel.VoucherNo;
            model.TaskNo = itemModel.TaskNo;
            model.TaskQty = itemModel.TaskQty;
            model.RemainQty = itemModel.RemainQty;
            model.RePickQty = itemModel.RePickQty;
            model.AreaNo = stockModel.AreaNo;
            model.HeightArea = itemModel.HeightArea;
            model.FloorType = itemModel.FloorType;
            model.IsSpcBatch = itemModel.IsSpcBatch;
            model.ScanQty = itemModel.ScanQty;
            model.FromBatchNo = itemModel.FromBatchNo;
            model.FromErpAreaNo = itemModel.FromErpAreaNo;
            model.FromErpWarehouse = itemModel.FromErpWarehouse;
            model.ToBatchNo =stockModel.BatchNo ;//itemModel.ToBatchNo
            model.ToErpAreaNo = itemModel.ToErpAreaNo;
            model.ToErpWarehouse = itemModel.ToErpWarehouse;            
            model.TaskType = itemModel.TaskType;
            model.DepartmentCode = itemModel.DepartmentCode;
            model.DepartmentName = itemModel.DepartmentName;
            model.EDate = itemModel.EDate;
            model.PickGroupNo = itemModel.PickGroupNo;
            model.PickLeaderUserNo = itemModel.PickLeaderUserNo;
            model.Status = itemModel.Status;
            model.StrStatus = itemModel.StrStatus;
            model.StrVoucherType = itemModel.StrVoucherType;
            model.StockQty = stockModel.Qty;
            model.SortArea = stockModel.SortArea;
            model.ERPVoucherType = itemModel.ERPVoucherType;
            model.Unit = itemModel.Unit;
            return model;
        }


        public List<T_OutStockTaskDetailsInfo> GetExportTaskDetail(T_OutStockTaskInfo model)
        {
            try
            {
                List<T_OutStockTaskDetailsInfo> modelList = new List<T_OutStockTaskDetailsInfo>();
                string strSql = "select * from V_OUTTASKDETAIL " + GetExportFilterSql(model);
                using (OracleDataReader reader = OracleDBHelper.ExecuteReader(strSql))
                {
                    modelList = base.ToModels(reader);
                }
                return modelList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetExportFilterSql(T_OutStockTaskInfo model)
        {
            string strSql = " where nvl(isDel,0) != 2  ";

            string strAnd = " and ";

            strSql += strAnd;
            strSql += "TaskType = 2 ";

            if (model.ID > 0) 
            {
                strSql += strAnd;
                strSql += " id = '"+model.ID+"'";
            }

            if (!string.IsNullOrEmpty(model.SupcusCode))
            {
                strSql += strAnd;
                strSql += " (SupcusCode Like '" + model.SupcusCode + "%'  or SupplierName Like '" + model.SupcusCode + "%' )";
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

            if (model.VoucherType > 0)
            {
                strSql += strAnd;
                strSql += " vouchertype ='" + model.VoucherType + "'  ";
            }

            if (!string.IsNullOrEmpty(model.TaskNo))
            {
                strSql += strAnd;
                strSql += " TaskNo ='" + model.TaskNo + "'  ";
            }

           

            return strSql;
        } 
        

        public List<T_OutStockTaskDetailsInfo> GetOutTaskDetailListByHeaderIDADF(List<T_OutStockTaskInfo> lstModel)
        {
            try
            {
                string strSql = string.Empty;
                string headerID = string.Empty;

                foreach (var item in lstModel) 
                {
                    headerID += item.ID + ",";
                }

                headerID = headerID.TrimEnd(',');

                strSql = "select * from v_Outtaskdetail where headerid in ("+headerID+")";

                return base.GetModelListBySql(strSql);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetDBVoucherNo(string strSerialNo) 
        {
            string strSql = "select materialdoc from (select materialdoc from t_Tasktrans where serialno  = '"+strSerialNo+"' and tasktype = 2  order by id desc) where rownum = 1";
            return base.GetScalarBySql(strSql).ToDBString();
        }

        #region 拣选小车操作

        public int GetCarNo(string strCarNo)
        {
            string strSql = "select count(1) from t_pickcar where carno = '" + strCarNo + "'";
            return base.GetScalarBySql(strSql).ToInt32();            
        }

        public string PostScanCar(string strCarNo)
        {
            string strSql = "select taskno from t_pickcar where carno = '" + strCarNo + "'";
            return base.GetScalarBySql(strSql).ToDBString();
        }

        public bool PostBindCarTask(string strCarNo, string strTaskNo, string strUserNo, ref string strError)
        {
            List<string> lstSql = new List<string>();
            string strSql = string.Empty;
            //int carID = base.GetTableID("SEQ_PICKCAR_ID");

            strSql = "update t_pickcar set taskno = '" + strTaskNo + "' where carno = '" + strCarNo + "'";
            //strSql = "insert into t_Pickcar (ID,Carno,Taskno,Creater,Createtime)" +
            //        " VALUES( '" + carID + "','" + strCarNo + "','" + strTaskNo + "','" + strUserNo + "',sysdate )";
            lstSql.Add(strSql);

            strSql = "update t_task set carno = '" + strCarNo + "' where taskno = '" + strTaskNo + "'";
            lstSql.Add(strSql);
            return base.SaveModelListBySqlToDB(lstSql, ref strError);

        }

        /// <summary>
        /// 手动释放拣选小车
        /// </summary>
        /// <param name="strCarNo"></param>
        /// <param name="strTaskNo"></param>
        /// <param name="strError"></param>
        /// <returns></returns>
        public bool DeleteCarModelBySql(string strCarNo, string strTaskNo, ref string strError)
        {
            List<string> lstSql = new List<string>();
            string strSql = string.Empty;

            strSql = "delete t_Pickcar where taskno = '" + strTaskNo + "' and carno = '" + strCarNo + "'";
            lstSql.Add(strSql);

            return base.SaveModelListBySqlToDB(lstSql, ref strError);

        }

        #endregion

        #region 根据ERP订单号获取拣货任务

        public bool GetOutTaskDetailByErpVoucherNo(string strErpVoucherNo, ref List<T_OutStockTaskDetailsInfo> modelListTaskDetail, ref string strError) 
        {
            //获取拣货单表体数据            
            string taskFilter = " erpvoucherno = '" + strErpVoucherNo + "' ";
            modelListTaskDetail = base.GetModelListByFilter("", taskFilter, "*");
            if (modelListTaskDetail == null || modelListTaskDetail.Count == 0)
            {
                strError = "未能获取到拣货数据！";
                return false;
            }
            return true;
        }
        #endregion
    }
}
