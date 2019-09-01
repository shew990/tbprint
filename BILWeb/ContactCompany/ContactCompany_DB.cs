﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILBasic.Common;
using BILBasic.DBA;
using BILBasic.User;
using Oracle.ManagedDataAccess.Client;

namespace BILWeb.ContactCompany
{
    public partial class T_ContactCompany_DB : BILBasic.Basing.Base_DB<T_ContactCompanyInfo>
    {

        /// <summary>
        /// 添加t_contactcompany
        /// </summary>
        protected override OracleParameter[] GetSaveModelOracleParameter(T_ContactCompanyInfo t_contactcompany)
        {
            //注意!head表ID要填basemodel的headerID new SqlParameter("@CustomerID", DbHelperSQL.ToDBValue(model.HeaderID)),
            throw new NotImplementedException();


        }

        protected override List<string> GetSaveSql(UserModel user,ref   T_ContactCompanyInfo model)
        {
            List<string> lstSql = new List<string>();
            string strSql = string.Empty;

            if (model.ID <= 0)
            {
                strSql = "insert into T_CONTACTCOMPANY (id, companycode, companyname, companynameen, companytype, country, province, city, creater, createtime)" +
                        "values (seq_contactcompany.Nextval, '" + model.CompanyCode + "', '" + model.CompanyName + "', '" + model.CompanyNameEN + "', '" + model.CompanyType + "', '" + model.Country + "', "+
                        "'" + model.Province + "', '" + model.City + "', '" + user.Creater + "', sysdate)";
                lstSql.Add(strSql);
            }
            else
            {
                strSql = "update t_Contactcompany a set a.Companycode='" + model.CompanyCode + "',a.Companyname='" + model.CompanyName + "',a.Companynameen='" + model.CompanyNameEN + "',a.Companytype='" + model.CompanyType + "',a.Country='" + model.Country + "',a.Province='" + model.Province + "'," +
                        "a.City='" + model.City + "',a.Modifyer='" + user.Modifyer + "',a.Modifytime=Sysdate where id = '"+model.ID+"'";
                lstSql.Add(strSql);
            }

            return lstSql;
        }

        protected override List<string> GetDeleteSql(UserModel user, T_ContactCompanyInfo model)
        {
            List<string> lstSql = new List<string>();
            string strSql = string.Empty;

            strSql = "delete t_Contactcompany where id = '" + model.ID + "'";

            lstSql.Add(strSql);

            return lstSql;
        }


        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        protected override T_ContactCompanyInfo ToModel(OracleDataReader reader)
        {
            T_ContactCompanyInfo t_contactcompany = new T_ContactCompanyInfo();

            t_contactcompany.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();
            t_contactcompany.CompanyCode = (string)OracleDBHelper.ToModelValue(reader, "COMPANYCODE");
            t_contactcompany.CompanyName = (string)OracleDBHelper.ToModelValue(reader, "COMPANYNAME");
            t_contactcompany.CompanyNameEN = (string)OracleDBHelper.ToModelValue(reader, "COMPANYNAMEEN");
            t_contactcompany.CompanyType = (decimal?)OracleDBHelper.ToModelValue(reader, "COMPANYTYPE");
            t_contactcompany.Country = (string)OracleDBHelper.ToModelValue(reader, "COUNTRY");
            t_contactcompany.Province = (string)OracleDBHelper.ToModelValue(reader, "PROVINCE");
            t_contactcompany.City = (string)OracleDBHelper.ToModelValue(reader, "CITY");
            t_contactcompany.Creater = (string)OracleDBHelper.ToModelValue(reader, "CREATER");
            t_contactcompany.CreateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CREATETIME");
            t_contactcompany.Modifyer = (string)OracleDBHelper.ToModelValue(reader, "MODIFYER");
            t_contactcompany.ModifyTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "MODIFYTIME");
            return t_contactcompany;
        }

        protected override string GetViewName()
        {
            return "v_contactcompany";
        }

        protected override string GetTableName()
        {
            return "T_CONTACTCOMPANY";
        }

        protected override string GetSaveProcedureName()
        {
            return "";
        }


    }
}
