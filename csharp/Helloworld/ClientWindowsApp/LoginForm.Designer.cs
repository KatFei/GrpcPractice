namespace ClientWindowsApp
{
    partial class LoginForm
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
            this.tblLayoutLog = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.MaskedTextBox();
            this.butLogin = new System.Windows.Forms.Button();
            this.tblLayoutLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblLayoutLog
            // 
            this.tblLayoutLog.ColumnCount = 2;
            this.tblLayoutLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.16279F));
            this.tblLayoutLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.83721F));
            this.tblLayoutLog.Controls.Add(this.label1, 0, 0);
            this.tblLayoutLog.Controls.Add(this.label2, 0, 1);
            this.tblLayoutLog.Controls.Add(this.tbUser, 1, 0);
            this.tblLayoutLog.Controls.Add(this.tbPassword, 1, 1);
            this.tblLayoutLog.Controls.Add(this.butLogin, 1, 2);
            this.tblLayoutLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutLog.Location = new System.Drawing.Point(10, 10);
            this.tblLayoutLog.Margin = new System.Windows.Forms.Padding(20);
            this.tblLayoutLog.Name = "tblLayoutLog";
            this.tblLayoutLog.Padding = new System.Windows.Forms.Padding(3);
            this.tblLayoutLog.RowCount = 3;
            this.tblLayoutLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tblLayoutLog.Size = new System.Drawing.Size(515, 167);
            this.tblLayoutLog.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(127, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "User:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label2.Size = new System.Drawing.Size(127, 53);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // tbUser
            // 
            this.tbUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbUser.Location = new System.Drawing.Point(139, 6);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(370, 35);
            this.tbUser.TabIndex = 2;
            // 
            // tbPassword
            // 
            this.tbPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPassword.Location = new System.Drawing.Point(139, 59);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(370, 35);
            this.tbPassword.TabIndex = 3;
            // 
            // butLogin
            // 
            this.butLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butLogin.Location = new System.Drawing.Point(139, 112);
            this.butLogin.Name = "butLogin";
            this.butLogin.Size = new System.Drawing.Size(239, 49);
            this.butLogin.TabIndex = 4;
            this.butLogin.Text = "Login";
            this.butLogin.UseVisualStyleBackColor = true;
            this.butLogin.Click += new System.EventHandler(this.butLogin_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 187);
            this.Controls.Add(this.tblLayoutLog);
            this.Name = "LoginForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "LoginForm";
            this.tblLayoutLog.ResumeLayout(false);
            this.tblLayoutLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblLayoutLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.MaskedTextBox tbPassword;
        private System.Windows.Forms.Button butLogin;
    }
}