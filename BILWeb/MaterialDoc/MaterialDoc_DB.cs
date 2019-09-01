//************************************************************
//******************************作者：方颖*********************
//******************************时间：2017/3/29 13:51:01*******

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

namespace BILWeb.MaterialDoc
{
    public partial class T_Material_Doc_DB : BILBasic.Basing.Base_DB<T_MaterialDoc_Info>
    {
        /// <summary>
        /// 添加t_material_doc
        /// </summary>
        protected override OracleParameter[] GetSaveModelOracleParameter(T_MaterialDoc_Info t_material_doc)
        {
            //注意!head表ID要填basemodel的headerID new SqlParameter("@CustomerID", DbHelperSQL.ToDBValue(model.HeaderID)),
            throw new NotImplementedException();
        }

        protected override List<string> GetSaveSql(BILBasic.User.UserModel user, ref T_MaterialDoc_Info model)
        {
            throw new NotImplementedException();
        }




        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        protected override T_MaterialDoc_Info ToModel(OracleDataReader reader)
        {
            T_MaterialDoc_Info t_material_doc = new T_MaterialDoc_Info();

            t_material_doc.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();
            t_material_doc.MaterialDoc = (string)OracleDBHelper.ToModelValue(reader, "MATERIALDOC");
            t_material_doc.DocDate = (DateTime?)OracleDBHelper.ToModelValue(reader, "DOCDATE");
            t_material_doc.PostDate = (DateTime?)OracleDBHelper.ToModelValue(reader, "POSTDATE");
            t_material_doc.InOutStockID = OracleDBHelper.ToModelValue(reader, "INOUTSTOCKID").ToInt32();
            t_material_doc.TaskID = OracleDBHelper.ToModelValue(reader, "TASKID").ToInt32();
            t_material_doc.MaterialDocType = OracleDBHelper.ToModelValue(reader, "MATERIALDOCTYPE").ToInt32();
            t_material_doc.TaskType = OracleDBHelper.ToModelValue(reader, "TASKTYPE").ToInt32();
            t_material_doc.TimeStampPost = (string)OracleDBHelper.ToModelValue(reader, "TIMESTAMPPOST");
            t_material_doc.IsDel = OracleDBHelper.ToModelValue(reader, "ISDEL").ToInt32();
            t_material_doc.Creater = (string)OracleDBHelper.ToModelValue(reader, "CREATER");
            t_material_doc.CreateTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "CREATETIME");
            t_material_doc.Modifyer = (string)OracleDBHelper.ToModelValue(reader, "MODIFYER");
            t_material_doc.ModifyTime = (DateTime?)OracleDBHelper.ToModelValue(reader, "MODIFYTIME");
            return t_material_doc;
        }

        protected override string GetViewName()
        {
            return "";
        }

        protected override string GetTableName()
        {
            return "T_MATERIAL_DOC";
        }

        protected override string GetSaveProcedureName()
        {
            return "";
        }


    }
}
