using DailyFieldReport.DAL;
using DailyFieldReport.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace DailyFieldReport.BAL
{

    public abstract class MST_CityBALBase
    {
        #region Private Fields

		private string _Message;

		#endregion Private Fields

		#region Public Properties

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

		#endregion Public Properties

		#region Constructor

        public MST_CityBALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

        public Boolean Insert(MST_CityENT entLOC_City)
		{
            MST_CityDAL dalLOC_City = new MST_CityDAL();
            if (dalLOC_City.Insert(entLOC_City))
			{
				return true;
			}
			else
			{
                this.Message = dalLOC_City.Message;
				return false;
			}
		}

		#endregion InsertOperation

		#region UpdateOperation

        public Boolean Update(MST_CityENT entLOC_City)
		{
            MST_CityDAL dalLOC_City = new MST_CityDAL();
            if (dalLOC_City.Update(entLOC_City))
			{
				return true;
			}
			else
			{
                this.Message = dalLOC_City.Message;
				return false;
			}
		}

		#endregion UpdateOperation

		#region DeleteOperation

		public Boolean Delete(SqlInt32 CityID)
		{
            MST_CityDAL dalLOC_City = new MST_CityDAL();
            if (dalLOC_City.Delete(CityID))
			{
				return true;
			}
			else
			{
                this.Message = dalLOC_City.Message;
				return false;
			}
		}

		#endregion DeleteOperation

		#region SelectOperation

        public MST_CityENT SelectPK(SqlInt32 CityID)
		{
            MST_CityDAL dalLOC_City = new MST_CityDAL();
            return dalLOC_City.SelectPK(CityID);
		}
		public DataTable SelectView(SqlInt32 CityID)
		{
            MST_CityDAL dalLOC_City = new MST_CityDAL();
            return dalLOC_City.SelectView(CityID);
		}
		public DataTable SelectAll()
		{
            MST_CityDAL dalLOC_City = new MST_CityDAL();
            return dalLOC_City.SelectAll();
		}
        //public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString ActivityName, SqlString ActivityCode, SqlInt32 DisciplineID)
        //{
        //    MST_ActivityDAL dalMST_Activity = new MST_ActivityDAL();
        //    return dalMST_Activity.SelectPage(PageOffset, PageSize, out TotalRecords, ActivityName, ActivityCode, DisciplineID);
        //}

		#endregion SelectOperation
    }
}