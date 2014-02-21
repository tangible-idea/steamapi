namespace SyncSteam
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnSignIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtPW = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.txtSteamGuardCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAuth = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabInfo = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lstFriendList = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSignIn
            // 
            this.btnSignIn.Enabled = false;
            this.btnSignIn.Location = new System.Drawing.Point(319, 6);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(75, 48);
            this.btnSignIn.TabIndex = 0;
            this.btnSignIn.Text = "로그인";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(100, 6);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(213, 21);
            this.txtID.TabIndex = 2;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // txtPW
            // 
            this.txtPW.Location = new System.Drawing.Point(100, 33);
            this.txtPW.Name = "txtPW";
            this.txtPW.PasswordChar = '*';
            this.txtPW.Size = new System.Drawing.Size(213, 21);
            this.txtPW.TabIndex = 4;
            this.txtPW.TextChanged += new System.EventHandler(this.txtPW_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "PW";
            // 
            // lstLog
            // 
            this.lstLog.FormattingEnabled = true;
            this.lstLog.ItemHeight = 12;
            this.lstLog.Location = new System.Drawing.Point(11, 429);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(380, 148);
            this.lstLog.TabIndex = 5;
            // 
            // txtSteamGuardCode
            // 
            this.txtSteamGuardCode.Enabled = false;
            this.txtSteamGuardCode.Location = new System.Drawing.Point(100, 60);
            this.txtSteamGuardCode.Name = "txtSteamGuardCode";
            this.txtSteamGuardCode.Size = new System.Drawing.Size(213, 21);
            this.txtSteamGuardCode.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "SteamGuard";
            // 
            // btnAuth
            // 
            this.btnAuth.Enabled = false;
            this.btnAuth.Location = new System.Drawing.Point(319, 61);
            this.btnAuth.Name = "btnAuth";
            this.btnAuth.Size = new System.Drawing.Size(75, 20);
            this.btnAuth.TabIndex = 8;
            this.btnAuth.Text = "인증";
            this.btnAuth.UseVisualStyleBackColor = true;
            this.btnAuth.Click += new System.EventHandler(this.btnAuth_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 589);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(403, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(58, 17);
            this.lblStatus.Text = "비접속중.";
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.tabPage1);
            this.tabInfo.Controls.Add(this.tabPage2);
            this.tabInfo.HotTrack = true;
            this.tabInfo.Location = new System.Drawing.Point(11, 100);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.SelectedIndex = 0;
            this.tabInfo.Size = new System.Drawing.Size(380, 314);
            this.tabInfo.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabInfo.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lstFriendList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(372, 288);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "친구 목록";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lstFriendList
            // 
            this.lstFriendList.FormattingEnabled = true;
            this.lstFriendList.ItemHeight = 12;
            this.lstFriendList.Location = new System.Drawing.Point(6, 9);
            this.lstFriendList.Name = "lstFriendList";
            this.lstFriendList.Size = new System.Drawing.Size(181, 268);
            this.lstFriendList.TabIndex = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtAccountName);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(372, 288);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "내 정보";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(70, 21);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(285, 21);
            this.txtAccountName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "계정명";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(403, 611);
            this.Controls.Add(this.tabInfo);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnAuth);
            this.Controls.Add(this.txtSteamGuardCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.txtPW);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSignIn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SteamSync";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabInfo.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtPW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.TextBox txtSteamGuardCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAuth;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.TabControl tabInfo;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox lstFriendList;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Label label5;
    }
}

