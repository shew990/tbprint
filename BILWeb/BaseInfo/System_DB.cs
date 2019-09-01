﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess;
using BILBasic.Basing;
using BILBasic.DBA;
using Oracle.ManagedDataAccess.Client;
using BILBasic.User;
using BILBasic.Common;
using BILWeb.BaseInfo;
using BILWeb.Query;

namespace BILWeb.BaseInfo
{
    public partial class T_System_DB
    {

        private int GetID()
        {
            object id = OracleDBHelper.ExecuteScalar(System.Data.CommandType.Text, "SELECT MAX(ID) FROM T_System");

            if (id == DBNull.Value)
                return 1;
            else
                return Convert.ToInt32(id) + 1;
        }

        public bool SaveData(T_System model, ref string ErrMsg)
        {
            try
            {
                string strSql = String.Empty;               

                if (model.id == 0)
                {
                    int id = GetID();
                    strSql = "insert into T_System (id, filepath, companyname,remark, remark1, remark2, remark3, remark4, remark5, remark6, remark7, remark8, remark9)" +
                                "values ('" + id + "', '"
                                + model.filepath + "','" 
                                + model.companyname + "','" 
                                + model.remark + "','"
                                + model.remark1 + "','" 
                                + model.remark2 + "','" 
                                + model.remark3 + "','"
                                + model.remark4 + "','"
                                + model.remark5 + "','"
                                + model.remark6 + "','"
                                + model.remark7 + "','"
                                + model.remark8 + "','"
                                + model.remark9 + "' )";
                }
                else
                {
                    strSql = "update T_System a set a.filepath = '" + model.filepath + "',a.companyname =  '" + model.companyname + "',a.remark= '" + model.remark + "',a.remark1= '" + model.remark1
                        + "',a.remark2= '" + model.remark2 + "',a.remark3= '" + model.remark3 + "',a.remark4= '" + model.remark4 + "',a.remark5= '" + model.remark5
                        + "',a.remark6= '" + model.remark6 + "',a.remark7 = '" + model.remark7 + "' ,a.remark8 = '" + model.remark8 + "' ,a.remark9= '" + model.remark9 + "' where a.Id = '" + model.id + "'";
                    
                }

                int i = OracleDBHelper.ExecuteNonQuery(System.Data.CommandType.Text, strSql);
                if (i == -2)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                return false;
            }
        }


        public List<T_System> GetModel()
        {
            string strSql = "select * from T_System";
            try
            {
                using (OracleDataReader reader = OracleDBHelper.ExecuteReader(strSql))
                {
                    return ToModels(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 将获取的多条数据转换成对象并添加到泛型集合返回
        /// </summary>
        protected List<T_System> ToModels(OracleDataReader reader)
        {
            var list = new List<T_System>();
            while (reader.Read())
            {
                list.Add(ToModel(reader));
            }
            return list;
        }

        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        private T_System ToModel(OracleDataReader reader)
        {
            T_System model = new T_System();

            model.id = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();
            model.filepath = OracleDBHelper.ToModelValue(reader, "filepath").ToDBString();
            model.companyname = OracleDBHelper.ToModelValue(reader, "companyname").ToDBString();
            model.remark = OracleDBHelper.ToModelValue(reader, "remark").ToDBString();
            model.remark1 = OracleDBHelper.ToModelValue(reader, "remark1").ToDBString();
            model.remark2 = OracleDBHelper.ToModelValue(reader, "remark2").ToDBString();
            model.remark3 = OracleDBHelper.ToModelValue(reader, "remark3").ToDBString();
            model.remark4 = OracleDBHelper.ToModelValue(reader, "remark4").ToDBString();
            model.remark5 = OracleDBHelper.ToModelValue(reader, "remark5").ToDBString();
            model.remark6 = OracleDBHelper.ToModelValue(reader, "remark6").ToDBString();
            model.remark7 = OracleDBHelper.ToModelValue(reader, "remark7").ToDBString();
            model.remark8 = OracleDBHelper.ToModelValue(reader, "remark8").ToDBString();
            model.remark9 = OracleDBHelper.ToModelValue(reader, "remark9").ToDBString();
            return model;
        }
    }
}