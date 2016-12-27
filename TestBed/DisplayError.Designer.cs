namespace TestBed
{
    partial class DisplayError
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
            this.lnkVideo = new System.Windows.Forms.LinkLabel();
            this.lnkHelp = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.lblErrorNumber = new System.Windows.Forms.Label();
            this.btnSubmitTicket = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lnkVideo
            // 
            this.lnkVideo.AutoSize = true;
            this.lnkVideo.Location = new System.Drawing.Point(44, 213);
            this.lnkVideo.Name = "lnkVideo";
            this.lnkVideo.Size = new System.Drawing.Size(177, 13);
            this.lnkVideo.TabIndex = 0;
            this.lnkVideo.TabStop = true;
            this.lnkVideo.Text = " Click here to see a link to the Video";
            this.lnkVideo.Visible = false;
            this.lnkVideo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkVideo_LinkClicked);
            // 
            // lnkHelp
            // 
            this.lnkHelp.AutoSize = true;
            this.lnkHelp.Location = new System.Drawing.Point(44, 267);
            this.lnkHelp.Name = "lnkHelp";
            this.lnkHelp.Size = new System.Drawing.Size(194, 13);
            this.lnkHelp.TabIndex = 1;
            this.lnkHelp.TabStop = true;
            this.lnkHelp.Text = "Click here to see the related help pages";
            this.lnkHelp.Visible = false;
            this.lnkHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkHelp_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.Location = new System.Drawing.Point(44, 121);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(35, 13);
            this.lblErrorMessage.TabIndex = 3;
            this.lblErrorMessage.Text = "label2";
            // 
            // lblErrorNumber
            // 
            this.lblErrorNumber.AutoSize = true;
            this.lblErrorNumber.Location = new System.Drawing.Point(44, 39);
            this.lblErrorNumber.Name = "lblErrorNumber";
            this.lblErrorNumber.Size = new System.Drawing.Size(35, 13);
            this.lblErrorNumber.TabIndex = 4;
            this.lblErrorNumber.Text = "label3";
            // 
            // btnSubmitTicket
            // 
            this.btnSubmitTicket.Location = new System.Drawing.Point(335, 283);
            this.btnSubmitTicket.Name = "btnSubmitTicket";
            this.btnSubmitTicket.Size = new System.Drawing.Size(75, 39);
            this.btnSubmitTicket.TabIndex = 6;
            this.btnSubmitTicket.Text = "Submit Ticket";
            this.btnSubmitTicket.UseVisualStyleBackColor = true;
            this.btnSubmitTicket.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(433, 283);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 39);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // DisplayError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 348);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSubmitTicket);
            this.Controls.Add(this.lblErrorNumber);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lnkHelp);
            this.Controls.Add(this.lnkVideo);
            this.Name = "DisplayError";
            this.Text = "Generic Error";
            this.Load += new System.EventHandler(this.DisplayError_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkVideo;
        private System.Windows.Forms.LinkLabel lnkHelp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.Label lblErrorNumber;
        private System.Windows.Forms.Button btnSubmitTicket;
        private System.Windows.Forms.Button btnOK;
    }
}