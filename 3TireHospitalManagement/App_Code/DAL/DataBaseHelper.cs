using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.SqlTypes;

namespace DailyFieldReport.DAL
{
    public class DataBaseHelper
    {
        Int32 CommandTimeOutSecond = 180;
        public DataBaseHelper()
        {

        }

        public Int32 ExecuteNonQuery(SqlDatabase sqlDB, DbCommand dbCMD)
        {
            dbCMD.CommandTimeout = CommandTimeOutSecond;
            return sqlDB.ExecuteNonQuery(dbCMD);
        }

        public DataTable LoadDataTable(SqlDatabase sqlDB, DbCommand dbCMD, DataTable dt)
        {
            dbCMD.CommandTimeout = CommandTimeOutSecond;
            using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
            {
                dt.Load(dr);
            }
            return dt;
        }

        public IDataReader ExecuteReader(SqlDatabase sqlDB, DbCommand dbCMD)
        {
            dbCMD.CommandTimeout = CommandTimeOutSecond;
            return sqlDB.ExecuteReader(dbCMD);
        }

        public SqlInt32 ExecuteScalar_Int32(SqlDatabase sqlDB, DbCommand dbCMD)
        {
            dbCMD.CommandTimeout = CommandTimeOutSecond;
            return Convert.ToInt32(sqlDB.ExecuteScalar(dbCMD));
        }

        public SqlBoolean ExecuteScalar_Boolean(SqlDatabase sqlDB, DbCommand dbCMD)
        {
            dbCMD.CommandTimeout = CommandTimeOutSecond;
            return Convert.ToBoolean(sqlDB.ExecuteScalar(dbCMD));
        }

        public SqlString ExecuteScalar_String(SqlDatabase sqlDB, DbCommand dbCMD)
        {
            dbCMD.CommandTimeout = CommandTimeOutSecond;
            return Convert.ToString(sqlDB.ExecuteScalar(dbCMD));
        }

        public object ExecuteScalar_object(SqlDatabase sqlDB, DbCommand dbCMD)
        {
            dbCMD.CommandTimeout = CommandTimeOutSecond;
            return sqlDB.ExecuteScalar(dbCMD);
        }
        public DataSet ExecuteDataSet(SqlDatabase sqlDB, DbCommand dbCMD)
        {
            dbCMD.CommandTimeout = CommandTimeOutSecond;
            return sqlDB.ExecuteDataSet(dbCMD);
        }

        public DataTable ExecuteQuery(SqlDatabase sqlDB, DbCommand dbCMD, String Query)
        {
            dbCMD.CommandTimeout = CommandTimeOutSecond;
            DataTable dt = new DataTable();
            dbCMD.CommandType = CommandType.Text;
            dbCMD.CommandText = Query;
            using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
            {
                dt.Load(dr);
            }
            return dt;
        }
    }
}
