
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILBasic.User;
using BILBasic.DBA;
using BILBasic.Common;
using Oracle.ManagedDataAccess.Client;
using BILWeb.Stock;
using BILWeb.InStock;
using BILWeb.Pallet;
using BILWeb.OutStockTask;

namespace BILWeb.OutStock
{
    public partial class T_OutStockDetail_DB : BILBasic.Basing.Base_DB<T_OutStockDetailInfo>
    {
        T_Stock_DB _db = new T_Stock_DB();

        /// <summary>
        /// 添加t_outstockdetails
        /// </summary>
        protected override OracleParameter[] GetSaveModelOracleParameter(T_OutStockDetailInfo t_outstockdetails)
        {
            //注意!head表ID要填basemodel的headerID new SqlParameter("@CustomerID", DbHelperSQL.ToDBValue(model.HeaderID)),
            throw new NotImplementedException();


        }

        protected override List<string> GetSaveSql(UserModel user,ref  T_OutStockDetailInfo model)
        {
            string strSql = string.Empty;
            List<string> lstSql = new List<string>();

            if (model.ID <= 0)
            {
                int detailID = base.GetTableID("seq_outstockdetail_id");
                model.ID = detailID;
                strSql = string.Format("insert into t_Outstockdetail (Id, Headerid,  Materialno, Materialdesc,Unit, Unitname, Outstockqty,  Creater, Createtime, Isdel,voucherno,partno) " +
                        "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',Sysdate,'1','{8}','{9}')", detailID, model.HeaderID, model.MaterialNo, model.MaterialDesc, model.Unit, model.UnitName, model.OutStockQty, user.UserNo, model.VoucherNo, model.PartNo);

                lstSql.Add(strSql);
            }
            else 
            {
                strSql = "update t_Outstockdetail a set a.Materialno = '" + model.MaterialNo + "',a.Partno='" + model.PartNo + "',a.Materialdesc='" + model.MaterialDesc + "',a.Outstockqty = '" + model.OutStockQty + "' where a.Id='" + model.ID + "'";
                lstSql.Add(strSql);
            }

            
            return lstSql;
        }




        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        protected override T_OutStockDetailInfo ToModel(OracleDataReader reader)
        {
            T_OutStockDetailInfo t_outstockdetails = new T_OutStockDetailInfo();

            t_outstockdetails.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32()
                ;
            t_outstockdetails.HeaderID = OracleDBHelper.ToModelValue(reader, "HeaderID").ToInt32();
            t_outstockdetails.ErpVoucherNo = (string)OracleDBHelper.ToModelValue(reader, "ERPVOUCHERNO");
            t_outstockdetails.MaterialNo = (string)OracleDBHelper.ToModelValue(reader, "MATERIALNO");
            t_outstockdetails.MaterialDesc = (string)OracleDBHelper.ToModelValue(reader, "MATERIALDESC");
            t_outstockdetails.RowNo = OracleDBHelper.ToModelValue(reader, "ROWNO").ToDBString();
            t_outstockdetails.Plant = (string)OracleDBHelper.ToModelValue(reader, "PLANT");
            t_outstockdetails.PlantName = (string)OracleDBHelper.ToModelValue(reader, "PLANTNAME");
            t_outstockdetails.ToStorageLoc = (string)OracleDBHelper.ToModelValue(reader, "TOSTORAGELOC");
            t_outstockdetails.Unit = (string)OracleDBHelper.ToModelValue(reader, "UNIT");
            t_outstockdetails.UnitName = (string)OracleDBHelper.ToModelValue(reader, "UNITNAME");
            t_outstockdetails.OutStockQty = (decimal)OracleDBHelper.ToModelValue(reader, "OUTSTOCKQTY");
            t_outstockdetails.OldOutStockQty = (decimal)OracleDBHelper.ToModelValue(reader, "OLDOUTSTOCKQTY");
            t_outstockdetails.RemainQty = (decimal)OracleDBHelper.ToModelValue(reader, "REMAINQTY");
            t_outstockdetails.Costcenter = (string)OracleDBHelper.ToModelValue(reader, "COSTCENTER");
            t_outstockdetails.Wbselem = (string)OracleDBHelper.ToModelValue(reader, "WBSELEM");
            t_outstockdetails.FromStorageLoc = (string)OracleDBHelper.ToModelValue(reader, "FROMSTORAGELOC");
            t_outstockdetails.ReviewStatus = (decimal?)OracleDBHelper.ToModelValue(reader, "REVIEWSTATUS");
            t_outstockdetails.DepartmentCode = (string)OracleDBHelper.ToModelValue(reader, "DEPARTMENTCODE");
            t_outstockdetails.DepartmentName = (string)OracleDBHelper.ToModelValue(reader, "DEPARTMENTNAME");
            t_outstockdetails.CloseOweUser = (string)OracleDBHelper.ToModelValue(reader, "CLOSEOWEUSER");
            t_outstockdetails.CloseOweDate = (DateTime?)OracleDBHelper.ToModelValue(reader, "CLOSEOWEDATE");
            t_outstockdetails.CloseOweRemark = (string)OracleDBHelper.ToModelValue(reader, "CLOSEOWEREMARK");
            t_outstockdetails.IsOweClose = (decimal?)OracleDBHelper.ToModelValue(reader, "ISOWECLOSE");
            t_outstockdetails.OweRemark = (string)OracleDBHelper.ToModelValue(reader, "OWEREMARK");
            t_outstockdetails.OweRemarkUser = (string)OracleDBHelper.ToModelValue(reader, "OWEREMARKUSER");
            t_outstockdetails.OweRemarkDate = (DateTime?)OracleDBHelper.ToModelValue(reader, "OWEREMARKDATE");
            t_outstockdetails.Creater = (string)OracleDBHelper.ToModelValue(reader, "CREATER");
            t_outstockdetails.CreateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CREATETIME");
            t_outstockdetails.Modifyer = (string)OracleDBHelper.ToModelValue(reader, "MODIFYER");
            t_outstockdetails.ModifyTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "MODIFYTIME");

            t_outstockdetails.PartNo = (string)OracleDBHelper.ToModelValue(reader, "PartNo");
            t_outstockdetails.RowNoDel = OracleDBHelper.ToModelValue(reader, "RowNoDel").ToDBString();           

            t_outstockdetails.CompanyCode = (string)OracleDBHelper.ToModelValue(reader, "CompanyCode");
            t_outstockdetails.StrongHoldCode = (string)OracleDBHelper.ToModelValue(reader, "StrongHoldCode");
            t_outstockdetails.StrongHoldName = (string)OracleDBHelper.ToModelValue(reader, "StrongHoldName");
            t_outstockdetails.VoucherType = OracleDBHelper.ToModelValue(reader, "VoucherType").ToInt32();
            t_outstockdetails.SourceVoucherNo = OracleDBHelper.ToModelValue(reader, "SourceVoucherNo").ToDBString();
            t_outstockdetails.SourceRowNo = OracleDBHelper.ToModelValue(reader, "SourceRowNo").ToDBString();
            t_outstockdetails.MaterialNoID = OracleDBHelper.ToModelValue(reader, "MaterialNoID").ToInt32();
            t_outstockdetails.IsSpcBatch = OracleDBHelper.ToModelValue(reader, "IsSpcBatch").ToDBString();
            t_outstockdetails.StrIsSpcBatch = t_outstockdetails.IsSpcBatch == "Y" ? "是" : "否";
            t_outstockdetails.FromBatchNo = OracleDBHelper.ToModelValue(reader, "FromBatchNo").ToDBString();            
            t_outstockdetails.FromBatchNo = OracleDBHelper.ToModelValue(reader, "FromBatchNo").ToDBString();
            t_outstockdetails.FromErpAreaNo = OracleDBHelper.ToModelValue(reader, "FromErpAreaNo").ToDBString();
            t_outstockdetails.FromErpWarehouse = OracleDBHelper.ToModelValue(reader, "FromErpWarehouse").ToDBString();
            t_outstockdetails.ToBatchno = OracleDBHelper.ToModelValue(reader, "ToBatchno").ToDBString();
            t_outstockdetails.ToErpAreaNo = OracleDBHelper.ToModelValue(reader, "ToErpAreaNo").ToDBString();
            t_outstockdetails.ToErpWarehouse = OracleDBHelper.ToModelValue(reader, "ToErpWarehouse").ToDBString();
            t_outstockdetails.VoucherNo = OracleDBHelper.ToModelValue(reader, "VoucherNo").ToDBString();
            t_outstockdetails.ERPVoucherType = OracleDBHelper.ToModelValue(reader, "ERPVoucherType").ToDBString();

            t_outstockdetails.StockQty = _db.GetSumStockQtyByMaterialIDForOutDetail(t_outstockdetails.MaterialNoID, t_outstockdetails.IsSpcBatch, t_outstockdetails.FromBatchNo, t_outstockdetails.FromErpWarehouse, t_outstockdetails.StrongHoldCode);

            t_outstockdetails.Address = OracleDBHelper.ToModelValue(reader, "Address").ToDBString();
            t_outstockdetails.Province = OracleDBHelper.ToModelValue(reader, "Province").ToDBString();
            t_outstockdetails.City = OracleDBHelper.ToModelValue(reader, "City").ToDBString();
            t_outstockdetails.Area = OracleDBHelper.ToModelValue(reader, "Area").ToDBString();
            t_outstockdetails.Phone = OracleDBHelper.ToModelValue(reader, "Phone").ToDBString();
            t_outstockdetails.Contact = OracleDBHelper.ToModelValue(reader, "Contact").ToDBString();
            t_outstockdetails.Address1 = OracleDBHelper.ToModelValue(reader, "Address1").ToDBString();
            t_outstockdetails.Status = OracleDBHelper.ToModelValue(reader, "Status").ToInt32();
            t_outstockdetails.ReviewQty = OracleDBHelper.ToModelValue(reader, "ReviewQty").ToDecimal();
            t_outstockdetails.PickQty = OracleDBHelper.ToModelValue(reader, "PickQty").ToDecimal();

            return t_outstockdetails;
        }


        //public override List<T_OutStockDetailInfo> GetModelListByHeaderID(int headerID)
        //{
        //    List<T_OutStockDetailInfo> list = base.GetModelListByHeaderID(headerID);
        //    if (list.Count > 0)
        //    {
        //        T_OutStockDetailInfo model = new T_OutStockDetailInfo();
        //        model.EditText = "";
        //        model.OrderNumber = "合计";
        //        model.OutStockQty = list.Sum(p => p.OutStockQty);

        //        list.Add(model);
        //    }

        //    return list;
        //}


        protected override string GetViewName()
        {
            return "V_OUTSTOCKDETAIL";
        }

        protected override string GetTableName()
        {
            return "T_OUTSTOCKDETAIL";
        }

        protected override string GetSaveProcedureName()
        {
            return "";
        }

        protected override List<string> GetDeleteSql(UserModel user, T_OutStockDetailInfo model)
        {
            List<string> lstSql = new List<string>();
            string strSql = string.Empty;

            strSql = "delete t_Outstockdetail where id = '" + model.ID + "'";

            lstSql.Add(strSql);

            return lstSql;
        }

        public bool SaveT_OutStockReviewDetailADF(UserModel userModel, List<T_OutStockDetailInfo> modelList,ref string strError) 
        {
            try
            {
                string strSql = string.Empty;
                List<string> lstSql = new List<string>();
                int ID = base.GetTableID("Seq_Pallet_Id");

                int detailID = 0;

                string VoucherNoID = base.GetTableID("Seq_Pallet_No").ToString();

                string VoucherNo = "P" + System.DateTime.Now.ToString("yyyyMMdd") + VoucherNoID.PadLeft(4, '0');

                strSql = string.Format("insert into t_Pallet(Id, Palletno, Creater, Createtime,Strongholdcode,Strongholdname,Companycode,Pallettype,Supplierno,Suppliername,ERPVOUCHERNO)" +
                                " values ('{0}','{1}','{2}',Sysdate,'{3}','{4}','{5}','2','{6}','{7}','{8}')", ID, VoucherNo, userModel.UserNo, modelList[0].StrongHoldCode, modelList[0].StrongHoldName, modelList[0].CompanyCode, modelList[0].CustomerCode, modelList[0].CustomerName, modelList[0].ErpVoucherNo);

                lstSql.Add(strSql);

                foreach (var item in modelList)
                {
                    item.PalletNo = VoucherNo;

                    foreach (var itemSerial in item.lstStock)
                    {
                        detailID = base.GetTableID("SEQ_PALLET_DETAIL_ID");
                        strSql = string.Format("insert into t_Palletdetail(Id, Headerid, Palletno, Materialno, Materialdesc, Serialno,Creater," +
                        "Createtime,RowNo,VOUCHERNO,ERPVOUCHERNO,materialnoid,qty,BARCODE,StrongHoldCode,StrongHoldName,CompanyCode,pallettype," +
                        "batchno,rownodel,PRODUCTDATE,SUPPRDBATCH,SUPPRDDATE,PRODUCTBATCH,EDATE,Supplierno,Suppliername)" +
                        "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',Sysdate,'{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','2'," +
                        "'{16}','{17}',to_date('{18}','yyyy-mm-dd hh24:mi:ss'),'{19}',to_date('{20}','yyyy-mm-dd hh24:mi:ss'),'{21}',to_date('{22}','yyyy-mm-dd hh24:mi:ss'),'{23}','{24}')", detailID, ID, VoucherNo, itemSerial.MaterialNo, itemSerial.MaterialDesc, itemSerial.SerialNo, userModel.UserNo,
                        string.Empty, item.VoucherNo, item.ErpVoucherNo, item.MaterialNoID, itemSerial.Qty, itemSerial.Barcode,
                        itemSerial.StrongHoldCode, itemSerial.StrongHoldName, itemSerial.CompanyCode, itemSerial.BatchNo, string.Empty,
                        itemSerial.ProductDate, itemSerial.SupPrdBatch, itemSerial.SupPrdDate, string.Empty, itemSerial.EDate, itemSerial.SupCode, itemSerial.SupName);

                        lstSql.Add(strSql);                        
                    }
                }
                return base.SaveModelListBySqlToDB(lstSql, ref strError);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        //提交复核扣库存SQL
        protected override List<string> GetSaveModelListSql(UserModel user, List<T_OutStockDetailInfo> modelList)
        {
            string strSql = string.Empty;
            List<string> lstSql = new List<string>();

            //int iVoucherType = modelList[0].VoucherType;

            //foreach (var item in modelList) 
            //{
            //    strSql = string.Format("update t_Outstockdetail a set a.Oldoutstockqty = nvl(a.Oldoutstockqty,0)+{0}," +
            //            "a.Reviewuserno = '{1}',a.Reviewdate = sysdate where a.id = '{2}'", item.ScanQty, user.UserNo, item.ID);
            //    lstSql.Add(strSql);

            //    strSql = string.Format("update t_Outstockdetail a set a.linestatus =(case when nvl(a.Oldoutstockqty,0)< nvl(a.Outstockqty,0) and nvl(a.Oldoutstockqty,0)<>0 then 2 when nvl(a.Oldoutstockqty,0)  = nvl(a.Outstockqty,0)  then 3 end )," +
            //                            " Toerpareano ='{0}',Toerpwarehouse='{1}' where id = '{2}'", item.ToErpAreaNo, item.ToErpWarehouse, item.ID);
            //    lstSql.Add(strSql);

            //    foreach (var itemStock in item.lstStock) 
            //    {
            //        lstSql.Add(GetStockTransSql(user, itemStock));
            //        lstSql.Add(GetTaskTransSql(user, itemStock, item));
            //        //只有调拨单,并且是调入BH仓库的 才能在生产接受扫描
            //        //if (iVoucherType == 23 && !item.ToErpWarehouse.Contains("BH")) 
            //        //{
            //        //    lstSql.Add(GetStockPRDSql(user, itemStock));
            //        //}

            //        //if (item.ERPVoucherType == "BF2")//ERP单据类型BF2不能扣账，需要转移到报废仓库
            //        //{
            //        //    lstSql.Add("update t_stock a set a.Warehouseid = '1080', a.Houseid='1262',a.Areaid='32177',a.Taskdetailesid='' where a.Serialno='" + itemStock.SerialNo + "'");
            //        //}
            //        //else if (iVoucherType == 23 && item.FromErpWarehouse.Contains("VMA") && item.ToErpWarehouse.Contains("AD"))//调拨单并且是从供应商调出的需要转移到调入对应的待收区
            //        //{
            //        //    strSql = "update t_stock a set a.Warehouseid = (select id from t_Warehouse b where b.Warehouseno='"+item.ToErpWarehouse+"'), " +
            //        //            " a.Houseid=( select id from v_house where housetype = 2 and Warehouseno = '" + item.ToErpWarehouse + "' )," +
            //        //            " a.Areaid=(select id from v_area a where a.warehouseno = '" + item.ToErpWarehouse + "' and a.AREATYPE = '2'),a.Taskdetailesid='' where a.Serialno='" + itemStock.SerialNo + "'";
            //        //    lstSql.Add(strSql);
            //        //}
            //        //else 
            //        //{
            //        //    lstSql.Add("delete t_Stock a where a.Serialno = '" + itemStock.SerialNo + "'");//其他单据类型需要扣账
            //        //}

            //        //strSql = "delete t_Palletdetail where serialno = '" + itemStock.SerialNo + "' and nvl(Pallettype,1) = 1";
            //        //lstSql.Add(strSql);

            //        //strSql = "delete t_Pallet where palletno = '" + itemStock.PalletNo + "' and (select count(1) from t_Palletdetail where palletno = '" + itemStock.PalletNo + "')=0";
            //        //lstSql.Add(strSql);
            //    }

            //}

            //strSql = "update t_Outstock a set a.Status = 3 where id = '" + modelList[0].HeaderID + "'";
            //lstSql.Add(strSql);

            //strSql = " update t_Outstock a set a.Status = 4 where " +
            //          "a.id in(select b.Headerid from t_Outstockdetail b  group by b.Headerid having(max(nvl(linestatus,1)) = 3 and min(nvl(linestatus,1))=3) and b.Headerid = '" + modelList[0].HeaderID + "')" +
            //          "and id = '" + modelList[0].HeaderID + "'";

            //lstSql.Add(strSql);

            //strSql = "update t_task a set a.Status = '4' where a.Instockid = '" + modelList[0].HeaderID + "'";
            //lstSql.Add(strSql);
            foreach (var item in modelList) 
            {
                strSql = "update t_Outstockdetail a set a.Postqty = '" + item.ScanQty + "',a.Postdate = sysdate,a.Poststatus = '" + item.LineStatus + "' where id = '" + item.ID + "'";
                lstSql.Add(strSql);
            }

            strSql = "delete FROM t_stock a  WHERE EXISTS" +
                    "( select * from (select a.Id from t_stock a left join t_Taskdetails b on a.Taskdetailesid = b.Id " +
                    "where b.Erpvoucherno = '" + modelList[0].ErpVoucherNo+ "') t where  a.Id = t.Id)";

            lstSql.Add(strSql);

            strSql = "insert into t_Stocktrans (id,Serialno,Materialno,Materialdesc,Warehouseid,Houseid,areaid,Qty,tmaterialno," +
                      "  pickareano,status,isdel,Creater,Createtime,Modifyer,Modifytime,Batchno,Oldstockid,Taskdetailesid," +
                      "  checkid,Transferdetailsid,Unit,receivestatus,Islimitstock,materialnoid,STRONGHOLDCODE,Strongholdname," +
                      "  COMPANYCODE,EDATE,BARCODE,EAN,HOUSEPROP) " +
                      "  select (Seq_Stocktrans_Id.Nextval),Serialno,Materialno,Materialdesc,Warehouseid,Houseid,areaid,Qty,tmaterialno," +
                      "  pickareano,status,isdel,Creater,Createtime,Modifyer,Modifytime,Batchno,Oldstockid,Taskdetailesid," +
                      "  checkid,Transferdetailsid,Unit,receivestatus,Islimitstock,materialnoid,STRONGHOLDCODE,Strongholdname," +
                      "  COMPANYCODE,EDATE,BARCODE,EAN,HOUSEPROP FROM t_stock a  WHERE EXISTS" +
                      "  ( select * from (select a.Id from t_stock a left join t_Taskdetails b on a.Taskdetailesid = b.Id " +
                      "  where b.Erpvoucherno = '" + modelList[0].ErpVoucherNo + "') t where  a.Id = t.Id)";
            lstSql.Add(strSql);


            strSql = "update t_Outstock a set a.Status = 5,Postdate = sysdate,Postuser = '"+user.UserName+"' where id = '" + modelList[0].HeaderID + "'";
            lstSql.Add(strSql);

            strSql = "update t_Pickcar a set taskno = ''" +
                    " where exists( select 1 from (select taskno from t_task a where a.Erpvoucherno = '" + modelList[0].ErpVoucherNo + "') b " +
                    " where a.Taskno=b.taskno)";
            //strSql = "update t_Pickcar a set taskno = '' where taskno in " +
            //        " (select taskno from t_task a where a.Erpvoucherno = '" + modelList[0].ErpVoucherNo + "')";
            lstSql.Add(strSql);

            return lstSql;
        }


        private string GetStockTransSql(UserModel user, T_StockInfo model)
        {
            string strSql = "INSERT INTO t_Stocktrans (Id, Barcode, Serialno, Materialno, Materialdesc, Warehouseid, Houseid, Areaid, Qty,  Status, Isdel, Creater, Createtime, " +
                             "Batchno, Sn,  Oldstockid, Taskdetailesid, Checkid, Transferdetailsid,  Unit, Unitname, Palletno, Receivestatus,  Islimitstock,  " +
                             "Materialnoid, Strongholdcode, Strongholdname, Companycode, Edate, Supcode, Supname, Productdate, Supprdbatch, Supprddate, Isquality)" +
                            "SELECT Seq_Stocktrans_Id.Nextval,A.Barcode,A.Serialno,A.Materialno,A.Materialdesc,A.Warehouseid,A.Houseid,A.Areaid,A.Qty, " +
                            "A.Status,A.Isdel,'" + user.UserName + "',A.Createtime,A.Batchno,A.Sn,A.Oldstockid,A.Taskdetailesid,A.Checkid,A.Transferdetailsid,A.Unit,A.Unitname,A.Palletno,A.Receivestatus," +
                            "A.Islimitstock,A.Materialnoid,A.Strongholdcode,A.Strongholdname,A.Companycode,A.Edate,A.Supcode,A.Supname,A.Productdate,A.Supprdbatch," +
                            "A.Supprddate,A.Isquality FROM T_STOCK A WHERE A.Serialno = '" + model.SerialNo + "'";
            return strSql;
        }

        private string GetStockPRDSql(UserModel user, T_StockInfo model)
        {
            string strSql = "INSERT INTO t_stockprd (Id, Barcode, Serialno, Materialno, Materialdesc, Warehouseid, Houseid, Areaid, Qty,  Status, Isdel, Creater, Createtime, " +
                             "Batchno, Sn,  Oldstockid, Taskdetailesid, Checkid, Transferdetailsid,  Unit, Unitname, Palletno, Receivestatus,  Islimitstock,  " +
                             "Materialnoid, Strongholdcode, Strongholdname, Companycode, Edate, Supcode, Supname, Productdate, Supprdbatch, Supprddate, Isquality)" +
                            "SELECT SEQ_STOCKPRD_ID.Nextval,A.Barcode,A.Serialno,A.Materialno,A.Materialdesc,A.Warehouseid,A.Houseid,A.Areaid,A.Qty, " +
                            "A.Status,A.Isdel,'" + user.UserName + "',A.Createtime,A.Batchno,A.Sn,A.Oldstockid,A.Taskdetailesid,A.Checkid,A.Transferdetailsid,A.Unit,A.Unitname,A.Palletno,A.Receivestatus," +
                            "A.Islimitstock,A.Materialnoid,A.Strongholdcode,A.Strongholdname,A.Companycode,A.Edate,A.Supcode,A.Supname,A.Productdate,A.Supprdbatch," +
                            "A.Supprddate,A.Isquality FROM T_STOCK A WHERE A.Serialno = '" + model.SerialNo + "'";
            return strSql;
        }

        private string GetTaskTransSql(UserModel user, T_StockInfo model, T_OutStockTaskDetailsInfo detailModel)
        {
            string strSql = string.Empty;
            
                strSql = "insert into t_tasktrans(Id, Serialno,towarehouseID,TohouseID, ToareaID, Materialno, Materialdesc, Supcuscode, " +
               "Supcusname, Qty, Tasktype, Vouchertype, Creater, Createtime,TaskdetailsId, Unit, Unitname,partno,materialnoid,erpvoucherno,voucherno," +
               "Strongholdcode,Strongholdname,Companycode,Productdate,Supprdbatch,Supprddate,Edate,taskno,status,batchno,barcode,houseprop,ean)" +
               " values (seq_tasktrans_id.Nextval,'" + model.SerialNo + "','" + model.WareHouseID + "','" + model.HouseID + "','" + model.AreaID + "'," +
               " '" + model.MaterialNo + "','" + model.MaterialDesc + "','" + detailModel.CustomerCode + "','" + detailModel.CustomerName + "','" + model.ScanQty + "','12'," +
               " (select vouchertype from t_outstock where id = '" + detailModel.HeaderID + "') ,'" + user.UserName + "',Sysdate,'" + model.TaskDetailesID + "', " +
               "'" + detailModel.Unit + "','" + detailModel.UnitName + "','" + detailModel.PartNo + "','" + detailModel.MaterialNoID + "','" + detailModel.ErpVoucherNo + "'," +
               "  '" + detailModel.VoucherNo + "','" + detailModel.StrongHoldCode + "','" + detailModel.StrongHoldName + "','" + detailModel.CompanyCode + "'," +
               "  to_date('" + model.ProductDate + "','yyyy-mm-dd hh24:mi:ss'),'" + model.SupPrdBatch + "',to_date('" + model.SupPrdDate + "','yyyy-mm-dd hh24:mi:ss'),to_date('" + model.EDate + "','yyyy-mm-dd hh24:mi:ss') ,'" + detailModel.TaskNo + "','" + model.Status + "','" + model.FromBatchNo + "','" + model.Barcode + "','" + model.HouseProp+ "','"+model.EAN+"') ";

            
            return strSql;
        }


        /// <summary>
        /// 保存复核扫描的数据
        /// </summary>
        /// <param name="user"></param>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public bool SaveReviewModelListSql(UserModel user, List<T_OutStockTaskDetailsInfo> modelList,ref string strError)
        {
            string strSql = string.Empty;
            List<string> lstSql = new List<string>();

            int iVoucherType = modelList[0].VoucherType;

            foreach (var item in modelList)
            {
                strSql = string.Format("update t_Outstockdetail a set a.Oldoutstockqty = nvl(a.Oldoutstockqty,0)+{0},a.reviewqty=nvl(a.reviewqty,0)+{0}," +
                        "a.Reviewuserno = '{1}',a.Reviewdate = sysdate where a.erpvoucherno='{2}' and a.materialnoid='{3}' and a.rowno = '"+item.RowNo+"' ", item.ScanQty, user.UserNo, item.ErpVoucherNo,item.MaterialNoID);
                lstSql.Add(strSql);


                strSql = string.Format("update t_Outstockdetail a set a.linestatus =(case when nvl(a.reviewqty,0)< nvl(a.Outstockqty,0) and nvl(a.reviewqty,0)<>0 then 3 when nvl(a.reviewqty,0)  = nvl(a.Outstockqty,0)  then 4 end )," +
                                        " Toerpareano ='{0}',Toerpwarehouse='{1}' where erpvoucherno='{2}' and materialnoid='{3}' and rowno = '{4}' ", item.ToErpAreaNo, item.ToErpWarehouse, item.ErpVoucherNo,item.MaterialNoID,item.RowNo);
                lstSql.Add(strSql);

                strSql = "update t_Taskdetails a set a.Reviewqty = nvl(a.Reviewqty,0) + '"+item.ScanQty+"',a.Reviewstatus = '"+item.ReviewStatus+"' ,a.Reviewdate = Sysdate,a.Reviewuser='"+user.UserNo+"' where id = '"+item.ID+"'";
                lstSql.Add(strSql);
                

                foreach (var itemStock in item.lstStockInfo)
                {
                    lstSql.Add(GetStockTransSql(user, itemStock));
                    lstSql.Add(GetTaskTransSql(user, itemStock, item));                    
                }
            }



            strSql = "update t_Outstock set status = 3 , Reviewuserno = '" + user.UserNo + "' where erpvoucherno = '" + modelList[0].ErpVoucherNo + "'";
            lstSql.Add(strSql);

            strSql = " update t_Outstock a set a.Status = 4 where " +
                      "a.erpvoucherno in(select b.erpvoucherno from t_Outstockdetail b  group by b.erpvoucherno having(max(nvl(linestatus,1)) = 4 and min(nvl(linestatus,1))=4) and b.erpvoucherno = '" + modelList[0].ErpVoucherNo + "')" +
                      "and erpvoucherno = '" + modelList[0].ErpVoucherNo + "'";

            lstSql.Add(strSql);

            strSql = "update t_task a set a.Reviewstatus = '" + modelList[0].ReviewStatus + "' where id = '" + modelList[0].HeaderID + "'";
            lstSql.Add(strSql);

            return base.SaveModelListBySqlToDB(lstSql, ref strError);            
        }


        public bool UpdateChangeMaterial(T_OutStockDetailInfo model,ref string strError) 
        {
            try
            {
                string strSql = string.Empty;
                List<string> lstSql = new List<string>();

                foreach (var item in model.lstStock) 
                {
                    strSql = "update t_stock a set a.MaterialChangeID = '" + item.MaterialChangeID + "' where a.Serialno = '"+item.SerialNo+"'";
                    lstSql.Add(strSql);
                }

                return base.UpdateModelListStatusBySql(lstSql,ref strError);
            }
            catch (Exception ex) 
            {
                strError = ex.Message;
                return false;
            }
        }

        public bool SaveT_ChangeMaterial(List<T_InStockDetailInfo> inStockList, List<T_OutStockDetailInfo> modelList, ref string strError) 
        {
            try
            {
                string strSql = string.Empty;
                List<string> lstSql = new List<string>();

                strSql = "update t_Instockdetail a set a.Linestatus = 3 where a.Headerid = '"+inStockList[0].HeaderID+"'";
                lstSql.Add(strSql);

                strSql = "update t_Instock a set a.Status = 3 where id = '" + inStockList[0].HeaderID + "'";
                lstSql.Add(strSql);

                strSql = "update t_Outstockdetail a set a.Linestatus = 3 where a.Headerid = '" + modelList[0].HeaderID + "'";
                lstSql.Add(strSql);

                strSql = "update t_Outstock a set a.Status = 3 where id = '" + modelList[0].HeaderID + "'";
                lstSql.Add(strSql);

                foreach (var item in modelList)
                {
                    foreach (var itemSerial in item.lstStock)
                    {
                        strSql = "update t_stock a set a.Strongholdcode = '" + inStockList[0].StrongHoldCode + "', a.Strongholdname = '" + inStockList[0].StrongHoldName + "',a.Materialchangeid = 0 where serialno = '" + itemSerial.SerialNo + "'";
                        lstSql.Add(strSql);

                        strSql = "update t_stock a set a.Materialnoid = (select max(id) from t_Material where materialno = '" + item.MaterialNo + "' and strongholdcode = '" + inStockList[0].StrongHoldCode + "') " +
                                " where a.Serialno = '" + itemSerial.SerialNo+ "'";
                        lstSql.Add(strSql);

                        strSql = "update t_Outbarcode a set a.Strongholdcode = '" + inStockList[0].StrongHoldCode + "',a.Strongholdname = '" + inStockList[0].StrongHoldName + "' where a.Serialno = '" + itemSerial.SerialNo + "'";
                        lstSql.Add(strSql);

                        strSql = "update t_Outbarcode a set a.Materialnoid = (select max(id) from t_Material where materialno = '" + item.MaterialNo + "' and strongholdcode = '" + inStockList[0].StrongHoldCode + "') " +
                                " where a.Serialno = '" + itemSerial.SerialNo + "'";
                        lstSql.Add(strSql);

                    }
                }

                return base.UpdateModelListStatusBySql(lstSql, ref strError);
            }
            catch (Exception ex) 
            {
                strError = ex.Message;
                return false;
            }
            
        }

        public string GetFHPalletNo(string strSerialNo)
        {
            string strSql = "select palletno from t_Palletdetail  where serialno = '" + strSerialNo + "' and nvl(pallettype,1) =2";
            return base.GetScalarBySql(strSql).ToDBString();
        }

        public string ScanOutStockReviewByCarNo(string CarNo) 
        {
            string strSql = "select b.Erpinvoucherno from t_Pickcar a left join t_task b on a.Taskno = b.Taskno where a.Carno='" + CarNo + "'";
            return base.GetScalarBySql(strSql).ToDBString();

        }

        public List<T_OutStockDetailInfo> GetModelListByHeaderIDForCar(int HeaderID)
        {
            return base.GetModelListByHeaderID(HeaderID);
        }

        #region PC复核页面打印装箱

        /// <summary>
        /// PC复核页面打印装箱
        /// </summary>
        /// <param name="ErpVoucherNo"></param>
        /// <param name="user"></param>
        /// <param name="strError"></param>
        /// <returns></returns>
        public List<T_PalletDetailInfo> CreatePalletByTaskTrans(string ErpVoucherNo, UserModel user)
        {
            try
            {
                List<T_PalletDetailInfo> modelList = new List<T_PalletDetailInfo>();
                string strSql = "select a.palletno,a.id,a.Erpvoucherno,a.Materialno,a.Materialnoid,a.Materialdesc,a.Ean,a.Qty,a.Strongholdcode,a.Strongholdname,a.Companycode,a.houseprop,a.Supcuscode,a.Supcusname from t_Tasktrans a where a.Erpvoucherno = '" + ErpVoucherNo + "'  and a.Creater='" + user.UserName + "' and a.Tasktype = 12";
                using (OracleDataReader dr = OracleDBHelper.ExecuteReader(strSql))
                {
                    while (dr.Read())
                    {
                        T_PalletDetailInfo model = new T_PalletDetailInfo();
                        model.ID = Convert.ToInt32(dr["id"]);
                        model.ErpVoucherNo = dr["Erpvoucherno"].ToString();
                        model.MaterialNo = dr["Materialno"].ToString();
                        model.MaterialNoID = dr["MaterialNoID"].ToInt32();
                        model.MaterialDesc = dr["MaterialDesc"].ToDBString();
                        model.EAN = dr["EAN"].ToDBString();
                        model.Qty = dr["Qty"].ToDecimal();
                        model.StrongHoldCode = dr["StrongHoldCode"].ToDBString();
                        model.StrongHoldName = dr["StrongHoldName"].ToDBString();
                        model.CompanyCode = dr["CompanyCode"].ToDBString();
                        model.HouseProp = dr["HouseProp"].ToInt32();
                        model.SuppliernNo = dr["Supcuscode"].ToDBString();
                        model.SupplierName = dr["Supcusname"].ToDBString();
                        model.PalletNo = dr["PalletNo"].ToDBString();

                        modelList.Add(model);
                    }
                }

                return modelList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 验证批次条码是否已经复核扫描

        public int CheckBarCodeIsReview(string strSerialNo) 
        {
            try
            {
                string strSql = "select count(1) from t_Tasktrans where serialno = '" + strSerialNo + "' AND tasktype = '12'";
                return base.GetScalarBySql(strSql).ToInt32();

            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
        #endregion

        #region 根据ERP订单号获取到的拣货明细构造出库表明细

        public List<T_OutStockDetailInfo> CreateOutStockDetailByTaskDetail(List<T_OutStockTaskDetailsInfo> modelList) 
        {
            List<T_OutStockDetailInfo> outStockDetailList = new List<T_OutStockDetailInfo>();
            foreach (var item in modelList) 
            {
                T_OutStockDetailInfo model = new T_OutStockDetailInfo();
                model.ID = item.ID;
                model.HeaderID = item.HeaderID;
                model.VoucherType = item.VoucherType;
                model.ErpVoucherNo = item.ErpVoucherNo;
                model.MaterialNo = item.MaterialNo;
                model.MaterialDesc = item.MaterialDesc;
                model.TaskQty = item.TaskQty.ToDecimal();
                model.OutStockQty = item.TaskQty.ToDecimal();
                model.StrLineStatus = item.StrLineStatus;
                model.HeaderID = item.HeaderID;
                model.TaskNo = item.TaskNo;
                model.VoucherNo = item.VoucherNo;
                model.RowNo = item.RowNo;
                model.UnShelveQty = item.UnShelveQty.ToDecimal();
                model.MaterialNoID = item.MaterialNoID;
                model.StrongHoldCode = item.StrongHoldCode;
                model.StrongHoldName = item.StrongHoldName;
                model.CompanyCode = item.CompanyCode;
                model.FromErpWarehouse = item.FromErpWarehouse;
                model.ReviewQty = item.ReviewQty.ToDecimal();
                model.ReviewStatus = item.ReviewStatus;
                model.ReviewUser = item.ReviewUser;
                model.ReviewDate = item.ReviewDate;
                model.CustomerCode = item.CustomerCode;
                model.CustomerName = item.CustomerName;
                model.Unit = item.Unit;
                model.RowNo = item.RowNo;
                model.HouseProp = item.HouseProp;
                model.StrHouseProp = item.StrHouseProp;
                model.UnReviewQty = item.UnReviewQty;
                model.PickQty = item.UnShelveQty.ToDecimal();

                outStockDetailList.Add(model);
            }
            return outStockDetailList;
        }

        #endregion

        
    }
}
