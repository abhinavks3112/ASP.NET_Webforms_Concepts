using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebFormBasics
{
    public partial class DropDownListWebForm : System.Web.UI.Page
    {
        private const string _testDBCSName = "TestDBCS";
        private const string _cmd_selectFromTblCity = "Select CityId, CityName, Country From tblCity";
        private const string _CityNameColumnName = "CityName";
        private const string _CityIdColumnName = "CityId";
        protected void Page_Load(object sender, EventArgs e)
        {
            /* 
             * Only fetch data from database and populate dropdown first time.
             * Subsequent fetch is not required since the value
             * will be maintained in dropdown control's viewstate
             */
            if (!IsPostBack)
            {
                PopulateCityDropDownList();
            }
        }

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
                ddlCity.DataTextField = _CityNameColumnName;
                ddlCity.DataValueField = _CityIdColumnName;

                /*
                 * Note: After specifying which columnn will be used for displaying Text and Values,
                 * THEN AND THEN ONLY BIND THE DATA and NOT BEFORE SPECIFYING, otherwise,
                 * it will display System.Data.Common.DataRecordInternal objects for each row,
                 * since it won't know which columns to display from.
                 */
                ddlCity.DataBind();
            }
        }
    }
}