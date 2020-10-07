using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

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
            }

        
    }
}