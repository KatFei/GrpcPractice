namespace ClientWindowsApp
{
    partial class SettingsForm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.label1 = new System.Windows.Forms.Label();
            this.listTags = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.listSites = new System.Windows.Forms.DataGridView();
            this.Sites = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.listSites)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(24, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Web-sites:";
            // 
            // listTags
            // 
            this.listTags.CheckBoxes = true;
            this.listTags.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listTags.GridLines = true;
            this.listTags.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listTags.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            this.listTags.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listTags.LabelEdit = true;
            this.listTags.Location = new System.Drawing.Point(240, 246);
            this.listTags.Name = "listTags";
            this.listTags.ShowItemToolTips = true;
            this.listTags.Size = new System.Drawing.Size(438, 163);
            this.listTags.TabIndex = 3;
            this.listTags.UseCompatibleStateImageBehavior = false;
            this.listTags.View = System.Windows.Forms.View.Details;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(24, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tags:";
            // 
            // butOk
            // 
            this.butOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butOk.Location = new System.Drawing.Point(110, 446);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(134, 44);
            this.butOk.TabIndex = 4;
            this.butOk.Text = "Save";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butCancel.Location = new System.Drawing.Point(464, 446);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(134, 44);
            this.butCancel.TabIndex = 5;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // listSites
            // 
            this.listSites.AllowUserToResizeColumns = false;
            this.listSites.AllowUserToResizeRows = false;
            this.listSites.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.listSites.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.listSites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listSites.ColumnHeadersVisible = false;
            this.listSites.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sites});
            this.listSites.GridColor = System.Drawing.SystemColors.Window;
            this.listSites.Location = new System.Drawing.Point(240, 43);
            this.listSites.Name = "listSites";
            this.listSites.RowHeadersVisible = false;
            this.listSites.RowHeadersWidth = 82;
            this.listSites.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.listSites.RowTemplate.Height = 33;
            this.listSites.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listSites.Size = new System.Drawing.Size(438, 163);
            this.listSites.TabIndex = 6;
            // 
            // Sites
            // 
            this.Sites.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Sites.HeaderText = "";
            this.Sites.MinimumWidth = 10;
            this.Sites.Name = "Sites";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 509);
            this.Controls.Add(this.listSites);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.listTags);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listSites)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listTags;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.DataGridView listSites;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sites;
    }
}