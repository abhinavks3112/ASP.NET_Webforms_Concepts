using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomEventLogApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateEventLogandEventSource_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtEventLogName.Text) && !String.IsNullOrWhiteSpace(txtEventLogSource.Text))
            {
                if (!System.Diagnostics.EventLog.SourceExists(txtEventLogSource.Text))
                {
                    System.Diagnostics.EventLog.CreateEventSource(txtEventLogSource.Text, txtEventLogName.Text);
                }
                MessageBox.Show("Event Log and Source created successfully", "Success!!");
            }
            else
            {
                MessageBox.Show("Event Log and Source are required", "Failed!!");
            }
        }
    }
}
