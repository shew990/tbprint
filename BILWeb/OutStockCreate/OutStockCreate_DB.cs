using BILBasic.DBA;
using BILBasic.User;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILBasic.Common;
using BILWeb.PickRule;
using BILWeb.Stock;
using BILBasic.XMLUtil;
using System.Data;
using BILWeb.Material;

namespace BILWeb.OutStockCreate
{
    public partial class T_OutStockCreate_DB : BILBasic.Basing.Base_DB<T_OutStockCreateInfo>
    {

        T_Material_DB mdb = new T_Material_DB();
        /// <summary>
        /// 添加t_outstockdetails
        /// </summary>
        protected override OracleParameter[] GetSaveModelOracleParameter(T_OutStockCreateInfo t_outstockdetails)
        {
            //注意!head表ID要填basemodel的headerID new SqlParameter("@CustomerID", DbHelperSQL.ToDBValue(model.HeaderID)),
            throw new NotImplementedException();


        }

        protected override List<string> GetSaveSql(UserModel user, ref  T_OutStockCreateInfo model)
        {
            throw new NotImplementedException();
        }

        protected override List<string> GetSaveModelListSql(UserModel user, List<T_OutStockCreateInfo> modelList)
        {
            //RuleAll.t_RuleAll_DB ruleDB = new RuleAll.t_RuleAll_DB();
            //List<RuleAll.T_RuleAllInfo> ruleList = ruleDB.GetRuleListByPage(4);

            //if (ruleList[0].IsEnable == 1)//不启用拣货分配规则 
            //{
            //    GetDisPickRuleModelList(modelList);//得到需要生单的数据
            //}
            //else if (ruleList[0].IsEnable == 2)//启用拣货分配规则 
            //{
            //    return CreateOutStockTask(user, modelList);//得到需要生单的数据
            //}

            return CreateOutStockTask(user, modelList);

            

            #region 注释公司代码
            //string strSql = string.Empty;
            //int voucherID = 0;

            //string VoucherNoID = string.Empty;
            //string VoucherNo = string.Empty;
            //List<string> lstSql = new List<string>();

            //var groupByList = from t in modelList.Where(t => t.OKSelect == true)
            //                  group t by new { t1 = t.VoucherNo } into m
            //                  select new
            //                  {
            //                      VoucherNo = m.Key.t1,
            //                  };

            //foreach (var item in groupByList)
            //{
            //    voucherID = base.GetTableID("SEQ_TASK_ID");

            //    VoucherNoID = base.GetTableID("SEQ_TASK_NO").ToString();

            //    VoucherNo = "D" + System.DateTime.Now.ToString("yyyyMMdd") + VoucherNoID.PadLeft(4, '0');

            //    strSql = string.Format("insert into t_task (Id, Vouchertype, Tasktype, Taskno, Status,   Taskissued,  Createtime,   Creater,  Instockid, Erpvoucherno,  Plant, Plantname,  Taskissueduser,voucherno,supcuscode,supcusname,movetype,erpdocno)" +
            //             " select '{0}',a.Vouchertype,'2','{1}','1', Sysdate,Sysdate,'{2}',a.Id,a.Erpvoucherno,a.Plant,a.Plantname,'{3}',a.voucherno,a.customercode,a.customername,a.movetype,a.erpdocno  from t_Outstock a where a.VoucherNo = '{4}'",
            //             voucherID, VoucherNo, user.UserNo, user.UserNo, item.VoucherNo);

            //    lstSql.Add(strSql);

            //    strSql = string.Format("insert into t_Taskdetails (Id,  Materialno, Materialdesc, Taskqty,  Remainqty,  Linestatus,  HEADERID,  Rowno, Createtime,  Unit  ,  Wbselem , Unitname,  Creater, Salename,SaleCode,erpvoucherno,materialnoid,voucherno,erpdocno)" +
            //        "select SEQ_TASKDETAIL_ID.Nextval,a.Materialno,a.Materialdesc,a.Outstockqty,a.Outstockqty,'1',(select id from t_task where voucherno = '{0}'),a.Rowno,Sysdate,a.Unit,a.Wbselem,a.Unitname," +
            //        "'{1}' ,a.salename,a.salecode,a.erpvoucherno,(select id from t_material where t_Material.partno = a.partno),'{3}',a.erpdocno from t_Outstockdetail a where a.voucherno = '{2}'", item.VoucherNo, user.UserNo, item.VoucherNo, item.VoucherNo);


            //    lstSql.Add(strSql);

            //    strSql = "update t_Outstockdetail a set a.Materialnoid = (select id from t_material where t_material.partno = a.partno) where a.Voucherno = '" + item.VoucherNo + "'";
            //    lstSql.Add(strSql);

            //    strSql = string.Format("update t_Outstock a set a.Status = 2 where a.voucherno = '{0}'", item.VoucherNo);
            //    lstSql.Add(strSql);

            //}

            //return lstSql;
            #endregion
           
        }

        #region 创建拣货单

        private List<string> CreateOutStockTask(UserModel user, List<T_OutStockCreateInfo> modelList) 
        {
            string strSql = string.Empty;
            int voucherID = 0;
            int voucherDetailID=0;

            string VoucherNoID = string.Empty;
            string VoucherNo = string.Empty;
            List<string> lstSql = new List<string>();

            

            foreach (var item in modelList) 
            {

                voucherID = base.GetTableID("SEQ_TASK_ID");

                VoucherNoID = base.GetTableID("SEQ_TASK_NO").ToString();

                VoucherNo = "D" + System.DateTime.Now.ToString("yyyyMMdd") + VoucherNoID.PadLeft(4, '0');

                strSql = "insert into t_task (Id, Vouchertype, Tasktype, Taskno, Status,Taskissued, Createtime,Creater," +
                    " Instockid, Erpvoucherno, Taskissueduser,voucherno,supcuscode,supcusname," +
                    " Strongholdcode,Strongholdname,Companycode,Departmentcode,Departmentname,ErpStatus,Voudate,Vouuser,isdel,warehouseid,erpvouchertype,IssueType,HOUSEPROP,"+
                    " SHIPNFLG,SHIPDFLG,SHIPPFLG,SHIPWFLG,TRADINGCONDITIONS,PROVINCE,CITY,AREA,CONTACT,PHONE,ADDRESS,ADDRESS1)" +
                    " values ('" + voucherID + "','" + item.VoucherType + "','2','" + VoucherNo + "','1',Sysdate,Sysdate,'" + user.UserNo + "'," +
                    " '"+item.HeaderID+"','"+item.ErpVoucherNo+"','"+user.UserNo+"','"+item.VoucherNo+"','"+item.CustomerCode+"','"+item.CustomerName+"',"+
                    " '"+item.StrongHoldCode+"','"+item.StrongHoldName+"','"+item.CompanyCode+"','"+item.DepartmentCode+"','"+item.DepartmentName+"','"+item.ERPStatus+"',"+
                    " '"+item.VouDate+"','"+item.VouUser+"','1','','"+item.ERPVoucherType+"','','"+item.HouseProp+"',"+
                    " '" + item.ShipNFlg + "','" + item.ShipDFlg + "','" + item.ShipPFlg + "','" + item.ShipWFlg + "','" + item.TradingConditions + "',"+
                    " '" + item.Province + "','" + item.City + "','" + item.Area + "','" + item.Contact + "','" + item.Phone + "','" + item.Address + "','"+item.Address1+"')";
                    

                lstSql.Add(strSql);

                foreach (var itemDetail in item.lstOutStockCreateInfo) 
                {
                    voucherDetailID = base.GetTableID("SEQ_TASKDETAIL_ID");

                    strSql = "insert into t_Taskdetails (Id,Materialno,Materialdesc,Taskqty,Remainqty,Linestatus,HEADERID, " +
                    "Rowno, Createtime,Unit,Unitname,  Creater,erpvoucherno,materialnoid,voucherno," +
                    " Strongholdcode,Strongholdname,Companycode ,Rownodel,Outstockqty,isdel," +
                    "ISSPCBATCH,FROMBATCHNO,Fromerpareano,Fromerpwarehouse,Tobatchno,Toerpareano,Toerpwarehouse,Outstockdetailid,productno)" +
                    " values( '" + voucherDetailID + "','" + itemDetail.MaterialNo + "','"+itemDetail.MaterialDesc+"','" + itemDetail.OutStockQty + "','" + itemDetail.OutStockQty + "','1','" + voucherID + "', " +
                    " '" + itemDetail.RowNo + "',sysdate,'" + itemDetail.Unit + "','"+itemDetail.Unitname+"','" + user.UserNo + "','" + itemDetail.ErpVoucherNo + "','" + itemDetail.MaterialNoID+ "','"+VoucherNo+"',"+
                    " '"+itemDetail.StrongHoldCode+"','"+itemDetail.StrongHoldName+"','"+itemDetail.CompanyCode+"','"+itemDetail.RowNoDel+"','"+itemDetail.OutStockQty+"','1',"+
                    " '','" + itemDetail.FromBatchno + "','','" + itemDetail.FromErpWareHouse + "','" + itemDetail.ToBatchno + "','','" + itemDetail.ToErpWareHouse + "','" + itemDetail.ID+ "','')";
                    
                    lstSql.Add(strSql);
                }
            }

            var newModelList = from t in modelList group t by new { t1 = t.HeaderID} into m
                               select new { HeaderID = m.Key.t1 };

            foreach (var item in newModelList) 
            {
                strSql = "update t_Outstock set status = '2' where id = '" + item.HeaderID + "'";
                lstSql.Add(strSql);

                strSql = "update t_Outstockdetail set linestatus = '2' where headerid = '" + item.HeaderID + "'";
                lstSql.Add(strSql);
            }

            return lstSql;

            ////根据物料类别，指定批次，楼层，拣货组长分组,高低库位
            //var groupByList = from t in modelList
            //              group t by new { t1 = t.MainTypeCode, t2 = t.IsSpcBatch, t3 = t.FloorType,t4=t.PickLeaderUserNo ,t5 = t.HeightArea,t6 = t.FromErpWareHouse,t7 = t.ErpVoucherNo} into m
            //              select new
            //              {
            //                  MainTypeCode = m.Key.t1,
            //                  IsSpcBatch = m.Key.t2,
            //                  FloorType = m.Key.t3,
            //                  PickLeaderUserNo = m.Key.t4,
            //                  HeightArea = m.Key.t5,
            //                  FromErpWareHouse = m.Key.t6,
            //                  ErpvoucherNo = m.Key.t7
            //              };


            //foreach (var itemGroup in groupByList)
            //{
            //    //获取分组数据，生成拣货单
            //    var itemList = modelList.FindAll(t => t.MainTypeCode == itemGroup.MainTypeCode 
            //        && t.IsSpcBatch == itemGroup.IsSpcBatch && t.FloorType == itemGroup.FloorType && t.PickLeaderUserNo==itemGroup.PickLeaderUserNo
            //        && t.HeightArea == itemGroup.HeightArea && t.FromErpWareHouse == itemGroup.FromErpWareHouse && t.ErpVoucherNo == itemGroup.ErpvoucherNo);

            //    voucherID = base.GetTableID("SEQ_TASK_ID");

            //    VoucherNoID = base.GetTableID("SEQ_TASK_NO").ToString();

            //    VoucherNo = "D" + System.DateTime.Now.ToString("yyyyMMdd") + VoucherNoID.PadLeft(4, '0');

            //    strSql = string.Format("insert into t_task (Id, Vouchertype, Tasktype, Taskno, Status,Taskissued, Createtime,Creater," +
            //            " Instockid, Erpvoucherno, Taskissueduser,voucherno,supcuscode,supcusname," +
            //            " Strongholdcode,Strongholdname,Companycode,Departmentcode,Departmentname,ErpStatus,Voudate,Vouuser,isdel,warehouseid,erpvouchertype,IssueType)" +
            //            " select '{0}',a.Vouchertype,'2','{1}','1', Sysdate,Sysdate,'{2}',a.Id,a.Erpvoucherno,'{3}'," +
            //            "a.voucherno,a.customercode,a.customername,a.Strongholdcode,a.Strongholdname,a.Companycode,a.Departmentcode,a.Departmentname,a.ErpStatus,a.voudate,a.vouuser,'1', "+
            //            " (select id from t_warehouse where warehouseno = '{5}'),'{6}',IssueType from t_Outstock a where a.id = '{4}'",
            //             voucherID, VoucherNo, user.UserNo, user.UserNo, itemList[0].HeaderID, itemList[0].FromErpWareHouse, modelList[0].ERPVoucherType);

            //    lstSql.Add(strSql);

            //    foreach (var itemDetail in itemList)
            //    {
            //        strSql = string.Format("insert into t_Taskdetails (Id,Materialno,Materialdesc,Taskqty,Remainqty,Linestatus,HEADERID, " +
            //        "Rowno, Createtime,Unit,Unitname,  Creater,erpvoucherno,materialnoid,voucherno," +
            //        " Strongholdcode,Strongholdname,Companycode ,Rownodel,Outstockqty,isdel,"+
            //        "ISSPCBATCH,FROMBATCHNO,Fromerpareano,Fromerpwarehouse,Tobatchno,Toerpareano,Toerpwarehouse,Outstockdetailid,productno)" +
            //        "select SEQ_TASKDETAIL_ID.Nextval,a.Materialno,a.Materialdesc,a.Outstockqty,a.Outstockqty,'1', " +
            //        " '{0}',a.Rowno,Sysdate,a.Unit,a.Unitname," +
            //        "'{1}' ,a.erpvoucherno,a.materialnoid,a.voucherno, " +
            //        " a.Strongholdcode,a.Strongholdname,a.Companycode,a.Rownodel,a.Outstockqty,'1','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{12}' from t_Outstockdetail a " +
            //        "where a.id = '{2}' and not Exists (select 1 from t_Taskdetails b where b.Outstockdetailid= '{11}')", voucherID, user.UserNo, itemDetail.ID, itemDetail.IsSpcBatch, itemDetail.FromBatchno,
            //        itemDetail.FromErpAreaNo, itemDetail.FromErpWareHouse, itemDetail.ToBatchno, itemDetail.ToErpAreaNo, itemDetail.ToErpWareHouse, itemDetail.ID, itemDetail.ID, itemDetail.ProductNo);

            //        lstSql.Add(strSql);

            //        //更新出库单表体状态为2，已经生单
            //        strSql = "update t_Outstockdetail a set a.Linestatus = 2 where id = '" + itemDetail.ID + "'";
            //        lstSql.Add(strSql);
            //    }

            //    strSql = "update t_Outstock a set a.Status = 2 where " +
            //            "a.id in(select b.Headerid from t_Outstockdetail b  group by b.Headerid having(max(nvl(linestatus,1)) = 2 and min(nvl(linestatus,1))=2) and b.Headerid = '" + itemList[0].HeaderID + "')" +
            //            "and id = '" + itemList[0].HeaderID + "'";
            //    lstSql.Add(strSql);

            //    //任务对应的楼层，拣货组，以及楼层的高低库位
            //    strSql = "insert into t_taskpickleader (Id, Taskid, Floortype, Pickleaderuserno, Pickgroupno,heightarea)" +
            //            " values (SEQ_TASKPICKLEADER_ID.Nextval,'" + voucherID + "','" + itemList[0].FloorType + "','" + itemList[0].PickLeaderUserNo + "','" + itemList[0].PickGroupNo + "','" + itemList[0].HeightArea+ "')";
            //    lstSql.Add(strSql);

            //}

            
        }


        

        #endregion

       

        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        protected override T_OutStockCreateInfo ToModel(OracleDataReader reader)
        {
            T_OutStockCreateInfo t_outstockdetails = new T_OutStockCreateInfo();

            t_outstockdetails.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();                ;
            t_outstockdetails.HeaderID = OracleDBHelper.ToModelValue(reader, "HeaderID").ToInt32();
            t_outstockdetails.ErpVoucherNo = OracleDBHelper.ToModelValue(reader, "ERPVOUCHERNO").ToDBString();
            t_outstockdetails.VoucherNo = OracleDBHelper.ToModelValue(reader, "VoucherNo").ToDBString();
            t_outstockdetails.MaterialNo = OracleDBHelper.ToModelValue(reader, "MATERIALNO").ToDBString();
            t_outstockdetails.MaterialDesc = OracleDBHelper.ToModelValue(reader, "MATERIALDESC").ToDBString();
            t_outstockdetails.RowNo = OracleDBHelper.ToModelValue(reader, "ROWNO").ToDBString();
            t_outstockdetails.Plant = OracleDBHelper.ToModelValue(reader, "PLANT").ToDBString();
            t_outstockdetails.PlantName = OracleDBHelper.ToModelValue(reader, "PLANTNAME").ToDBString();
            t_outstockdetails.ToStorageLoc = OracleDBHelper.ToModelValue(reader, "TOSTORAGELOC").ToDBString();
            t_outstockdetails.Unit = OracleDBHelper.ToModelValue(reader, "UNIT").ToDBString();
            t_outstockdetails.Unitname = OracleDBHelper.ToModelValue(reader, "UNITNAME").ToDBString();
            t_outstockdetails.OutStockQty = (decimal?)OracleDBHelper.ToModelValue(reader, "OUTSTOCKQTY");
            t_outstockdetails.OldOutStockQty = (decimal?)OracleDBHelper.ToModelValue(reader, "OLDOUTSTOCKQTY");
            t_outstockdetails.RemainQty = (decimal?)OracleDBHelper.ToModelValue(reader, "REMAINQTY");
            t_outstockdetails.Costcenter = OracleDBHelper.ToModelValue(reader, "COSTCENTER").ToDBString();
            t_outstockdetails.Wbselem = OracleDBHelper.ToModelValue(reader, "WBSELEM").ToDBString();
            t_outstockdetails.FromStorageLoc = OracleDBHelper.ToModelValue(reader, "FROMSTORAGELOC").ToDBString();
            t_outstockdetails.ReviewStatus = (decimal?)OracleDBHelper.ToModelValue(reader, "REVIEWSTATUS");
            t_outstockdetails.DepartmentCode = OracleDBHelper.ToModelValue(reader, "DEPARTMENTCODE").ToDBString();
            t_outstockdetails.DepartmentName = OracleDBHelper.ToModelValue(reader, "DEPARTMENTNAME").ToDBString();
            t_outstockdetails.CloseOweUser = OracleDBHelper.ToModelValue(reader, "CLOSEOWEUSER").ToDBString();
            t_outstockdetails.CloseOweDate = (DateTime?)OracleDBHelper.ToModelValue(reader, "CLOSEOWEDATE");
            t_outstockdetails.CloseOweRemark = OracleDBHelper.ToModelValue(reader, "CLOSEOWEREMARK").ToDBString();
            t_outstockdetails.IsOweClose = (decimal?)OracleDBHelper.ToModelValue(reader, "ISOWECLOSE");
            t_outstockdetails.OweRemark = OracleDBHelper.ToModelValue(reader, "OWEREMARK").ToDBString();
            t_outstockdetails.OweRemarkUser = OracleDBHelper.ToModelValue(reader, "OWEREMARKUSER").ToDBString();
            t_outstockdetails.OweRemarkDate = (DateTime?)OracleDBHelper.ToModelValue(reader, "OWEREMARKDATE");
            t_outstockdetails.Creater = OracleDBHelper.ToModelValue(reader, "CREATER").ToDBString();
            t_outstockdetails.CreateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CREATETIME");
            t_outstockdetails.Modifyer = OracleDBHelper.ToModelValue(reader, "MODIFYER").ToDBString();
            t_outstockdetails.ModifyTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "MODIFYTIME");
            t_outstockdetails.LineStatus = OracleDBHelper.ToModelValue(reader, "LineStatus").ToInt32();
            //t_outstockdetails.CurrentOutStockQty = (decimal)OracleDBHelper.ToModelValue(reader, "CurrentOutStockQty");
            t_outstockdetails.StrVoucherType = OracleDBHelper.ToModelValue(reader, "StrVoucherType").ToDBString();
            t_outstockdetails.CustomerCode = OracleDBHelper.ToModelValue(reader, "CustomerCode").ToDBString();
            t_outstockdetails.CustomerName = OracleDBHelper.ToModelValue(reader, "CustomerName").ToDBString();
            t_outstockdetails.VoucherType = OracleDBHelper.ToModelValue(reader, "VoucherType").ToInt32();            
            t_outstockdetails.MaterialNoID = OracleDBHelper.ToModelValue(reader, "MaterialNoID").ToInt32();
            t_outstockdetails.StrongHoldCode = OracleDBHelper.ToModelValue(reader, "StrongHoldCode").ToDBString();
            t_outstockdetails.StrongHoldName = OracleDBHelper.ToModelValue(reader, "StrongHoldName").ToDBString();
            t_outstockdetails.CompanyCode = OracleDBHelper.ToModelValue(reader, "CompanyCode").ToDBString();
            t_outstockdetails.RowNoDel = OracleDBHelper.ToModelValue(reader, "RowNoDel").ToDBString();
            t_outstockdetails.FromShipmentDate = (DateTime?)OracleDBHelper.ToModelValue(reader, "ShipmentDate");
            t_outstockdetails.MainTypeCode = OracleDBHelper.ToModelValue(reader, "MainTypeCode").ToDBString();
            t_outstockdetails.DepartmentCode = OracleDBHelper.ToModelValue(reader, "DepartmentCode").ToDBString();
            t_outstockdetails.DepartmentName = OracleDBHelper.ToModelValue(reader, "DepartmentName").ToDBString();
            t_outstockdetails.IsSpcBatch = OracleDBHelper.ToModelValue(reader, "IsSpcBatch").ToDBString();
            t_outstockdetails.FromBatchno = OracleDBHelper.ToModelValue(reader, "FromBatchno").ToDBString();
            t_outstockdetails.FromErpAreaNo = OracleDBHelper.ToModelValue(reader, "FromErpAreaNo").ToDBString();
            t_outstockdetails.FromErpWareHouse = OracleDBHelper.ToModelValue(reader, "FromErpWareHouse").ToDBString();
            t_outstockdetails.ToBatchno = OracleDBHelper.ToModelValue(reader, "ToBatchno").ToDBString();
            t_outstockdetails.ToErpAreaNo = OracleDBHelper.ToModelValue(reader, "ToErpAreaNo").ToDBString();
            t_outstockdetails.ToErpWareHouse = OracleDBHelper.ToModelValue(reader, "ToErpWareHouse").ToDBString();
            //t_outstockdetails.StockQty = (decimal)OracleDBHelper.ToModelValue(reader, "StockQty");
            t_outstockdetails.ProductNo = OracleDBHelper.ToModelValue(reader, "ProductNo").ToDBString();
            t_outstockdetails.ERPVoucherType = OracleDBHelper.ToModelValue(reader, "ERPVoucherType").ToDBString();
            t_outstockdetails.StrIsSpcBatch = t_outstockdetails.IsSpcBatch == "Y" ? "是" : "否";

            t_outstockdetails.ShipNFlg = OracleDBHelper.ToModelValue(reader, "ShipNFlg").ToDBString();
            t_outstockdetails.ShipDFlg = OracleDBHelper.ToModelValue(reader, "ShipDFlg").ToDBString();
            t_outstockdetails.ShipPFlg = OracleDBHelper.ToModelValue(reader, "ShipPFlg").ToDBString();
            t_outstockdetails.ShipWFlg = OracleDBHelper.ToModelValue(reader, "ShipWFlg").ToDBString();
            t_outstockdetails.TradingConditions = OracleDBHelper.ToModelValue(reader, "TradingConditions").ToDBString();
            t_outstockdetails.Address = OracleDBHelper.ToModelValue(reader, "Address").ToDBString();
            t_outstockdetails.Province = OracleDBHelper.ToModelValue(reader, "Province").ToDBString();
            t_outstockdetails.City = OracleDBHelper.ToModelValue(reader, "City").ToDBString();
            t_outstockdetails.Area = OracleDBHelper.ToModelValue(reader, "Area").ToDBString();
            t_outstockdetails.Phone = OracleDBHelper.ToModelValue(reader, "Phone").ToDBString();
            t_outstockdetails.Contact = OracleDBHelper.ToModelValue(reader, "Contact").ToDBString();
            t_outstockdetails.Address1 = OracleDBHelper.ToModelValue(reader, "Address1").ToDBString();
            t_outstockdetails.PackQty = mdb.GetMaterialPackQty(t_outstockdetails.MaterialNo, t_outstockdetails.StrongHoldCode);
            //t_outstockdetails.BoxQty = t_outstockdetails.PackQty == 0 || t_outstockdetails.RemainQty.ToDecimal() < t_outstockdetails.PackQty
            //? 0 : Math.Floor(t_outstockdetails.RemainQty.ToDecimal() / t_outstockdetails.PackQty);
            //t_outstockdetails.ScatQty = t_outstockdetails.PackQty == 0 ? 0 : (t_outstockdetails.RemainQty.ToDecimal() % t_outstockdetails.PackQty);
                
            return t_outstockdetails;
        }
         
        public override List<T_OutStockCreateInfo> GetModelListByPage(UserModel user, T_OutStockCreateInfo model, ref DividPage page)
        {
            List<T_OutStockCreateInfo> modelList= new List<T_OutStockCreateInfo>();
            RuleAll.t_RuleAll_DB ruleDB = new RuleAll.t_RuleAll_DB();
            List<RuleAll.T_RuleAllInfo> ruleList = ruleDB.GetRuleListByPage(10);
            if (ruleList[0].IsEnable == 1) //不启用占用库存
            {
                modelList= base.GetModelListByPage(user, model, ref page);
            }
            else //占用库存
            {
                modelList = base.GetModelListByPage(user, model, ref page);

            }
            return modelList;
        }


        public override List<T_OutStockCreateInfo> GetModelListByHeaderID(int headerID)
        {
            List<T_OutStockCreateInfo> list = base.GetModelListByHeaderID(headerID);
            if (list.Count > 0)
            {
                T_OutStockCreateInfo model = new T_OutStockCreateInfo();
                model.EditText = "";
                model.OrderNumber = "合计";
                model.OutStockQty = list.Sum(p => p.OutStockQty);

                list.Add(model);
            }

            return list;
        }

        protected override string GetFilterSql(UserModel user, T_OutStockCreateInfo model)
        {
            string strSql = base.GetFilterSql(user, model);
            string strAnd = " and ";

            strSql += strAnd;
            strSql += "  nvl(LINESTATUS,1)='1' ";


            if (!string.IsNullOrEmpty(model.SelectHeaderID))
            {
                strSql += strAnd;
                strSql += " headerid in (" + model.SelectHeaderID + ")";
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

            if (model.VoucherType > 0)
            {
                strSql += strAnd;
                strSql += " VoucherType ='" + model.VoucherType + "'  ";
            }

            if (!string.IsNullOrEmpty(model.ErpVoucherNo))
            {
                strSql += strAnd;
                strSql += " ErpVoucherNo Like '" + model.ErpVoucherNo + "%'  ";
            }

            if (!string.IsNullOrEmpty(model.MaterialNo))
            {
                strSql += strAnd;
                strSql += " MaterialNo Like '" + model.MaterialNo + "%'  ";
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

            if (model.StrongHoldType == 3)
            {
                strSql += strAnd;
                strSql += " StrongHoldCode ='FC1'";
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

            return strSql;
        }

        protected override string GetViewName()
        {
            return "V_OUTSTOCKCREATE";
        }

        protected override string GetTableName()
        {
            return "";
        }

        protected override string GetSaveProcedureName()
        {
            return "";
        }

        /// <summary>
        /// 验证单据是否生成下架任务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int CheckVoucherIsCreate(string VoucherNo)
        {
            string strSql = string.Format("select nvl(a.Status,1) as status  from t_outstock a where a.VoucherNo ='{0}'", VoucherNo);
            return GetScalarBySql(strSql).ToInt32();
        }

        /// <summary>
        /// 验证发货单据物料行能否生成拣货单
        /// </summary>
        /// <param name="modelList"></param>
        /// <param name="strError"></param>
        /// <returns></returns>
        public bool CheckCreatePickBefore(List<T_OutStockCreateInfo> modelList, ref string strError) 
        {
            try
            {
                int iResult = 0;

                string strOutStockCreateXml = XmlUtil.Serializer(typeof(List<T_OutStockCreateInfo>), modelList);
                OracleParameter[] cmdParms = new OracleParameter[] 
            {
                new OracleParameter("strOutStockCreateXml", OracleDbType.NClob),                
                new OracleParameter("bResult", OracleDbType.Int32,ParameterDirection.Output),
                new OracleParameter("ErrString", OracleDbType.NVarchar2,200,strError,ParameterDirection.Output)
            };

                cmdParms[0].Value = strOutStockCreateXml;

                OracleDBHelper.ExecuteNonQuery3(OracleDBHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "p_checkcreatepickbefore", cmdParms);
                iResult = Convert.ToInt32(cmdParms[1].Value.ToString());
                strError = cmdParms[2].Value.ToString();

                return iResult == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckOutStockCreate(List<T_OutStockCreateInfo> modelList, ref string strError)
        {
            try
            {
                int iResult = 0;

                string strOutStockCreateXml = XmlUtil.Serializer(typeof(List<T_OutStockCreateInfo>), modelList);
                OracleParameter[] cmdParms = new OracleParameter[] 
            {
                new OracleParameter("OutStockCreateXml", OracleDbType.NClob),                
                new OracleParameter("bResult", OracleDbType.Int32,ParameterDirection.Output),
                new OracleParameter("ErrString", OracleDbType.NVarchar2,200,strError,ParameterDirection.Output)
            };

                cmdParms[0].Value = strOutStockCreateXml;

                OracleDBHelper.ExecuteNonQuery3(OracleDBHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "P_Check_OutStockCreate", cmdParms);
                iResult = Convert.ToInt32(cmdParms[1].Value.ToString());
                strError = cmdParms[2].Value.ToString();

                return iResult == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
