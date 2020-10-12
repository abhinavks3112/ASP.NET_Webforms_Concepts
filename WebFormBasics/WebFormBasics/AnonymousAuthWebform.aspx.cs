using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormBasics
{
    public partial class AnonymousAuthWebform : System.Web.UI.Page
    {
        private string userRoleGroup = "Guests";
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Application code executed using: ");
            Response.Write(System.Security.Principal.WindowsIdentity.GetCurrent().Name + "</br>");

            Response.Write("Is user authenticated? ");
            Response.Write(User.Identity.IsAuthenticated.ToString() + "</br>");

            Response.Write("Authentication type, if Authenticated: ");
            Response.Write(User.Identity.AuthenticationType + "</br>");

            Response.Write("User Name, if Authenticated: ");
            Response.Write(User.Identity.Name + "</br>");

            if(User.IsInRole(userRoleGroup))
            {
                Response.Write("Only users with role \"" + userRoleGroup + "\" can see this message");
            }
        }
    }
}