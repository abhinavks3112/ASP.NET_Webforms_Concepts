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
             * First method to retrive another/previous form's value
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
             * Second method to retrive another/previous form's value is by using the PreviousPage property
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
             * Third method, if we are sure from which webform we are coming from then,
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
             * Fourth Method using query strings
             * When using Window.Open with query strings
             */
            //lblNameValue.Text = Request.QueryString["Name"];
            //lblEmailValue.Text = Request.QueryString["Email"];

            //OR
            //lblNameValue.Text = Request.QueryString["UserName"];
            //lblEmailValue.Text = Request.QueryString["UserEmail"];

            /*
             * Fifth Method using context.handler
             * It will only work for first time because in case there is a postback on the current page, then
             * reference to current page will be returned in context.handler.
             * Also, will work only if we get to this page using Server.Transfer or Server.Execute, otherwise
             * context.handler won't return previous page id or reference.
             */
            if (!IsPostBack)
            {
                /*
                 * Directly using webform name will fail in case we get to this page directly using url,
                 * then context.handler won't be able to typecast it to PageNavigationTechWebForm and it will give a runtime
                 * exception. So a better way is written afterwards.
                 */
                //PageNavigationTechWebForm lastPage = (PageNavigationTechWebForm)Context.Handler;
                Page lastPage = (Page)Context.Handler;
               
                if (lastPage is PageNavigationTechWebForm)
                {
                    lblNameValue.Text = ((PageNavigationTechWebForm) lastPage).Name;
                    lblEmailValue.Text = ((PageNavigationTechWebForm) lastPage).Email;
                }
            }
        }
    }
}