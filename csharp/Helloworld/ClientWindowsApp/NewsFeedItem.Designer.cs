using Helloworld;
using System.ServiceModel.Syndication;

namespace ClientWindowsApp
{
    partial class NewsFeedItem
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
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblSummary = new System.Windows.Forms.Label();
            this.lblPublished = new System.Windows.Forms.Label();
            this.flowLayoutPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel7.Controls.Add(this.lblSubject);
            this.flowLayoutPanel7.Controls.Add(this.lblSummary);
            this.flowLayoutPanel7.Controls.Add(this.lblPublished);
            this.flowLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel7.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(555, 146);
            this.flowLayoutPanel7.TabIndex = 4;
            this.flowLayoutPanel7.WrapContents = false;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoEllipsis = true;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSubject.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSubject.Location = new System.Drawing.Point(3, 0);
            this.lblSubject.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(549, 29);
            this.lblSubject.TabIndex = 0;
            this.lblSubject.Text = "Subject: ";
            this.lblSubject.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NewsFeedItem_MouseClick);
            // 
            // lblSummary
            // 
            this.lblSummary.AutoEllipsis = true;
            this.lblSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSummary.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblSummary.Location = new System.Drawing.Point(3, 32);
            this.lblSummary.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(549, 87);
            this.lblSummary.TabIndex = 1;
            this.lblSummary.Text = "Short summary: The institution of slavery turned a poor, fledgling nation into a " +
    "financial powerhouse, and the cotton plantation was. . .";
            this.lblSummary.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NewsFeedItem_MouseClick);
            // 
            // lblPublished
            // 
            this.lblPublished.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPublished.AutoSize = true;
            this.lblPublished.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPublished.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPublished.Location = new System.Drawing.Point(453, 122);
            this.lblPublished.Name = "lblPublished";
            this.lblPublished.Size = new System.Drawing.Size(99, 22);
            this.lblPublished.TabIndex = 2;
            this.lblPublished.Text = "Published: ";
            this.lblPublished.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // NewsFeedItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel7);
            this.Name = "NewsFeedItem";
            this.Size = new System.Drawing.Size(555, 151);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NewsFeedItem_MouseClick);
            this.flowLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Label lblPublished;
    }
}
