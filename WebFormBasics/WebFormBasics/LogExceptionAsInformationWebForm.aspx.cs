using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Diagnostics;

namespace WebFormBasics
{
    public partial class LogExceptionAsInformationWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDivide_Click(object sender, EventArgs e)
        {
            try
            {
                int firstNumber = Convert.ToInt32(txtFirstNumber.Text);
                int secondNumber = Convert.ToInt32(txtSecondNumber.Text);

                int result = firstNumber / secondNumber;
                lblMessage.Text = result.ToString();
                lblMessage.ForeColor = Color.Navy;
            }
            catch (FormatException formatException)
            {
                Logger.Log(formatException, EventLogEntryType.Information);
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Only Numbers are allowed";            
            }
            catch (OverflowException overflowException)
            {
                Logger.Log(overflowException, EventLogEntryType.Information);
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Numbers must be between " + Int32.MinValue.ToString() + " and " + Int32.MaxValue.ToString();
            }
            catch (DivideByZeroException divideByZeroException)
            {
                Logger.Log(divideByZeroException);
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Denominator cannot be zero";
            }
            catch (Exception exception)
            {
                Logger.Log(exception);
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "An unknown error has occured. Please try again after some time.";
            }
        }
    }
}