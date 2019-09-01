using BILBasic.DBA;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BILWeb.AppVersion
{
    public class AppVersion_DB
    {
        internal OracleDataReader GetAppVersionByVersion(AppVersionInfo model)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT * FROM T_AppVersionLog WHERE AppName = '{0}' AND AppVersion = '{1}' ", model.AppName, model.AppVersion);

            return OracleDBHelper.ExecuteReader(CommandType.Text, strSql, null);
        }
    }
}
