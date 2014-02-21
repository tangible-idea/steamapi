namespace SyncSteam
{
    partial class frmInfo
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
            this.lblFriendList = new System.Windows.Forms.Label();
            this.lstFriendList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblFriendList
            // 
            this.lblFriendList.AutoSize = true;
            this.lblFriendList.Location = new System.Drawing.Point(12, 9);
            this.lblFriendList.Name = "lblFriendList";
            this.lblFriendList.Size = new System.Drawing.Size(57, 12);
            this.lblFriendList.TabIndex = 0;
            this.lblFriendList.Text = "친구 목록";
            // 
            // lstFriendList
            // 
            this.lstFriendList.FormattingEnabled = true;
            this.lstFriendList.ItemHeight = 12;
            this.lstFriendList.Location = new System.Drawing.Point(14, 33);
            this.lstFriendList.Name = "lstFriendList";
            this.lstFriendList.Size = new System.Drawing.Size(120, 400);
            this.lstFriendList.TabIndex = 1;
            // 
            // frmInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 454);
            this.Controls.Add(this.lstFriendList);
            this.Controls.Add(this.lblFriendList);
            this.Name = "frmInfo";
            this.Text = "Steam Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFriendList;
        private System.Windows.Forms.ListBox lstFriendList;
    }
}