using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormBasics
{
    public partial class ButtonEventsWebForm : System.Web.UI.Page
    {
        private const string _click_Button_Msg = "Button Clicked!! <br /><br /><hr>";
        private const string _cmd_Print = "Print";
        private const string _cmd_Print_Button_Click_Msg = "Print button clicked.<br /><br /><hr>";
        private const string _cmd_Delete = "Delete";
        private const string _cmd_Delete_Button_Click_Msg = "Delete button clicked.<br /><br /><hr>";
        private const string _cmd_Show = "Show";
        private const string _cmd_Args_Show_Top10 = "Top10";
        private const string _cmd_Show_Top10_Button_Click_Msg = "Show Top 10 Employees button clicked.<br /><br /><hr>";
        private const string _cmd_Args_Show_Bottom10 = "Bottom10";
        private const string _cmd_Show_Bottom10_Button_Click_Msg = "Show Bottom 10 Employees button clicked.<br /><br /><hr>";
        private const string _cmd_Default_Click_Msg = "Unknown button clicked!<br /><br /><hr>";
        protected void Page_Load(object sender, EventArgs e)
        {
            /* We can dynamically assign event handlers to control events using different delegates 
             for different events eg. EventHandler delegate for click event, CommandEventHandler for control's
             command event.
             Alternatively, we can assign them statically on Design Page using property or on source page.
             Eg. OnClick="Button_Click"
            */
            // btnDelete.Click +=  new EventHandler(Button_Click);

            // btnPrint.Command += new CommandEventHandler(ButtonCommand_Click);
        }

        /* 
        * When button is clicked both click and command events get raised.
        * Click event gets called before command event. 
        */
        /*
         * Command event, makes it possible to have a single event handler method responding to the click event
         * of multiple buttons. The command event, CommandName and CommandArgument properties are extremely useful
         * when working with data-bound controls like Repeater, GridView, DataList, etc.
        */
        protected void ButtonCommand_Click(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case _cmd_Print:
                    lblOutput.Text = _cmd_Print_Button_Click_Msg;
                    break;
                case _cmd_Delete:
                    lblOutput.Text = _cmd_Delete_Button_Click_Msg;
                    break;
                case _cmd_Show:
                    if (e.CommandArgument.ToString() == _cmd_Args_Show_Top10)
                    {
                        lblOutput.Text = _cmd_Show_Top10_Button_Click_Msg;
                    }
                    else if (e.CommandArgument.ToString() == _cmd_Args_Show_Bottom10)
                    {
                        lblOutput.Text = _cmd_Show_Bottom10_Button_Click_Msg;
                    }
                    break;
                default:
                    lblOutput.Text = _cmd_Default_Click_Msg;
                    break;
            }
        }

        /* Server side click event written here */
        /* 
         * When button is clicked both click and command events get raised.
         * Click event gets called before command event. 
        */
        protected void Button_Click(object sender, EventArgs e)
        {
            Response.Write(_click_Button_Msg);
        }
    }
}