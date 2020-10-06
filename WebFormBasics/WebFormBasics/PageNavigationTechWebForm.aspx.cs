using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormBasics
{
    public partial class PageNavigationTechWebForm : System.Web.UI.Page
    {
        private string path_About_Page ="~/About.aspx";
        private string path_PageNavigateToWebform = "~/PageNavigatedToWebForm.aspx";
        private string questionMark = "?";
        private string equalSign = "=";
        private string amperSand = "=";
        private string userNameText = "UserName";
        private string userEmailText = "UserEmail";
        private string userInfoCookieName = "UserInfo";
        private string cookieNotSupportedBrowserMessage = "Your browser does not support cookies. Please install one of the modern browsers.";
        private string cookieDisabledOnBrowserMessage = "We have detected that cookies are disabled in your browser. Please enable cookies";
        private const string TOTAL_USER_SESSIONS_KEY = "TotalUserSessions";
        private void UpdateStatus()
        {
            /*
            * Display Status after transfer won't work with Server.Transfer but will work with Server.Execute.
            * Server.Transfer terminates the execution of the current page and starts the execution of the new page, 
            * where as Server.Execute process the second Web form without leaving the first Web form. After completing
            * the execution of the first webform, the control returns to the second webform.
            */
            lblStatus.Text = "Processing Completed";
        }
        
        /*
         * Public read-only properly for strongly typed TextBoxes names, so that they can be accessed in other form
         */
        public string Name
        {
            get
            {
                return txtName.Text;
            }
        }

        public string Email
        {
            get
            {
                return txtEmail.Text;
            }
        }
        public string UserInfoCookie
        {
            get
            {
                return userInfoCookieName;
            }
        }
        public string UserNameCookie
        {
            get
            {
                return userNameText;
            }
        }
        public string UserEmailCookie
        {
            get
            {
                return userEmailText;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Number of users online is " + Application[TOTAL_USER_SESSIONS_KEY].ToString() + "\n");
            if (!IsPostBack)
            {
                // Check if the client browser supports cookie
                if (Request.Browser.Cookies)
                {
                    /*
                     * Check if cookie is enabled in client browser
                     */

                    // If querystring not present then user has reached this url for the first time
                    if (Request.QueryString["CheckCookie"] == null)
                    { 
                        // Create a test cookie
                        HttpCookie cookie = new HttpCookie("TestCookie", "1");
                        // Try to send and save it on client
                        Response.Cookies.Add(cookie);

                        // Redirect to same browser with a random query string
                        Response.Redirect("PageNavigationTechWebForm?CheckCookie=1");
                    }
                    /*
                    * Check if querystring is present in current url, which if present means we have
                    * returned a test cookie in last request and trying to read it.
                    */
                    else
                    {
                        HttpCookie cookie = Request.Cookies["TestCookie"];
                        if(cookie == null)
                        {
                            lblStatus.Text = cookieDisabledOnBrowserMessage;
                        }
                    }
                }
                else
                {
                    lblStatus.Text = cookieNotSupportedBrowserMessage;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(path_About_Page);
        }

        protected void btnServerTransfer_Click(object sender, EventArgs e)
        {
            /*
             * By default, the boolean parameter preserveForm=true for Server.Transfer.
             * This ensures that the posted form values can be retrieved on the transferred page/form.
             * It can only be used to tranfer on same server, it does this without making a roundtrip to
             * client and back unlike Response.Redirect. So, its comparatively faster than Response.Redirect.
             * It also doesn't change the URL.
             * If we try to use this to transfer to another server's page, it will give a runtime error.
             */
            // Server.Transfer(path_PageNavigateToWebform);

            /*
             * This ensures that the posted form values can't be retrieved on the transferred page/form
             * using Http Request object, it can still be retrieved by other method such as using Page class
             * PreviousPage propery..
             */
            Server.Transfer(path_PageNavigateToWebform, false);

            UpdateStatus();
        }

        protected void btnServerExecute_Click(object sender, EventArgs e)
        {           
            /*
             * This ensures that the posted form values can't be retrieved on the transferred page/form
             * using Http Request object, it can still be retrieved by other method such as using Page class
             * PreviousPage propery.
             */
            Server.Execute(path_PageNavigateToWebform, false);

            UpdateStatus();
        }

        protected void btnQueryString_Click(object sender, EventArgs e)
        {
            /*
             * Urlencode in case we have name like A & B, then if not replaced with escape symbol, due to '&' B will treated as separate query string
             */
            Response.Redirect(path_PageNavigateToWebform + questionMark + userNameText + equalSign + Server.UrlEncode(txtName.Text)
                + amperSand + userEmailText + equalSign + Server.UrlEncode(txtEmail.Text));
        }

        protected void btnCookies_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie(userInfoCookieName);
            cookie[userNameText] = Server.UrlEncode(txtName.Text);
            cookie[userEmailText] = Server.UrlEncode(txtEmail.Text);

            // When expiry is added to cookies it becomes Persistent cookies otherwise non-persistent cookies
            cookie.Expires = DateTime.Now.AddDays(30);

            Response.Cookies.Add(cookie);

            Response.Redirect(path_PageNavigateToWebform);
        }

        protected void btnSession_Click(object sender, EventArgs e)
        {
            /*
             * Session state mode by default is InProc meaning session state data is stored in server memory for specified session
             * duration (by default, 20 minutes). We can change this duration in web.config > configuration > system.web > sessionstate -> mode attribute
             * plus timeout attribute and setting the time in numerical minutes.
             * Session state data are available across all pages within the single session.
             * These are like SINGLE USER's Global Data.
             */
            Session[userNameText] = txtName.Text;
            Session[userEmailText] = txtEmail.Text;

            /* If cookieless session is used, relative url is a must since Session Id is passed in url as query string and in
             * absolute url session id will get omitted and session won't work correctly.
             * Here, we are using relative path only.            
             */
            Response.Redirect(path_PageNavigateToWebform);
        }

        protected void btnApplication_Click(object sender, EventArgs e)
        {
            /*
             * Application state data is stored in server memory from the time the application starts and until it stops.
             * Application state data are available across all pages across all sessions.
             * These are like MULTIPLE USER's Global Data.
             */
            Application[userNameText] = txtName.Text;
            Application[userEmailText] = txtEmail.Text;

            Response.Redirect(path_PageNavigateToWebform);
        }
    }
}