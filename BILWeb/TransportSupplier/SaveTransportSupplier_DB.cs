//************************************************************
//******************************作者：方颖*********************
//******************************时间：2016/10/20 11:01:37*******

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILBasic.Basing;
using BILBasic.DBA;
using BILBasic.Common;
using BILWeb.Login.User;
using BILBasic.User;
using Oracle.ManagedDataAccess.Client;
using BILWeb.Warehouse;

namespace BILWeb.TransportSupplier
{
    public partial class T_SaveTransportSupplier_DB : Base_DB<T_TransportSupplier>
    {
        protected override OracleParameter[] GetSaveModelOracleParameter(T_TransportSupplier model)
        {
            throw new NotImplementedException();
        }

        protected override string GetSaveProcedureName()
        {
            throw new NotImplementedException();
        }

        protected override List<string> GetSaveSql(UserModel user, ref T_TransportSupplier model)
        {
            throw new NotImplementedException();
        }

        protected override string GetTableName()
        {
            throw new NotImplementedException();
        }

        protected override string GetViewName()
        {
            throw new NotImplementedException();
        }

        protected override T_TransportSupplier ToModel(OracleDataReader reader)
        {
            throw new NotImplementedException();
        }

        internal bool SaveTransportSupplierADF(List<TransportSupplierDetail> modeliist, ref string strError)
        {
            try
            {
                string type = modeliist[0].type;//1:装2：卸
                string strSql = string.Empty;
                List<string> lstSql = new List<string>();

                List<TransportSupplierDetail> delmodeliist = (from st in modeliist
                                                              group st by new
                                                              {
                                                                  st.palletno,
                                                                  st.platenumber
                                                              }
                                                              into temp
                                                              select new TransportSupplierDetail()
                                                              {
                                                                  palletno = temp.Key.palletno,
                                                                  platenumber = temp.Key.platenumber
                                                              }).ToList();
                for (int i = 0; i < delmodeliist.Count; i++)
                {
                    if (type == "1")
                    {
                        strSql = @"delete from T_TRANSPORTSUPPLIERDETAIL where type=1 and palletno='" + delmodeliist[i].palletno + "' and PLATENUMBER='" + delmodeliist[i].platenumber + "'";
                        lstSql.Add(strSql);
                    }
                    if (type == "2")
                    {
                        strSql = @"delete from T_TRANSPORTSUPPLIERDETAIL where type=2 and palletno='" + delmodeliist[i].palletno + "'";
                        lstSql.Add(strSql);
                    }
                }

                for (int i = 0; i < modeliist.Count; i++)
                {


                    int ID = base.GetTableID("SEQ_TRANSPORTSUPPLIERDETAIL");
                    strSql = @"INSERT into T_TRANSPORTSUPPLIERDETAIL(ID,ERPVOUCHERNO,PLATENUMBER,FEIGHT,CREATETIME,isdel,palletno,boxcount,outboxcount,customername,voucherno,type,remark,remark1,remark2,remark3,creater)
                    VALUES(" + ID + ",'{0}', '{1}', '{2}',SYSDATE, '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}')";
                    strSql = string.Format(strSql, modeliist[i].erpvoucherno, modeliist[i].platenumber, modeliist[i].FEIGHT,
                       modeliist[i].isdel, modeliist[i].palletno, modeliist[i].boxcount, modeliist[i].outboxcount,
                       modeliist[i].customername, modeliist[i].voucherno, modeliist[i].type, modeliist[i].remark, modeliist[i].remark1, modeliist[i].remark2, modeliist[i].remark3, modeliist[i].creater);
                    lstSql.Add(strSql);
                }
                return base.SaveModelListBySqlToDB(lstSql, ref strError);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
