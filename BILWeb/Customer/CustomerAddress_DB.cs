﻿//************************************************************
//******************************作者：方颖*********************
//******************************时间：2017/2/21 10:37:56*******

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess;
using BILBasic.Basing;
using BILBasic.DBA;
using Oracle.ManagedDataAccess.Client;
using BILBasic.Common;
using BILBasic.User;

namespace BILWeb.Customer
{
    public partial class T_CustomerAddress_DB : BILBasic.Basing.Base_DB<T_CustomerAddressInfo>
    {

        /// <summary>
        /// 添加t_customeraddress
        /// </summary>
        protected override OracleParameter[] GetSaveModelOracleParameter(T_CustomerAddressInfo t_customeraddress)
        {
            //注意!head表ID要填basemodel的headerID new SqlParameter("@CustomerID", DbHelperSQL.ToDBValue(model.HeaderID)),
            OracleParameter[] param = new OracleParameter[]{
              new OracleParameter("@bResult",OracleDbType.Int32),
               new OracleParameter("@ErrorMsg",OracleDbType.NVarchar2,1000),
               
               new OracleParameter("@v_ID", OracleDBHelper.ToDBValue(t_customeraddress.ID)),
               new OracleParameter("@v_HeaderID", OracleDBHelper.ToDBValue(t_customeraddress.HeaderID).ToOracleValue()),               
               new OracleParameter("@v_Note", t_customeraddress.Note.ToOracleValue()),
               new OracleParameter("@v_Contactperson", t_customeraddress.ContactPerson.ToOracleValue()),
               new OracleParameter("@v_Contacttel", t_customeraddress.ContactTel.ToOracleValue()),
               new OracleParameter("@v_Mobile", t_customeraddress.Mobile.ToOracleValue()),
               new OracleParameter("@v_Fax", t_customeraddress.Fax.ToOracleValue()),               
               new OracleParameter("@v_Email", t_customeraddress.Email.ToOracleValue()),
               new OracleParameter("@v_Isdel", t_customeraddress.IsDel.ToOracleValue()),
               new OracleParameter("@v_Isdefault", t_customeraddress.IsDefault.ToOracleValue()),
               new OracleParameter("@v_Address", t_customeraddress.Address.ToOracleValue()),
               new OracleParameter("@v_CreateTime", t_customeraddress.CreateTime.ToOracleValue()),
               new OracleParameter("@v_Creater", t_customeraddress.Creater.ToOracleValue()),               
               new OracleParameter("@v_Modifyer", t_customeraddress.Modifyer.ToOracleValue()),
               new OracleParameter("@v_ModifyTime", t_customeraddress.ModifyTime.ToOracleValue())
              
              };
            param[0].Direction = System.Data.ParameterDirection.Output;
            param[1].Direction = System.Data.ParameterDirection.Output;
            param[2].Direction = System.Data.ParameterDirection.InputOutput;
            return param;
        }

        protected override List<string> GetSaveSql(UserModel user, ref T_CustomerAddressInfo model)
        {
 	        throw new System.NotImplementedException();
        } 

        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        protected override T_CustomerAddressInfo ToModel(OracleDataReader reader)
        {
            T_CustomerAddressInfo t_customeraddress = new T_CustomerAddressInfo();

            t_customeraddress.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();
            t_customeraddress.HeaderID = OracleDBHelper.ToModelValue(reader, "HEADERID").ToInt32();
            t_customeraddress.Note = (string)OracleDBHelper.ToModelValue(reader, "NOTE");
            t_customeraddress.ContactPerson = (string)OracleDBHelper.ToModelValue(reader, "CONTACTPERSON");
            t_customeraddress.ContactTel = (string)OracleDBHelper.ToModelValue(reader, "CONTACTTEL");
            t_customeraddress.Mobile = (string)OracleDBHelper.ToModelValue(reader, "MOBILE");
            t_customeraddress.Fax = (string)OracleDBHelper.ToModelValue(reader, "FAX");
            t_customeraddress.Email = (string)OracleDBHelper.ToModelValue(reader, "EMAIL");
            t_customeraddress.IsDel = (decimal?)OracleDBHelper.ToModelValue(reader, "ISDEL");
            t_customeraddress.Creater = (string)OracleDBHelper.ToModelValue(reader, "CREATER");
            t_customeraddress.CreateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CREATERTIME");
            t_customeraddress.Modifyer = (string)OracleDBHelper.ToModelValue(reader, "MODIFYER");
            t_customeraddress.ModifyTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "MODIFYTIME");
            t_customeraddress.IsDefault = (decimal?)OracleDBHelper.ToModelValue(reader, "ISDEFAULT");
            t_customeraddress.Address = (string)OracleDBHelper.ToModelValue(reader, "ADDRESS");
            return t_customeraddress;
        }

        protected override string GetViewName()
        {
            return "V_CUSTOMERADDRESS";
        }

        protected override string GetTableName()
        {
            return "T_CUSTOMERADDRESS";
        }

        protected override string GetSaveProcedureName()
        {
            return "P_SAVE_T_CUSTOMERADDRESS";
        }

        protected override string GetDeleteProcedureName()
        {
            return "P_Delete_T_CUSTOMERADDRESS";
        }


    }
}
