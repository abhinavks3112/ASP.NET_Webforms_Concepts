using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormBasics
{
    public partial class PageLifeCycleEventWebForm : System.Web.UI.Page
    {
        /* Enter some input in textbox and submit and watch the event sequence and viewstate values*/
        protected void Page_PreInit(object sender, EventArgs e)
        { 
            Response.Write("Page_PreInit Event" + "<br />");
            Response.Write("Control's ViewState value: " + ViewStateValue() + "<br /><br /><hr><br />");
        }

        private string ViewStateValue()
        {
            return txtInput.Text == "" ? "Blank" : txtInput.Text;
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Write("Page_Init Event" + "<br />");
            Response.Write("Control's ViewState value: " + ViewStateValue() + "<br /><br /><hr><br />");
        }
        protected void Page_InitComplete(object sender, EventArgs e)
        {
            Response.Write("Page_InitComplete Event" + "<br />");
            Response.Write("Control's ViewState value: " + ViewStateValue() + "<br /><br /><hr><br />");
        }
        protected void Page_Page_PreLoad(object sender, EventArgs e)
        {
            Response.Write("Page_Page_PreLoad Event" + "<br />");
            Response.Write("Control's ViewState value: " + ViewStateValue() + "<br /><br /><hr><br />");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Page_Load Event" + "<br />");
            Response.Write("Control's ViewState value: " + ViewStateValue() + "<br /><br /><hr><br />");
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Response.Write("Page_LoadComplete Event" + "<br />");
            Response.Write("Control's ViewState value: " + ViewStateValue() + "<br /><br /><hr><br />");
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("Page_PreRender Event" + "<br />");
            Response.Write("Control's ViewState value: " + ViewStateValue() + "<br /><br /><hr><br />");
        }
        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            Response.Write("Page_PreRenderComplete Event" + "<br />");
            Response.Write("Control's ViewState value: " + ViewStateValue() + "<br /><br /><hr><br />");
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Response.Write("ASP.NET Server Control Event: Postback Event" + "<br />");
            Response.Write("Control's ViewState value: " + ViewStateValue() + "<br /><br /><hr><br />");
        }

        protected void txtInput_TextChanged(object sender, EventArgs e)
        {
            /*
             * To convert it to postback event set its AutoPostBack property to true.
             * And then to postback this event, after inputting text, either by pressing enter
             * or moving the focus away from textbox, eg. by pressing tab, or clicking somewhere else.
             */
            Response.Write("ASP.NET Server Control Event: Cached Event" + "<br />");
            Response.Write("Control's ViewState value: " + ViewStateValue() + "<br /><br /><hr><br />");
        }
    }
}