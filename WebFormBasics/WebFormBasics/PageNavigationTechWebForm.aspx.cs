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

        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}