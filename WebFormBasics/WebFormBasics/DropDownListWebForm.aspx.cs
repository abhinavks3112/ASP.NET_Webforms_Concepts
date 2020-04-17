using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebFormBasics
{
    public partial class DropDownListWebForm : System.Web.UI.Page
    {
        #region----Private Variables----

        private const string _testDBCSName = "TestDBCS";

        private const string _cmd_selectFromTblCity = "Select CityId, CityName, Country From tblCity";
        private const string _cityNameColumnName = "CityName"; // From tblCity Table
        private const string _cityIdColumnName = "CityId"; // From tblCity Table

        private const string _countriesXML_RelativeOrVirtualPath = "~/Data/Countries.xml";
        private const string _countryNameTagName = "CountryName"; // From Countries XML File
        private const string _countryIdTagName = "CountryId"; // From Countries XML File

        private const string _select_City_Msg = "----Select a City----";
        private const string _select_Country_Msg = "----Select a Country----";
        private const int _starting_Index = 0;
        private const string __item_Value_At_Starting_Index = "-1";

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            /* 
             * Only fetch data from database and populate dropdown first time.
             * Subsequent fetch is not required since the value
             * will be maintained in dropdown control's viewstate
             */
            if (!IsPostBack)
            {
                /*
                 * We need to provide the actual physical location of the file to the server.
                 * Since the physical location may vary depending on where this application will be installed,
                 * we need to get physical location at runtime. Eg. In one computer it may be in C drive, in other D Drive,
                 * but the relative path of xml file, relative to the project will remain the same
                 * (eg. in our case it is inside the Data folder).
                 * So, we will use Server.MapPath to map this relative/virtual path to its physical path at runtime.
                 */
                string CountriesXML_PhysicalPath = Server.MapPath(_countriesXML_RelativeOrVirtualPath);

                PopulateCityDropDownList();
                PopulateCountryDropDownList(CountriesXML_PhysicalPath);
            }
        }

        // Populate dropdown using data from database
        private void PopulateCityDropDownList()
        {
            string cs = ConfigurationManager.ConnectionStrings[_testDBCSName].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(_cmd_selectFromTblCity, con);
                con.Open();

                // Set the datasource for dropdown list
                ddlCity.DataSource = cmd.ExecuteReader();

                /*
                 * Since in DataReader, we are reading whole table with multiple columns, we need to specify the column name
                 * which the dropdown list will use to display Names/Text, eg, in our case we want city names so we will
                 * specify that particular column name.
                 * We also need to specify column will server as corresponding value for the text, eg in our case,
                 * it will be CityId column which will uniquely identify each city.
                 * Note: We can specify these properties in dropdown list's attributes also. 
                 * Then, we won't need to specify these here.
                 */
                ddlCity.DataTextField = _cityNameColumnName;
                ddlCity.DataValueField = _cityIdColumnName;

                /*
                 * Note: After specifying which columnn will be used for displaying Text and Values,
                 * THEN AND THEN ONLY BIND THE DATA and NOT BEFORE SPECIFYING, otherwise,
                 * it will display System.Data.Common.DataRecordInternal objects for each row,
                 * since it won't know which columns to display from.
                 */
                ddlCity.DataBind();
            }

            // Insert select message at the start of the dropdownlist item
            InsertSelectMessageToDropDownList(ddlCity, _select_City_Msg, __item_Value_At_Starting_Index, _starting_Index);
        }

        // Populate dropdown using data from XML
        private void PopulateCountryDropDownList(string xmlPhysicalPath)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(xmlPhysicalPath);

            ddlCountries.DataSource = ds;
            ddlCountries.DataTextField = _countryNameTagName;
            ddlCountries.DataValueField = _countryIdTagName;
            ddlCountries.DataBind();

            // Insert select message at the start of the dropdownlist item
            InsertSelectMessageToDropDownList(ddlCountries, _select_Country_Msg, __item_Value_At_Starting_Index, _starting_Index);
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
    
    }
}