using BILBasic.Language;
using BILWeb.OutBarCode;
using BILWeb.StrategeRuleAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILBasic.Common;


namespace BILWeb.Stock
{
    public class Stock_SerialEnableRule : StrategeRuleAll<T_StockInfo>
    {
        

        //启用序列号管理
        public override bool GetStockByBarCode(T_StockInfo model, ref List<T_StockInfo> modelList, ref string strError)
        {
            string strSerialNo = string.Empty;
            int iWareHouseID = 0;
            T_Stock_Func sfunc = new T_Stock_Func();
            T_StockInfo newModel = new T_StockInfo();
            List<T_StockInfo> newModelList = new List<T_StockInfo>();
            T_Stock_DB db = new T_Stock_DB();
            

            if (model.Barcode.Contains("@") == true)
            {
                strSerialNo = OutBarCode_DeCode.GetEndSerialNo(model.Barcode);
                //根据序列号查库存
                if (sfunc.GetStockByBarCode(strSerialNo, ref newModel, ref strError) == false)
                {
                    return false;
                }
                
            }
            else 
            {
                iWareHouseID = model.WareHouseID;

                newModelList = db.GetStockByWHBarCode(model);
                if (newModelList == null || newModelList.Count==0)
                {
                    strError = Language_CHS.StockIsEmpty;
                    return false;
                }
                if (string.IsNullOrEmpty(model.ErpVoucherNo))
                {
                    newModelList = newModelList.Where(t => t.TaskDetailesID == 0).ToList();
                }
                else 
                {
                    newModelList = newModelList.Where(t => t.TaskDetailesID > 0).ToList();
                }
                
            }

            //整箱或者零数发货
            if (model.ScanType == 2 || model.ScanType == 3)
            {
                if (model.Barcode.Contains("@") == true)
                {
                    modelList.Add(newModel);
                }
                else 
                {
                    modelList.AddRange(newModelList);
                }                
            }

            //整托发货
            if (model.ScanType == 1 && model.Barcode.Contains("@") == true)
            {
                if (string.IsNullOrEmpty(newModel.PalletNo))
                {
                    strError = Language_CHS.StockPEmpty;
                    return false;
                }

                if (sfunc.GetStockInfoByPalletNo(newModel.PalletNo, ref modelList, ref strError) == false)
                {
                    return false;
                }
            }

            decimal SumQty = modelList.Sum(t1 => t1.Qty).ToDecimal();
            modelList.ForEach(t => t.PalletQty = SumQty);

            return true;

        }

    }
}
