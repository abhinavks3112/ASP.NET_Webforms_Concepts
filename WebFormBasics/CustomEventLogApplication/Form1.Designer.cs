namespace CustomEventLogApplication
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblEventLogName = new System.Windows.Forms.Label();
            this.lblEventLogSource = new System.Windows.Forms.Label();
            this.txtEventLogName = new System.Windows.Forms.TextBox();
            this.txtEventLogSource = new System.Windows.Forms.TextBox();
            this.btnCreateEventLogandEventSource = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEventLogName
            // 
            this.lblEventLogName.AutoSize = true;
            this.lblEventLogName.Location = new System.Drawing.Point(31, 21);
            this.lblEventLogName.Name = "lblEventLogName";
            this.lblEventLogName.Size = new System.Drawing.Size(87, 13);
            this.lblEventLogName.TabIndex = 0;
            this.lblEventLogName.Text = "Event Log Name";
            // 
            // lblEventLogSource
            // 
            this.lblEventLogSource.AutoSize = true;
            this.lblEventLogSource.Location = new System.Drawing.Point(31, 73);
            this.lblEventLogSource.Name = "lblEventLogSource";
            this.lblEventLogSource.Size = new System.Drawing.Size(93, 13);
            this.lblEventLogSource.TabIndex = 1;
            this.lblEventLogSource.Text = "Event Log Source";
            // 
            // txtEventLogName
            // 
            this.txtEventLogName.Location = new System.Drawing.Point(124, 18);
            this.txtEventLogName.Name = "txtEventLogName";
            this.txtEventLogName.Size = new System.Drawing.Size(185, 20);
            this.txtEventLogName.TabIndex = 2;
            // 
            // txtEventLogSource
            // 
            this.txtEventLogSource.Location = new System.Drawing.Point(124, 66);
            this.txtEventLogSource.Name = "txtEventLogSource";
            this.txtEventLogSource.Size = new System.Drawing.Size(185, 20);
            this.txtEventLogSource.TabIndex = 3;
            // 
            // btnCreateEventLogandEventSource
            // 
            this.btnCreateEventLogandEventSource.Location = new System.Drawing.Point(34, 124);
            this.btnCreateEventLogandEventSource.Name = "btnCreateEventLogandEventSource";
            this.btnCreateEventLogandEventSource.Size = new System.Drawing.Size(275, 23);
            this.btnCreateEventLogandEventSource.TabIndex = 4;
            this.btnCreateEventLogandEventSource.Text = "Create Event Log and Event Source";
            this.btnCreateEventLogandEventSource.UseVisualStyleBackColor = true;
            this.btnCreateEventLogandEventSource.Click += new System.EventHandler(this.btnCreateEventLogandEventSource_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 179);
            this.Controls.Add(this.btnCreateEventLogandEventSource);
            this.Controls.Add(this.txtEventLogSource);
            this.Controls.Add(this.txtEventLogName);
            this.Controls.Add(this.lblEventLogSource);
            this.Controls.Add(this.lblEventLogName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEventLogName;
        private System.Windows.Forms.Label lblEventLogSource;
        private System.Windows.Forms.TextBox txtEventLogName;
        private System.Windows.Forms.TextBox txtEventLogSource;
        private System.Windows.Forms.Button btnCreateEventLogandEventSource;
    }
}

