using BILBasic.DBA;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILBasic.Common;
using BILBasic.User;

namespace BILWeb.Pallet
{
    public partial class T_Pallet_DB : BILBasic.Basing.Base_DB<T_PalletInfo>
    {

        /// <summary>
        /// 添加t_pallet
        /// </summary>
        protected override OracleParameter[] GetSaveModelOracleParameter(T_PalletInfo t_pallet)
        {
            //注意!head表ID要填basemodel的headerID new SqlParameter("@CustomerID", DbHelperSQL.ToDBValue(model.HeaderID)),
            throw new NotImplementedException();


        }

        protected override List<string> GetSaveSql(UserModel user, ref T_PalletInfo t_pallet)
        {
            throw new NotImplementedException();
        }




        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        protected override T_PalletInfo ToModel(OracleDataReader reader)
        {
            T_PalletInfo t_pallet = new T_PalletInfo();

            t_pallet.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();
            t_pallet.PalletNo = (string)OracleDBHelper.ToModelValue(reader, "PALLETNO");
            t_pallet.Creater = (string)OracleDBHelper.ToModelValue(reader, "CREATER");
            t_pallet.CreateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CREATETIME");
            t_pallet.Modifyer = (string)OracleDBHelper.ToModelValue(reader, "MODIFYER");
            t_pallet.ModifyTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "MODIFYTIME");
            return t_pallet;
        }

        protected override string GetViewName()
        {
            return "";
        }

        protected override string GetTableName()
        {
            return "T_PALLET";
        }

        protected override string GetSaveProcedureName()
        {
            return "";
        }


    }
}
