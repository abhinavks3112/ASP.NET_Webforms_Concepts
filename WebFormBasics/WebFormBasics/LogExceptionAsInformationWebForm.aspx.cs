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
                if (Trace.IsEnabled)
                {
                    /*
                     * Trace has advantage for Response.Write for debugging in that it is by default only accessible by
                     * developer(in trace.axd file) and not end user, provided pageOutput="false", that is we are not appending
                     * trace output on the webpage itself.
                     * Also, all Response.Write used for debugging needs to removed, before the application is deployed, but in
                     * case of tracing we just need to disable it in web.config, provide it is not enabled on page level.
                     * 
                     */
                    // Executing Trace.Write or Trace.Warn without checking Trace is enabled will not throw any exception
                    // Only difference with Trace.Write is that, warn's message is in red, write's message is in black
                    Trace.Write(formatException.Message);
                }
            }
            catch (OverflowException overflowException)
            {
                Logger.Log(overflowException, EventLogEntryType.Information);
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Numbers must be between " + Int32.MinValue.ToString() + " and " + Int32.MaxValue.ToString();

                if (Trace.IsEnabled)
                {
                    // Only difference with Trace.Write is that, warn's message is in red, write's message is in black
                    Trace.Warn(overflowException.Message);
                }
            }
            catch (DivideByZeroException divideByZeroException)
            {
                Logger.Log(divideByZeroException);
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Denominator cannot be zero";
                if (Trace.IsEnabled)
                {
                    // Only difference with Trace.Write is that, warn's message is in red, write's message is in black
                    Trace.Warn(divideByZeroException.Message);
                }
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