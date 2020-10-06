using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormBasics
{
    public partial class PageNavigatedToWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             * First method to retrive another/previous form's value: Cross Page Postback
             * Since form values are preserved when using Server.Transfer, we can retrieve it using Request's object
             * Form collection. We will have to provide the control's name of previous form to fetch the values.
             */
            /*
             * The below form of using control name text is not good because there could be mistake in typing name or name
             * could be changed in original name so better technique is to retrieve it from using a public property.
            */
            //System.Collections.Specialized.NameValueCollection previousFormCollection = Request.Form;
            //lblNameValue.Text = previousFormCollection["txtName"];
            //lblEmailValue.Text = previousFormCollection["txtEmail"];

            /*
             * Using the PreviousPage property
             * of the Page class.
             * Note: This method only works i.e previousPage != null, ONLY in those cases, where we have been
             * redirected either by using Server.Transfer(even when we have set preserveForm=false) or using Cross Page Post Back.
             * It DOESN'T work with Response.Redirect.
             */
            //Page previousPage = Page.PreviousPage;

            //// Check if we have been redirected to this page or not
            //if (previousPage != null)
            //{
            /*
            * The below form of using control name text is not good because there could be mistake in typing name or name
            * could be changed in original name so better technique is to retrieve it from using a public property.
           */
            //    lblNameValue.Text = ((TextBox)previousPage.FindControl("txtName")).Text;
            //    lblEmailValue.Text = ((TextBox)previousPage.FindControl("txtEmail")).Text;
            //}

            /*
             * If we are sure from which webform we are coming from then,
             * instead of using Page object, we can directly use an instance of previous form
             * and hence its public properties for strongly types reference.
             */
            //PageNavigationTechWebForm previousPage = this.PreviousPage;

            //// Check if we have been redirected to this page or not
            //if (previousPage != null)
            //{
            /*
            * The below form of using getting text using a public property for getting control's content is good.
           */
            //    lblNameValue.Text = previousPage.Name;
            //    lblEmailValue.Text = previousPage.Email;
            //}

            /*
             * Second Method using : Query strings
             * When using Window.Open with query strings
             */
            //lblNameValue.Text = Server.UrlDecode(Request.QueryString["Name"]);
            //lblEmailValue.Text = Server.UrlDecode(Request.QueryString["Email"]);

            //OR
            //lblNameValue.Text = Server.UrlDecode(Request.QueryString["UserName"]);
            //lblEmailValue.Text = Server.UrlDecode(Request.QueryString["UserEmail"]);

            /*
             * Third Method using : context.handler
             * It will only work for first time because in case there is a postback on the current page, then
             * reference to current page will be returned in context.handler.
             * Also, will work only if we get to this page using Server.Transfer or Server.Execute, otherwise
             * context.handler won't return previous page id or reference.
             */
            //if (!IsPostBack)
            //{
            //    /*
            //     * Directly using webform name will fail in case we get to this page directly using url,
            //     * then context.handler won't be able to typecast it to PageNavigationTechWebForm and it will give a runtime
            //     * exception. So a better way is written afterwards.
            //     */
            //    //PageNavigationTechWebForm lastPage = (PageNavigationTechWebForm)Context.Handler;
            //    Page lastPage = (Page)Context.Handler;

            //    if (lastPage is PageNavigationTechWebForm)
            //    {
            //        lblNameValue.Text = ((PageNavigationTechWebForm) lastPage).Name;
            //        lblEmailValue.Text = ((PageNavigationTechWebForm) lastPage).Email;
            //    }
            //}

            /*
             * Fourth Method using cookies
             */
            HttpCookie cookie = Request.Cookies["UserInfo"];
            if (cookie != null)
            {
                lblNameValue.Text = Server.UrlDecode(cookie["UserName"]);
                lblEmailValue.Text = Server.UrlDecode(cookie["UserEmail"]);
            }

            /*
             * Fifth Method using session
             * Session can store any data type including complex object eg. customer class,
             * so when retrieving we need to convert back the data.
             * Also, a good practise to check if session data is not null before performing any operation on it like
             * converting it to other data type which will lead to runtime exception. Session data could be null due 
             * to multiple reasons, one being session timeout.
             */
            if (Session["UserName"] != null)
                lblNameValue.Text = Session["UserName"].ToString();
            if (Session["UserEmail"] != null)
                lblEmailValue.Text = Session["UserEmail"].ToString();

            /*
             * Fifth Method using Application
             * Application can store any data type including complex object eg. customer class,
             * so when retrieving we need to convert back the data.
             * Also, a good practise to check if application data is not null before performing any operation on it like
             * converting it to other data type which will lead to runtime exception. Application data could be null due 
             * to multiple reasons, one being session timeout.
             * Note: Although we can use it to send data between web forms but we shouldn't if the purpose is just this,
             * instead some other methods should be used, because it will occupy memory for the whole duration till application
             * stops.
             */
            if (Application["UserName"] != null)
                lblNameValue.Text = Application["UserName"].ToString();
            if (Application["UserEmail"] != null)
                lblEmailValue.Text = Application["UserEmail"].ToString();

        }
    }
}