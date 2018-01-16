namespace BlueTooth_Connector_Arduino
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
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbListDevices = new System.Windows.Forms.ComboBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.lblLog = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(33, 87);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(238, 20);
            this.txtMessage.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(33, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbListDevices
            // 
            this.cbListDevices.FormattingEnabled = true;
            this.cbListDevices.Location = new System.Drawing.Point(132, 14);
            this.cbListDevices.Name = "cbListDevices";
            this.cbListDevices.Size = new System.Drawing.Size(246, 21);
            this.cbListDevices.TabIndex = 4;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(277, 87);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(101, 23);
            this.btnSendMessage.TabIndex = 5;
            this.btnSendMessage.Text = "Send Message";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(33, 140);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(25, 13);
            this.lblLog.TabIndex = 6;
            this.lblLog.Text = "Log";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(30, 239);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(25, 13);
            this.lblError.TabIndex = 7;
            this.lblError.Text = "Log";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 272);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.cbListDevices);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtMessage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cbListDevices;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Label lblError;
    }
}

