using BILWeb.OutStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Print
{
    public class Common
    {
        public static T_OutStockInfo getoutstock(string strErpVoucherNo) {
            T_OutStock_Func func = new T_OutStock_Func();
            T_OutStockInfo model = new T_OutStockInfo();
            string strError = "";
            if (func.GetOutStockDetailForPrint(strErpVoucherNo, ref model, ref strError))
            {
                return model;
            }
            else {
                return  null;
            }
        } 
    }
}