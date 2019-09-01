//************************************************************
//******************************作者：方颖*********************
//******************************时间：2017/6/27 11:36:53*******

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
using BILWeb.Stock;

namespace BILWeb.Quality
{
    public partial class T_QualityDetail_DB : BILBasic.Basing.Base_DB<T_QualityDetailInfo>
    {

        /// <summary>
        /// 添加t_qualitydetail
        /// </summary>
        protected override OracleParameter[] GetSaveModelOracleParameter(T_QualityDetailInfo t_qualitydetail)
        {
            //注意!head表ID要填basemodel的headerID new SqlParameter("@CustomerID", DbHelperSQL.ToDBValue(model.HeaderID)),
            throw new NotImplementedException();
        }

        protected override List<string> GetSaveSql(BILBasic.User.UserModel user, ref T_QualityDetailInfo model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        protected override T_QualityDetailInfo ToModel(OracleDataReader reader)
        {
            T_QualityDetailInfo t_qualitydetail = new T_QualityDetailInfo();

            t_qualitydetail.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();
            t_qualitydetail.ErpInVoucherNo = (string)OracleDBHelper.ToModelValue(reader, "ERPVOUCHERNO");
            t_qualitydetail.StrongHoldCode = (string)OracleDBHelper.ToModelValue(reader, "STRONGHOLDCODE");
            t_qualitydetail.StrongHoldName = (string)OracleDBHelper.ToModelValue(reader, "STRONGHOLDNAME");
            t_qualitydetail.CompanyCode = (string)OracleDBHelper.ToModelValue(reader, "COMPANYCODE");
            t_qualitydetail.ERPCreater = (string)OracleDBHelper.ToModelValue(reader, "ERPCREATER");
            t_qualitydetail.VouDate = (DateTime?)OracleDBHelper.ToModelValue(reader, "VOUDATE");
            t_qualitydetail.VouUser = (string)OracleDBHelper.ToModelValue(reader, "VOUUSER");
            t_qualitydetail.ERPStatus = OracleDBHelper.ToModelValue(reader, "ERPSTATUS").ToDBString();
            t_qualitydetail.ERPNote = (string)OracleDBHelper.ToModelValue(reader, "ERPNOTE");
            t_qualitydetail.CreateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CREATETIME");
            t_qualitydetail.Creater = (string)OracleDBHelper.ToModelValue(reader, "CREATER");
            t_qualitydetail.Modifyer = (string)OracleDBHelper.ToModelValue(reader, "MODIFYER");
            t_qualitydetail.ModifyTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "MODIFYTIME");
            t_qualitydetail.Status = OracleDBHelper.ToModelValue(reader, "STATUS").ToInt32();
            t_qualitydetail.TimeStamp = (DateTime?)OracleDBHelper.ToModelValue(reader, "TIMESTAMP");
            t_qualitydetail.IsDel = OracleDBHelper.ToModelValue(reader, "ISDEL").ToInt32();
            
            t_qualitydetail.NoticeStatus = OracleDBHelper.ToModelValue(reader, "NOTICESTATUS").ToInt32();
            t_qualitydetail.QualityType = OracleDBHelper.ToModelValue(reader, "QUALITYTYPE").ToInt32();
            t_qualitydetail.MaterialNo = (string)OracleDBHelper.ToModelValue(reader, "MATERIALNO");
            t_qualitydetail.MaterialDesc = (string)OracleDBHelper.ToModelValue(reader, "MATERIALDESC");
            t_qualitydetail.InSQty = (decimal?)OracleDBHelper.ToModelValue(reader, "INSQTY");
            t_qualitydetail.Unit = (string)OracleDBHelper.ToModelValue(reader, "UNIT");
            t_qualitydetail.UnitName = (string)OracleDBHelper.ToModelValue(reader, "UNITNAME");
            t_qualitydetail.QuanQty = (decimal?)OracleDBHelper.ToModelValue(reader, "QUANQTY");
            t_qualitydetail.UnQuanQty = (decimal?)OracleDBHelper.ToModelValue(reader, "UNQUANQTY");
            t_qualitydetail.DesQty = (decimal?)OracleDBHelper.ToModelValue(reader, "DESQTY");
            t_qualitydetail.WarehouseNo = (string)OracleDBHelper.ToModelValue(reader, "WAREHOUSENO");
            t_qualitydetail.BatchNo = (string)OracleDBHelper.ToModelValue(reader, "BATCHNO");
            t_qualitydetail.ErpVoucherNo = (string)OracleDBHelper.ToModelValue(reader, "ErpVoucherNo");           
            t_qualitydetail.ErpInVoucherNo = (string)OracleDBHelper.ToModelValue(reader, "ErpInVoucherNo");
            t_qualitydetail.SampQty = (decimal)OracleDBHelper.ToModelValue(reader, "SampQty");
            t_qualitydetail.RemainQty = (decimal?)OracleDBHelper.ToModelValue(reader, "RemainQty");
            t_qualitydetail.MaterialNoID = OracleDBHelper.ToModelValue(reader, "MaterialNoID").ToInt32();

            if (Common_Func.readerExists(reader, "Areano")) t_qualitydetail.AreaNo = (string)OracleDBHelper.ToModelValue(reader, "Areano");
            if (Common_Func.readerExists(reader, "AreaType")) t_qualitydetail.AreaType = reader["AreaType"].ToInt32();

            return t_qualitydetail;

        }

        /// <summary>
        /// 获取取样保存SQL
        /// </summary>
        /// <param name="user"></param>
        /// <param name="modelList"></param>
        /// <returns></returns>
        protected override List<string> GetSaveModelListSql(UserModel user, List<T_QualityDetailInfo> modelList)
        {         
            string strSql = string.Empty;
            List<string> lstSql = new List<string>();
            string NewSerialno = string.Empty;

            foreach (var item in modelList)
            {
                //strSql = "update t_Quality a set a.remainqty = (case when (nvl(a.remainqty,0) - '" + item.ScanQty + "') <= 0 then 0 else nvl(a.remainqty,0) - '" + item.ScanQty + "' end)," +
                //        "a.Scanqty = (nvl(a.Receiveqty,0) + '" + item.ScanQty + "') ," +
                //        "a.Scanuserno = '" + user.UserNo + "',a.Scandate = Sysdate where id = '" + item.ID + "'";
                //lstSql.Add(strSql);

                strSql = "update t_Quality a set a.Status = (case when '" + item.ScanQty + "' < nvl(a.Sampqty,0) and nvl(a.Sampqty,0)<>0 then 2" +
                        " when  '" + item.ScanQty + "' = nvl(a.Sampqty,0) and nvl(a.Sampqty,0)<>0 then 3 end ),a.Scanuserno = '" + user.UserNo + "',a.Scandate = Sysdate, a.Scanqty =  '" + item.ScanQty + "',a.Remainqty = a.Sampqty - '"+item.ScanQty+"'  where id = '" + item.ID + "'";
                lstSql.Add(strSql);

                strSql = "update t_Taskdetails b set b.Remainqty = b.Remainqty - '"+item.ScanQty+"' where b.Id =  "+
                        "(select b.id from t_task a left join t_Taskdetails b on a.Id =b.Headerid "+
                        "where a.Erpinvoucherno = '"+item.ErpInVoucherNo+"' and b.Materialnoid = '"+item.MaterialNoID+"'"+
                        "and b.Batchno = '"+item.BatchNo+"')";

                lstSql.Add(strSql);

                strSql = "update t_stock a set a.Status = 2 where a.Materialnoid = '" + item.MaterialNoID + "' and a.Batchno = '" + item.BatchNo + "' and a.Strongholdcode = '" + item.StrongHoldCode + "' and a.Warehouseid = (select id from t_Warehouse where warehouseno = '" + item.WarehouseNo + "') and a.Areaid in ( select id from v_Area  a where a.warehouseno = '" + item.WarehouseNo + "' and a.AREANO in " +
                        " (select areano from t_Qualitydetail where headerid = '"+item.ID+"'))";
                lstSql.Add(strSql);

                foreach (var stockItem in item.lstStock)
                {
                    strSql = "update t_stock a set a.Warehouseid = (select warehouseid from v_Area where areano = '" + item.ToErpAreaNo + "' and warehouseno = '" + item.ToErpWarehouse + "')," +
                                " a.Houseid = (select houseid from v_Area where areano = '" + item.ToErpAreaNo + "' and warehouseno = '" + item.ToErpWarehouse + "'),a.Areaid  = (select id from v_Area where areano = '" + item.ToErpAreaNo + "' and warehouseno = '" + item.ToErpWarehouse + "')" +
                                " ,a.Palletno = '' where serialno = '" + stockItem.SerialNo + "'";
                    lstSql.Add(strSql);

                    strSql = "DELETE t_Palletdetail WHERE SERIALNO = '" + stockItem.SerialNo + "'";
                    lstSql.Add(strSql);

                    strSql = "delete t_Pallet where palletno =( select a.Palletno from t_Palletdetail a  where serialno = '" + stockItem.SerialNo + "' )  and (select count(1) from t_Palletdetail where palletno =( select a.Palletno from t_Palletdetail a  where serialno = '" + stockItem.SerialNo + "') )=0";
                    lstSql.Add(strSql);

                    //if (stockItem.PickModel == 2) //整箱取样
                    //{
                    //    //查找取样库，更新库存仓库ID
                    //    strSql = "update t_stock a set a.Warehouseid = (select warehouseid from v_Area where areano = '" + item.ToErpAreaNo+ "')," +
                    //            " a.Houseid = (select houseid from v_Area where areano = '" + item.ToErpAreaNo + "'),a.Areaid  = (select id from v_Area where areano = '" + item.ToErpAreaNo + "')" +
                    //            " where serialno = '"+stockItem.SerialNo+"'";
                    //    lstSql.Add(strSql);
                    //}
                    //else if (stockItem.PickModel == 3)//拆零取样
                    //{
                    //    //strSql = GetAmountQtySql(stockItem, ref NewSerialno);//生成条码表拆零条码
                    //    //lstSql.Add(strSql);

                    //    //strSql = GetAmountQtyInsertStockSql(stockItem, user, NewSerialno);
                    //    //lstSql.Add(strSql);

                    //    //strSql = "update t_stock a set a.Qty = a.Qty - '" + stockItem.AmountQty + "'  where serialno = '" + stockItem.SerialNo + "'";
                    //    //lstSql.Add(strSql);

                    //    //strSql = "delete t_stock where serialno = '" + stockItem.SerialNo + "' and qty =0";
                    //    //lstSql.Add(strSql);
                    //    strSql = "update t_stock a set a.Warehouseid = (select warehouseid from v_Area where areano = '" + item.ToErpAreaNo + "')," +
                    //            " a.Houseid = (select houseid from v_Area where areano = '" + item.ToErpAreaNo + "'),a.Areaid  = (select id from v_Area where areano = '" + item.ToErpAreaNo + "')" +
                    //            " where serialno = '" + stockItem.SerialNo + "'";
                    //    lstSql.Add(strSql);

                    //    if (!string.IsNullOrEmpty(stockItem.PalletNo))
                    //    {
                    //        strSql = GetAmountQtyInsertPalletSql(stockItem, user, NewSerialno, stockItem.PalletNo);
                    //        lstSql.Add(strSql);

                    //        strSql = "update t_Palletdetail a set a.Qty = a.qty - '" + stockItem.AmountQty + "' where serialno = '" + stockItem.SerialNo + "'";
                    //        lstSql.Add(strSql);

                    //        strSql = "delete t_Palletdetail a where a.Serialno = '" + stockItem.AmountQty + "' and a.Qty = 0";
                    //        lstSql.Add(strSql);
                    //    }
                    //}
                }
            }

            return lstSql;
        }


        public  string GetAmountQtySql(T_StockInfo model, ref string NewSerialNo)
        {
            int barcodeID = GetTableID("Seq_Outbarcode_Id");

            string SeqSerialNo = base.GetTableID("SEQ_SERIAL_NO").ToString();

            NewSerialNo = System.DateTime.Now.ToString("yyyyMMdd") + SeqSerialNo.PadLeft(6, '0');

            string strSql = "insert into t_Outbarcode (Id, Voucherno, Rowno, Erpvoucherno, Vouchertype, Materialno, Materialdesc, Cuscode," +
                            "Cusname, Supcode, Supname, Outpackqty, Innerpackqty, Voucherqty, Qty, Nopack, Printqty, Barcode, " +
                            "Barcodetype, Serialno, Barcodeno, Outcount, Innercount, Mantissaqty, Isrohs, Outbox_Id, " +
                            "Inner_Id, Abatchqty, Isdel, Creater, Createtime, Materialnoid, Strongholdcode, " +
                            "Strongholdname, Companycode, Productdate, Supprdbatch, Supprddate, Productbatch, Edate, Storecondition," +
                            "Specialrequire, Batchno, Barcodemtype, Rownodel, Protectway, Boxweight, Unit, Labelmark, Boxdetail, Matebatch," +
                            "Mixdate, Relaweight,Ean)" +
                            "select '" + barcodeID + "',voucherno,rowno,erpvoucherno,vouchertype, Materialno, Materialdesc, Cuscode," +
                            "Cusname, Supcode, Supname, Outpackqty, Innerpackqty, Voucherqty, '" + model.AmountQty + "',Nopack, Printqty," +
                            "Barcodetype || '@' || Strongholdcode || '@' || materialno || '@' || ean || '@' || to_char(edate,'yyyy-MM-dd') || '@' || '"+model.BatchNo+"'  || '@' || '" + model.AmountQty.ToInt32() + "' || '@' || '" + NewSerialNo + "'," +
                            "Barcodetype, '" + NewSerialNo + "', Barcodeno, Outcount, Innercount, Mantissaqty, Isrohs,'" + model.ID+ "',Inner_Id, " +
                            "Abatchqty, Isdel, Creater, sysdate, Materialnoid, Strongholdcode, " +
                            "Strongholdname, Companycode, Productdate, Supprdbatch, Supprddate, Productbatch, Edate, Storecondition," +
                            "Specialrequire, Batchno, Barcodemtype, Rownodel, Protectway, Boxweight, Unit, Labelmark, Boxdetail, Matebatch," +
                            "Mixdate, Relaweight,ean from t_Outbarcode where serialno = '" + model.SerialNo + "'";
            return strSql;

        }

        public  string GetAmountQtyInsertStockSql(T_StockInfo model, UserModel user, string NewSerialNo)
        {
            int stockID = 0;
            string strSql = string.Empty;

            //整箱区拣货直接插入库存
            if (model.HouseProp == 1)
            {
                stockID = GetTableID("Seq_Stock_Id");

                strSql = "insert into t_Stock(Id, Barcode, Serialno, Materialno, Materialdesc, Warehouseid, Houseid, Areaid, Qty, Status, Isdel," +
                                "Creater, Createtime, Batchno,  Oldstockid, Unit, Unitname,  " +
                                "Receivestatus,  Islimitstock,  Materialnoid, Strongholdcode, Strongholdname, Companycode," +
                                "Edate, Supcode, Supname, Productdate, Supprdbatch, Supprddate, Isquality,Stocktype,ean)" +
                                "select '" + stockID + "',barcode,serialno,materialno,Materialdesc,'" + model.WareHouseID + "', '" + model.HouseID + "', '" + model.AreaID + "', Qty ,'" + model.Status + "','1'," +
                                "'" + user.UserNo + "',Sysdate,batchno,'" + model.ID + "',unit,'" + model.UnitName + "','" + model.ReceiveStatus + "','" + model.IsLimitStock + "',Materialnoid," +
                                "Strongholdcode, Strongholdname, Companycode,Edate, Supcode, Supname, Productdate, Supprdbatch,Supprddate, '3',1,ean from t_Outbarcode where serialno = '" + NewSerialNo + "'";

            }
            else if(model.HouseProp==2)
            {
                //如果是零拣区需要根据拣货ID+69码+物料编码查看是否已经拣货
                string strSql1 = "select count(1) from t_stock a where a.Taskdetailesid='" + model.TaskDetailesID.ToInt32() + "' and a.Materialnoid='" + model.MaterialNoID + "' and a.Ean='" + model.EAN + "' and a.batchno = '" + model.BatchNo + "' and a.Strongholdcode='" + model.StrongHoldCode + "' and  a.HouseProp='" + model.HouseProp + "' and a.edate =to_date( '" + model.StrEDate + "','yyyy/MM/dd')";
                int count = base.GetScalarBySql(strSql1).ToInt32();
                if (count == 0)
                {
                    stockID = GetTableID("Seq_Stock_Id");

                    strSql = "insert into t_Stock(Id, Barcode, Serialno, Materialno, Materialdesc, Warehouseid, Houseid, Areaid, Qty, Status, Isdel," +
                                    "Creater, Createtime, Batchno,  Oldstockid, Unit, Unitname,  " +
                                    "Receivestatus,  Islimitstock,  Materialnoid, Strongholdcode, Strongholdname, Companycode," +
                                    "Edate, Supcode, Supname, Productdate, Supprdbatch, Supprddate, Isquality,Stocktype,Taskdetailesid,houseprop,ean)" +
                                    "select '" + stockID + "',barcode,serialno,materialno,Materialdesc,'" + model.WareHouseID + "', '" + model.HouseID + "', '" + model.AreaID + "', Qty ,'" + model.Status + "','1'," +
                                    "'" + user.UserNo + "',Sysdate,batchno,'" + model.ID + "',unit,'" + model.UnitName + "','" + model.ReceiveStatus + "','" + model.IsLimitStock + "',Materialnoid," +
                                    "Strongholdcode, Strongholdname, Companycode,Edate, Supcode, Supname, Productdate, Supprdbatch,Supprddate, '" + model.IsQuality + "',1,'"+model.TaskDetailesID+"','"+model.HouseProp+"',ean from t_Outbarcode where serialno = '" + NewSerialNo + "'";

                }
                else 
                {
                    strSql = "update t_Stock set qty = qty + '" + model.AmountQty + "',serialno = '" + NewSerialNo + "' ,barcode = (select barcode from t_Outbarcode where serialno = '" + NewSerialNo + "') where Taskdetailesid='" + model.TaskDetailesID + "' and Materialnoid='" + model.MaterialNoID + "' and Ean='" + model.EAN + "' and batchno = '" + model.BatchNo + "' and Strongholdcode='" + model.StrongHoldCode + "' and HouseProp='" + model.HouseProp + "' and edate = to_date( '" + model.StrEDate + "','yyyy/MM/dd')";
                }
            }
            
            return strSql;
        }

        public string GetAmountQtyInsertPalletSql(T_StockInfo model, UserModel user, string NewSerialNo,string PalletNo)
        {
            int palletDetailID = GetTableID("Seq_Pallet_Detail_Id");

            string strSql = "insert into t_Palletdetail(Id, Headerid, Palletno, Materialno, Materialdesc, Serialno, Creater, Createtime, " +
                            "Isdel, Rowno, Voucherno, Erpvoucherno, Partno, Materialnoid, Qty, Barcode, Strongholdcode, " +
                            "Strongholdname, Companycode, Batchno,  Rownodel)" +
                            "select '" + palletDetailID + "',(select id from t_Pallet where palletno = '" + PalletNo + "'),'" + PalletNo + "',Materialno, Materialdesc, Serialno,'" + user.UserNo + "', Sysdate," +
                            "'1',Rowno, Voucherno, Erpvoucherno, '" + model.PalletNo + "', Materialnoid, Qty, Barcode, Strongholdcode, " +
                            "Strongholdname, Companycode, Batchno,  Rownodel from t_Outbarcode where serialno = '" + NewSerialNo + "'";

            return strSql;
        }

        protected override string GetViewName()
        {
            return "v_Quanitydetail";
        }

        protected override string GetTableName()
        {
            return "T_QUALITYDETAIL";
        }

        protected override string GetSaveProcedureName()
        {
            return "";
        }

        protected override string GetHeaderIDFieldName()
        {
            return "ID";
        }

        //根据检验单号获取已经审核并且没有更新过库存的单子
        public List<T_QualityDetailInfo> GetQualityUpadteStock(string ErpVoucherNo) 
        {
            string strSql = "select a.*,b.Areano,(select v_area.AREATYPE from v_area where v_area.warehouseno = a.Warehouseno and v_area.AREANO = b.Areano) as AREATYPE from t_Quality a left join " +
                             "t_Qualitydetail b"+
                            " on a.Id  = b.Headerid where a.Erpstatuscode = 'Y' and "+
                            "nvl(a.Isupdatestock,1) = 1 and a.Erpvoucherno = '" + ErpVoucherNo + "'";
            return base.GetModelListBySql(strSql);
        }

    }
}
