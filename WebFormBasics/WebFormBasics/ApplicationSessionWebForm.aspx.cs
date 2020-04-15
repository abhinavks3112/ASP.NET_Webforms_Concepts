using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormBasics
{
    public partial class ApplicationSessionWebForm : System.Web.UI.Page
    {
        private const string TOTAL_APPLICATIONS_KEY = "TotalApplications";
        private const string TOTAL_USER_SESSIONS_KEY = "TotalUserSessions";
        protected void Page_Load(object sender, EventArgs e)
        {
            // Open 2 or more browser one after another and see the results
            Response.Write("Number of Applications: " + Application[TOTAL_APPLICATIONS_KEY]);
            Response.Write("<br />");
            Response.Write("Number of users Online: " + Application[TOTAL_USER_SESSIONS_KEY]);
        }
    }
}