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

    public partial class T_SaveTransportSupplier_Func : TBase_Func<T_SaveTransportSupplier_DB, T_TransportSupplier>
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

        public string SaveTransportSupplierListADF(string ModelJson)
        {
            BaseMessage_Model<string> messageModel = new BaseMessage_Model<string>();

            try
            {
                string strError = string.Empty;

                if (string.IsNullOrEmpty(ModelJson))
                {
                    messageModel.Message = "客户端传入装车数据为空！";
                    messageModel.HeaderStatus = "E";
                    return BILBasic.JSONUtil.JSONHelper.ObjectToJson<BaseMessage_Model<string>>(messageModel);
                }

                List<TransportSupplierDetail> modellist = BILBasic.JSONUtil.JSONHelper.JsonToObject<List<TransportSupplierDetail>>(ModelJson);

                if (modellist == null)
                {
                    messageModel.Message = "客户端传入JSON转装车数据为空！";
                    messageModel.HeaderStatus = "E";
                    return BILBasic.JSONUtil.JSONHelper.ObjectToJson<BaseMessage_Model<string>>(messageModel);
                }

                T_SaveTransportSupplier_DB _db = new T_SaveTransportSupplier_DB();
                if (_db.SaveTransportSupplierADF(modellist, ref strError) == false)
                {
                    messageModel.Message = strError;
                    messageModel.HeaderStatus = "E";
                    return BILBasic.JSONUtil.JSONHelper.ObjectToJson<BaseMessage_Model<string>>(messageModel);
                }
                else
                {
                    messageModel.Message = "装车数据保存成功！";
                    messageModel.HeaderStatus = "S";
                    return BILBasic.JSONUtil.JSONHelper.ObjectToJson<BaseMessage_Model<string>>(messageModel);
                }

            }
            catch (Exception ex)
            {
                messageModel.Message = ex.Message;
                messageModel.HeaderStatus = "E";
                return BILBasic.JSONUtil.JSONHelper.ObjectToJson<BaseMessage_Model<string>>(messageModel);
            }

        }
    }
}