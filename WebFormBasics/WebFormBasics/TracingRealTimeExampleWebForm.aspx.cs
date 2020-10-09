using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormBasics
{
    public partial class TracingRealTimeExampleWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Write Custom Trace message for individual element and check trace log 
             * for its performance or time taken. Using this we can identify which part
             is taking more time and then evaluate further*/
            Trace.Warn("LoadAllEmployee() started");
            LoadAllEmployee();
            Trace.Warn("LoadAllEmployee() completed");

            Trace.Warn("LoadTotalNumberOfEmployeesByDepartment() started");
            LoadTotalNumberOfEmployeesByDepartment();
            Trace.Warn("LoadTotalNumberOfEmployeesByDepartment() completed");
            
            Trace.Warn("LoadTotalNumberOfEmployeesByGender() started");
            LoadTotalNumberOfEmployeesByGender();
            Trace.Warn("LoadTotalNumberOfEmployeesByGender() completed");
        }

        private void LoadAllEmployee()
        {
            gvAllEmployees.DataSource = ExecuteStoredProcedure("spGetEmployees");
            gvAllEmployees.DataBind();
        }
        private void LoadTotalNumberOfEmployeesByDepartment()
        {
            gvEmployeeCountByDept.DataSource = ExecuteStoredProcedure("spGetEmployeesByDepartment");
            gvEmployeeCountByDept.DataBind();
        }
        private void LoadTotalNumberOfEmployeesByGender()
        {
            gvEmployeeCountByGender.DataSource = ExecuteStoredProcedure("spGetEmployeesByGender");
            gvEmployeeCountByGender.DataBind();
        }
        private DataSet ExecuteStoredProcedure(string spName)
        {
            // Create a dataset
            DataSet ds = new DataSet();

            // Get the connection string
            string cs = ConfigurationManager.ConnectionStrings["TestDBCS"].ConnectionString;

            // Initialize sql connection object with the connection string
            SqlConnection con = new SqlConnection(cs);

            // Create a sql command object and specify the command type as stored procedure and specify the sql connection object
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Connection = con;

            // Create a SqlDataAdapter object and intialize it with the sql command object
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // Open the db connection
            con.Open();

            // Using data adapter fill the dataset
            da.Fill(ds);

            // Close the db connection
            con.Close();

            if(spName == "spGetEmployeesByGender")
            {
                Thread.Sleep(5000);
            }

            // Return the dataset
            return ds;
        }
    }
}