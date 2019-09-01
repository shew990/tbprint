using BILBasic.DBA;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILBasic.Common;

namespace BILBasic.Interface
{
     class T_Interface_DB
    {
        public List<T_InterfaceInfo> GetInterface()
        {
            try
            {
                List<T_InterfaceInfo> lstModel = new List<T_InterfaceInfo>();
                string sql = "select * from v_depinterface";

                using (OracleDataReader reader = OracleDBHelper.ExecuteReader(sql))
                {
                    while (reader.Read())
                    {
                        T_InterfaceInfo model = new T_InterfaceInfo();
                        model.DLLName = reader["DLLName"].ToDBString();
                        model.Route = reader["Route"].ToDBString();
                        model.FunctionName = reader["FunctionName"].ToDBString();
                        model.Function = reader["Function"].ToDBString();
                        model.VoucherType = reader["VoucherType"].ToInt32();
                        model.StrVoucherType = reader["StrVoucherType"].ToDBString();
                        model.ClassName = reader["ClassName"].ToDBString();
                        lstModel.Add(model);
                    }
                    
                }
                return lstModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
