using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebFormBasics
{
    public class Global : HttpApplication
    {
        private const string TOTAL_APPLICATIONS_KEY = "TotalApplications";
        private const string TOTAL_USER_SESSIONS_KEY = "TotalUserSessions";

        private string errorDisplayPageRelativePath = "~/Error.aspx";

        // Handle Application Level Error
        void Application_Error(object sender, EventArgs e)
        {
            // Get Exception
            Exception ex = Server.GetLastError();
            if (ex != null)
            {
                // Log error
                Logger.Log(ex);

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
                // Response.Redirect(errorDisplayPageRelativePath);
                Server.Transfer(errorDisplayPageRelativePath);
            }
        }
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Create and initialize Application state variables
            Application[TOTAL_APPLICATIONS_KEY] = 0;
            Application[TOTAL_USER_SESSIONS_KEY] = 0;

            // Increment Total Applications by 1
            Application[TOTAL_APPLICATIONS_KEY] = Convert.ToInt32(Application[TOTAL_APPLICATIONS_KEY]) + 1;
        }

        void Session_Start(object sender, EventArgs e)
        {
            // Thread Lock for synchronization
            Application.Lock();
            // Increment Total User Sessions by 1
            Application[TOTAL_USER_SESSIONS_KEY] = Convert.ToInt32(Application[TOTAL_USER_SESSIONS_KEY]) + 1;
            // Thread UnLock for synchronization
            Application.UnLock();
        }

        void Session_End(object sender, EventArgs e)
        {
            // Thread Lock for synchronization
            Application.Lock();
            // Decrement Total User Sessions by 1
            Application[TOTAL_USER_SESSIONS_KEY] = Convert.ToInt32(Application[TOTAL_USER_SESSIONS_KEY]) - 1;
            // Thread UnLock for synchronization
            Application.UnLock();
        }
    }
}