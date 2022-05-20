namespace MusicRenamer
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnTitle = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnDifferentName = new System.Windows.Forms.Button();
            this.btnFolders = new System.Windows.Forms.Button();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.notifications = new System.Windows.Forms.Label();
            this.renameAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTitle
            // 
            this.btnTitle.Location = new System.Drawing.Point(12, 267);
            this.btnTitle.Name = "btnTitle";
            this.btnTitle.Size = new System.Drawing.Size(250, 23);
            this.btnTitle.TabIndex = 0;
            this.btnTitle.Text = "Title";
            this.btnTitle.UseVisualStyleBackColor = true;
            this.btnTitle.Click += new System.EventHandler(this.btntitle_Click);
            // 
            // bindingSource1
            // 
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // btnDifferentName
            // 
            this.btnDifferentName.Location = new System.Drawing.Point(268, 267);
            this.btnDifferentName.Name = "btnDifferentName";
            this.btnDifferentName.Size = new System.Drawing.Size(24, 23);
            this.btnDifferentName.TabIndex = 2;
            this.btnDifferentName.Text = "...";
            this.btnDifferentName.UseVisualStyleBackColor = true;
            this.btnDifferentName.Click += new System.EventHandler(this.btnDifferentName_Click);
            // 
            // btnFolders
            // 
            this.btnFolders.Location = new System.Drawing.Point(12, 40);
            this.btnFolders.Name = "btnFolders";
            this.btnFolders.Size = new System.Drawing.Size(93, 23);
            this.btnFolders.TabIndex = 4;
            this.btnFolders.Text = "Select Folder";
            this.btnFolders.UseVisualStyleBackColor = true;
            this.btnFolders.Click += new System.EventHandler(this.btnFolders_Click);
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.Location = new System.Drawing.Point(13, 80);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(279, 160);
            this.listBoxFiles.TabIndex = 5;
            this.listBoxFiles.SelectedIndexChanged += new System.EventHandler(this.listBoxFiles_SelectedIndexChanged);
            // 
            // notifications
            // 
            this.notifications.AutoSize = true;
            this.notifications.Location = new System.Drawing.Point(12, 332);
            this.notifications.MaximumSize = new System.Drawing.Size(280, 0);
            this.notifications.Name = "notifications";
            this.notifications.Size = new System.Drawing.Size(60, 13);
            this.notifications.TabIndex = 6;
            this.notifications.Text = "Meldungen";
            // 
            // renameAll
            // 
            this.renameAll.Location = new System.Drawing.Point(13, 296);
            this.renameAll.Name = "renameAll";
            this.renameAll.Size = new System.Drawing.Size(280, 23);
            this.renameAll.TabIndex = 7;
            this.renameAll.Text = "Rename All To Title";
            this.renameAll.UseVisualStyleBackColor = true;
            this.renameAll.Click += new System.EventHandler(this.btnRenameAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Rename to:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 461);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.renameAll);
            this.Controls.Add(this.notifications);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.btnFolders);
            this.Controls.Add(this.btnDifferentName);
            this.Controls.Add(this.btnTitle);
            this.Name = "Form1";
            this.Text = "Music Renamer";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTitle;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button btnDifferentName;
        private System.Windows.Forms.Button btnRenameAll;
        private System.Windows.Forms.Button btnFolders;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.Label notifications;
        private System.Windows.Forms.Button renameAll;
        private System.Windows.Forms.Label label1;
    }
}

