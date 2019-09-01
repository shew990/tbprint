//************************************************************
//******************************作者：方颖*********************
//******************************时间：2017/6/21 16:37:43*******

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

namespace BILWeb.PickRule
{
    public partial class T_PickRule_DB : BILBasic.Basing.Base_DB<T_PickRuleInfo>
    {

        /// <summary>
        /// 添加t_pickrule
        /// </summary>
        protected override OracleParameter[] GetSaveModelOracleParameter(T_PickRuleInfo t_pickrule)
        {
            //注意!head表ID要填basemodel的headerID new SqlParameter("@CustomerID", DbHelperSQL.ToDBValue(model.HeaderID)),
            throw new NotImplementedException();


        }


        protected override List<string> GetSaveSql(BILBasic.User.UserModel user, ref T_PickRuleInfo model)
        {
            string strSql = string.Empty;
            List<string> lstSql = new List<string>();

            //更新
            if (model.ID > 0)
            {
                strSql = "update t_Pickrule a set a.Materialclasscode = '"+model.MaterialClassCode+"',a.Materialclassname = '"+model.MaterialClassName+"'," +
                        "a.Pickrulecode='"+model.PickRuleCode+"',a.Pickrulename='"+model.PickRuleName+"',a.Note='"+model.Note+"',a.Modifyer = '"+user.UserNo+"' ,a.Modifytime = Sysdate,a.status = '"+model.Status+"'" +
                        "where id = '"+model.ID+"'";
                lstSql.Add(strSql);
            }
            else //插入
            {
                int voucherID = base.GetTableID("Seq_Pickrule_Id");

                model.ID = voucherID;

                strSql = "insert into t_Pickrule(Id, Materialclasscode, Materialclassname, Pickrulecode, Pickrulename, Createtime, Creater, Isdel, Status, Note,RuleType)" +
                         " values('" + voucherID + "','" + model.MaterialClassCode + "','" + model.MaterialClassName + "','" + model.PickRuleCode + "','" + model.PickRuleName + "'," +
                        " Sysdate,'" + user.UserNo + "','1','"+model.Status+"','"+model.Note+"','"+model.RuleType+"')";

                lstSql.Add(strSql);
            }

            return lstSql;
        }


        /// <summary>
        /// 将获取的单条数据转封装成对象返回
        /// </summary>
        protected override T_PickRuleInfo ToModel(OracleDataReader reader)
        {
            T_PickRuleInfo t_pickrule = new T_PickRuleInfo();

            t_pickrule.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();
            t_pickrule.MaterialClassCode = OracleDBHelper.ToModelValue(reader, "MATERIALCLASSCODE").ToDBString();
            t_pickrule.MaterialClassName = OracleDBHelper.ToModelValue(reader, "MATERIALCLASSNAME").ToDBString();
            t_pickrule.PickRuleCode = OracleDBHelper.ToModelValue(reader, "PICKRULECODE").ToInt32();
            t_pickrule.PickRuleName = OracleDBHelper.ToModelValue(reader, "PICKRULENAME").ToDBString();
            t_pickrule.CreateTime = OracleDBHelper.ToModelValue(reader, "CREATETIME").ToDateTime();
            t_pickrule.Creater = OracleDBHelper.ToModelValue(reader, "CREATER").ToDBString();
            t_pickrule.Modifyer = OracleDBHelper.ToModelValue(reader, "MODIFYER").ToDBString();
            t_pickrule.ModifyTime = OracleDBHelper.ToModelValue(reader, "MODIFYTIME").ToDateTime();
            t_pickrule.IsDel = OracleDBHelper.ToModelValue(reader, "ISDEL").ToInt32();
            t_pickrule.Status = OracleDBHelper.ToModelValue(reader, "STATUS").ToInt32();

            t_pickrule.StrCreater = OracleDBHelper.ToModelValue(reader, "STRCREATER").ToDBString();
            t_pickrule.StrStatus = OracleDBHelper.ToModelValue(reader, "StrStatus").ToDBString();

            t_pickrule.ParameterIDN = OracleDBHelper.ToModelValue(reader, "ParameterIDN").ToDBString();

            t_pickrule.RuleType = OracleDBHelper.ToModelValue(reader, "RuleType").ToInt32();

            return t_pickrule;
        }

        protected override string GetViewName()
        {
            return "V_PICKRULE";
        }

        protected override string GetTableName()
        {
            return "T_PICKRULE";
        }

        protected override string GetSaveProcedureName()
        {
            return "";
        }


        protected override string GetFilterSql(BILBasic.User.UserModel user, T_PickRuleInfo model)
        {
            string strSql = base.GetFilterSql(user, model);
            string strAnd = " and ";
           

            if (!string.IsNullOrEmpty(model.MaterialClassName))
            {
                strSql += strAnd;
                strSql += " (MaterialClassCode Like '" + model.MaterialClassName + "%'  or MaterialClassName Like '" + model.MaterialClassName + "%' )";
            }

            if (!string.IsNullOrEmpty(model.PickRuleName))
            {
                strSql += strAnd;
                strSql += " (PickRuleCode Like '" + model.PickRuleCode + "%'  or PickRuleName Like '" + model.PickRuleName + "%' )";
            }

            if (model.RuleType > 0)
            {
                strSql += strAnd;
                strSql += " RuleType = '" + model.RuleType + "'";
            }

            return strSql ;
        }

        protected override List<string> GetDeleteSql(BILBasic.User.UserModel user, T_PickRuleInfo model)
        {
            List<string> lstSql = new List<string>();
            string strSql = string.Empty;

            strSql = "delete t_pickrule where id = '" + model.ID + "'";

            lstSql.Add(strSql);

            return lstSql;
        }

        /// <summary>
        /// 获取所有的拣货规则
        /// </summary>
        /// <returns></returns>
        public List<T_PickRuleInfo> GetAllPickRule() 
        {
            string strSql = "select * from v_Pickrule where  nvl(status,0) = 1";
            return base.GetModelListBySql(strSql);
        }


        public List<T_PickRuleInfo> GetPearRuleListByPage(int type)
        {
            T_PickRuleInfo model = new T_PickRuleInfo();
            model.RuleType = type;
            //if (type == 0) 
            //{
            //    model.RuleType = type;
            //}
            BILBasic.Common.DividPage page = null;
            
            return GetModelListByPage(null, model, ref page);
        }

    }
}
