using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CityReport.ENT
{
	public abstract class MST_CityENTBase
	{
        #region Properties


        protected SqlInt32 _CityID;
        public SqlInt32 CityID
        {
            get
            {
                return _CityID;
            }
            set
            {
                _CityID = value;
            }
        }

        protected SqlString _CityName;
        public SqlString CityName
        {
            get
            {
                return _CityName;
            }
            set
            {
                _CityName = value;
            }
        }

        protected SqlDateTime _CreationDate;
        public SqlDateTime CreationDate
        {
            get
            {
                return _CreationDate;
            }
            set
            {
                _CreationDate = value;
            }
        }

   

        #endregion Properties

        #region Constructor

        public MST_CityENTBase()
	    {

        }
        #endregion Constructor

        #region ToString

    

        #endregion ToString
    }
}