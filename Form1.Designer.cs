namespace WGH_Notification_Engine
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblToPeople = new System.Windows.Forms.Label();
            this.lblSendingUser = new System.Windows.Forms.Label();
            this.lblMessageType = new System.Windows.Forms.Label();
            this.lblMessageText = new System.Windows.Forms.Label();
            this.lblGameID = new System.Windows.Forms.Label();
            this.lblMessagePriority = new System.Windows.Forms.Label();
            this.textBoxWhoTo = new System.Windows.Forms.TextBox();
            this.textBoxSender = new System.Windows.Forms.TextBox();
            this.textBoxMessageType = new System.Windows.Forms.TextBox();
            this.textBoxMessageText = new System.Windows.Forms.TextBox();
            this.textBoxGameID = new System.Windows.Forms.TextBox();
            this.textBoxMessagePriority = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblToPeople
            // 
            this.lblToPeople.AutoSize = true;
            this.lblToPeople.Location = new System.Drawing.Point(28, 59);
            this.lblToPeople.Name = "lblToPeople";
            this.lblToPeople.Size = new System.Drawing.Size(276, 15);
            this.lblToPeople.TabIndex = 0;
            this.lblToPeople.Text = "Who To (Comma Seperated, e-mail, phone, UserID)";
            // 
            // lblSendingUser
            // 
            this.lblSendingUser.AutoSize = true;
            this.lblSendingUser.Location = new System.Drawing.Point(28, 108);
            this.lblSendingUser.Name = "lblSendingUser";
            this.lblSendingUser.Size = new System.Drawing.Size(234, 15);
            this.lblSendingUser.TabIndex = 1;
            this.lblSendingUser.Text = "Sender (Numeric) or \"System\" (Mandatory)";
            // 
            // lblMessageType
            // 
            this.lblMessageType.AutoSize = true;
            this.lblMessageType.Location = new System.Drawing.Point(28, 157);
            this.lblMessageType.Name = "lblMessageType";
            this.lblMessageType.Size = new System.Drawing.Size(201, 15);
            this.lblMessageType.TabIndex = 2;
            this.lblMessageType.Text = "Message Type (Numeric, Mandatory)";
            // 
            // lblMessageText
            // 
            this.lblMessageText.AutoSize = true;
            this.lblMessageText.Location = new System.Drawing.Point(28, 206);
            this.lblMessageText.Name = "lblMessageText";
            this.lblMessageText.Size = new System.Drawing.Size(171, 15);
            this.lblMessageText.TabIndex = 3;
            this.lblMessageText.Text = "Message Text (String, Optional)";
            // 
            // lblGameID
            // 
            this.lblGameID.AutoSize = true;
            this.lblGameID.Location = new System.Drawing.Point(28, 255);
            this.lblGameID.Name = "lblGameID";
            this.lblGameID.Size = new System.Drawing.Size(157, 15);
            this.lblGameID.TabIndex = 4;
            this.lblGameID.Text = "Game ID (numeric, optional)";
            // 
            // lblMessagePriority
            // 
            this.lblMessagePriority.AutoSize = true;
            this.lblMessagePriority.Location = new System.Drawing.Point(28, 304);
            this.lblMessagePriority.Name = "lblMessagePriority";
            this.lblMessagePriority.Size = new System.Drawing.Size(212, 15);
            this.lblMessagePriority.TabIndex = 5;
            this.lblMessagePriority.Text = "Message Priority (1,2 or 3 - Mandatory)";
            // 
            // textBoxWhoTo
            // 
            this.textBoxWhoTo.Location = new System.Drawing.Point(304, 56);
            this.textBoxWhoTo.Name = "textBoxWhoTo";
            this.textBoxWhoTo.Size = new System.Drawing.Size(100, 23);
            this.textBoxWhoTo.TabIndex = 6;
            // 
            // textBoxSender
            // 
            this.textBoxSender.Location = new System.Drawing.Point(304, 105);
            this.textBoxSender.Name = "textBoxSender";
            this.textBoxSender.Size = new System.Drawing.Size(100, 23);
            this.textBoxSender.TabIndex = 7;
            // 
            // textBoxMessageType
            // 
            this.textBoxMessageType.Location = new System.Drawing.Point(304, 154);
            this.textBoxMessageType.Name = "textBoxMessageType";
            this.textBoxMessageType.Size = new System.Drawing.Size(100, 23);
            this.textBoxMessageType.TabIndex = 8;
            // 
            // textBoxMessageText
            // 
            this.textBoxMessageText.Location = new System.Drawing.Point(304, 203);
            this.textBoxMessageText.Name = "textBoxMessageText";
            this.textBoxMessageText.Size = new System.Drawing.Size(100, 23);
            this.textBoxMessageText.TabIndex = 9;
            // 
            // textBoxGameID
            // 
            this.textBoxGameID.Location = new System.Drawing.Point(304, 252);
            this.textBoxGameID.Name = "textBoxGameID";
            this.textBoxGameID.Size = new System.Drawing.Size(100, 23);
            this.textBoxGameID.TabIndex = 10;
            // 
            // textBoxMessagePriority
            // 
            this.textBoxMessagePriority.Location = new System.Drawing.Point(304, 301);
            this.textBoxMessagePriority.Name = "textBoxMessagePriority";
            this.textBoxMessagePriority.Size = new System.Drawing.Size(100, 23);
            this.textBoxMessagePriority.TabIndex = 11;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(55, 379);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Prefix each with \"email\", \"text\" or \"app\"";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.textBoxMessagePriority);
            this.Controls.Add(this.textBoxGameID);
            this.Controls.Add(this.textBoxMessageText);
            this.Controls.Add(this.textBoxMessageType);
            this.Controls.Add(this.textBoxSender);
            this.Controls.Add(this.textBoxWhoTo);
            this.Controls.Add(this.lblMessagePriority);
            this.Controls.Add(this.lblGameID);
            this.Controls.Add(this.lblMessageText);
            this.Controls.Add(this.lblMessageType);
            this.Controls.Add(this.lblSendingUser);
            this.Controls.Add(this.lblToPeople);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblToPeople;
        private System.Windows.Forms.Label lblSendingUser;
        private System.Windows.Forms.Label lblMessageType;
        private System.Windows.Forms.Label lblMessageText;
        private System.Windows.Forms.Label lblGameID;
        private System.Windows.Forms.Label lblMessagePriority;
        private System.Windows.Forms.TextBox textBoxWhoTo;
        private System.Windows.Forms.TextBox textBoxSender;
        private System.Windows.Forms.TextBox textBoxMessageType;
        private System.Windows.Forms.TextBox textBoxMessageText;
        private System.Windows.Forms.TextBox textBoxGameID;
        private System.Windows.Forms.TextBox textBoxMessagePriority;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
    }
}

