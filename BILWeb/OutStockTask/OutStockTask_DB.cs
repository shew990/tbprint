using BILBasic.DBA;
using BILBasic.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILBasic.Common;
using Oracle.ManagedDataAccess.Client;
using BILWeb.Login;

namespace BILWeb.OutStockTask
{
    public partial class T_OutStockTask_DB : BILBasic.Basing.Base_DB<T_OutStockTaskInfo>
    {

        /// <summary>
        /// 添加t_task
        /// </summary>
        protected override OracleParameter[] GetSaveModelOracleParameter(T_OutStockTaskInfo t_task)
        {
            //注意!head表ID要填basemodel的headerID new SqlParameter("@CustomerID", DbHelperSQL.ToDBValue(model.HeaderID)),
            throw new NotImplementedException();


        }

        protected override List<string> GetSaveSql(UserModel user, ref T_OutStockTaskInfo t_task)
        {
            throw new NotImplementedException();
        }




        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        protected override T_OutStockTaskInfo ToModel(OracleDataReader reader)
        {
            T_OutStockTaskInfo t_task = new T_OutStockTaskInfo();

            t_task.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();
            t_task.VoucherType = OracleDBHelper.ToModelValue(reader, "VOUCHERTYPE").ToInt32();
            t_task.TaskType = (decimal?)OracleDBHelper.ToModelValue(reader, "TASKTYPE");
            t_task.TaskNo = OracleDBHelper.ToModelValue(reader, "TASKNO").ToDBString();
            t_task.SupcusName = OracleDBHelper.ToModelValue(reader, "SUPCUSNAME").ToDBString();
            t_task.Status = OracleDBHelper.ToModelValue(reader, "Status").ToInt32();
            t_task.AuditUserNo = OracleDBHelper.ToModelValue(reader, "AUDITUSERNO").ToDBString();
            t_task.AuditDateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "AUDITDATETIME");
            t_task.TaskIssued = (DateTime?)OracleDBHelper.ToModelValue(reader, "TASKISSUED");
            t_task.ReceiveUserNo = OracleDBHelper.ToModelValue(reader, "RECEIVEUSERNO").ToDBString();
            t_task.CreateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CREATETIME");
            t_task.Remark = OracleDBHelper.ToModelValue(reader, "REMARK").ToDBString();
            t_task.Reason = OracleDBHelper.ToModelValue(reader, "REASON").ToDBString();
            t_task.SupcusCode = OracleDBHelper.ToModelValue(reader, "SupcusCode").ToDBString();
            t_task.Creater = OracleDBHelper.ToModelValue(reader, "CREATER").ToDBString();
            t_task.IsShelvePost = (decimal?)OracleDBHelper.ToModelValue(reader, "ISSHELVEPOST");
            //t_task.Receive_ID = (decimal?)OracleDBHelper.ToModelValue(reader, "RECEIVE_ID");
            t_task.ErpVoucherNo = OracleDBHelper.ToModelValue(reader, "ERPVoucherNo").ToDBString();
            t_task.IsQuality = (decimal?)OracleDBHelper.ToModelValue(reader, "ISQUALITY");
            t_task.IsReceivePost = (decimal?)OracleDBHelper.ToModelValue(reader, "ISRECEIVEPOST");
            t_task.Plant = OracleDBHelper.ToModelValue(reader, "PLANT").ToDBString();
            t_task.PlanName = OracleDBHelper.ToModelValue(reader, "PLANTNAME").ToDBString();
            t_task.PostStatus = (decimal?)OracleDBHelper.ToModelValue(reader, "POSTSTATUS");
            t_task.MoveType = OracleDBHelper.ToModelValue(reader, "MOVETYPE").ToDBString();
            t_task.IsOutStockPost = (decimal?)OracleDBHelper.ToModelValue(reader, "ISOUTSTOCKPOST");
            t_task.IsUnderShelvePost = (decimal?)OracleDBHelper.ToModelValue(reader, "ISUNDERSHELVEPOST");
            t_task.DepartmentCode = OracleDBHelper.ToModelValue(reader, "DEPARTMENTCODE").ToDBString();
            t_task.DepartmentName = OracleDBHelper.ToModelValue(reader, "DEPARTMENTNAME").ToDBString();
            t_task.ReviewStatus = (decimal?)OracleDBHelper.ToModelValue(reader, "REVIEWSTATUS");
            t_task.MoveReasonCode = OracleDBHelper.ToModelValue(reader, "MOVEREASONCODE").ToDBString();
            t_task.MoveReasonDesc = OracleDBHelper.ToModelValue(reader, "MOVEREASONDESC").ToDBString();
            t_task.PrintQty = (decimal?)OracleDBHelper.ToModelValue(reader, "PRINTQTY");
            t_task.PrintTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "PRINTTIME");
            t_task.CloseDateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CLOSEDATETIME");
            t_task.CloseUserNo = OracleDBHelper.ToModelValue(reader, "CLOSEUSERNO").ToDBString();
            t_task.CloseReason = OracleDBHelper.ToModelValue(reader, "CLOSEREASON").ToDBString();
            t_task.IsOwe = (decimal?)OracleDBHelper.ToModelValue(reader, "ISOWE");
            t_task.IsUrgent = (decimal?)OracleDBHelper.ToModelValue(reader, "ISURGENT");
            t_task.OutStockDate = (DateTime?)OracleDBHelper.ToModelValue(reader, "OUTSTOCKDATE");

            t_task.StrVoucherType = OracleDBHelper.ToModelValue(reader, "StrVoucherType").ToDBString();
            t_task.StrStatus = OracleDBHelper.ToModelValue(reader, "StrStatus").ToDBString();
            t_task.StrCreater = OracleDBHelper.ToModelValue(reader, "StrCreater").ToDBString();
            t_task.FloorType = OracleDBHelper.ToModelValue(reader, "FloorType").ToInt32();
            t_task.PickGroupNo = OracleDBHelper.ToModelValue(reader, "PickGroupNo").ToDBString();
            t_task.PickLeaderUserNo = OracleDBHelper.ToModelValue(reader, "PickLeaderUserNo").ToDBString();
            t_task.StrPickLeaderUserNo = OracleDBHelper.ToModelValue(reader, "StrPickLeaderUserNo").ToDBString();
            t_task.CompanyCode = OracleDBHelper.ToModelValue(reader, "CompanyCode").ToDBString();
            t_task.StrongHoldCode = OracleDBHelper.ToModelValue(reader, "StrongHoldCode").ToDBString();
            t_task.StrongHoldName = OracleDBHelper.ToModelValue(reader, "StrongHoldName").ToDBString();

            t_task.WareHouseID = OracleDBHelper.ToModelValue(reader, "WareHouseID").ToInt32();
            t_task.WareHouseName = OracleDBHelper.ToModelValue(reader, "WareHouseName").ToDBString();
            t_task.WareHouseNo = OracleDBHelper.ToModelValue(reader, "WareHouseNo").ToDBString();

            t_task.IsEdate = OracleDBHelper.ToModelValue(reader, "IsEdate").ToDBString();
            t_task.PickUserNo = OracleDBHelper.ToModelValue(reader, "PickUserNo").ToDBString();

            BILWeb.Login.User.User_DB _db = new Login.User.User_DB();
            BILWeb.Login.User.UserInfo usermodel =  _db.GetModelByFilterByUserNo(t_task.PickUserNo);
            if (usermodel != null)
            {
                t_task.PickUserName = usermodel.UserName;
            }

            t_task.FloorName = OracleDBHelper.ToModelValue(reader, "FloorName").ToDBString();
            t_task.HeightArea = OracleDBHelper.ToModelValue(reader, "HeightArea").ToDBString();
            t_task.HeightAreaName = OracleDBHelper.ToModelValue(reader, "HeightAreaName").ToDBString();
            t_task.VouUser = OracleDBHelper.ToModelValue(reader, "VouUser").ToDBString();

            t_task.IssueType = OracleDBHelper.ToModelValue(reader, "IssueType").ToDBString();

            return t_task;
        }


        protected override string GetFilterSql(UserModel user, T_OutStockTaskInfo model)
        {
            string strUserNo = string.Empty;

            string strSql = base.GetFilterSql(user, model);
            string strAnd = " and ";

            if (model.Status > 0)
            {
                if (model.Status == 1 || model.Status == 2)
                {
                    strSql += strAnd;
                    strSql += "( status=1 or status=2 )";

                }
                else
                {
                    strSql += strAnd;
                    strSql += "status= '" + model.Status + "'";
                }
            }

            if (!string.IsNullOrEmpty(model.SupcusCode))
            {
                strSql += strAnd;
                strSql += " (SupcusCode Like '" + model.SupcusCode + "%'  or SUPCUSNAME Like '" + model.SupcusCode + "%' )";
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

            if (!string.IsNullOrEmpty(model.TaskNo))
            {
                strSql += strAnd;
                strSql += " (taskno Like '" + model.TaskNo + "%'  )";
            }
                        

            if (model.VoucherType > 0)
            {
                strSql += strAnd;
                strSql += " VoucherType ='" + model.VoucherType + "'";
            }

            if (!string.IsNullOrEmpty(model.ErpVoucherNo))
            {
                strSql += strAnd;
                strSql += " ErpVoucherNo like '" + model.ErpVoucherNo + "%'";
            }

            //if (!string.IsNullOrEmpty(model.PickLeaderUserNo))
            //{                
            //    strSql += strAnd;
            //    strSql += " Pickleaderuserno like '" + GetUserNo(model.PickLeaderUserNo) + "%'";
            //}

            //if (!string.IsNullOrEmpty(model.PickUserNo))
            //{                
            //    strSql += strAnd;
            //    strSql += " ID in (select taskid from t_Taskpick where Pickuserno like '" + GetUserNo(model.PickUserNo) + "%')";
            //}

            if (!string.IsNullOrEmpty(model.StrongHoldCode))
            {
                strSql += strAnd;
                strSql += " (StrongHoldCode like '" + model.StrongHoldCode + "%' )";
            }

            if (!string.IsNullOrEmpty(model.StrongHoldName))
            {
                strSql += strAnd;
                strSql += " (StrongHoldName like '" + model.StrongHoldName + "%' )";
            }

            if (model.WareHouseID > 0) 
            {
                strSql += strAnd;
                strSql += " warehouseid = '" + model.WareHouseID + "' ";
            }

            if (!string.IsNullOrEmpty(model.MaterialNo))
            {
                strSql += strAnd;
                strSql += "  id in ( SELECT HEADERID FROM v_Outtaskdetail WHERE MATERIALNO LIKE '%" + model.MaterialNo + "%' ) ";
            }

            if (!string.IsNullOrEmpty(model.VouUser))
            {
                strSql += strAnd;
                strSql += "  VouUser like '" + model.VouUser + "%' ";
            }

            if (!string.IsNullOrEmpty(model.CarNo)) 
            {
                strSql += strAnd;
                strSql += " taskno = ( select taskno from t_pickcar where carno = '"+model.CarNo+"' ) ";
            }

            strSql += strAnd;
            strSql += " tasktype = 2 ";            

            return strSql + " order by id  ";
        }

        private string GetUserNo(string UserNo) 
        {
            string strUserNo = string.Empty;
            if (TOOL.RegexMatch.isExists(UserNo) == true)
            {
                strUserNo = UserNo.Substring(0, UserNo.Length - 1);
            }
            else
            {
                strUserNo = UserNo;
            }
            return strUserNo;
        }

        protected override string GetViewName()
        {
            return "V_OUTTASK";
        }

        protected override string GetTableName()
        {
            return "T_TASK";
        }

        protected override string GetSaveProcedureName()
        {
            return "";
        }


        protected override List<string> GetUpdateSql(UserModel user, T_OutStockTaskInfo model)
        {
            List<string> lstSql = new List<string>();

            string strSql = "update t_Task a set a.Status = '" + model.Status + "' where id = '" + model.ID + "'";

            lstSql.Add(strSql);

            return lstSql;
        }

        /// <summary>
        /// 一张拣货单可以分配给多个拣货人
        /// </summary>
        /// <param name="UserList"></param>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public bool SavePickUserList(List<UserModel> UserList,List<T_OutStockTaskInfo> modelList,ref string strError) 
        {
            List<string> lstSql = new List<string>();
            string strSql = string.Empty;

            foreach (var itemModel in modelList) 
            {
                //拣货单再次分配，先清空之前分配的拣货单
                strSql = "delete t_Taskpick where taskid = '" + itemModel.ID + "'";
                lstSql.Add(strSql);

                foreach (var item in UserList) 
                {
                    strSql = "insert into t_Taskpick(Id, Taskdetailid, Pickuserno, Taskid) " +
                            " Select seq_taskpick_id.Nextval,a.id,'"+item.UserNo+"',a.Headerid from t_Taskdetails a  where headerid = '"+itemModel.ID+"'";
                    lstSql.Add(strSql);
                }
            }

            return base.SaveModelListBySqlToDB(lstSql, ref strError);
        }

    }
}
