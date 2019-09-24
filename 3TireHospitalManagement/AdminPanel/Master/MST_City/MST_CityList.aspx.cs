using DailyFieldReport.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_MST_MST_CityList : System.Web.UI.Page
{  
    #region 11.0 Variables


    #endregion 11.0 Variables

    #region 12.0 Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {
        #region 12.0 Check User Login

        //if (Session["UserID"] == null)
        //    Response.Redirect(CV.LoginPageURL);

        #endregion 12.0 Check User Login

        if (!Page.IsPostBack)
        {
            #region 12.1 DropDown List Fill Section

            FillCityGridView();

            #endregion 12.1 DropDown List Fill Section

            #region 12.2 Set Default Value

            //lblSearchHeader.Text = CV.SearchHeaderText;
            //lblSearchResultHeader.Text = CV.SearchResultHeaderText;
            //upr.DisplayAfter = CV.UpdateProgressDisplayAfter;

            //Search(1);

            #endregion 12.2 Set Default Value

            #region 12.3 Set Help Text
            // ucHelp.ShowHelp("Help Text will be shown here");
            #endregion 12.3 Set Help Text
        }
    }

    #endregion 12.0 Page Load Event

    #region 13.0 FillLabels

    private void FillLabels(String FormName)
    {
    }

    #endregion

    #region 14.0 DropDownList

    #region 14.1 Fill DropDownList



    #endregion 14.1 Fill DropDownList

    #endregion 14.0 DropDownList

    #region 15.0 Search

    #region 15.1 Button Search Click Event


    #endregion 15.1 Button Search Click Event

    #region 15.2 Search Function


    #endregion 15.2 Search Function

    #endregion 15.0 Search

    #region 16.0 Repeater Events

    #region 16.1 Item Command Event

    #region FillCityGridView
    private void FillCityGridView()
    {
        MST_CityBAL balMST_State = new MST_CityBAL();
        gvCity.DataSource = balMST_State.SelectAll(); ;
        gvCity.DataBind();
  
    }
    #endregion FillCityGridView

    #endregion 16.1 Item Command Event

    #endregion 16.0 Repeater Events

    #region 17.0 Pagination

    #region 17.1 Pagination Events

    #region ItemDataBound Event


    #endregion ItemDataBound Event

    #region PageChange Event

    #endregion PageChange Event

    #endregion 17.1 Pagination Events

    #endregion 17.0 Pagination

    #region 18.0 Button Delete Click Event

    #region DeleteCity
    protected void GvCity_ItermCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            try
            {
                MST_CityBAL balMST_City = new MST_CityBAL();
                balMST_City.Delete(Convert.ToInt32(e.CommandArgument));
            }
            catch (Exception ex)
            {
                lblMessege.Text = ex.Message;
            }
            finally
            {
                FillCityGridView();
            }
        }
    }
    #endregion DeleteCity

    #endregion 18.0 Button Delete Click Event

    #region 19.0 Export Data

    #region 19.1 Excel Export Button Click Event

    #endregion 19.1 Excel Export Button Click Event

    #endregion 19.0 Export Data

    #region 20.0 Cancel Button Event

    protected void btnClear_Click(object sender, EventArgs e)
    {
       
    }

    #endregion 20.0 Cancel Button Event

    #region 21.0 ddlPageSize Selected Index Changed Event

   

    #endregion 21.0 ddlPageSize Selected Index Changed Event

    #region 22.0 ClearControls

   

    #endregion 22.0 ClearControls
}
    

   

