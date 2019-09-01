using BILBasic.Basing;
using BILBasic.JSONUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BILWeb.OutStock
{
    public partial class T_OutStock_Func : TBase_Func<T_OutStock_DB, T_OutStockInfo>,IOutStockService
    {

        protected override bool CheckModelBeforeSave(T_OutStockInfo model, ref string strError)
        {
            if (model == null)
            {
                strError = "客户端传来的实体类不能为空！";
                return false;
            }
            
            return true;
        }

        protected override string GetModelChineseName()
        {
            return "出库单";
        }

        protected override T_OutStockInfo GetModelByJson(string strJson)
        {
            return JSONHelper.JsonToObject<T_OutStockInfo>(strJson);
        }

        public bool GetOutStockAndDetailsModelByNo(string erpNo, ref BILWeb.OutStockTask.T_OutStockTaskInfo head, ref List<BILWeb.OutStockTask.T_OutStockTaskDetailsInfo> lstDetail, ref string ErrMsg)
        {
            T_OutStock_DB os = new T_OutStock_DB();
            return os.GetOutStockAndDetailsModelByNo(erpNo, ref head, ref lstDetail, ref ErrMsg);
        }

        protected override bool Sync(T_OutStockInfo model, ref string strErrMsg)
        {
            BILWeb.SyncService.ParamaterField_Func PFunc = new BILWeb.SyncService.ParamaterField_Func();
            return PFunc.Sync(20, string.Empty, model.ErpVoucherNo, model.VoucherType, ref strErrMsg, "ERP", -1, null);
        }

        /// <summary>
        /// 扫描小车或者ERP订单号复核，返回的是表头+表体的数据
        /// 表体需要根据相同物料汇总
        /// </summary>
        /// <param name="strCarNo"></param>
        /// <param name="model"></param>
        /// <param name="strError"></param>
        /// <returns></returns>
        public bool GetModelListByCar(string strCarNo, ref T_OutStockInfo model ,ref string strError)
        {
            try
            {
                if (string.IsNullOrEmpty(strCarNo))
                {
                    strError = "扫描或输入拣货车编号为空！";
                    return false;
                }
                T_OutStock_DB _db = new T_OutStock_DB();
                return _db.GetModelListByCar(strCarNo,ref  model,ref  strError);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        #region PC打印发货清单
        public bool GetOutStockDetailForPrint(string strErpVoucherNo, ref T_OutStockInfo model, ref string strError)
        {
            try
            {
                if (string.IsNullOrEmpty(strErpVoucherNo))
                {
                    strError = "传入的ERP单号为空！";
                    return false;
                }

                T_OutStock_DB tdb = new T_OutStock_DB();
                model = tdb.GetOutStockDetailForPrint(strErpVoucherNo);

                if (model == null) 
                {
                    strError = "单号不存在！" +strErpVoucherNo;
                    return false;
                }

                if (string.IsNullOrEmpty(model.ShipDFlg) || model.ShipDFlg == "N") 
                {
                    strError = "订单不需要发货清单！" + strErpVoucherNo;
                    return false;
                }

                List<T_OutStockDetailInfo> modelList = new List<T_OutStockDetailInfo>();
                T_OutStockDetail_Func tfunc = new T_OutStockDetail_Func();
                bool bSucc = tfunc.GetModelListByHeaderID(ref modelList, model.ID, ref strError);
                if (bSucc == false)
                {                    
                    return false;
                }

                if (string.IsNullOrEmpty(model.ShipPFlg) || model.ShipPFlg == "N") 
                {
                     modelList.ForEach(t => t.Price = 0);
                }

                model.lstDetail = modelList;

                return true;

            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }
        #endregion

        #region 验证发货单据是否已经在WMS存在

        public int GetOutStockNoIsExists(string strErpVoucherNo) 
        {
            T_OutStock_DB _db = new T_OutStock_DB();
            return _db.GetOutStockNoIsExists(strErpVoucherNo);
        }

        #endregion

    }
}
