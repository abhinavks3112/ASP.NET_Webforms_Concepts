using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormBasics
{
    public partial class CascadingDropDownListsWebForm : System.Web.UI.Page
    {
        #region----Private Variables----

        private const string _testDBCSName = "TestDBCS";

        private const string _sp_Name_GetContinents = "spGetContinents";
        private const string _sp_Name_spGetCountriesByContinentId = "spGetCountriesByContinentId";
        private const string _sp_Name_spGetCountriesByContinentId_Args_Name = "@ContinentId";
        private const string _sp_Name_spGetCitiesByCountryId = "spGetCitiesByCountryId";
        private const string _sp_Name_spGetCitiesByCountryId_Args_Name = "@CountryId";

        private const string _select_Continent_Msg = "----Select a Continent----";
        private const string _select_Country_Msg = "----Select a Country----";
        private const string _select_City_Msg = "----Select a City----";
       
        private const int _starting_Index = 0;
        private const string __item_Value_At_Starting_Index = "-1";

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ddlContinents.DataSource = GetData(_sp_Name_GetContinents, null);
                ddlContinents.DataBind();

                // Insert select message at the start of the dropdownlist item
                InsertSelectMessageToDropDownList(ddlContinents, _select_Continent_Msg, __item_Value_At_Starting_Index, _starting_Index);
                InsertSelectMessageToDropDownList(ddlCountries, _select_Country_Msg, __item_Value_At_Starting_Index, _starting_Index);
                InsertSelectMessageToDropDownList(ddlCities, _select_City_Msg, __item_Value_At_Starting_Index, _starting_Index);

                // Initially the dependent dropdownlists should be disabled
                ddlCountries.Enabled = false;
                ddlCities.Enabled = false;

                /*
               * By Default, its triggers cached event, but for cascading to work, we need it to trigger SelectedIndexChanged event,
               * before we post the page using submit button or something,
               * so we will convert it to postback event by setting AutoPostBack property of this dropdown to true.
               */
                ddlContinents.AutoPostBack = true;
                ddlCountries.AutoPostBack = true;
            }
        }

        private DataSet GetData(string SPName, SqlParameter parameter)
        {
            string cs = ConfigurationManager.ConnectionStrings[_testDBCSName].ConnectionString;
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter(SPName, con);

                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                if(parameter != null)
                {
                    da.SelectCommand.Parameters.Add(parameter);
                }

                DataSet ds = new DataSet();
                
                con.Open();

                da.Fill(ds);

                return ds;
            }
        }

        // Insert specified message and corresponding value, at the specified index of the dropdownlist
        private void InsertSelectMessageToDropDownList(DropDownList ddl, string message, string value, int index)
        {
            /*
             * DropDownList is a collection of list items, so to add a new item, we create a new instance of
             * ListItem class, provide the text and value for the same and add/insert the item to the DropDownList.
             */
            ListItem item = new ListItem(message, value);

            /* 
             * We can't use Items.Add() here since that will add the message to the end, but this
             * message should be at our specified index(eg. in our case, we want it at starting index ie. 0).
             * So, we use insert method for the same.
             */
            ddl.Items.Insert(index, item);
        }

        /*
         * By Default, its a cached event, but for cascading to work, we need it to trigger this event,
         * so we will convert it to postback event by setting AutoPostBack property of this dropdown to true.
         */
        protected void ddlContinents_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If first item ie. Select Item text is not selected then enable the dependent dropdownlist and populate it
            if(ddlContinents.SelectedIndex !=  _starting_Index)
            {
                ddlCountries.Enabled = true;
                ddlCountries.DataSource = GetData(_sp_Name_spGetCountriesByContinentId, 
                    new SqlParameter(_sp_Name_spGetCountriesByContinentId_Args_Name, ddlContinents.SelectedItem.Value));
                ddlCountries.DataBind();
                
                // Insert select message at the start of the dropdownlist item
                InsertSelectMessageToDropDownList(ddlCountries, _select_Country_Msg, __item_Value_At_Starting_Index, _starting_Index);

                // Reset the Cities dropdown list to point to first index since we don't want previous selections to appear
                ddlCities.Enabled = false;
                ddlCities.SelectedIndex = _starting_Index;
            }
            // If starting option is selected reset all dependent dropdownlists
            else if(ddlContinents.SelectedIndex == _starting_Index)
            {
                // Reset the Countries dropdown list to point to first index and disable it
                ddlCountries.SelectedIndex = _starting_Index;
                ddlCountries.Enabled = false;

                // Reset the Cities dropdown list to point to first index and disable it
                ddlCities.SelectedIndex = _starting_Index;
                ddlCities.Enabled = false;
            }
        }

        /*
         * By Default, its a cached event, but for cascading to work, we need it to trigger this event,
         * so we will convert it to postback event by setting AutoPostBack property of this dropdown to true.
         */
        protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If first item ie. Select Item text is not selected then enable the dependent dropdownlist and populate it
            if (ddlCountries.SelectedIndex != _starting_Index)
            {
                ddlCities.Enabled = true;
                ddlCities.DataSource = GetData(_sp_Name_spGetCitiesByCountryId,
                    new SqlParameter(_sp_Name_spGetCitiesByCountryId_Args_Name, ddlCountries.SelectedValue)) ;
                ddlCities.DataBind();

                // Insert select message at the start of the dropdownlist item
                InsertSelectMessageToDropDownList(ddlCities, _select_City_Msg, __item_Value_At_Starting_Index, _starting_Index);
            }
            else if (ddlCountries.SelectedIndex == _starting_Index)
            {
                // Reset the Cities dropdown list to point to first index and disable it
                ddlCities.SelectedIndex = _starting_Index;
                ddlCities.Enabled = false;
            }
        }
    
    }
}