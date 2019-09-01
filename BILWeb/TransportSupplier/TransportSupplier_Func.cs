using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILBasic.Basing;
using BILWeb.Login.User;
using BILWeb.TransportSupplier;

namespace BILWeb.TransportSupplier
{

    public partial class T_TransportSupplier_Func : TBase_Func<T_TransportSupplier_DB, T_TransportSupplier>
    {
        protected override bool CheckModelBeforeSave(T_TransportSupplier model, ref string strError)
        {
            if (model == null)
            {
                strError = "客户端传来的实体类不能为空！";
                return false;
            }

            if (BILBasic.Common.Common_Func.IsNullOrEmpty(model.TransportSupplierID.ToString()))
            {
                strError = "承运商编号不能为空！";
                return false;
            }

            if (BILBasic.Common.Common_Func.IsNullOrEmpty(model.TransportSupplierName))
            {
                strError = "承运商名称不能为空！";
                return false;
            }

            return true;
        }

        protected override string GetModelChineseName()
        {
            return "承运商";
        }

        public bool GetModelListBySql(UserInfo user, ref List<T_TransportSupplier> lstTransportSupplier)
        {
            try
            {
                T_TransportSupplier_DB thd = new T_TransportSupplier_DB();
                lstTransportSupplier = thd.GetModelListBySql(user, false);
                if (lstTransportSupplier == null || lstTransportSupplier.Count <= 0) { return false; }
                else { return true; }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetTransportSupplierList()
        {
            BaseMessage_Model<List<T_TransportSupplier>> messageModel = new BaseMessage_Model<List<T_TransportSupplier>>();
            try
            {

                T_TransportSupplier_DB _db = new T_TransportSupplier_DB();
                List<T_TransportSupplier> modelList = _db.GetTransportSupplierList();

                if (modelList == null || modelList.Count == 0)
                {
                    messageModel.Message = "获取承运商列表为空！";
                    messageModel.HeaderStatus = "E";
                    return BILBasic.JSONUtil.JSONHelper.ObjectToJson<BaseMessage_Model<List<T_TransportSupplier>>>(messageModel);
                }

                messageModel.HeaderStatus = "S";
                messageModel.ModelJson = modelList;

                return BILBasic.JSONUtil.JSONHelper.ObjectToJson<BaseMessage_Model<List<T_TransportSupplier>>>(messageModel);

            }
            catch (Exception ex)
            {
                messageModel.Message = ex.Message;
                messageModel.HeaderStatus = "E";
                return BILBasic.JSONUtil.JSONHelper.ObjectToJson<BaseMessage_Model<List<T_TransportSupplier>>>(messageModel);
            }
        }


        public string GetTransportSupplierDetailList(string Palletno)
        {
            BaseMessage_Model<List<TransportSupplierDetail>> messageModel = new BaseMessage_Model<List<TransportSupplierDetail>>();
            try
            {

                T_TransportSupplier_DB _db = new T_TransportSupplier_DB();
                List<TransportSupplierDetail> modelList = _db.GetTransportSupplierDetailList(Palletno);

                if (modelList == null || modelList.Count == 0)
                {
                    messageModel.Message = "没有获取到装车信息！";
                    messageModel.HeaderStatus = "E";
                    return BILBasic.JSONUtil.JSONHelper.ObjectToJson<BaseMessage_Model<List<TransportSupplierDetail>>>(messageModel);
                }

                messageModel.HeaderStatus = "S";
                messageModel.ModelJson = modelList;
                return BILBasic.JSONUtil.JSONHelper.ObjectToJson<BaseMessage_Model<List<TransportSupplierDetail>>>(messageModel);

            }
            catch (Exception ex)
            {
                messageModel.Message = ex.Message;
                messageModel.HeaderStatus = "E";
                return BILBasic.JSONUtil.JSONHelper.ObjectToJson<BaseMessage_Model<List<TransportSupplierDetail>>>(messageModel);
            }
        }
        
    }
}