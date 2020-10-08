using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;

namespace WebFormBasics
{
    public class Logger
    {
        // Log to window's event viewer
        private static void LogToEventViewer(EventLogEntryType eventLogEntryType, String exceptionMessage)
        {
            // Log exception to Window's Event Viewer
            if (EventLog.SourceExists("WindowEventLogTestExample.com"))
            {
                /*
                 * Logging exception in our custom created Log in Windows event viewer.
                 * (Code in CustomEventLogApplication project in same solution)
                 */
                EventLog log = new EventLog("WindowEventLogTestExample");
                log.Source = "WindowEventLogTestExample.com";

                log.WriteEntry(exceptionMessage, eventLogEntryType);
            }
        }
        // Log to database
        private static void LogToDatabase(string exceptionMessage)
        {
            string cs = ConfigurationManager.ConnectionStrings["TestDBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spInsertLog";
            cmd.Parameters.AddWithValue("@ExceptionMessage", exceptionMessage);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        
        // Log with default type error
        public static void Log(Exception exception)
        {
            Log(exception, EventLogEntryType.Error);
        }
        
        // Log with given log type
        public static void Log(Exception exception, EventLogEntryType eventLogEntryType)
        {
            StringBuilder exceptionMessage = new StringBuilder();

            do
            {
                exceptionMessage.Append("Exception Type" + Environment.NewLine);
                exceptionMessage.Append(exception.GetType().Name);
                exceptionMessage.Append(Environment.NewLine + Environment.NewLine);
                exceptionMessage.Append("Message" + Environment.NewLine);
                exceptionMessage.Append(exception.Message + Environment.NewLine + Environment.NewLine);
                exceptionMessage.Append("Stack trace" + Environment.NewLine);
                exceptionMessage.Append(exception.StackTrace + Environment.NewLine + Environment.NewLine);

                exception = exception.InnerException;
            } while (exception != null);

            string logProvider = ConfigurationManager.AppSettings["LogProvider"];

            if (logProvider.ToLower() == "database" || logProvider.ToLower() == "both")
            {
                // Log into the database
                LogToDatabase(exceptionMessage.ToString());
                
            }

            if (logProvider.ToLower() == "eventviewer" || logProvider.ToLower() == "both")
            {
                // Log to window's event viewer
                LogToEventViewer(eventLogEntryType, exceptionMessage.ToString());
            }

            string sendEmail = ConfigurationManager.AppSettings["SendEmail"];

            if (sendEmail.ToLower() == "true")
            {
                // Log to window's event viewer
                SendEmail(exceptionMessage.ToString());
            }
        }

        // Send automated email with exception info
        public static void SendEmail(string messageBody)
        {
            // Create message
            MailMessage message = new MailMessage("montyks3112@gmail.com", "montyks3112@gmail.com");
            message.Subject = "Exception";
            message.Body = messageBody;

            /*
             * Better configurable way is to specify it in web config.
             * <system.net>
		            <mailSettings>
			            <smtp deliveryMethod="Network">
				            <network host="smtp.gmail.com" port="587" userName="abc@gmail.com" password="abcpassword" enableSsl="true"/>
			            </smtp>
		            </mailSettings>
	            </system.net>
             */
            //// Specify smtp server and port
            //SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);            
            //// If the smtp server uses https then we need to enable ssl
            //smtpClient.EnableSsl = true;
            //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //// Provide the credentia for server
            //smtpClient.Credentials = new System.Net.NetworkCredential()
            //{
            //    UserName = "abc@gmail.com",
            //    Password = "abcpassword"
            //};

            // All the settings will automatically be picked up from web config when sending mail
            SmtpClient smtpClient = new SmtpClient();
            // Send the message
            smtpClient.Send(message);
        }
    }
}