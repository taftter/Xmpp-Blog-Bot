namespace Blog
{
    partial class frmMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.chkAutoLogin = new System.Windows.Forms.CheckBox();
            this.chkAutoResolve = new System.Windows.Forms.CheckBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRes = new System.Windows.Forms.TextBox();
            this.txtPw = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAutoAddAcc = new System.Windows.Forms.CheckBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnSetSts = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSts = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstAddlist = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lstOnlines = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rchMonitor = new System.Windows.Forms.RichTextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.btnLogout);
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Controls.Add(this.chkAutoLogin);
            this.groupBox1.Controls.Add(this.chkAutoResolve);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtHost);
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtRes);
            this.groupBox1.Controls.Add(this.txtPw);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 289);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login Bot Jid";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 261);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 17);
            this.lblStatus.TabIndex = 16;
            this.lblStatus.Text = "Status";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(124, 217);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 33);
            this.btnLogout.TabIndex = 15;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(16, 217);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 33);
            this.btnLogin.TabIndex = 14;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // chkAutoLogin
            // 
            this.chkAutoLogin.AutoSize = true;
            this.chkAutoLogin.Location = new System.Drawing.Point(16, 163);
            this.chkAutoLogin.Name = "chkAutoLogin";
            this.chkAutoLogin.Size = new System.Drawing.Size(98, 21);
            this.chkAutoLogin.TabIndex = 13;
            this.chkAutoLogin.Text = "Auto Login";
            this.chkAutoLogin.UseVisualStyleBackColor = true;
            // 
            // chkAutoResolve
            // 
            this.chkAutoResolve.AutoSize = true;
            this.chkAutoResolve.Location = new System.Drawing.Point(16, 190);
            this.chkAutoResolve.Name = "chkAutoResolve";
            this.chkAutoResolve.Size = new System.Drawing.Size(147, 21);
            this.chkAutoResolve.TabIndex = 12;
            this.chkAutoResolve.Text = "Auto Resolve Host";
            this.chkAutoResolve.UseVisualStyleBackColor = true;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(178, 161);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(46, 22);
            this.txtPort.TabIndex = 11;
            this.txtPort.Text = "5222";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(100, 133);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(124, 22);
            this.txtHost.TabIndex = 10;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(100, 105);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(124, 22);
            this.txtServer.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(130, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Port :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Host/IP :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Server :";
            // 
            // txtRes
            // 
            this.txtRes.Location = new System.Drawing.Point(100, 77);
            this.txtRes.Name = "txtRes";
            this.txtRes.Size = new System.Drawing.Size(124, 22);
            this.txtRes.TabIndex = 5;
            this.txtRes.Text = "testing_Blog_Bot";
            // 
            // txtPw
            // 
            this.txtPw.Location = new System.Drawing.Point(100, 49);
            this.txtPw.Name = "txtPw";
            this.txtPw.Size = new System.Drawing.Size(124, 22);
            this.txtPw.TabIndex = 4;
            this.txtPw.Text = "123321";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(100, 21);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(124, 22);
            this.txtID.TabIndex = 3;
            this.txtID.Text = "blog";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Resource :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAutoAddAcc);
            this.groupBox2.Controls.Add(this.btnHelp);
            this.groupBox2.Controls.Add(this.btnSetSts);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtSts);
            this.groupBox2.Location = new System.Drawing.Point(257, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 289);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // chkAutoAddAcc
            // 
            this.chkAutoAddAcc.AutoSize = true;
            this.chkAutoAddAcc.Checked = true;
            this.chkAutoAddAcc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoAddAcc.Location = new System.Drawing.Point(14, 262);
            this.chkAutoAddAcc.Name = "chkAutoAddAcc";
            this.chkAutoAddAcc.Size = new System.Drawing.Size(172, 21);
            this.chkAutoAddAcc.TabIndex = 4;
            this.chkAutoAddAcc.Text = "Auto Accept Add Reqs";
            this.chkAutoAddAcc.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(6, 225);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(188, 29);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "Bot Help Section";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnSetSts
            // 
            this.btnSetSts.Location = new System.Drawing.Point(6, 190);
            this.btnSetSts.Name = "btnSetSts";
            this.btnSetSts.Size = new System.Drawing.Size(188, 29);
            this.btnSetSts.TabIndex = 2;
            this.btnSetSts.Text = "Set Status";
            this.btnSetSts.UseVisualStyleBackColor = true;
            this.btnSetSts.Click += new System.EventHandler(this.btnSetSts_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Bot Status :";
            // 
            // txtSts
            // 
            this.txtSts.Location = new System.Drawing.Point(6, 38);
            this.txtSts.Multiline = true;
            this.txtSts.Name = "txtSts";
            this.txtSts.Size = new System.Drawing.Size(188, 146);
            this.txtSts.TabIndex = 0;
            this.txtSts.Text = "BLog BOT !";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstAddlist);
            this.groupBox3.Location = new System.Drawing.Point(669, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 289);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "BOTH Rosters";
            // 
            // lstAddlist
            // 
            this.lstAddlist.FormattingEnabled = true;
            this.lstAddlist.ItemHeight = 16;
            this.lstAddlist.Location = new System.Drawing.Point(6, 21);
            this.lstAddlist.Name = "lstAddlist";
            this.lstAddlist.Size = new System.Drawing.Size(188, 260);
            this.lstAddlist.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lstOnlines);
            this.groupBox4.Location = new System.Drawing.Point(463, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 289);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Online Rosters";
            // 
            // lstOnlines
            // 
            this.lstOnlines.FormattingEnabled = true;
            this.lstOnlines.ItemHeight = 16;
            this.lstOnlines.Location = new System.Drawing.Point(6, 21);
            this.lstOnlines.Name = "lstOnlines";
            this.lstOnlines.Size = new System.Drawing.Size(188, 260);
            this.lstOnlines.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rchMonitor);
            this.groupBox5.Location = new System.Drawing.Point(12, 307);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(651, 302);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "MONITOR";
            // 
            // rchMonitor
            // 
            this.rchMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchMonitor.Location = new System.Drawing.Point(3, 18);
            this.rchMonitor.Name = "rchMonitor";
            this.rchMonitor.Size = new System.Drawing.Size(645, 281);
            this.rchMonitor.TabIndex = 0;
            this.rchMonitor.Text = "";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.listBox1);
            this.groupBox6.Location = new System.Drawing.Point(669, 307);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(200, 302);
            this.groupBox6.TabIndex = 19;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Logged in Users";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(6, 21);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(188, 276);
            this.listBox1.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(881, 621);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blog BOT";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAutoLogin;
        private System.Windows.Forms.CheckBox chkAutoResolve;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRes;
        private System.Windows.Forms.TextBox txtPw;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSetSts;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSts;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lstAddlist;
        private System.Windows.Forms.ListBox lstOnlines;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox rchMonitor;
        private System.Windows.Forms.CheckBox chkAutoAddAcc;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListBox listBox1;
    }
}

