using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormBasics
{
    public partial class ValidationControlsWebForm : System.Web.UI.Page
    {
        private const string _msg_Success_Status = "Data saved sucessfully";
        private const string _msg_Failed_Status = "Validations failed! Data could not be saved.";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            /*
             * Page.IsValid indicates whether all the validations on the page succeeded or not, even in the case when javascript
             * is disabled on client side and validations didn't run on client side. On the server side the validations are
             * still performed and it outputs the results to Page.IsValid.
             */
            if (Page.IsValid)
            {
                lblStatus.Text = _msg_Success_Status;
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblStatus.Text = _msg_Failed_Status;
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        /*
         * Server side validation for custom validator
         */
        protected void CustomValidatorEvenNumber_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Check if input is empty
            if (args.Value == "")
            {
                args.IsValid = false;
            }
            else
            {
                // Check if it an integer value(eg 10) or string value(eg. TEN)
                int Number;
                bool isNumber = int.TryParse(args.Value, out Number);

                /* 
                 * 1. Check if it an integer value(eg 10) and,
                 * 2. Number is not zero and,
                 * 3. Also divisible by 2,
                 * then set isValid to true
                */
                if (isNumber && Number != 0 && ((Convert.ToInt32(Number) % 2) == 0))
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
        }
    }
}
 