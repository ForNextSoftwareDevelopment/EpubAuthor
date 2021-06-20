
namespace EpubAuthor
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnCooseFolder = new System.Windows.Forms.Button();
            this.tbFolder = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.btnStart = new System.Windows.Forms.Button();
            this.chkSubDirectories = new System.Windows.Forms.CheckBox();
            this.chkTitles = new System.Windows.Forms.CheckBox();
            this.chkAddNameInTitle = new System.Windows.Forms.CheckBox();
            this.chkRemoveCalibre = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCooseFolder
            // 
            this.btnCooseFolder.Location = new System.Drawing.Point(12, 12);
            this.btnCooseFolder.Name = "btnCooseFolder";
            this.btnCooseFolder.Size = new System.Drawing.Size(131, 23);
            this.btnCooseFolder.TabIndex = 0;
            this.btnCooseFolder.Text = "Choose Folder";
            this.btnCooseFolder.UseVisualStyleBackColor = true;
            this.btnCooseFolder.Click += new System.EventHandler(this.btnChooseFolder_Click);
            // 
            // tbFolder
            // 
            this.tbFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFolder.BackColor = System.Drawing.SystemColors.Info;
            this.tbFolder.Location = new System.Drawing.Point(149, 12);
            this.tbFolder.Name = "tbFolder";
            this.tbFolder.ReadOnly = true;
            this.tbFolder.Size = new System.Drawing.Size(474, 23);
            this.tbFolder.TabIndex = 1;
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvFiles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Location = new System.Drawing.Point(12, 41);
            this.dgvFiles.MultiSelect = false;
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.ReadOnly = true;
            this.dgvFiles.RowTemplate.Height = 25;
            this.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiles.Size = new System.Drawing.Size(760, 451);
            this.dgvFiles.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStart.Location = new System.Drawing.Point(12, 523);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(760, 26);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // chkSubDirectories
            // 
            this.chkSubDirectories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSubDirectories.AutoSize = true;
            this.chkSubDirectories.Location = new System.Drawing.Point(629, 14);
            this.chkSubDirectories.Name = "chkSubDirectories";
            this.chkSubDirectories.Size = new System.Drawing.Size(143, 19);
            this.chkSubDirectories.TabIndex = 4;
            this.chkSubDirectories.Text = "Include Subdirectories";
            this.chkSubDirectories.UseVisualStyleBackColor = true;
            this.chkSubDirectories.Click += new System.EventHandler(this.chkSubDirectories_Click);
            // 
            // chkTitles
            // 
            this.chkTitles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkTitles.AutoSize = true;
            this.chkTitles.Location = new System.Drawing.Point(12, 498);
            this.chkTitles.Name = "chkTitles";
            this.chkTitles.Size = new System.Drawing.Size(97, 19);
            this.chkTitles.TabIndex = 5;
            this.chkTitles.Text = "Change Titles";
            this.chkTitles.UseVisualStyleBackColor = true;
            // 
            // chkAddNameInTitle
            // 
            this.chkAddNameInTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAddNameInTitle.AutoSize = true;
            this.chkAddNameInTitle.Location = new System.Drawing.Point(149, 498);
            this.chkAddNameInTitle.Name = "chkAddNameInTitle";
            this.chkAddNameInTitle.Size = new System.Drawing.Size(176, 19);
            this.chkAddNameInTitle.TabIndex = 6;
            this.chkAddNameInTitle.Text = "Add Subfolder Name to Title";
            this.chkAddNameInTitle.UseVisualStyleBackColor = true;
            // 
            // chkRemoveCalibre
            // 
            this.chkRemoveCalibre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRemoveCalibre.AutoSize = true;
            this.chkRemoveCalibre.Location = new System.Drawing.Point(639, 498);
            this.chkRemoveCalibre.Name = "chkRemoveCalibre";
            this.chkRemoveCalibre.Size = new System.Drawing.Size(133, 19);
            this.chkRemoveCalibre.TabIndex = 7;
            this.chkRemoveCalibre.Text = "Remove Calibre Info";
            this.chkRemoveCalibre.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.chkRemoveCalibre);
            this.Controls.Add(this.chkAddNameInTitle);
            this.Controls.Add(this.chkTitles);
            this.Controls.Add(this.chkSubDirectories);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.dgvFiles);
            this.Controls.Add(this.tbFolder);
            this.Controls.Add(this.btnCooseFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Epub Author";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCooseFolder;
        private System.Windows.Forms.TextBox tbFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox chkSubDirectories;
        private System.Windows.Forms.CheckBox chkTitles;
        private System.Windows.Forms.CheckBox chkAddNameInTitle;
        private System.Windows.Forms.CheckBox chkRemoveCalibre;
    }
}

