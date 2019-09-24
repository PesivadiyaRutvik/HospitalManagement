using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace DailyFieldReport.DAL
{
    public class DataBaseConfig
    {
        public string myConnectionString = ConfigurationManager.ConnectionStrings["HospitalManagementConnectionString"].ConnectionString;

        public string GetErrorMessage(int Error)
        {
            return "";
        }

        public string Error547 = "This record cannot be inserted or deleted.\n Violation of foreignkey";
        public string Error547Delete = "This record cannot be inserted or deleted.\n Violation of foreignkey";
        public string Error2627 = "Duplicate value cannot be inserted.\nViolation of uniqueness.";
        public string Error2601 = "Duplicate value cannot be inserted.\nViolation of uniqueness.";
        public string SQLDataExceptionMessage(SqlException sqlex)
        {
            switch (sqlex.Number)
            {
                case 17:
                    //     SQL Server does not exist or access denied. 
                    return "SQL Server does not exist or access denied.";
                //case 4060:
                //    // Invalid Database  
                //    return "Invalid Database";
                case 18456:
                    // Login Failed 
                    return "Login Failed ";
                case 547:
                    // ForeignKey Violation 
                    return Error547;
                case 2627:
                    // Unique Index/Constriant Violation 
                    return Error2627;
                case 2601:
                    // Unique Index/Constriant Violation 
                    return Error2601;
                default:
                    // throw a general DAL Exception 
                    return sqlex.Message;
            }
        }
        //public string SQLDataExceptionHandler(SqlException sqlex, string Operation)
        //{
        //    switch (sqlex.Number)
        //    {
        //        case 17:
        //            //     SQL Server does not exist or access denied. 
        //            return "SQL Server does not exist or access denied.";
        //        //case 4060:
        //        //    // Invalid Database  
        //        //    return "Invalid Database";
        //        case 18456:
        //            // Login Failed 
        //            return "Login Failed ";
        //        case 547:
        //            // ForeignKey Violation 
        //            if (Operation == "Delete")
        //                return Error547Delete;
        //            else
        //                return Error547;
        //        case 2627:
        //            // Unique Index/Constriant Violation 
        //            return Error2627;
        //        case 2601:
        //            // Unique Index/Constriant Violation 
        //            return Error2601;
        //        default:
        //            // throw a general DAL Exception 
        //            return sqlex.Message;
        //    }
        //}

        public Boolean SQLDataExceptionHandler(SqlException sqlex)
        {
            #region Log DataBase Error in File
            //DirectoryInfo di = new DirectoryInfo("ErrorFiles");
            //if (!di.Exists)
            //    di.Create();
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine("DateTime=" + DateTime.Now.ToString());
            ////sb.AppendLine("UserID=" + 1.ToString());
            //sb.AppendLine("Message=" + sqlex.Message.ToString());
            //sb.AppendLine("Number=" + sqlex.Number.ToString());
            //if (sqlex.Procedure != null)
            //    sb.AppendLine("Procedure=" + sqlex.Procedure.ToString());
            //if (sqlex.Server != null)
            //    sb.AppendLine("Server=" + sqlex.Server.ToString());
            //sb.AppendLine("ErrorCode=" + sqlex.ErrorCode.ToString());
            //sb.AppendLine("LineNumber=" + sqlex.LineNumber.ToString());
            //sb.AppendLine("State=" + sqlex.State.ToString());
            //if (sqlex.TargetSite != null)
            //    sb.AppendLine("TargetSite=" + sqlex.TargetSite.ToString());
            //sb.AppendLine("Class=" + sqlex.Class.ToString());
            //if (sqlex.Source != null)
            //    sb.AppendLine("Source=" + sqlex.Source.ToString());
            //if (sqlex.StackTrace != null)
            //    sb.AppendLine("StackTrace=" + sqlex.StackTrace.ToString());
            //if (sqlex.InnerException != null)
            //{
            //    sb.AppendLine("Inner Exception");
            //    sb.AppendLine("Message=" + sqlex.InnerException.Message.ToString());
            //    sb.AppendLine("Source=" + sqlex.InnerException.Source.ToString());
            //    sb.AppendLine("");
            //}
            //foreach (SqlError sqlerror in sqlex.Errors)
            //{
            //    sb.AppendLine("Message=" + sqlerror.Message.ToString());
            //    sb.AppendLine("Number=" + sqlerror.Number.ToString());
            //    if (sqlex.Procedure != null)
            //        sb.AppendLine("Procedure=" + sqlex.Procedure.ToString());
            //    if (sqlex.Server != null)
            //        sb.AppendLine("Server=" + sqlex.Server.ToString());
            //    sb.AppendLine("ErrorCode=" + sqlex.ErrorCode.ToString());
            //    sb.AppendLine("LineNumber=" + sqlex.LineNumber.ToString());
            //    sb.AppendLine("State=" + sqlex.State.ToString());
            //    if (sqlex.TargetSite != null)
            //        sb.AppendLine("TargetSite=" + sqlex.TargetSite.ToString());
            //    sb.AppendLine("Class=" + sqlex.Class.ToString());
            //    if (sqlex.Source != null)
            //        sb.AppendLine("Source=" + sqlex.Source.ToString());
            //    if (sqlex.StackTrace != null)
            //        sb.AppendLine("StackTrace=" + sqlex.StackTrace.ToString());
            //}
            //StreamWriter sw;
            //sw = File.CreateText("ErrorFiles\\" + DateTime.Now.ToString("yyMMdd_HHmmss") + ".txt");
            //sw.Write(sb.ToString());
            //sw.Close();
            #endregion Log DataBase Error in File

            //return false;
            return true;

        }
        public bool SQLDataExceptionLogger(SqlException sqlex)
        {
            return false;
            switch (sqlex.Number)
            {
                case 17:
                    //     SQL Server does not exist or access denied. 
                    return ExceptionPolicy.HandleException(sqlex, "SQLError17");
                //case 4060:
                // Invalid Database  
                //     return ExceptionPolicy.HandleException(sqlex, "SQLError4060");
                case 18456:
                    // Login Failed 
                    return ExceptionPolicy.HandleException(sqlex, "SQLError18456");
                case 547:
                    // ForeignKey Violation 
                    return ExceptionPolicy.HandleException(sqlex, "SQLError547");
                case 2627:
                    // Unique Index/Constriant Violation 
                    return ExceptionPolicy.HandleException(sqlex, "SQLError2627");
                case 2601:
                    // Unique Index/Constriant Violation 
                    return ExceptionPolicy.HandleException(sqlex, "SQLError2601");
                default:
                    // throw a general DAL Exception 
                    return ExceptionPolicy.HandleException(sqlex, "SQLError");
            }
        }
        public string ExceptionMessage(Exception ex)
        {
            return "";
        }
        public Boolean ExceptionHandler(Exception ex)
        {
            return true;
        }
    }
}
