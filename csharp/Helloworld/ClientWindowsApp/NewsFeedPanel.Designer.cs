using System.ServiceModel.Syndication;

namespace ClientWindowsApp
{
    partial class NewsFeedPanel
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        //private System.Windows.Forms.FlowLayoutPanel flListItemTemplate;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Label lblPublished;
        private System.ServiceModel.Syndication.SyndicationItem newsItem;

        public SyndicationItem NewsItem { get => newsItem; //set => newsItem = value; 
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
            //this.flListItemTemplate = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblSummary = new System.Windows.Forms.Label();
            this.lblPublished = new System.Windows.Forms.Label();
            //this.flListItemTemplate.SuspendLayout();
            this.SuspendLayout();
            // 
            // flListItemTemplate
            // 
            //this.flListItemTemplate.AutoSize = true;
            //this.flListItemTemplate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            //this.flListItemTemplate.BackColor = System.Drawing.Color.White;
            //this.flListItemTemplate.Controls.Add(this.lblSubject);
            //this.flListItemTemplate.Controls.Add(this.lblSummary);
            //this.flListItemTemplate.Controls.Add(this.lblPublished);
            //this.flListItemTemplate.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            //this.flListItemTemplate.Location = new System.Drawing.Point(3, 3);
            //this.flListItemTemplate.Name = "flListItemTemplate";
            //this.flListItemTemplate.Size = new System.Drawing.Size(549, 149);
            //this.flListItemTemplate.TabIndex = 0;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSubject.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSubject.Location = new System.Drawing.Point(3, 3);
            this.lblSubject.Margin = new System.Windows.Forms.Padding(3);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(115, 29);
            this.lblSubject.TabIndex = 0;
            this.lblSubject.Text = "Subject: ";
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSummary.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblSummary.Location = new System.Drawing.Point(3, 35);
            this.lblSummary.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(543, 87);
            this.lblSummary.TabIndex = 1;
            this.lblSummary.Text = "Short summary: The institution of slavery turned a poor, fledgling nation into a " +
    "financial powerhouse, and the cotton plantation was. . .";
            // 
            // lblPublished
            // 
            this.lblPublished.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPublished.AutoSize = true;
            this.lblPublished.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPublished.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPublished.Location = new System.Drawing.Point(442, 125);
            this.lblPublished.Name = "lblPublished";
            this.lblPublished.Size = new System.Drawing.Size(104, 24);
            this.lblPublished.TabIndex = 2;
            this.lblPublished.Text = "Published: ";
            this.lblPublished.TextAlign = System.Drawing.ContentAlignment.BottomRight;

            // 
            // NewsFeedPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "NewsFeedPanel";
            this.Size = new System.Drawing.Size(549, 149);
            //this.flListItemTemplate.ResumeLayout(false);
            //this.flListItemTemplate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
