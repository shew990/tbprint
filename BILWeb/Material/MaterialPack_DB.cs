using BILBasic.DBA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILBasic.Common;
using BILBasic.User;

namespace BILWeb.Material
{
    public partial class MaterialPack_DB : BILBasic.Basing.Base_DB<MaterialPack_Model>
    {
        protected override Oracle.ManagedDataAccess.Client.OracleParameter[] GetSaveModelOracleParameter(MaterialPack_Model model)
        {
            throw new NotImplementedException();
        }

        protected override MaterialPack_Model ToModel(Oracle.ManagedDataAccess.Client.OracleDataReader reader)
        {
            MaterialPack_Model materialPack = new MaterialPack_Model();

            materialPack.ID = OracleDBHelper.ToModelValue(reader, "ID").ToInt32();
            materialPack.HeaderID = OracleDBHelper.ToModelValue(reader, "HeaderID").ToInt32();
            materialPack.MATERIALNO = (string)OracleDBHelper.ToModelValue(reader, "MATERIALNO");
            materialPack.MATERIALDESC = (string)OracleDBHelper.ToModelValue(reader, "MATERIALDESC");
            materialPack.QUALITYDAY = OracleDBHelper.ToModelValue(reader, "QUALITYDAY").ToInt32();
            materialPack.QUALITYMON = OracleDBHelper.ToModelValue(reader, "QUALITYMON").ToInt32();
            materialPack.QTY = OracleDBHelper.ToModelValue(reader, "QTY").ToInt32();
            materialPack.UNIT = (string)OracleDBHelper.ToModelValue(reader, "UNIT");
            materialPack.WATERCODE = (string)OracleDBHelper.ToModelValue(reader, "WATERCODE");
            materialPack.ISDEL = OracleDBHelper.ToModelValue(reader, "ISDEL").ToInt32();
            materialPack.StrongHoldCode = (string)OracleDBHelper.ToModelValue(reader, "STRONGHOLDNAME");
            materialPack.StrongHoldName = (string)OracleDBHelper.ToModelValue(reader, "STRONGHOLDCODE");
            materialPack.CompanyCode = (string)OracleDBHelper.ToModelValue(reader, "COMPANYCODE");
            materialPack.UNITNUM = Convert.ToDecimal(OracleDBHelper.ToModelValue(reader, "UNITNUM"));
            return materialPack;

        }

        protected override string GetFilterSql(UserModel user, MaterialPack_Model model)
        {

            string strSql = string.Empty;
            string strAnd = " and ";
            strSql += base.GetFilterSql(user, model);
            if (!Common_Func.IsNullOrEmpty(model.WATERCODE))
            {
                strSql += strAnd;
                strSql += " (WATERCODE = '" + model.WATERCODE + "' ) ";
            }

            if (!Common_Func.IsNullOrEmpty(model.StrongHoldCode))
            {
                strSql += strAnd;
                strSql += " (StrongHoldCode = '" + model.StrongHoldCode + "' ) ";
            }
            return strSql;
        }
        protected override string GetViewName()
        {
            return "V_MaterialPack";
        }

        protected override string GetTableName()
        {
            return "t_material_pack";
        }

        protected override string GetSaveProcedureName()
        {
            throw new NotImplementedException();
        }

        protected override List<string> GetSaveSql(BILBasic.User.UserModel user, ref MaterialPack_Model model)
        {
            throw new NotImplementedException();
        }


        public string GetQUALITYDAY(string materialno,ref string strError)
        {
            strError = "";
            try
            {
                string strSql = "select QUALITYDAY from V_MaterialPack where materialno='"+ materialno + "'";
                return GetScalarBySql(strSql).ToString();
            }
            catch (Exception ex)
            {
                strError = ex.Message + ex.TargetSite;
                return "";
            }
        }

    }
}
