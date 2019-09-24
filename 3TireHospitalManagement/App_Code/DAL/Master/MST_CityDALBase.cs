using DailyFieldReport.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace DailyFieldReport.DAL
{
    public abstract class MST_CityDALBase : DataBaseConfig
    {
        #region Properties

		private string _Message;
		public string Message
		{
			get
			{
				return _Message;
			}
			set
			{
				_Message = value;
			}
		}

		#endregion Properties

		#region Constructor

        public MST_CityDALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

        public Boolean Insert(MST_CityENT entLOC_City)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_City_Insert");

				sqlDB.AddOutParameter(dbCMD, "@CityID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@CityName", SqlDbType.VarChar, entLOC_City.CityName);

                sqlDB.AddInParameter(dbCMD, "@CreationDate", SqlDbType.DateTime, entLOC_City.CreationDate);
				

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entLOC_City.CityID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@CityID"].Value);

				return true;
			}
			catch (SqlException sqlex)
			{
				Message = SQLDataExceptionMessage(sqlex);
				if (SQLDataExceptionHandler(sqlex))
					throw;
				return false;
			}
			catch (Exception ex)
			{
				Message = ExceptionMessage(ex);
				if (ExceptionHandler(ex))
					throw;
				return false;
			}
		}

		#endregion InsertOperation

		#region UpdateOperation

        public Boolean Update(MST_CityENT entLOC_City)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_City_UpdateByPK");

                sqlDB.AddInParameter(dbCMD, "@CityID", SqlDbType.Int, entLOC_City.CityID);
                sqlDB.AddInParameter(dbCMD, "@CityName", SqlDbType.VarChar, entLOC_City.CityName);

                //sqlDB.AddInParameter(dbCMD, "@CreationDate", SqlDbType.DateTime, entLOC_City.CreationDate);
				

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.ExecuteNonQuery(sqlDB, dbCMD);

				return true;
			}
			catch (SqlException sqlex)
			{
				Message = SQLDataExceptionMessage(sqlex);
				if (SQLDataExceptionHandler(sqlex))
					throw;
				return false;
			}
			catch (Exception ex)
			{
				Message = ExceptionMessage(ex);
				if (ExceptionHandler(ex))
					throw;
				return false;
			}
		}

		#endregion UpdateOperation

		#region DeleteOperation

        public Boolean Delete(SqlInt32 CityID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_City_DeletePK");

                sqlDB.AddInParameter(dbCMD, "@CityID", SqlDbType.Int, CityID);

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.ExecuteNonQuery(sqlDB, dbCMD);

				return true;
			}
			catch (SqlException sqlex)
			{
				Message = SQLDataExceptionMessage(sqlex);
				if (SQLDataExceptionHandler(sqlex))
					throw;
				return false;
			}
			catch (Exception ex)
			{
				Message = ExceptionMessage(ex);
				if (ExceptionHandler(ex))
					throw;
				return false;
			}
		}

		#endregion DeleteOperation

		#region SelectOperation

		public MST_CityENT SelectPK(SqlInt32 CityID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_City_SelectByPK");

                sqlDB.AddInParameter(dbCMD, "@CityID", SqlDbType.Int, CityID);

                MST_CityENT entLOC_City = new MST_CityENT();
				DataBaseHelper DBH = new DataBaseHelper();
				using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
				{
					while (dr.Read())
					{
                        if (!dr["CityID"].Equals(System.DBNull.Value))
                            entLOC_City.CityID = Convert.ToInt32(dr["CityID"]);

						if(!dr["CityName"].Equals(System.DBNull.Value))
                            entLOC_City.CityName = Convert.ToString(dr["CityName"]);

                        if (!dr["CreationDate"].Equals(System.DBNull.Value))
                            entLOC_City.CreationDate = Convert.ToDateTime(dr["CreationDate"]);

					

					}
				}
                return entLOC_City;
			}
			catch (SqlException sqlex)
			{
				Message = SQLDataExceptionMessage(sqlex);
				if (SQLDataExceptionHandler(sqlex))
					throw;
				return null;
			}
			catch (Exception ex)
			{
				Message = ExceptionMessage(ex);
				if (ExceptionHandler(ex))
					throw;
				return null;
			}
		}
		public DataTable SelectView(SqlInt32 ActivityID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Activity_SelectView");

				sqlDB.AddInParameter(dbCMD, "@ActivityID", SqlDbType.Int, ActivityID);

				DataTable dtMST_Activity = new DataTable("PR_MST_Activity_SelectView");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Activity);

				return dtMST_Activity;
			}
			catch (SqlException sqlex)
			{
				Message = SQLDataExceptionMessage(sqlex);
				if (SQLDataExceptionHandler(sqlex))
					throw;
				return null;
			}
			catch (Exception ex)
			{
				Message = ExceptionMessage(ex);
				if (ExceptionHandler(ex))
					throw;
				return null;
			}
		}
		public DataTable SelectAll()
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_City_SelectAll");

                DataTable dtMST_Activity = new DataTable("PR_LOC_City_SelectAll");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Activity);

				return dtMST_Activity;
			}
			catch (SqlException sqlex)
			{
				Message = SQLDataExceptionMessage(sqlex);
				if (SQLDataExceptionHandler(sqlex))
					throw;
				return null;
			}
			catch (Exception ex)
			{
				Message = ExceptionMessage(ex);
				if (ExceptionHandler(ex))
					throw;
				return null;
			}
		}
		public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString ActivityName, SqlString ActivityCode, SqlInt32 DisciplineID)
		{
			TotalRecords = 0;
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Activity_SelectPage");
				sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
				sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
				sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@ActivityName", SqlDbType.NVarChar, ActivityName);
                sqlDB.AddInParameter(dbCMD, "@ActivityCode", SqlDbType.NVarChar, ActivityCode);
                sqlDB.AddInParameter(dbCMD, "@DisciplineID", SqlDbType.Int, DisciplineID);

				DataTable dtMST_Activity = new DataTable("PR_MST_Activity_SelectPage");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Activity);

				TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

				return dtMST_Activity;
			}
			catch (SqlException sqlex)
			{
				Message = SQLDataExceptionMessage(sqlex);
				if (SQLDataExceptionHandler(sqlex))
					throw;
				return null;
			}
			catch (Exception ex)
			{
				Message = ExceptionMessage(ex);
				if (ExceptionHandler(ex))
					throw;
				return null;
			}
		}

		#endregion SelectOperation

		#region ComboBox


		#endregion ComboBox

		#region AutoComplete


		#endregion AutoComplete
    }
}