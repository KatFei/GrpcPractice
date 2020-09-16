using Helloworld;
using System.ServiceModel.Syndication;

namespace ClientWindowsApp
{
    partial class NewsFeedItemBox
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //private System.ServiceModel.Syndication.SyndicationItem newsItem;
        private NewsReply newsItem;
        public NewsReply NewsItem
        {
            get => newsItem; //set => newsItem = value; 
        }
        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.grBoxMain = new System.Windows.Forms.GroupBox();
            this.lblPublished = new System.Windows.Forms.Label();
            this.lblSummary = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.grBoxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // grBoxMain
            // 
            this.grBoxMain.BackColor = System.Drawing.Color.White;
            this.grBoxMain.Controls.Add(this.lblPublished);
            this.grBoxMain.Controls.Add(this.lblSummary);
            this.grBoxMain.Controls.Add(this.lblSubject);
            this.grBoxMain.Location = new System.Drawing.Point(2, 4);
            this.grBoxMain.Name = "grBoxMain";
            this.grBoxMain.Size = new System.Drawing.Size(551, 139);
            this.grBoxMain.TabIndex = 6;
            this.grBoxMain.TabStop = false;
            this.grBoxMain.Text = "groupBox1";
            // 
            // lblPublished
            // 
            this.lblPublished.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPublished.AutoSize = true;
            this.lblPublished.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPublished.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPublished.Location = new System.Drawing.Point(447, 115);
            this.lblPublished.Name = "lblPublished";
            this.lblPublished.Size = new System.Drawing.Size(104, 24);
            this.lblPublished.TabIndex = 3;
            this.lblPublished.Text = "Published: ";
            this.lblPublished.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblSummary
            // 
            this.lblSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSummary.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblSummary.Location = new System.Drawing.Point(2, 27);
            this.lblSummary.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(549, 87);
            this.lblSummary.TabIndex = 2;
            this.lblSummary.Text = "Short summary: The institution of slavery turned a poor, fledgling nation into a " +
    "financial powerhouse, and the cotton plantation was. . .";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSubject.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSubject.Location = new System.Drawing.Point(3, 0);
            this.lblSubject.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(115, 29);
            this.lblSubject.TabIndex = 1;
            this.lblSubject.Text = "Subject: ";
            // 
            // NewsFeedItemBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grBoxMain);
            this.Name = "NewsFeedItemBox";
            this.Size = new System.Drawing.Size(555, 146);
            this.grBoxMain.ResumeLayout(false);
            this.grBoxMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grBoxMain;
        private System.Windows.Forms.Label lblPublished;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Label lblSubject;
    }
}
