using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormBasics
{
    public partial class ExceptionHandlingWebForm : System.Web.UI.Page
    {
        private string countriesXMLRelativePath = "~/Data/Countries.xml";
        private string errorDisplayPageRelativePath = "~/Error.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Name of windows User/Account which is accessing the file
                Response.Write(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath(countriesXMLRelativePath));

                gvCountries.DataSource = ds;
                gvCountries.DataBind();
            }
            // Comment all catch block to trigger page level error event handler
            catch (System.IO.FileNotFoundException fileNotFound)
            {
                //Log the result
                // Display the message
                lblStatus.Text = "File is missing!!";
            }
            catch (System.UnauthorizedAccessException unauthorizedException)
            {
                //Log the result
                // Display the message
                lblStatus.Text = "Access is denied!!";
            }
            catch (Exception ex)
            {
                //Log the result
                // Display the message
                lblStatus.Text = "Uh Oh!! We have encountered an error!! Please check back after some time";
            }
            finally
            {
                // Cleanup Code
            }
        }

        // Comment the Page_Error and all catch block above to trigger Application level error event handler in Global.asax
        // Handle Page Level Error
        protected void Page_Error(object sender, EventArgs e)
        {
            // Get Exception
            Exception ex = Server.GetLastError();

            // Log error
            // Clear exception
            /*
             * If the exception is not cleared in the Page_Error event, it gets propagated to the application level, 
             * and Application_Error event handler gets executed. If we are not clearing the exception at the 
             * application level, the application crashes with the "Yellow Screen of Death".
             */
            Server.ClearError();

            // Redirect to custom error display page
            /*
             * If the exception is cleared and redirection to Errors.aspx is not done, then a blank page is displayed,
             * provided that we are not handling it at application level also.  
             * This is because web form processing is immediately stopped when an exception occurs.
             */
            Response.Redirect(errorDisplayPageRelativePath);
        }
    }
}