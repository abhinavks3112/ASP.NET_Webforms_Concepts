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