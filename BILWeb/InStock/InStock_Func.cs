using BILBasic.Basing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILBasic.JSONUtil;

namespace BILWeb.InStock
{
    public partial class T_InStock_Func : TBase_Func<T_InStock_DB, T_InStockInfo>,IInStockService
     {
   
        protected override bool CheckModelBeforeSave(T_InStockInfo model, ref string strError)
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
            return "收货";
        }
        
        protected override T_InStockInfo GetModelByJson(string ModelJson)
        {
            return JSONHelper.JsonToObject<T_InStockInfo>(ModelJson);
        }

        public string GetInStockStatusByTaskNo(string strTaskNo) 
        {
            T_InStock_DB _db = new T_InStock_DB();
            return _db.GetInStockStatusByTaskNo(strTaskNo);
        }

        public int GetInStockVoucherType(string strTaskNo) 
        {
            T_InStock_DB _db = new T_InStock_DB();
            return _db.GetInStockVoucherType(strTaskNo);
        }
   
     }
 }

